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
       
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");

        public altaUsuario()
        {
            InitializeComponent();
            llenarCombo(comboBox1);
            llenarCombo(comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usr = new Usuario();
            usr.username = textBox1.Text;
            usr.password = textBox2.Text;
            usr.nombre = textBox3.Text;
            usr.apellido = textBox4.Text;
            usr.mail = textBox5.Text;
            usr.tel = Int32.Parse(textBox6.Text);
            usr.direccion = textBox7.Text;
            usr.fecha_nac = dateTimePicker1.Value.Date;
            //usr.tipo_identidad = textBox1.Text;
            usr.nro_identidad = Int32.Parse(textBox9.Text);

            usr.guardar();           
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void llenarCombo(ComboBox combo)
        {
            combo.DisplayMember = "nombre";
            combo.ValueMember = "id";

            List<TipoIdentidad> lista = new List<TipoIdentidad>();  

            SqlCommand query = new SqlCommand("select * from GAME_OF_QUERYS.tipo_identidad", connect);
            
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                TipoIdentidad Item = new TipoIdentidad();
                Item.id = (int) objReader["id"];
                Item.nombre = (string) objReader["nombre"];
                lista.Add(Item);
            }

            connect.Close();
            combo.DataSource = lista; 
        }
    }
}
