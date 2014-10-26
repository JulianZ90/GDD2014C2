using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    public class Rol
    {
        public Rol()
        {
            this.Funcionalidades = new List<Funcionalidad>();
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public List<Funcionalidad> Funcionalidades { get; set; }
    }
}
