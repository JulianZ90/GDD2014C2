/*cargar hoteles (16) y regimenes (4) */
insert into GAME_OF_QUERYS.hotel (ciudad, calle, nro_calle, cantidad_estrella, recarga_estrella,
								 pais_id)
select distinct Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella,Hotel_Recarga_Estrella,
				'1'
from gd_esquema.Maestra 

insert into GAME_OF_QUERYS.regimen(descripcion, precio_base,estado)
select distinct Regimen_Descripcion, Regimen_Precio,'1'
from gd_esquema.Maestra

/*cargo la tabla reg_hotel

todos los hoteles tienen los 4 regimenes
pero por las dudas hago mas verificaciones si andamos
flojos de tiempo esto se puede mejorar*/

insert into GAME_OF_QUERYS.hotel_reg( hotel_id, reg_id)
select distinct h.id, r.id
from gd_esquema.Maestra m 
			join GAME_OF_QUERYS.regimen r on r.descripcion=m.Regimen_Descripcion
			join GAME_OF_QUERYS.hotel h on h.ciudad=m.Hotel_Ciudad and h.calle=m.Hotel_Calle
							and h.nro_calle=m.Hotel_Nro_Calle
/*order by h.hotel_id, r.reg_id opcional */



/*cargo tipo_ident , pais y los clientes (100.740)
falta sacar horas minutos y segundos de la fecha de nacimiento*/
insert into GAME_OF_QUERYS.pais (id, nombre) values ('1', 'Argentina')
insert into GAME_OF_QUERYS.tipo_identidad (id, nombre) values ('1', 'DNI')
insert into GAME_OF_QUERYS.tipo_identidad (id, nombre) values ('2', 'Pasaporte')

insert into GAME_OF_QUERYS.cliente (tipo_identidad_id, nro_identidad, apellido,nombre,
					fecha_nac, mail, calle, nro_calle, piso,
					depto, pais_origen_id,nacionalidad,permitido_ingreso)
select distinct '2',Cliente_Pasaporte_Nro, Cliente_Apellido,
				Cliente_Nombre, Cliente_Fecha_Nac, Cliente_Mail,
				Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso,
				Cliente_Depto, '1',Cliente_Nacionalidad,'1'
from gd_esquema.Maestra
/* esto es para ver los domicilios repetidos luego con un select hardcodeado
se puede ver que es gente que vive junta 
select distinct COUNT(*), calle, nro_calle, piso, depto
from cliente
group by calle, nro_calle, piso, depto
order by 1 */

/*cargo los tipos de habitacion*/
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
							
/* cargo estado_reserva 
sacar los id y poner autoindexacion*/
set identity_insert GD2C2014.GAME_OF_QUERYS.tipo_habitacion on
insert into GAME_OF_QUERYS.estado_reserva (id,descripcion)values(1,'correcta')
insert into GAME_OF_QUERYS.estado_reserva (id,descripcion)values(2,'modificada')
insert into GAME_OF_QUERYS.estado_reserva (id,descripcion)values(3,'cancelada por recepcion')
insert into GAME_OF_QUERYS.estado_reserva (id,descripcion)values(4,'cancelada por cliente')
insert into GAME_OF_QUERYS.estado_reserva (id,descripcion)values(5,'cancelada por No-Show')
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