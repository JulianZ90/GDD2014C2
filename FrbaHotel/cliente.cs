using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaHotel
{
    class Cliente
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");

        public int id { get; set; }
        public long? nro_identidad { get; set; }
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
        public bool permitido_ingreso { get; set; }
        public TipoIdentidad tipo_identidad { get; set; }
        public Pais pais { get; set; }

        public Cliente() { }

        public Cliente(int id)
        {
            this.id = id;
        }

        public void insert(){}

        public void update(){}


    }
}
