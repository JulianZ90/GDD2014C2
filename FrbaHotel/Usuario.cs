using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaHotel
{
    class Usuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string  nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public int? tel { get; set; }
        public string direccion { get; set; }
        public DateTime? fecha_nac { get; set; }
        public bool estado { get; set; }
        public int? nro_identidad { get; set; }
        public TipoIdentidad tipo_identidad { get; set; }


        public void guardar(){
                SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
                SqlCommand query = new SqlCommand("insert into GAME_OF_QUERYS.usuarios (username, password, nombre, apellido, mail, tel , dir, fec_nac, estado, dni) values (@username, @password, @nombre, @apellido, @mail, @tel , @dir, @fec_nac, @estado, @dni)", connect);
                query.Parameters.AddWithValue("username", username);
                query.Parameters.AddWithValue("password", password);
                query.Parameters.AddWithValue("nombre", nombre);
                query.Parameters.AddWithValue("apellido", apellido);
                query.Parameters.AddWithValue("mail", mail);
                query.Parameters.AddWithValue("tel", tel);
                query.Parameters.AddWithValue("dir", direccion);
                query.Parameters.AddWithValue("fec_nac", fecha_nac.Value.Date );
                query.Parameters.AddWithValue("estado", estado);
                query.Parameters.AddWithValue("tipo_doc", tipo_identidad.id);
                query.Parameters.AddWithValue("dni", nro_identidad);

                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
         }

    }

    
}
