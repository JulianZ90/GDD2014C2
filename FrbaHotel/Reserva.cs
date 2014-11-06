using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    public class Reserva
    {
        public Reserva()
        {
            this.Habitaciones = new List<Habitacion>();
        }

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
       
    }
}
