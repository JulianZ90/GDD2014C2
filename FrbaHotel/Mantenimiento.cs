﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace FrbaHotel
{
    public class Mantenimiento
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);

        public int id { get; set; }
        public Hotel hotel { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string descripcion { get; set; }


        public void insert(){
            SqlCommand query = new SqlCommand("insert into GAME_OF_QUERYS.mantenimiento (hotel_id, fecha_inicio, fecha_fin, descripcion) values (@hotel_id,@ini, @fin, @desc) ", connect);
            query.Parameters.AddWithValue("hotel_id", hotel.id);
            query.Parameters.AddWithValue("ini", fecha_inicio);
            query.Parameters.AddWithValue("fin", fecha_fin);
            query.Parameters.AddWithValue("desc", descripcion);

            connect.Open();
            query.ExecuteNonQuery();
            connect.Close();
        }

        public bool delete()
        {
            if (this.fecha_inicio > DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]))
            {
                SqlCommand query = new SqlCommand("delete from GAME_OF_QUERYS.mantenimiento where id=@id ", connect);
                query.Parameters.AddWithValue("id", this.id);
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();

                return true;
            }
            else
                return false;

        }

    }
}
