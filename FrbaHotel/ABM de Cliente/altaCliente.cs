using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class altaCliente : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        Cliente cliente;
        Reserva Reserva;
        bool reserva = false;
        
        //alta
        public altaCliente()
        {
            InitializeComponent();
            llenarTipoDoc();
            llenarPais();
            cliente = new Cliente();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        //modificacion
        public altaCliente(int cliente_id)
        {
            InitializeComponent();
            button1.Text = "Modificar";
            llenarTipoDoc();
            llenarPais();
            cliente = new Cliente(cliente_id);
            cargarConCliente(cliente);
            this.StartPosition = FormStartPosition.CenterParent;

        }

        //alta de un cliente para una reserva
        public altaCliente(Reserva NuevaReserva)
        {
            InitializeComponent();
            llenarTipoDoc();
            llenarPais();
            cliente = new Cliente();
            Reserva = NuevaReserva;
            reserva = true;
            this.StartPosition = FormStartPosition.CenterParent;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked) cliente.tipo_identidad = (TipoIdentidad)comboBox1.SelectedItem;
            if (textBox9.Text != "") cliente.nro_identidad = long.Parse(textBox9.Text);
            cliente.apellido = textBox1.Text;
            cliente.nombre = textBox2.Text;
            if (checkBox2.Checked) cliente.fecha_nac = dateTimePicker1.Value.Date;
            cliente.mail = textBox3.Text;
            if (textBox4.Text != "") cliente.tel = Int32.Parse(textBox4.Text);
            cliente.calle = textBox5.Text;
            if (textBox6.Text != "") cliente.nro_calle = Int32.Parse(textBox6.Text);
            if (textBox11.Text != "") cliente.piso = Int32.Parse(textBox11.Text);
            if (textBox7.Text != "") cliente.depto = textBox7.Text[0];
            cliente.ciudad = textBox8.Text;
            cliente.nacionalidad = textBox10.Text;
            if (checkBox4.Checked) cliente.pais = (Pais)comboBox2.SelectedItem;
            cliente.permitido_ingreso = checkBox1.Checked;

            if (cliente.id < 1)
            {
                // no tiene id todavia, es un alta
                if (reserva)
                {
                    int cliente_id = cliente.insert(reserva);   //me devuelve el id del cliente que inserte
                    SqlCommand query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.reserva(hotel_id, cliente_id, regimen_id, estado_id, fecha_realizacion, fecha_inicio, fecha_fin, usuario_ultima_modif_id) VALUES (@hotel, @cliente, @regimen, @estado, @fechaHoy, @fechaInicio, @fechaFin, @usuario); SELECT SCOPE_IDENTITY()", connect);
                    query.Parameters.AddWithValue("@hotel", Reserva.hotel.id);
                    query.Parameters.AddWithValue("@cliente", cliente_id);
                    query.Parameters.AddWithValue("@regimen", Reserva.Regimen.id);
                    query.Parameters.AddWithValue("@estado", Reserva.Estado.Id);
                    query.Parameters.AddWithValue("@fechaHoy", Reserva.FechaRealizacion);
                    query.Parameters.AddWithValue("@fechaInicio", Reserva.FechaInicio);
                    query.Parameters.AddWithValue("@fechaFin", Reserva.FechaFin);
                    query.Parameters.AddWithValue("@usuario", Reserva.UltimoUsuario.id);

                    connect.Open();
                    int reserva_id = Convert.ToInt32(query.ExecuteScalar());    //me devuelve el id de la reserva que se inserto
                    connect.Close();
                    //agrego las habitaciones a reserva_habitacion
                    foreach (Habitacion Item in Reserva.Habitaciones)
                    {
                        query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.reserva_habitacion(reserva_id, habitacion_id) VALUES (@reserva, @habitacion)", connect);
                        query.Parameters.AddWithValue("@reserva", reserva_id);
                        query.Parameters.AddWithValue("@habitacion", Item.Id);
                        connect.Open();
                        query.ExecuteNonQuery();
                        connect.Close();
                    }
                    MessageBox.Show("Su código de reserva es: " + reserva_id + ". Recuerde que necesitará este código para modificar o cancelar su reserva.");
                    this.Close();
                }
                else
                {
                    cliente.insert();
                    ((FrmPrincipal)this.MdiParent).setStatus("Cliente creado");
                }
            }
            else
            {
                cliente.update();
                ((FrmPrincipal)this.Owner.MdiParent).setStatus("Cliente id=" + cliente.id.ToString() + " modificado");
                this.Close();
            }

        }

        private void cargarConCliente(Cliente c)
        {
            textBox9.Text = c.nro_identidad.ToString();
            textBox1.Text = c.apellido;
            textBox2.Text = c.nombre;

            if (c.fecha_nac != null)
            {
                dateTimePicker1.Enabled = true;
                checkBox2.Checked = true;
                dateTimePicker1.Value = (DateTime)c.fecha_nac;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                checkBox2.Checked = false;
            }

            textBox3.Text = c.mail;
            textBox4.Text = c.tel.ToString();
            textBox5.Text = c.calle;
            textBox6.Text = c.nro_calle.ToString();
            textBox11.Text = c.piso.ToString();
            textBox7.Text = c.depto.ToString();
            textBox8.Text = c.ciudad;
            textBox10.Text = c.nacionalidad;
            checkBox1.Checked = c.permitido_ingreso;

            //dni
            if (c.tipo_identidad != null)
            {
                comboBox1.Enabled = true;
                checkBox3.Checked = true;
                comboBox1.SelectedItem = c.tipo_identidad;
            }
            else
            {
                comboBox1.Enabled = false;
                checkBox3.Checked = false;
            }

            //pais
            if (c.pais != null)
            {
                comboBox2.Enabled = true;
                checkBox4.Checked = true;
                comboBox2.SelectedItem = c.pais;
            }
            else
            {
                comboBox2.Enabled = false;
                checkBox4.Checked = false;
            }
        }

        private void llenarTipoDoc()
        {
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";

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
            comboBox1.DataSource = lista;
        }

        private void llenarPais()
        {
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "id";

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
            comboBox2.DataSource = lista;
        }

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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                comboBox2.Enabled = true;
            else
                comboBox2.Enabled = false;
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
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
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
            this.textBox9.Text = string.Empty;
            this.textBox10.Text = string.Empty;
            this.textBox11.Text = string.Empty;
            this.checkBox1.Checked = true;
            this.checkBox2.Checked = true;
            this.checkBox3.Checked = true;
            this.checkBox4.Checked = true;
            this.dateTimePicker1.Value = DateTime.Today;
            this.comboBox1.SelectedValue = 0;
            this.comboBox2.SelectedValue = 0;
        }
    }
}
