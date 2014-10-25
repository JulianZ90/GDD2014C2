using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class listadoUsuario : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");

        public listadoUsuario()
        {
            InitializeComponent();
            SqlDataAdapter dataadapter = new SqlDataAdapter("select usuario.*, tipo_identidad.nombre as tipo from GAME_OF_QUERYS.usuario left join GAME_OF_QUERYS.tipo_identidad on tipo_identidad.id = usuario.id", connect);
            DataSet ds = new DataSet();
            connect.Open();
            dataadapter.Fill(ds, "USUARIOS");
            connect.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "USUARIOS";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Usuario> lista = new List<Usuario>();

            SqlCommand query = new SqlCommand("select usuario.*, tipo_identidad.nombre as tipo from GAME_OF_QUERYS.usuario left join GAME_OF_QUERYS.tipo_identidad on tipo_identidad.id = usuario.id", connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Usuario user = new Usuario();
                user.id = (int)objReader["id"];
                user.username = (string)objReader["username"];
                user.password = (string)objReader["password"];
                user.nombre = (string)objReader["nombre"];
                user.apellido = (string)objReader["apellido"];
                user.mail= (string)objReader["mail"];
                user.tel = (int)objReader["tel"];
                user.direccion = (string)objReader["direccion"];
                user.fecha_nac = (DateTime)objReader["fecha_nac"];
                user.estado= (bool)objReader["estado"];
                user.nro_identidad = (int)objReader["nro_identidad"];

                TipoIdentidad tipo = new TipoIdentidad();
                tipo.nombre = (string)objReader["tipo"];
                user.tipo_identidad = tipo;

                lista.Add(user);
            }

            connect.Close();
            dataGridView1.DataSource = lista; 
        }
    }
}
