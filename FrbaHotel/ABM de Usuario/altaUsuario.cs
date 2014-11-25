using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Configuration;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class altaUsuario : Form
    {
        Usuario user = null;
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        LoginId Log = null;
        bool AsignarRol = false;

        // alta
        public altaUsuario(LoginId Login)
        {
            InitializeComponent();
            llenarCombo(comboBox1);
            llenarRoles();
            user = new Usuario();
            Log = Login;
            textBox2.ReadOnly = false;
            textBox8.ReadOnly = true;
            SqlCommand query = new SqlCommand("SELECT nombre FROM GAME_OF_QUERYS.hotel WHERE id = @hotelId", connect);
            query.Parameters.AddWithValue("@hotelId", Log.Hotel_Id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();
            if (objReader.Read())
            {
                textBox8.Text = (string)objReader["nombre"];
            }
            connect.Close();
            Hotel HotelUser = new Hotel();
            HotelUser.id = Login.Hotel_Id;
            HotelUser.nombre = textBox8.Text;
            user.hotel = HotelUser;
        }

        //modificacion
        public altaUsuario(int usr_id, LoginId Login)
        {
            InitializeComponent();
            button1.Text = "Modificar";
            llenarCombo(comboBox1);
            llenarRoles();
            Log = Login;
            user = new Usuario(usr_id, Log.Hotel_Id);
            textBox8.ReadOnly = true;
            SqlCommand query = new SqlCommand("SELECT nombre FROM GAME_OF_QUERYS.hotel WHERE id = @hotelId", connect);
            query.Parameters.AddWithValue("@hotelId", Log.Hotel_Id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();
            if (objReader.Read())
            {
                textBox8.Text = (string)objReader["nombre"];
            }
            connect.Close();
            Hotel HotelUser = new Hotel();
            HotelUser.id = Login.Hotel_Id;
            HotelUser.nombre = textBox8.Text;
            user.hotel = HotelUser;
            cargarConUsuario(user);
        }

        //asignar rol a un usuario que ya trabaja en otro hotel
        public altaUsuario(int usr_id, LoginId Login, bool Existente)
        {
            InitializeComponent();
            button1.Text = "Asignar roles a un usuario de otro hotel de la cadena";
            llenarCombo(comboBox1);
            llenarRoles();
            Log = Login;
            AsignarRol = true;
            user = new Usuario(usr_id, Log.Hotel_Id);
            SqlCommand query = new SqlCommand("SELECT nombre FROM GAME_OF_QUERYS.hotel WHERE id = @hotelId", connect);
            query.Parameters.AddWithValue("@hotelId", Log.Hotel_Id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();
            if (objReader.Read())
            {
                textBox8.Text = (string)objReader["nombre"];
            }
            connect.Close();
            Hotel HotelUser = new Hotel();
            HotelUser.id = Login.Hotel_Id;
            HotelUser.nombre = textBox8.Text;
            user.hotel = HotelUser;
            cargarConUsuario(user);
            textBox1.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            dateTimePicker1.Enabled = false;
            checkBox2.Enabled = false;
            comboBox1.Enabled = false;
            checkBox3.Enabled = false;
            checkBox1.Enabled = false;
            MessageBox.Show("Desde aqui solo podra asignar roles a este usuario. Si desea modificar cualquiera de sus campos debera buscarlo en 'Usuarios de este hotel' una vez asignados sus roles");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                user.username = textBox1.Text;
            else
            {
                MessageBox.Show("Campos obligatorios incompletos");
                return;
            }

            if(textBox2.Text != "")
                user.password = getHash(textBox2.Text);
            else
            {
                MessageBox.Show("Campos obligatorios incompletos");
                return;
            }

            user.nombre = textBox3.Text;
            user.apellido = textBox4.Text;
            user.mail = textBox5.Text;
            if (textBox6.Text != "") user.tel = long.Parse(textBox6.Text);
            user.direccion = textBox7.Text;
            if (checkBox2.Checked) user.fecha_nac = dateTimePicker1.Value.Date;
            if (checkBox3.Checked) user.tipo_identidad = (TipoIdentidad)comboBox1.SelectedItem;
            if (textBox9.Text != "") user.nro_identidad = long.Parse(textBox9.Text);
            user.estado = checkBox1.Checked;

            user.roles = listBox2.SelectedItems.Cast<Rol>().ToList();

            if (user.roles.Count == 0)
            {
                MessageBox.Show("Debe asignar al menos un rol");
                return;
            }

            if (user.id<1)
            {
                // no tiene id todavia, es un alta
                user.insert();
                button1.Enabled = false;
            }
            else
            {
                if (!AsignarRol)
                {
                    user.update();
                }
                else
                {
                    user.asignarRoles();
                }
            }
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
                Item.id = (int)objReader["id"];
                Item.nombre = (string)objReader["nombre"];
                lista.Add(Item);
            }

            connect.Close();
            combo.DataSource = lista;

            combo.SelectedIndex = 0;
        }

 
        private void llenarRoles()
        {
            listBox2.DisplayMember = "Descripcion";
            listBox2.ValueMember = "Id";

            List<Rol> lista = new List<Rol>();

            SqlCommand query = new SqlCommand("select id, descripcion from GAME_OF_QUERYS.rol", connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                if((string)objReader["descripcion"] != "Guest" && (string)objReader["descripcion"] != "admin")
                {
                    Rol Item = new Rol();
                    Item.Id = (int)objReader["id"];
                    Item.Descripcion = (string)objReader["descripcion"];

                    lista.Add(Item);
                }
            }

            connect.Close();
            listBox2.DataSource = lista;
        }

        private void cargarConUsuario(Usuario u)
        {
            textBox1.Text = u.username;
            textBox2.Text = u.password;
            textBox3.Text = u.nombre;
            textBox4.Text = u.apellido;
            textBox5.Text = u.mail;
            textBox6.Text = u.tel.ToString();
            textBox7.Text = u.direccion;
            textBox9.Text = u.nro_identidad.ToString();
            checkBox1.Checked = u.estado;

            if (u.fecha_nac != null)
            {
                dateTimePicker1.Enabled = true;
                checkBox2.Checked = true;
                dateTimePicker1.Value = (DateTime)u.fecha_nac;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                checkBox2.Checked = false;
            }


            //dni
            if (u.tipo_identidad != null)
            {
                comboBox1.Enabled = true;
                checkBox3.Checked = true;
                comboBox1.SelectedItem = u.tipo_identidad;
            }
            else
            {
                comboBox1.Enabled = false;
                checkBox3.Checked = false;
            }

            // selecciono los roles que tiene el user
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (u.roles.Exists(x => (x.Id == ((Rol)listBox2.Items[i]).Id)))
                    listBox2.SetSelected(i, true);
                else
                    listBox2.SetSelected(i, false);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                dateTimePicker1.Enabled = true;
            else
                dateTimePicker1.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                comboBox1.Enabled = true;
            else
                comboBox1.Enabled = false;
        }

        private string getHash(string pass)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(pass));
                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | (e.KeyChar == ' ')) //Al pulsar una letra o espacio
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
            if (Char.IsLetter(e.KeyChar) | (e.KeyChar == ' ')) //Al pulsar una letra o espacio
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
            if (Char.IsDigit(e.KeyChar)) //Al pulsar un numero
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
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) //Al pulsar un numero
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
            this.dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.textBox5.Text = string.Empty;
            this.textBox6.Text = string.Empty;
            this.textBox7.Text = string.Empty;
            this.textBox9.Text = string.Empty;
            this.comboBox1.SelectedIndex = 0;
            this.checkBox1.Checked = true;
            this.checkBox2.Checked = true;
            this.checkBox3.Checked = true;
            button1.Enabled = true;
        }

        private void altaUsuario_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
        }
    }
}
