using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class altaHotel : Form
    {
        Hotel hotel = null;
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");

        public altaHotel()
        {
            InitializeComponent();
            llenarComboPais();
        }

        public altaHotel(int id) {
            llenarComboPais();
            hotel = new Hotel(id);
            //cargarConHotel(hotel);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void llenarComboPais()
        {
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";

            List<Pais> lista = new List<Pais>();

            SqlCommand query = new SqlCommand("select * from GAME_OF_QUERYS.pais", connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Pais Item = new Pais();
                Item.id = (int)objReader["id"];
                Item.nombre = (string)objReader["nombre"];
                lista.Add(Item);
            }

            connect.Close();
            comboBox1.DataSource = lista;
        }

       // public void cargarConHotel(Hotel h)
        //{ }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                comboBox1.Enabled = true;
            else
                comboBox1.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                dateTimePicker1.Enabled = true;
            else
                dateTimePicker1.Enabled = false;
        }
    }
}
