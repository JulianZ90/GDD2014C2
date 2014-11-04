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

    }
}
