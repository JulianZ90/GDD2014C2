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
            llenarRegimenes();
            hotel = new Hotel();
        }

        public altaHotel(int id)
        {
            InitializeComponent();
            button1.Text = "Modificar";
            llenarComboPais();
            llenarRegimenes();
            hotel = new Hotel(id);
            cargarConHotel(hotel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hotel.nombre = textBox1.Text;
            hotel.calle = textBox2.Text;
            if (textBox3.Text != "") hotel.nro_calle = Int32.Parse(textBox3.Text);
            hotel.ciudad = textBox4.Text;
            if (checkBox3.Checked) hotel.pais = (Pais)comboBox1.SelectedItem;
            if (textBox6.Text != "") hotel.tel = Int32.Parse(textBox6.Text);
            hotel.mail = textBox7.Text;
            if (checkBox2.Checked) hotel.fecha_creacion = dateTimePicker1.Value.Date;
            if (textBox8.Text != "") hotel.cantidad_estrella = Int32.Parse(textBox8.Text);
            if (textBox5.Text != "") hotel.recarga_estrella = Int32.Parse(textBox5.Text);

            hotel.regimenes = listBox1.SelectedItems.Cast<Regimen>().ToList();

            if (hotel.id < 1)
            {
                // no tiene id todavia, es un alta
                hotel.insert();
                ((FrmPrincipal)this.MdiParent).setStatus("Hotel creado");
            }
            else
            {
                hotel.update();
                ((FrmPrincipal)this.Owner.MdiParent).setStatus("Hotel id=" + hotel.id.ToString() + " modificado");
                this.Close();
            }
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

        private void llenarRegimenes()
        {
            listBox1.DisplayMember = "descripcion";
            listBox1.ValueMember = "id";

            List<Regimen> lista = new List<Regimen>();

            SqlCommand query = new SqlCommand("select * from GAME_OF_QUERYS.regimen where estado=1", connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Regimen Item = new Regimen();
                Item.id = (int)objReader["id"];
                Item.descripcion = (string)objReader["descripcion"];
                lista.Add(Item);
            }

            connect.Close();
            listBox1.DataSource = lista;

        }

        private void cargarConHotel(Hotel h)
        {
            textBox1.Text = h.nombre;
            textBox2.Text = h.calle;
            textBox3.Text = h.nro_calle.ToString();
            textBox4.Text = h.ciudad;

            if (h.pais!= null)
            {
                comboBox1.Enabled = true;
                checkBox3.Checked = true;
                comboBox1.SelectedItem = h.pais;
            }
            else
            {
                comboBox1.Enabled = false;
                checkBox3.Checked = false;
            }

            textBox6.Text = h.tel.ToString();
            textBox7.Text = h.mail;

            if (h.fecha_creacion!= null)
            {
                dateTimePicker1.Enabled = true;
                checkBox2.Checked = true;
                dateTimePicker1.Value = (DateTime)h.fecha_creacion;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                checkBox2.Checked = false;
            }

            textBox8.Text = h.cantidad_estrella.ToString();
            textBox5.Text = h.recarga_estrella.ToString();

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (h.regimenes.Exists(x => (x.id == ((Regimen)listBox1.Items[i]).id)))
                    listBox1.SetSelected(i, true);
                else
                    listBox1.SetSelected(i, false);
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) //Al pulsar un numero o coma o punto 
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) //Al pulsar un numero o coma o punto 
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) //Al pulsar un numero o coma o punto 
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) //Al pulsar un numero o coma o punto 
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) //Al pulsar un numero o coma o punto 
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) //Al pulsar un numero o coma o punto 
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) //Al pulsar un numero o coma o punto 
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.textBox5.Text = string.Empty;
            this.textBox6.Text = string.Empty;
            this.textBox7.Text = string.Empty;
            this.textBox8.Text = string.Empty;
            this.checkBox2.Checked = true;
            this.checkBox3.Checked = true;
            this.dateTimePicker1.Value = DateTime.Today;
            this.comboBox1.SelectedValue = 0;
        }
    }
}
