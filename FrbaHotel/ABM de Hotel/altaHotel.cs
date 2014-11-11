using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace FrbaHotel.ABM_de_Hotel
{
    public partial class altaHotel : Form
    {
        Hotel hotel = null;
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        LoginId Log = null;

        public altaHotel(LoginId Login)
        {
            InitializeComponent();
            llenarComboPais();
            llenarRegimenes();
            hotel = new Hotel();
            Log = Login;
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
            if (textBox1.Text != "")
                hotel.nombre = textBox1.Text;
            else 
            {
                MessageBox.Show("Campos obligatorios incompletos");
                return;
            }

            if(textBox2.Text !="")
                hotel.calle = textBox2.Text;
            else
            {
                MessageBox.Show("Campos obligatorios incompletos");
                return;
            }

            if (textBox3.Text != "") hotel.nro_calle = Int32.Parse(textBox3.Text);
            else
            {
                MessageBox.Show("Campos obligatorios incompletos");
                return;
            }

            if(textBox4.Text!="")
            hotel.ciudad = textBox4.Text;
            else
            {
                MessageBox.Show("Campos obligatorios incompletos");
                return;
            } 
            
            hotel.pais = (Pais)comboBox1.SelectedItem;
            if (textBox6.Text != "") hotel.tel = long.Parse(textBox6.Text);
            hotel.mail = textBox7.Text;
            hotel.fecha_creacion = dateTimePicker1.Value.Date;
            if (textBox8.Text != "") hotel.cantidad_estrella = Int32.Parse(textBox8.Text);
            else
            {
                MessageBox.Show("Campos obligatorios incompletos");
                return;
            }

            if (textBox5.Text != "") hotel.recarga_estrella = Int32.Parse(textBox5.Text);
            else
            {
                MessageBox.Show("Campos obligatorios incompletos");
                return;
            }

            hotel.regimenes = listBox1.SelectedItems.Cast<Regimen>().ToList();

            if (hotel.regimenes.Count == 0)
            {
                MessageBox.Show("Tiene que asignar al menos un regimen");
                return;
            }

            if (!hotel.regimenesEnUso())
            {
                MessageBox.Show("Modificacion no permitida. Un regimen que desea eliminar se necesita para una futura reserva.");
                return;
            }


            if (hotel.id < 1)
            {
                // no tiene id todavia, es un alta
                hotel.insert(Log);
                MessageBox.Show("Hotel creado");
                button1.Enabled = false;
                return;
            }
            else
            {
                hotel.update();
                MessageBox.Show("Hotel id=" + hotel.id.ToString() + " modificado");
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

            comboBox1.SelectedIndex = 0;
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
            listBox1.SelectedIndex = -1;

        }

        private void cargarConHotel(Hotel h)
        {
            textBox1.Text = h.nombre;
            textBox2.Text = h.calle;
            textBox3.Text = h.nro_calle.ToString();
            textBox4.Text = h.ciudad;
            comboBox1.SelectedItem = h.pais;
            textBox6.Text = h.tel.ToString();
            textBox7.Text = h.mail;
            
            if(h.fecha_creacion != null)
                dateTimePicker1.Value = (DateTime)h.fecha_creacion;
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
            this.dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
            this.comboBox1.SelectedIndex = 0;
            button1.Enabled = true;
        }

        private void altaHotel_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
        }
    }
}
