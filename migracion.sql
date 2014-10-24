/*cargar argentina en pais, hotel (16) y regimen (4) */
insert into GAME_OF_QUERYS.pais (nombre) values ('Argentina')


insert into GAME_OF_QUERYS.hotel (ciudad, calle, nro_calle, cantidad_estrella, recarga_estrella,
								 pais_id)
select distinct Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella,Hotel_Recarga_Estrella,
				(select id from GAME_OF_QUERYS.pais where nombre='Argentina')
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
					depto,nacionalidad,permitido_ingreso)
select distinct (select id from GAME_OF_QUERYS.tipo_identidad where nombre='Pasaporte'),Cliente_Pasaporte_Nro, Cliente_Apellido,
				Cliente_Nombre,cast(Cliente_Fecha_Nac as Date), Cliente_Mail,
				Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso,
				Cliente_Depto,Cliente_Nacionalidad,'1'
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
insert into GAME_OF_QUERYS.reserva(id,cliente_id,regimen_id, fecha_inicio, fecha_fin)
select distinct m.Reserva_Codigo, c.id, r.id, cast(m.Reserva_Fecha_Inicio as Date), DATEADD (day ,m.Reserva_Cant_Noches , cast(m.Reserva_Fecha_Inicio as Date) )
from gd_esquema.Maestra m
						join GAME_OF_QUERYS.cliente c on m.cliente_pasaporte_nro=c.nro_identidad and
														m.Cliente_Mail=c.mail
						join GAME_OF_QUERYS.regimen r on r.descripcion = m.regimen_descripcion
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

/*cargar estadia (89603)*/

insert into GAME_OF_QUERYS.estadia (check_in, check_out, reserva_id,habitacion_id)
select distinct cast(m.Estadia_Fecha_Inicio as date),
			 DATEADD (day ,m.estadia_Cant_Noches , cast(m.estadia_Fecha_Inicio as Date) ),m.Reserva_Codigo,
			 h.id
from gd_esquema.Maestra m join GAME_OF_QUERYS.habitacion h on h.nro=m.Habitacion_Numero and
															h.piso=m.Habitacion_Piso
						  join GAME_OF_QUERYS.hotel ho on ho.ciudad=m.Hotel_Ciudad and
														ho.calle=m.Hotel_Calle and
														ho.nro_calle= m.Hotel_Nro_Calle
															
where Estadia_Fecha_Inicio is not null and
	 ho.id = h.hotel_id

/*cargar consumible_estadia (207341)*/

insert into GAME_OF_QUERYS.consumible_estadia (consumible_id,estadia_id,cantidad)
select distinct c.id, e.id, COUNT(m.Consumible_Descripcion)
from gd_esquema.Maestra m 
join GAME_OF_QUERYS.consumible c	on m.Consumible_Codigo= c.id
join GAME_OF_QUERYS.estadia e		on m.Reserva_Codigo=e.reserva_id
group by c.id,e.id

/* cargar cliente_estadia (89603) */

insert into GAME_OF_QUERYS.cliente_estadia (cliente_id,estadia_id)
select distinct c.id, e.id
from gd_esquema.Maestra m 
join GAME_OF_QUERYS.cliente c 
							on m.cliente_pasaporte_nro=c.nro_identidad and
														m.Cliente_Mail=c.mail
join GAME_OF_QUERYS.estadia e on m.Reserva_Codigo=e.reserva_id

/*cargar factura (89603)*/
insert into GAME_OF_QUERYS.factura (fecha,estadia_id)
select distinct CAST(m.Factura_Fecha as DATE), e.id
from gd_esquema.Maestra m 
join GAME_OF_QUERYS.estadia e on m.Reserva_Codigo=e.reserva_id
where m.Factura_Fecha is not null



insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('Administrador',1)
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('Recepcionista',1)
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('Guest',1)
insert into GAME_OF_QUERYS.rol (descripcion, estado) values ('admin',1)


insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmRol')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('ambUsuario')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmCliente')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmHabitacion')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('abmRegimen')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('generarReserva')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('cancelarReserva')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('registrarEstadia')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('facturar')
insert into GAME_OF_QUERYS.funcionalidad (descripcion) values ('estadistico')

insert into GAME_OF_QUERYS.usuario (username) values ('guest' )
insert into GAME_OF_QUERYS.usuario (username,password, nombre,estado) values ('admin', HASHBYTES('SHA1', 'w23e' ), 'Administrador General','1')

