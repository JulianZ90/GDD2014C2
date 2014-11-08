using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaHotel
{
    public class consumible
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");

        public int id { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        
        public consumible() { }

        public consumible(int id)
        {
            this.id = id;

            SqlCommand query = new SqlCommand("select * from GAME_OF_QUERYS.consumible where id=@consumible_id", connect);
            query.Parameters.AddWithValue("consumible_id", id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            if (objReader.Read())
            {
                this.descripcion = objReader["descripcion"] as string;
                this.precio = (decimal)objReader["precio"];
            }
            else
            {
                return;
            }
            objReader.Close();
        }
        public void insert()
        {
            SqlCommand query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.consumible ( precio, descripcion) VALUES (@precio, @descripcion); SELECT SCOPE_IDENTITY()", connect);

            query.Parameters.AddWithValue("precio", precio);
            query.Parameters.AddWithValue("descripcion", descripcion);

            connect.Open();
            query.ExecuteNonQuery();
            connect.Close();
        }

        public void update()
        {
            SqlCommand query = new SqlCommand("update GAME_OF_QUERYS.consumible set precio=@precio, descripcion=@descripcion where id=@id ", connect);
            
            query.Parameters.AddWithValue("id", this.id);
            query.Parameters.AddWithValue("precio", precio);
            query.Parameters.AddWithValue("descripcion", descripcion);

            query.ExecuteNonQuery();
            connect.Close();
        }
        public void delete()
        {
            SqlCommand query = new SqlCommand("delete from GAME_OF_QUERYS.consumible where id = @id", connect);
            query.Parameters.AddWithValue("id", this.id);
            //query.Parameters.AddWithValue("precio", precio);
            //query.Parameters.AddWithValue("descripcion", descripcion);

            query.ExecuteNonQuery();
            connect.Close();
        }

    }
}
