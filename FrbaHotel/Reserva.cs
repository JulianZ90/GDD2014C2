using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaHotel
{
    public class Reserva
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");

        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Regimen Regimen { get; set; }
        public EstadoReserva Estado { get; set; }
        public DateTime? FechaRealizacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Usuario UltimoUsuario { get; set; }
        public string CancelMotivo { get; set; }
        public DateTime? CancelFecha { get; set; }
        public List<Habitacion> Habitaciones { get; set; }

        public Hotel hotel { get; set; }
        public DateTime? checkin { get; set; }
        public DateTime? checkout { get; set; }
        public Usuario user_checkin { get; set; }
        public Usuario user_checkout { get; set; }
        public List<Cliente> huespedes { get; set; }
        public List<consumible> consumibles { get; set; }
        
        public Reserva()
        {
            this.Habitaciones = new List<Habitacion>();
        }

        public void hacerCheckin()
        {
            //TODO falta agregar el user_check_in_id de la session
            SqlCommand query = new SqlCommand("update GAME_OF_QUERYS.reserva set check_in=@checkin where id=@reserva", connect);
            query.Parameters.AddWithValue("reserva", Id);
            query.Parameters.AddWithValue("checkin", checkin);
            connect.Open();
            query.ExecuteNonQuery();

            query = new SqlCommand("delete from GAME_OF_QUERYS.cliente_reserva where reserva_id=@reserva", connect);
            query.Parameters.AddWithValue("reserva", Id);
            query.ExecuteNonQuery();

            foreach (Cliente h in huespedes)
            {
                query = new SqlCommand("insert into GAME_OF_QUERYS.cliente_reserva (reserva_id,cliente_id) values(@reserva , @cliente) ", connect);
                query.Parameters.AddWithValue("reserva", Id);
                query.Parameters.AddWithValue("cliente", h.id);
                query.ExecuteNonQuery();
            }
            


            connect.Close();

        }
 
    }
}
