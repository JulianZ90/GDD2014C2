using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    class Hotel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string calle { get; set; }
        public int? nro_calle { get; set; }
        public string ciudad { get; set; }
        public Pais pais { get; set; }
        public int? tel { get; set; }
        public int? cantidad_estrella { get; set; }
        public int? recarga_estrella { get; set; }
        public DateTime? fecha_creacion { get; set; }

        //public List<Regimen> regimenes { get; set; }
        public List<Habitacion> habitaciones { get; set; }
        //public List<Mantenimiento> mantenimientos { get; set; }
    }
}
