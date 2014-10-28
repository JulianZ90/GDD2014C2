using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int Hotel_id { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public string Ubicacion { get; set; }
        public TipoHabitacion Tipo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
