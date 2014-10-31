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
        public DateTime? fecha_nac { get; set; }
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

        public void insert(){
            SqlCommand query = new SqlCommand("insert into GAME_OF_QUERYS.cliente (tipo_identidad_id, nro_identidad, apellido, nombre, fecha_nac, mail, tel , calle, nro_calle, piso, depto, ciudad, nacionalidad, permitido_ingreso, pais_origen_id) values (@tipo, @nro_identidad, @apellido,@nombre, @fecha_nac,  @mail, @tel , @calle, @nro_calle, @piso,@depto, @ciudad, @nacionalidad, @permitido, @pais); SELECT SCOPE_IDENTITY()", connect);
            if (tipo_identidad == null)
                query.Parameters.AddWithValue("tipo", DBNull.Value);
            else
                query.Parameters.AddWithValue("tipo", tipo_identidad.id);

            if (nro_identidad == null)
                query.Parameters.AddWithValue("nro_identidad", DBNull.Value);
            else
                query.Parameters.AddWithValue("nro_identidad", nro_identidad);
            
            query.Parameters.AddWithValue("nombre", nombre);
            query.Parameters.AddWithValue("apellido", apellido);

            if (fecha_nac == null)
                query.Parameters.AddWithValue("fecha_nac", DBNull.Value);
            else
                query.Parameters.AddWithValue("fecha_nac", fecha_nac.Value.Date);

            query.Parameters.AddWithValue("mail", mail);

            if (tel == null)
                query.Parameters.AddWithValue("tel", DBNull.Value);
            else
                query.Parameters.AddWithValue("tel", tel);

            query.Parameters.AddWithValue("calle", calle);

            if (nro_calle == null)
                query.Parameters.AddWithValue("nro_calle", DBNull.Value);
            else
                query.Parameters.AddWithValue("nro_calle", nro_calle);
            
            if (piso == null)
                query.Parameters.AddWithValue("piso", DBNull.Value);
            else
                query.Parameters.AddWithValue("piso", piso);

            query.Parameters.AddWithValue("depto", depto);
            query.Parameters.AddWithValue("ciudad", ciudad);
            query.Parameters.AddWithValue("nacionalidad", nacionalidad);
            query.Parameters.AddWithValue("permitido", permitido_ingreso);

            if (pais == null)
                query.Parameters.AddWithValue("pais", DBNull.Value);
            else
                query.Parameters.AddWithValue("pais", pais.id);



            connect.Open();
            query.ExecuteNonQuery();
            connect.Close();           
        }

        public void update(){
        
        
        }


    }
}
