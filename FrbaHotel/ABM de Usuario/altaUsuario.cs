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
    public partial class altaUsuario : Form
    {
       
        
        public altaUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
            SqlCommand query = new SqlCommand("insert into GAME_OF_QUERYS.usuarios (username, password, nombre, apellido, mail, tel , dir, fec_nac, estado, dni) values (@username, @password, @nombre, @apellido, @mail, @tel , @dir, @fec_nac, @estado, @dni)", connect);
            query.Parameters.AddWithValue("username", textBox1.Text);
            query.Parameters.AddWithValue("password", textBox2.Text);
            query.Parameters.AddWithValue("nombre", textBox3.Text);
            query.Parameters.AddWithValue("apellido", textBox4.Text);
            query.Parameters.AddWithValue("mail", textBox5.Text);
            query.Parameters.AddWithValue("tel", textBox6.Text);
            query.Parameters.AddWithValue("dir", textBox7.Text);
            query.Parameters.AddWithValue("fec_nac", dateTimePicker1.Value.Date);
            query.Parameters.AddWithValue("estado", checkBox1.Checked);
            //query.Parameters.AddWithValue("tipo_doc", comboBox1.SelectedValue);
            query.Parameters.AddWithValue("dni", textBox9.Text);

            connect.Open();
            query.ExecuteNonQuery();
            connect.Close();
        }
    }
}
