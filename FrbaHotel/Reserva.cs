using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaHotel
{
    public class Reserva
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);

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
            SqlCommand query = new SqlCommand("update GAME_OF_QUERYS.reserva set check_in=@checkin, user_check_in_id=@user, estado_id=6 where id=@reserva", connect);
            query.Parameters.AddWithValue("reserva", Id);
            query.Parameters.AddWithValue("checkin", checkin);
            query.Parameters.AddWithValue("user", user_checkin.id);
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


        public void hacerCheckout()
        {
            SqlCommand query = new SqlCommand("update GAME_OF_QUERYS.reserva set check_out=@checkout, user_check_out_id=@user where id=@reserva", connect);
            query.Parameters.AddWithValue("reserva", Id);
            query.Parameters.AddWithValue("checkout", checkout);
            query.Parameters.AddWithValue("user", user_checkout.id);
            connect.Open();
            query.ExecuteNonQuery();
            connect.Close();
        }


        public bool isCancel()
        {
            return this.Estado.Descripcion.Contains("cancelada");
        }

        public bool tieneIngreso()
        { 
            return this.Estado.Descripcion == "con ingreso";
        }

        public void registrarConsumibles()
        {
            SqlCommand query = new SqlCommand("delete GAME_OF_QUERYS.consumible_reserva where consumible_reserva.reserva_id=@reserva", connect);
            query.Parameters.AddWithValue("reserva", Id);
            connect.Open();
            query.ExecuteNonQuery();

            foreach (consumible h in consumibles)
            {
                query = new SqlCommand("insert into GAME_OF_QUERYS.consumible_reserva (reserva_id,consumible_id, cantidad, habitacion_id) values(@reserva , @consu,@cant,@hab) ", connect);
                query.Parameters.AddWithValue("reserva", Id);
                query.Parameters.AddWithValue("consu", h.id);
                query.Parameters.AddWithValue("cant", h.cantidad);
                query.Parameters.AddWithValue("hab", h.habitacion.Id);
                query.ExecuteNonQuery();
            }

            connect.Close();
        }
 
    }
}
