﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;


namespace FrbaHotel
{
    public class Usuario
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string  nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public long? tel { get; set; }
        public string direccion { get; set; }
        public DateTime? fecha_nac { get; set; }
        public bool estado { get; set; }
        public long? nro_identidad { get; set; }
        public TipoIdentidad tipo_identidad { get; set; }
        public Hotel hotel { get; set; }
        public List<Rol> roles { get; set; }

        public Usuario() { }

        public Usuario(int id, int hotelId)
        {
            roles = new List<Rol>();
            this.id = id;

            SqlCommand query = new SqlCommand("select * from GAME_OF_QUERYS.usuario where id=@user_id", connect);
            query.Parameters.AddWithValue("user_id", id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();
            
            if (objReader.Read())
            {
                this.username = objReader["username"] as string;
                this.password = objReader["password"] as string;
                this.nombre = objReader["nombre"] as string;
                this.apellido = objReader["apellido"] as string;
                this.mail = objReader["mail"] as string;
                this.tel = objReader["tel"] as long?;
                this.direccion = objReader["direccion"] as string;
                this.fecha_nac = objReader["fecha_nac"] as DateTime?;
                this.estado = (bool)objReader["estado"];
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
                return ;
            }
            objReader.Close();

            query = new SqlCommand("select distinct rol_id from GAME_OF_QUERYS.hotel_usuario_rol where usuario_id=@user_id and hotel_id = @hotel_id", connect);
            query.Parameters.AddWithValue("user_id", id);
            query.Parameters.AddWithValue("@hotel_id", hotelId);
            objReader = query.ExecuteReader();
            
            while (objReader.Read())
            {
                Rol rol = new Rol();
                rol.Id = (int)objReader["rol_id"];
                roles.Add(rol);
            }

            connect.Close();
        }

        public void insert(){

            SqlCommand query = new SqlCommand("insert into GAME_OF_QUERYS.usuario (username, password, nombre, apellido, mail, tel , direccion, fecha_nac, estado, nro_identidad, tipo_identidad_id) values (@username, @password, @nombre, @apellido, @mail, @tel , @dir, @fec_nac, @estado, @dni,@tipo); SELECT SCOPE_IDENTITY()", connect);
            query.Parameters.AddWithValue("username", username);
            query.Parameters.AddWithValue("password", password);
            query.Parameters.AddWithValue("nombre", nombre);
            query.Parameters.AddWithValue("apellido", apellido);
            query.Parameters.AddWithValue("mail", mail);

            if(tel==null) 
                query.Parameters.AddWithValue("tel", DBNull.Value);
            else 
                query.Parameters.AddWithValue("tel", tel);

            query.Parameters.AddWithValue("dir", direccion);

            if (fecha_nac == null) 
                query.Parameters.AddWithValue("fec_nac", DBNull.Value);
            else 
                query.Parameters.AddWithValue("fec_nac", fecha_nac.Value.Date );

            query.Parameters.AddWithValue("estado", estado);

            if (tipo_identidad == null)
                query.Parameters.AddWithValue("tipo", DBNull.Value);
            else 
                query.Parameters.AddWithValue("tipo", tipo_identidad.id);
            
            if (nro_identidad == null)
                query.Parameters.AddWithValue("dni", DBNull.Value);
            else
                query.Parameters.AddWithValue("dni", nro_identidad);
            

            connect.Open();
            int user_id;
            try
            {
                user_id = Convert.ToInt32(query.ExecuteScalar());
            }
            catch (SqlException l)
            {
                MessageBox.Show("Nombre de usuario repetido");
                connect.Close();
                return;
            }
            
           
            // agrego los roles asignados
            foreach (Rol rol in roles)
            {
                query = new SqlCommand("insert into GAME_OF_QUERYS.hotel_usuario_rol (hotel_id, rol_id, usuario_id) values (@hotel, @rol,@usuario)", connect);
                query.Parameters.AddWithValue("hotel", this.hotel.id);
                query.Parameters.AddWithValue("rol", rol.Id);
                query.Parameters.AddWithValue("usuario", user_id);
                query.ExecuteNonQuery();
            }
            
            connect.Close();

            MessageBox.Show("Usuario creado");
                
         }

        public void update(){
            SqlCommand query = new SqlCommand("delete from GAME_OF_QUERYS.hotel_usuario_rol where usuario_id=@usuario and hotel_id = @hotelId", connect);
            query.Parameters.AddWithValue("usuario", this.id);
            query.Parameters.AddWithValue("@hotelId", this.hotel.id);
            connect.Open();
            query.ExecuteNonQuery();

            query = new SqlCommand("update GAME_OF_QUERYS.usuario set username=@username, password=@password, nombre=@nombre, apellido=@apellido, mail=@mail, tel=@tel , direccion=@dir, fecha_nac=@fec_nac, estado=@estado, nro_identidad=@dni, tipo_identidad_id=@tipo where id=@user_id", connect);
            query.Parameters.AddWithValue("user_id", this.id);
            query.Parameters.AddWithValue("username", username);
            query.Parameters.AddWithValue("password", password);
            query.Parameters.AddWithValue("nombre", nombre);
            query.Parameters.AddWithValue("apellido", apellido);
            query.Parameters.AddWithValue("mail", mail);

            if (tel == null)
                query.Parameters.AddWithValue("tel", DBNull.Value);
            else
                query.Parameters.AddWithValue("tel", tel);

            query.Parameters.AddWithValue("dir", direccion);
            query.Parameters.AddWithValue("fec_nac", fecha_nac.Value.Date);
            query.Parameters.AddWithValue("estado", estado);
            query.Parameters.AddWithValue("tipo", tipo_identidad.id);

            if (nro_identidad == null)
                query.Parameters.AddWithValue("dni", DBNull.Value);
            else
                query.Parameters.AddWithValue("dni", nro_identidad);

            query.ExecuteNonQuery();

            foreach (Rol rol in roles)
            {
                query = new SqlCommand("insert into GAME_OF_QUERYS.hotel_usuario_rol (hotel_id, rol_id, usuario_id) values (@hotel, @rol,@usuario)", connect);
                query.Parameters.AddWithValue("hotel", this.hotel.id);
                query.Parameters.AddWithValue("rol", rol.Id);
                query.Parameters.AddWithValue("usuario", this.id);
                query.ExecuteNonQuery();
            }
            
            
            connect.Close();

            MessageBox.Show("Usuario con id=" + id.ToString() + " modificado");
        }

        public void asignarRoles()
        {
            connect.Open();
            foreach (Rol rol in roles)
            {
                SqlCommand query = new SqlCommand("insert into GAME_OF_QUERYS.hotel_usuario_rol (hotel_id, rol_id, usuario_id) values (@hotel, @rol,@usuario)", connect);
                query.Parameters.AddWithValue("hotel", this.hotel.id);
                query.Parameters.AddWithValue("rol", rol.Id);
                query.Parameters.AddWithValue("usuario", this.id);
                query.ExecuteNonQuery();
            }
            connect.Close();

            MessageBox.Show("Usuario con id=" + id.ToString() + " asignado al hotel actual");
        }

    }

    
}
