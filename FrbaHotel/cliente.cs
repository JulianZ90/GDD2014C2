using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace FrbaHotel
{
    public class Cliente
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);

        public int id { get; set; }
        public long? nro_identidad { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public DateTime? fecha_nac { get; set; }
        public string mail { get; set; }
        public long? tel { get; set; }
        public string calle { get; set; }
        public int? nro_calle { get; set; }
        public int? piso { get; set; }
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

            SqlCommand query = new SqlCommand("select * from GAME_OF_QUERYS.cliente where id=@cliente_id", connect);
            query.Parameters.AddWithValue("cliente_id", id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            if (objReader.Read())
            {
                this.nombre = objReader["nombre"] as string;
                this.apellido = objReader["apellido"] as string;
                this.fecha_nac = objReader["fecha_nac"] as DateTime?;
                this.mail = objReader["mail"] as string;
                this.tel = objReader["tel"] as int?;
                this.calle = objReader["calle"] as string;
                this.nro_calle = objReader["nro_calle"] as int?;
                this.piso = objReader["piso"] as int?;
                this.depto = objReader["depto"].ToString()[0];
                this.ciudad = objReader["ciudad"] as string;
                this.nacionalidad = objReader["nacionalidad"] as string;
                this.nro_identidad = objReader["nro_identidad"] as int?;

                if (objReader["tipo_identidad_id"] != DBNull.Value)
                {
                    this.tipo_identidad = new TipoIdentidad();
                    this.tipo_identidad.id = (int)objReader["tipo_identidad_id"];
                }
                else
                    this.tipo_identidad = null;

            }
            else
            {
                return;
            }
            objReader.Close();
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
            SqlCommand query = new SqlCommand("update GAME_OF_QUERYS.cliente set tipo_identidad_id=@tipo, nro_identidad=@nro_identidad, apellido=@apellido, nombre=@nombre, fecha_nac=@fecha_nac, mail=@mail, tel=@tel , calle=@calle, nro_calle=@nro_calle, piso=@piso, depto=@depto, ciudad=@ciudad, nacionalidad=@nacionalidad, permitido_ingreso=@permitido, pais_origen_id=@pais where id=@cliente_id ", connect);
            query.Parameters.AddWithValue("cliente_id", this.id);
            query.Parameters.AddWithValue("tipo", tipo_identidad.id);

            if (nro_identidad == null)
                query.Parameters.AddWithValue("nro_identidad", DBNull.Value);
            else
                query.Parameters.AddWithValue("nro_identidad", nro_identidad);

            query.Parameters.AddWithValue("nombre", nombre);
            query.Parameters.AddWithValue("apellido", apellido);
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
            query.Parameters.AddWithValue("pais", pais.id);


            query.ExecuteNonQuery();
            connect.Close();

        }


        public int insert(bool reserva)
        {
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
            int idCliente = Convert.ToInt32(query.ExecuteScalar());
            connect.Close();

            return idCliente;
        }


    }
}
