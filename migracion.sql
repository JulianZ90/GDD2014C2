/*cargar argentina en pais, hoteles (16) y regimenes (4) */
insert into GAME_OF_QUERYS.pais (nombre) values ('Argentina')


insert into GAME_OF_QUERYS.hotel (ciudad, calle, nro_calle, cantidad_estrella, recarga_estrella,
								 pais_id)
select distinct Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella,Hotel_Recarga_Estrella,
				(select id from GAME_OF_QUERYS.pais where nombre='Argentina')
from gd_esquema.Maestra 

insert into GAME_OF_QUERYS.regimen(descripcion, precio_base,estado)
select distinct Regimen_Descripcion, Regimen_Precio,'1'
from gd_esquema.Maestra

/*cargo la tabla reg_hotel (4x16, todos los hoteles tienen los 4 regimenes)*/

insert into GAME_OF_QUERYS.hotel_reg( hotel_id, reg_id)
select distinct h.id, r.id
from GAME_OF_QUERYS.hotel h, GAME_OF_QUERYS.regimen r

/*cargo tipo_ident dni y pasaporte y los clientes (100.740)
falta sacar horas minutos y segundos de la fecha de nacimiento*/

insert into GAME_OF_QUERYS.tipo_identidad (nombre) values ('DNI')
insert into GAME_OF_QUERYS.tipo_identidad (nombre) values ('Pasaporte')

insert into GAME_OF_QUERYS.cliente (tipo_identidad_id, nro_identidad, apellido,nombre,
					fecha_nac, mail, calle, nro_calle, piso,
					depto,nacionalidad,permitido_ingreso)
select distinct (select id from GAME_OF_QUERYS.tipo_identidad where nombre='Pasaporte'),Cliente_Pasaporte_Nro, Cliente_Apellido,
				Cliente_Nombre, Cliente_Fecha_Nac, Cliente_Mail,
				Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso,
				Cliente_Depto,Cliente_Nacionalidad,'1'
from gd_esquema.Maestra

/*cargo los tipos de habitacion (5)*/
set identity_insert GD2C2014.GAME_OF_QUERYS.tipo_habitacion on
insert into GAME_OF_QUERYS.tipo_habitacion (id, descripcion, porcentual)
select distinct Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion ,
				 Habitacion_Tipo_Porcentual
from gd_esquema.Maestra

/*cargo las habitaciones (345 en total)*/

insert into GAME_OF_QUERYS.habitacion (hotel_id,nro,piso,ubicacion,tipo_hab_id,
										estado_habitacion)
select distinct h.id, m.Habitacion_Numero, m.Habitacion_Piso,
		 m.Habitacion_Frente, m.Habitacion_Tipo_Codigo, '1'
from gd_esquema.Maestra m 
			join GAME_OF_QUERYS.hotel h on h.ciudad=m.Hotel_Ciudad and h.calle=m.Hotel_Calle
							and h.nro_calle=m.Hotel_Nro_Calle
							
/* cargo estado_reserva */
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('correcta')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('modificada')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('cancelada por recepcion')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('cancelada por cliente')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('cancelada por No-Show')
insert into GAME_OF_QUERYS.estado_reserva (descripcion)values('con ingreso')

							
/*cargo las reservas, 1 cliente no tiene mas de 1 reserva en la tabla (casualidad),
pero hay reservas con mas de un cliente

con las reservas que tienen mas de un cliente  , atajar el error,
el problema puede ser que hayan id de reservas repetidos

y ver de que manera saber si se puede en que estado esta la reserva 
seguro que lo mas facil va a ser ver las finalizadas  */

insert into reserva (id,cliente_id /*,regimen_idfecha_inicio,fecha_fin*/)
select distinct m.Reserva_Codigo, c.id, r.id
				/*m.Reserva_Fecha_Inicioobtener fecha fin*/
from gd_esquema.Maestra m
						join cliente c on m.cliente_pasaporte_nro=c.nro_identidad
						join regimen r on r.descripcion = m.regimen_descripcion

select distinct m.reserva_codigo, c.id
from gd_esquema.Maestra m
						join cliente c on m.cliente_pasaporte_nro=c.nro_identidad