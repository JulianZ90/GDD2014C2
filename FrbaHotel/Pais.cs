using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    public class Pais
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(nombre))
                return "";
            else
                return nombre;
        }
    }
}
