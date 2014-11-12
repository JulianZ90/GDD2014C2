/*cargar argentina en pais, hotel (16) y regimen (4) */
insert into GAME_OF_QUERYS.pais (nombre) values ('Argentina')


insert into GAME_OF_QUERYS.hotel (ciudad, calle, nro_calle, cantidad_estrella, recarga_estrella,
								 pais_id, nombre)
select distinct ltrim(rtrim(Hotel_Ciudad)), Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella,Hotel_Recarga_Estrella,
				(select id from GAME_OF_QUERYS.pais where nombre='Argentina'),
				( ltrim(rtrim(Hotel_Ciudad)) + ' ' + ltrim(rtrim(Hotel_Calle)) )
from gd_esquema.Maestra 

insert into GAME_OF_QUERYS.regimen(descripcion, precio_base,estado)
select distinct Regimen_Descripcion, Regimen_Precio,'1'
from gd_esquema.Maestra

/*cargar reg_hotel (4x16, todos los hoteles tienen los 4 regimenes)*/

insert into GAME_OF_QUERYS.hotel_reg( hotel_id, reg_id)
select distinct h.id, r.id
from GAME_OF_QUERYS.hotel h, GAME_OF_QUERYS.regimen r

/*cargar tipo_ident dni y pasaporte y los clientes (100740)*/

insert into GAME_OF_QUERYS.tipo_identidad (nombre) values ('DNI')
insert into GAME_OF_QUERYS.tipo_identidad (nombre) values ('Pasaporte')

insert into GAME_OF_QUERYS.cliente (tipo_identidad_id, nro_identidad, apellido,nombre,
					fecha_nac, mail, calle, nro_calle, piso,
					depto,nacionalidad,permitido_ingreso, pais_origen_id)
select distinct (select id from GAME_OF_QUERYS.tipo_identidad where nombre='Pasaporte'),Cliente_Pasaporte_Nro, Cliente_Apellido,
				Cliente_Nombre,cast(Cliente_Fecha_Nac as Date), Cliente_Mail,
				Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso,
				Cliente_Depto,Cliente_Nacionalidad,'1','1'
from gd_esquema.Maestra

/*cargar tipo_habitacion (5)*/
set identity_insert GD2C2014.GAME_OF_QUERYS.tipo_habitacion on
insert into GAME_OF_QUERYS.tipo_habitacion (id, descripcion, porcentual)
select distinct Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion ,
				 Habitacion_Tipo_Porcentual
from gd_esquema.Maestra
set identity_insert GD2C2014.GAME_OF_QUERYS.tipo_habitacion off

/*cargar habitacion (345)*/

insert into GAME_OF_QUERYS.habitacion (hotel_id,nro,piso,ubicacion,tipo_hab_id,
										estado_habitacion)
select distinct h.id, m.Habitacion_Numero, m.Habitacion_Piso,
		 m.Habitacion_Frente, m.Habitacion_Tipo_Codigo, '1'
from gd_esquema.Maestra m 
			join GAME_OF_QUERYS.hotel h on h.ciudad=m.Hotel_Ciudad and h.calle=m.Hotel_Calle
							and h.nro_calle=m.Hotel_Nro_Calle
							
/* cargar estado_reserva (6)*/
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('correcta')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('modificada')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('cancelada por recepcion')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('cancelada por cliente')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('cancelada por No-Show')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('con ingreso')

/*cargar reserva (100740)*/

set identity_insert GD2C2014.GAME_OF_QUERYS.reserva on
insert into GAME_OF_QUERYS.reserva(id,cliente_id,regimen_id, fecha_inicio, fecha_fin,hotel_id)
select distinct m.Reserva_Codigo, c.id, r.id, cast(m.Reserva_Fecha_Inicio as Date), DATEADD (day ,m.Reserva_Cant_Noches , cast(m.Reserva_Fecha_Inicio as Date) ),h.id
from gd_esquema.Maestra m
						join GAME_OF_QUERYS.cliente c on m.cliente_pasaporte_nro=c.nro_identidad and
														m.Cliente_Mail=c.mail
						join GAME_OF_QUERYS.regimen r on r.descripcion = m.regimen_descripcion
						
						join GAME_OF_QUERYS.hotel h on h.ciudad=m.Hotel_Ciudad and h.calle=m.Hotel_Calle
							and h.nro_calle=m.Hotel_Nro_Calle
						
set identity_insert GD2C2014.GAME_OF_QUERYS.reserva off	

/*cargar reserva_habitacion (100740)*/

insert into GAME_OF_QUERYS.reserva_habitacion ( reserva_id, habitacion_id)
select distinct m.reserva_codigo, h.id
from gd_esquema.Maestra m
						join GAME_OF_QUERYS.hotel ho on m.Hotel_Calle = ho.calle and
														m.Hotel_Nro_Calle=ho.nro_calle
													and m.Hotel_Ciudad=ho.ciudad
						join GAME_OF_QUERYS.habitacion h on m.Habitacion_Piso=h.piso and
													m.Habitacion_Numero=h.nro
where ho.id = h.hotel_id
																					
/*cargar consumible (4) */

set identity_insert GD2C2014.GAME_OF_QUERYS.consumible on
insert into GAME_OF_QUERYS.consumible (id,descripcion,precio)
select distinct Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
from gd_esquema.Maestra
where Consumible_Codigo is not null
set identity_insert GD2C2014.GAME_OF_QUERYS.consumible off	

/*cargar checkin checkout (89603)*/
merge into GAME_OF_QUERYS.reserva
using ( 
select distinct 
cast(m.Estadia_Fecha_Inicio as date) as checkin,
DATEADD (day ,m.estadia_Cant_Noches , cast(m.estadia_Fecha_Inicio as Date) ) as checkout, 
m.Reserva_Codigo as reserva
from gd_esquema.Maestra m
where Estadia_Fecha_Inicio is not null
) e
on (reserva.id = e.reserva) 
when matched then
	update set reserva.check_in=e.checkin, reserva.check_out=e.checkout;
	



/*cargar consumible_reserva (207341)*/

insert into GAME_OF_QUERYS.consumible_reserva (consumible_id,reserva_id,cantidad, habitacion_id)
select distinct c.id, m.Reserva_Codigo, COUNT(m.Consumible_Descripcion), r.habitacion_id
from gd_esquema.Maestra m 
join GAME_OF_QUERYS.consumible c	on m.Consumible_Codigo= c.id
join GAME_OF_QUERYS.reserva_habitacion r on r.reserva_id = m.Reserva_Codigo
group by c.id,m.Reserva_Codigo, r.habitacion_id



/* cargar cliente_estadia (89603) */
/* cargar cliente_reserva (100740)  ahora son mas porque antes no se consideraba al que reservo como
 huesped de la habitacion */
insert into GAME_OF_QUERYS.cliente_reserva (cliente_id,reserva_id)
select distinct c.id, m.Reserva_Codigo
from gd_esquema.Maestra m 
join GAME_OF_QUERYS.cliente c on m.cliente_pasaporte_nro=c.nro_identidad and m.Cliente_Mail=c.mail



/*cargar medios de pago*/
insert into GAME_OF_QUERYS.medio_de_pago(nombre) values ('Efectivo')
insert into GAME_OF_QUERYS.medio_de_pago(nombre) values ('Tarjeta de credito')


/*cargar factura (89603)*/
set identity_insert GD2C2014.GAME_OF_QUERYS.factura on
insert into GAME_OF_QUERYS.factura (id,fecha,reserva_id, medio_de_pago_id)
select distinct m.Factura_Nro, CAST(m.Factura_Fecha as DATE), r.id, (select id from GAME_OF_QUERYS.medio_de_pago where nombre='Efectivo')
from gd_esquema.Maestra m 
join GAME_OF_QUERYS.reserva r on m.Reserva_Codigo=r.id
where m.Factura_Nro is not null
set identity_insert GD2C2014.GAME_OF_QUERYS.factura off	


/*cargar rol (4)*/
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('Administrador',1)
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('Recepcionista',1)
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('Guest',1)
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('admin',1)

/*cargar funcionalidad (11)*/
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmRol')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('ambUsuario')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmCliente')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmHabitacion')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmRegimen')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('Reservas')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('registrarEstadia y Facturacion')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('estadistico')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmHotel')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('consumibles')

/*cargar usuario (2)*/

insert into GAME_OF_QUERYS.usuario (username,estado) values ('guest', 1 )
insert into GAME_OF_QUERYS.usuario (username,password, nombre,estado) values ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 'Administrador General','1')

/* Para que ande el login el usuario tiene que tener un registro en la tabla hotel_usuario_rol */
insert into GAME_OF_QUERYS.hotel_usuario_rol (hotel_id, usuario_id, rol_id) 
(select hotel.id,2,4 from GAME_OF_QUERYS.hotel )


/* Inserto las funcionalidades del rol admin (todas) */
insert into GAME_OF_QUERYS.rol_funcionalidad(rol_id, funcionalidad_id)
(select r.id, f.id from GAME_OF_QUERYS.rol r, GAME_OF_QUERYS.funcionalidad f WHERE r.descripcion = 'admin')

/****** Object:  Table [GAME_OF_QUERYS].[rol_funcionalidad]    Script Date: 11/11/2014 10:26:42 ******/
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 2)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 3)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 4)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 6)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 7)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 8)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 9)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (1, 10)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (2, 3)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (2, 6)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (2, 7)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (2, 10)
INSERT [GAME_OF_QUERYS].[rol_funcionalidad] ([rol_id], [funcionalidad_id]) VALUES (3, 6)


/*Trigger para controlar funcionalidades de cada rol
ABM de Rol: Exclusivo del administrador general
ABM de Hotel y ABM de Usuario: exclusivos del administrador o administrador general
*/
GO
CREATE TRIGGER GAME_OF_QUERYS.TrigInsRolFuncionalidad
ON GAME_OF_QUERYS.rol_funcionalidad
INSTEAD OF INSERT AS

BEGIN
DECLARE @idRol int, @idFuncionalidad int
SELECT @idFuncionalidad = funcionalidad_id, @idRol = rol_id FROM inserted

IF((@idFuncionalidad IN (2,9) AND @idRol NOT IN (1, 4)) OR (@idFuncionalidad = 1 AND @idRol != 4))
BEGIN
RAISERROR('No se puede asignar funcionalidad a rol', 10, 1)
RETURN
END

INSERT INTO GAME_OF_QUERYS.rol_funcionalidad(rol_id, funcionalidad_id) VALUES(@idRol, @idFuncionalidad)
END
GO


--cargar estado_id en reserva	se tiene en cuenta que la maxima fecha de check out en la tabla maestra es 31-12-2016, por lo que tomamos como 'dia de hoy' a 01-01-2017
--reservas que tienen estadia --> estado: 6 - con ingreso
update GAME_OF_QUERYS.reserva set estado_id = 
(select id from GAME_OF_QUERYS.estado_reserva where descripcion='con ingreso')
where fecha_inicio <= (select MAX(check_out) from GAME_OF_QUERYS.reserva)
and reserva.check_in is not null

--reservas viejas que no aparecen en la tabla de estadia --> estado: 5 - cancelada por no-show
update GAME_OF_QUERYS.reserva set estado_id = (select id from GAME_OF_QUERYS.estado_reserva where descripcion='cancelada por No-Show')
where fecha_inicio <= (select MAX(check_out) from GAME_OF_QUERYS.reserva)	--max(check_out) es la maxima fecha que aparece
and reserva.check_in is null

--reservas proximas --> estado: 1 - correcta (por ahora no hay ninguna)
update GAME_OF_QUERYS.reserva set estado_id = (select id from GAME_OF_QUERYS.estado_reserva where descripcion='correcta')
where fecha_inicio > (select MAX(check_out) from GAME_OF_QUERYS.reserva)
and reserva.check_in is null



/*Stored Procedures para listados*/
GO
-- Hoteles con mayor cantidad de reservas canceladas
CREATE PROCEDURE GAME_OF_QUERYS.mayoresCancelaciones @year int, @trimestreInicio int, @trimestreFin int
AS
SELECT TOP 5 hotel_id, nombre AS 'nombre del hotel', COUNT(*) AS cantidad FROM GAME_OF_QUERYS.reserva
JOIN GAME_OF_QUERYS.hotel ON (hotel.id = reserva.hotel_id)
WHERE estado_id IN (3, 4, 5) AND (MONTH(fecha_inicio) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(fecha_inicio) = @year
GROUP BY hotel_id, nombre
ORDER BY cantidad DESC
GO

-- Hoteles con mayor cantidad de consumibles falcturados
CREATE PROCEDURE GAME_OF_QUERYS.mayoresConsumibles @year int, @trimestreInicio int, @trimestreFin int
AS
SELECT TOP 5 hotel_id, nombre AS 'nombre del hotel', COUNT(consumible_id) AS cantidad FROM GAME_OF_QUERYS.consumible_reserva
JOIN GAME_OF_QUERYS.reserva ON (consumible_reserva.reserva_id = reserva.id)
JOIN GAME_OF_QUERYS.hotel ON (hotel.id = reserva.hotel_id)
WHERE check_in IS NOT NULL AND check_out IS NOT NULL AND(MONTH(check_in) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(check_in) = @year
GROUP BY hotel_id, nombre
ORDER BY cantidad DESC
GO

-- Hoteles con mayor cantidad de días fuera de servicio
CREATE PROCEDURE GAME_OF_QUERYS.mayoresMantenimiento @year int, @trimestreInicio int, @trimestreFin int
AS
SELECT TOP 5 hotel_id, nombre AS 'nombre del hotel', SUM(DATEDIFF(DAY, fecha_inicio, fecha_fin)) AS cantidad FROM GAME_OF_QUERYS.mantenimiento
JOIN GAME_OF_QUERYS.hotel ON (hotel.id = mantenimiento.hotel_id)
WHERE (MONTH(fecha_inicio) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(fecha_inicio) = @year
GROUP BY hotel_id, nombre
ORDER BY cantidad DESC
GO

-- Habitaciones con mayor cantidad de días que fueron ocupadas
CREATE PROCEDURE GAME_OF_QUERYS.habitacionesOcupadas @year int, @trimestreInicio int, @trimestreFin int
AS
SELECT TOP 5 nombre AS 'nombre de hotel', reserva.hotel_id, nro AS 'nro de habitacion', SUM(DATEDIFF(DAY, check_in, check_out)) AS cantidad FROM GAME_OF_QUERYS.reserva
JOIN GAME_OF_QUERYS.reserva_habitacion ON (reserva.id = reserva_habitacion.reserva_id)
JOIN GAME_OF_QUERYS.habitacion ON (reserva_habitacion.habitacion_id = habitacion.id)
JOIN GAME_OF_QUERYS.hotel ON (hotel.id = reserva.hotel_id)
WHERE check_in IS NOT NULL AND check_out IS NOT NULL AND (MONTH(check_in) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(check_in) = @year
GROUP BY reserva.hotel_id, nombre, nro
ORDER BY cantidad DESC
GO


-- Puntos de los clientes: 1 por cada $10 de estadia y 1 por cada $5 de consumibles

CREATE PROCEDURE GAME_OF_QUERYS.puntosCliente @year int, @trimestreInicio int, @trimestreFin int
AS
SELECT TOP 5 cliente_id, cliente.nombre + ' ' + cliente.apellido AS 'nombre y apellido', ROUND(CAST((SUM(DISTINCT((precio_base*porcentual + cantidad_estrella*recarga_estrella) * (DATEDIFF(DAY, check_in, check_out))))/10 + SUM(cantidad*precio)/5) AS FLOAT), 0, 1) AS puntos
FROM GAME_OF_QUERYS.reserva
JOIN GAME_OF_QUERYS.reserva_habitacion ON (reserva.id = reserva_habitacion.reserva_id)
JOIN GAME_OF_QUERYS.consumible_reserva ON (reserva.id = consumible_reserva.reserva_id)
JOIN GAME_OF_QUERYS.consumible ON (consumible.id = consumible_reserva.consumible_id)
JOIN GAME_OF_QUERYS.regimen ON (reserva.regimen_id = regimen.id)
JOIN GAME_OF_QUERYS.hotel ON (reserva.hotel_id = hotel.id)
JOIN GAME_OF_QUERYS.habitacion ON (reserva_habitacion.habitacion_id = habitacion.id)
JOIN GAME_OF_QUERYS.tipo_habitacion ON (tipo_habitacion.id = habitacion.tipo_hab_id)
JOIN GAME_OF_QUERYS.cliente ON (cliente.id = reserva.cliente_id)
WHERE check_in IS NOT NULL AND check_out IS NOT NULL
AND (MONTH(check_in) BETWEEN @trimestreInicio AND @trimestreFin) AND YEAR(check_in) = @year
group by cliente_id, cliente.nombre, cliente.apellido
order by puntos DESC
GO