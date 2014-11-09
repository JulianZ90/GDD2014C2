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

        // alta
        public altaUsuario()
        {
            InitializeComponent();
            llenarCombo(comboBox1);
            llenarHoteles();
            llenarRoles();
            user = new Usuario();
            textBox2.ReadOnly = false;
        }

        //modificacion
        public altaUsuario(int usr_id)
        {
            InitializeComponent();
            button1.Text = "Modificar";
            llenarCombo(comboBox1);
            llenarHoteles();
            llenarRoles();
            user = new Usuario(usr_id);
            cargarConUsuario(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user.username = textBox1.Text;
            user.password = getHash(textBox2.Text);
            user.nombre = textBox3.Text;
            user.apellido = textBox4.Text;
            user.mail = textBox5.Text;
            if (textBox6.Text != "") user.tel = Int32.Parse(textBox6.Text);
            user.direccion = textBox7.Text;
            if (checkBox2.Checked) user.fecha_nac = dateTimePicker1.Value.Date;
            if (checkBox3.Checked) user.tipo_identidad = (TipoIdentidad)comboBox1.SelectedItem;
            if (textBox9.Text != "") user.nro_identidad = long.Parse(textBox9.Text);
            user.estado = checkBox1.Checked;

            user.hoteles = listBox1.SelectedItems.Cast<Hotel>().ToList();
            user.roles = listBox2.SelectedItems.Cast<Rol>().ToList();

            if (user.id<1)
            {
                // no tiene id todavia, es un alta
                user.insert();
                ((FrmPrincipal)this.MdiParent).setStatus("Usuario creado");
            }
            else
            {
                user.update();
                ((FrmPrincipal)this.Owner.MdiParent).setStatus("Usuario id="+user.id.ToString()+" modificado");
                this.Close();
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
        }

        private void llenarHoteles()
        {
            listBox1.DisplayMember = "nombre";
            listBox1.ValueMember = "id";

            List<Hotel> lista = new List<Hotel>();

            SqlCommand query = new SqlCommand("select id, nombre from GAME_OF_QUERYS.hotel", connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Hotel Item = new Hotel();
                Item.id = (int)objReader["id"];
                Item.nombre = (string)objReader["nombre"];
                lista.Add(Item);
            }

            connect.Close();
            listBox1.DataSource = lista;
        
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

            //selecciono los hoteles que tiene el user
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (u.hoteles.Exists(x => (x.id == ((Hotel)listBox1.Items[i]).id)))
                    listBox1.SetSelected(i, true);
                else
                    listBox1.SetSelected(i, false);
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
            if (Char.IsLetter(e.KeyChar)) //Al pulsar un numero
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
            if (Char.IsLetter(e.KeyChar)) //Al pulsar un numero
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
            this.dateTimePicker1.Value = DateTime.Today;
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.textBox5.Text = string.Empty;
            this.textBox6.Text = string.Empty;
            this.textBox7.Text = string.Empty;
            this.textBox9.Text = string.Empty;
            this.comboBox1.SelectedValue = 0;
            this.checkBox1.Checked = true;
            this.checkBox2.Checked = true;
            this.checkBox3.Checked = true;
        }
    }
}
