select *
from gd_esquema.Maestra
where Reserva_Codigo = '10327'


select DISTINCT m1.Cliente_Pasaporte_Nro, m1.Cliente_Mail 'mail cliente 1', m2.Cliente_Mail 'mail cliente 2'
from gd_esquema.Maestra m1
join gd_esquema.Maestra m2 on (m1.Cliente_Pasaporte_Nro = m2.Cliente_Pasaporte_Nro)
WHERE m1.Cliente_Mail < m2.Cliente_Mail