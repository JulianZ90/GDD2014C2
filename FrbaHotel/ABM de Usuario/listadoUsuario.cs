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
            SqlDataAdapter dataadapter = new SqlDataAdapter("select * from GAME_OF_QUERYS.usuario", connect);
            DataSet ds = new DataSet();
            connect.Open();
            dataadapter.Fill(ds, "USUARIOS");
            connect.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "USUARIOS";

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
