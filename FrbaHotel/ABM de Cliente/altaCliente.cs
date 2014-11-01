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
        
        //alta
        public altaCliente()
        {
            InitializeComponent();
            llenarTipoDoc();
            llenarPais();
            cliente = new Cliente();
        }

        //modificacion
        public altaCliente(int cliente_id)
        {
            InitializeComponent();
            llenarTipoDoc();
            llenarPais();
            cliente = new Cliente(cliente_id);
            cargarConCliente(cliente);
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
            cliente.depto = textBox7.Text[0];
            cliente.ciudad = textBox8.Text;
            cliente.nacionalidad = textBox10.Text;
            if (checkBox4.Checked) cliente.pais = (Pais)comboBox2.SelectedItem;
            cliente.permitido_ingreso = checkBox1.Checked;

            if (cliente.id < 1)
            {
                // no tiene id todavia, es un alta
                cliente.insert();
                ((FrmPrincipal)this.MdiParent).setStatus("Cliente creado");
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
    }
}
