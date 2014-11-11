using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace FrbaHotel
{
    public class Hotel
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        
        public int id { get; set; }
        public string nombre { get; set; }
        public string calle { get; set; }
        public int? nro_calle { get; set; }
        public string ciudad { get; set; }
        public Pais pais { get; set; }
        public long? tel { get; set; }
        public int cantidad_estrella { get; set; }
        public int recarga_estrella { get; set; }
        public DateTime? fecha_creacion { get; set; }
        public string mail { get; set; }

        public List<Regimen> regimenes { get; set; }
        public List<Habitacion> habitaciones { get; set; }
        //public List<Mantenimiento> mantenimientos { get; set; }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(nombre))
                return "";
            else
                return nombre;
        }


        public Hotel() { }

        public Hotel(int id)
        {
            this.id= id;
            regimenes = new List<Regimen>();

            SqlCommand query = new SqlCommand("select * from GAME_OF_QUERYS.hotel where id=@hotel_id", connect);
            query.Parameters.AddWithValue("hotel_id", this.id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            if (objReader.Read())
            {
                this.calle = objReader["calle"] as string;
                this.nro_calle = objReader["nro_calle"] as int?;
                this.ciudad = objReader["ciudad"] as string;
                this.cantidad_estrella = (int)objReader["cantidad_estrella"];
                this.recarga_estrella = (int)objReader["recarga_estrella"];
                this.tel = objReader["tel"] as long?;
                this.mail = objReader["mail"] as string;
                this.fecha_creacion = objReader["fecha_creacion"] as DateTime?;
                this.nombre = objReader["nombre"] as string;

                if (objReader["pais_id"] != DBNull.Value)
                {
                    this.pais = new Pais();
                    this.pais.id = (int)objReader["pais_id"];
                }
                else
                    this.pais = null;
            }
            else
            {
                return;
            }
            objReader.Close();

            query = new SqlCommand("select distinct reg_id from GAME_OF_QUERYS.hotel_reg where hotel_id=@id", connect);
            query.Parameters.AddWithValue("id", this.id);
            objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Regimen reg = new Regimen();
                reg.id = (int)objReader["reg_id"];
                regimenes.Add(reg);
            }
            objReader.Close();
            connect.Close();
        }

        public void insert(LoginId Log)
        {
            SqlCommand query = new SqlCommand("insert into GAME_OF_QUERYS.hotel (calle, nro_calle, ciudad, cantidad_estrella, recarga_estrella, pais_id , tel, mail, fecha_creacion, nombre) values (@calle, @nro_calle, @ciudad, @cantidad_estrella, @recarga_estrella, @pais_id , @tel, @mail, @fecha_creacion, @nombre); SELECT SCOPE_IDENTITY()", connect);
            query.Parameters.AddWithValue("calle", calle);
            
            if(nro_calle==null)
                query.Parameters.AddWithValue("nro_calle", DBNull.Value);
            else
                query.Parameters.AddWithValue("nro_calle", nro_calle);

            query.Parameters.AddWithValue("ciudad", ciudad);

            if (cantidad_estrella == null)
                query.Parameters.AddWithValue("cantidad_estrella", DBNull.Value);
            else
                query.Parameters.AddWithValue("cantidad_estrella", cantidad_estrella);

            if (recarga_estrella == null)
                query.Parameters.AddWithValue("recarga_estrella", DBNull.Value);
            else
                query.Parameters.AddWithValue("recarga_estrella", recarga_estrella);

            if(pais==null)
                query.Parameters.AddWithValue("pais_id", DBNull.Value);
            else
                query.Parameters.AddWithValue("pais_id", pais.id);

            if (tel == null)
                query.Parameters.AddWithValue("tel", DBNull.Value);
            else
                query.Parameters.AddWithValue("tel", tel);

            query.Parameters.AddWithValue("mail", mail);

            if (fecha_creacion == null)
                query.Parameters.AddWithValue("fecha_creacion", DBNull.Value);
            else
                query.Parameters.AddWithValue("fecha_creacion", fecha_creacion);

            query.Parameters.AddWithValue("nombre", nombre);

            connect.Open();
            int hotel_id = Convert.ToInt32(query.ExecuteScalar());
            
            foreach (Regimen reg in regimenes)
            {
                query = new SqlCommand("insert into GAME_OF_QUERYS.hotel_reg (hotel_id, reg_id) values (@hotel, @reg)", connect);
                query.Parameters.AddWithValue("hotel", hotel_id);
                query.Parameters.AddWithValue("reg", reg.id);
                query.ExecuteNonQuery();
            }
            connect.Close();

            query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.hotel_usuario_rol(hotel_id, usuario_id, rol_id) VALUES (@hotel, @usuario, @rol)", connect);
            query.Parameters.AddWithValue("@hotel", hotel_id);
            query.Parameters.AddWithValue("@usuario", Log.Usuario_Id);
            query.Parameters.AddWithValue("@rol", 1);   //harccodeado el id del administrador
            connect.Open();
            query.ExecuteNonQuery();
            connect.Close();

        }

        public void update()
        {
            SqlCommand query = new SqlCommand("delete from GAME_OF_QUERYS.hotel_reg where hotel_id=@hotel", connect);
            query.Parameters.AddWithValue("hotel", this.id);
            connect.Open();
            query.ExecuteNonQuery();


            query = new SqlCommand("update GAME_OF_QUERYS.hotel set calle=@calle, nro_calle=@nro_calle, ciudad=@ciudad, cantidad_estrella=@cantidad_estrella, recarga_estrella=@recarga_estrella, pais_id= @pais_id, tel=@tel, mail=@mail, fecha_creacion=@fecha_creacion, nombre=@nombre where hotel.id = @hotel_id", connect);
            query.Parameters.AddWithValue("hotel_id", this.id);
            query.Parameters.AddWithValue("calle", calle);

            if (nro_calle == null)
                query.Parameters.AddWithValue("nro_calle", DBNull.Value);
            else
                query.Parameters.AddWithValue("nro_calle", nro_calle);

            query.Parameters.AddWithValue("ciudad", ciudad);

            if (cantidad_estrella == null)
                query.Parameters.AddWithValue("cantidad_estrella", DBNull.Value);
            else
                query.Parameters.AddWithValue("cantidad_estrella", cantidad_estrella);

            if (recarga_estrella == null)
                query.Parameters.AddWithValue("recarga_estrella", DBNull.Value);
            else
                query.Parameters.AddWithValue("recarga_estrella", recarga_estrella);

            if (pais == null)
                query.Parameters.AddWithValue("pais_id", DBNull.Value);
            else
                query.Parameters.AddWithValue("pais_id", pais.id);

            if (tel == null)
                query.Parameters.AddWithValue("tel", DBNull.Value);
            else
                query.Parameters.AddWithValue("tel", tel);

            query.Parameters.AddWithValue("mail", mail);

            if (fecha_creacion == null)
                query.Parameters.AddWithValue("fecha_creacion", DBNull.Value);
            else
                query.Parameters.AddWithValue("fecha_creacion", fecha_creacion);

            query.Parameters.AddWithValue("nombre", nombre);

            query.ExecuteNonQuery();

            foreach (Regimen reg in regimenes)
            {
                query = new SqlCommand("insert into GAME_OF_QUERYS.hotel_reg (hotel_id, reg_id) values (@hotel, @reg)", connect);
                query.Parameters.AddWithValue("hotel", this.id);
                query.Parameters.AddWithValue("reg", reg.id);
                query.ExecuteNonQuery();
            }
            connect.Close();
        
        }

        public bool hotelDisponible(DateTime i, DateTime f, int h)
        { 
            string query_str = @"select COUNT(id) as cant from GAME_OF_QUERYS.reserva
                            where ((fecha_inicio between @ini and @fin)
                            or (fecha_fin between @ini and @fin))
                            and estado_id in (1,2,6)
                            and hotel_id=@hotel";

            SqlCommand query = new SqlCommand(query_str, connect);
            query.Parameters.AddWithValue("@ini",i);
            query.Parameters.AddWithValue("@fin", f);
            query.Parameters.AddWithValue("@hotel", h);
            connect.Open();
            int cant = (int)query.ExecuteScalar();
            connect.Close();

            if (cant > 0)
                return false;
            else
            {
                return true;
            }
        }

        public bool regimenesEnUso()
        {
            List<Regimen> lstRegimenesNecesarios = new List<Regimen>();

            SqlCommand query = new SqlCommand("SELECT DISTINCT regimen_id FROM GAME_OF_QUERYS.reserva WHERE fecha_fin > @fechaHoy AND estado_id IN (1, 2, 6)", connect);
            query.Parameters.AddWithValue("@fechaHoy", DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]));
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();
            while (objReader.Read())
            {
                Regimen Regimen = new Regimen();
                Regimen.id = (int)objReader["regimen_id"];
                lstRegimenesNecesarios.Add(Regimen);
            }
            connect.Close();

            foreach (Regimen Item in this.regimenes)
            {
                foreach (Regimen Regimen in lstRegimenesNecesarios)
                {
                    if (Regimen.id == Item.id)
                    {
                        lstRegimenesNecesarios.Remove(Regimen);
                        break;
                    }
                }
            }

            if (lstRegimenesNecesarios.Count > 0)
                return false;
            else
                return true;

        }

    }
}
