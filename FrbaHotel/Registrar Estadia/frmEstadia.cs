using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmEstadia : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        Reserva reserva;

        public frmEstadia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query_str = @"select reserva.*, regimen.descripcion as regimen, estado_reserva.descripcion as estado,
                cliente.nombre, cliente.apellido, cliente.nro_identidad, tipo_identidad.nombre as tipo,
                reserva_habitacion.habitacion_id,
                habitacion.nro as hab_nro,tipo_habitacion.descripcion as hab_tipo

                from GAME_OF_QUERYS.reserva
                join GAME_OF_QUERYS.regimen on reserva.regimen_id = regimen.id
                left join GAME_OF_QUERYS.estado_reserva on reserva.estado_id = estado_reserva.id
                join GAME_OF_QUERYS.cliente on reserva.cliente_id = cliente.id
                join GAME_OF_QUERYS.tipo_identidad on cliente.tipo_identidad_id = tipo_identidad.id

                join GAME_OF_QUERYS.reserva_habitacion on reserva.id = reserva_habitacion.reserva_id
                join GAME_OF_QUERYS.habitacion on reserva_habitacion.habitacion_id = habitacion.id
                left join GAME_OF_QUERYS.tipo_habitacion on reserva_habitacion.habitacion_id = tipo_habitacion.id
                where reserva.id=@reserva ";

            SqlCommand query = new SqlCommand(query_str, connect);
            string q = query.CommandText;
            query.Parameters.AddWithValue("reserva", textBox1.Text);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            if (objReader.HasRows)
            {
                reserva = new Reserva();
                List<Habitacion> habs = new List<Habitacion>();
                

                reserva.Id = (int)objReader["id"];
                reserva.Cliente = new Cliente();
                reserva.Cliente.nombre = objReader["nombre"] as string;
                reserva.Cliente.apellido = objReader["apellido"] as string; ;

                
                /*this.username = objReader["username"] as string;
                this.tel = objReader["tel"] as int?;
                this.fecha_nac = objReader["fecha_nac"] as DateTime?;
                this.estado = (bool)objReader["estado"];
                this.nro_identidad = objReader["nro_identidad"] as long?;

                if (objReader["tipo_identidad_id"] != DBNull.Value)
                {
                    this.tipo_identidad = new TipoIdentidad();
                    this.tipo_identidad.id = (int)objReader["tipo_identidad_id"];
                }
                else
                    this.tipo_identidad = null;*/
                
                while (objReader.Read())
                {
                    Habitacion hab = new Habitacion();
                    hab.Id = (int)objReader["habitacion_id"];
                    hab.Numero = (int)objReader["hab_nro"];

                    habs.Add(hab);                    
                }
                reserva.Habitaciones = habs;
            }
            else
            {
                return;
            }
            
            
            

            connect.Close();
                
            



        }
    }
}
