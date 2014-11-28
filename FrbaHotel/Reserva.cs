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
        public int estadia_id { get; set; }

        public Reserva()
        {
            this.Habitaciones = new List<Habitacion>();
        }

        public void hacerCheckin()
        {
            //TODO falta agregar el user_check_in_id de la session
            SqlCommand query = new SqlCommand("update GAME_OF_QUERYS.reserva set estado_id=6 where id=@reserva", connect);
            query.Parameters.AddWithValue("reserva", Id);

            connect.Open();
            query.ExecuteNonQuery();

            query = new SqlCommand("insert into GAME_OF_QUERYS.estadia(check_in, reserva_id, user_check_in_id) values (@checkin, @reserva, @user); SELECT SCOPE_IDENTITY()", connect);
            query.Parameters.AddWithValue("reserva", Id);
            query.Parameters.AddWithValue("checkin", checkin);
            query.Parameters.AddWithValue("user", user_checkin.id);

            int EstadiaId = Convert.ToInt32(query.ExecuteScalar());
            this.estadia_id = EstadiaId;

            query = new SqlCommand("delete from GAME_OF_QUERYS.cliente_estadia where estadia_id=@estadia", connect);
            query.Parameters.AddWithValue("@estadia", EstadiaId);
            query.ExecuteNonQuery();

            foreach (Cliente h in huespedes)
            {
                query = new SqlCommand("insert into GAME_OF_QUERYS.cliente_estadia (estadia_id,cliente_id) values(@estadia , @cliente) ", connect);
                query.Parameters.AddWithValue("@estadia", EstadiaId);
                query.Parameters.AddWithValue("cliente", h.id);
                query.ExecuteNonQuery();
            }

            connect.Close();
        }


        public void hacerCheckout()
        {
            SqlCommand query = new SqlCommand("update GAME_OF_QUERYS.estadia set check_out=@checkout, user_check_out_id=@user where id=@estadia", connect);
            query.Parameters.AddWithValue("estadia", this.estadia_id);
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
            SqlCommand query = new SqlCommand("delete from GAME_OF_QUERYS.consumible_estadia where estadia_id=@estadia", connect);
            query.Parameters.AddWithValue("@estadia", this.estadia_id);

            connect.Open();
            query.ExecuteNonQuery();

            foreach (consumible h in consumibles)
            {
                query = new SqlCommand("insert into GAME_OF_QUERYS.consumible_estadia (estadia_id,consumible_id, cantidad, habitacion_id) values(@estadia , @consu,@cant,@hab) ", connect);
                query.Parameters.AddWithValue("estadia", this.estadia_id);
                query.Parameters.AddWithValue("consu", h.id);
                query.Parameters.AddWithValue("cant", h.cantidad);
                query.Parameters.AddWithValue("hab", h.habitacion.Id);
                query.ExecuteNonQuery();
            }

            connect.Close();
        }


        public int obtenerEstadia(int ReservaId)
        {
            SqlCommand query = new SqlCommand("select id from GAME_OF_QUERYS.estadia where reserva_id = @reserva", connect);
            query.Parameters.AddWithValue("@reserva", ReservaId);

            connect.Open();
            int EstadiaId = (int)query.ExecuteScalar();
            connect.Close();
            return EstadiaId;
        }
 
    }
}
