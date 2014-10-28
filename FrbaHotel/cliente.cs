using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    class cliente
    {
        //public int id { get; set; }
        public int nro_identidad { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public DateTime fecha_nac { get; set; }
        public string mail { get; set; }
        public int tel { get; set; }
        public string calle { get; set; }
        public int nro_calle { get; set; }
        public int piso { get; set; }
        public char depto { get; set; }
        public string ciudad { get; set; }
        public string nacionalidad { get; set; }
        public string localidad { get; set; }
        public int permitido_ingreso { get; set; }
        public TipoIdentidad tipo_identidad { get; set; }
    }
}
