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
    public partial class listadoHoteles : Form
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);

        public listadoHoteles()
        {
            InitializeComponent();
            llenarComboPais();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            // Add a button column MODIFICAR. 
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "M";
            buttonColumn.Name = "mODIFICAR";
            buttonColumn.Text = "";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Width = 20;
            dataGridView1.Columns.Add(buttonColumn);

            // Add a button column BAJA. 
            DataGridViewButtonColumn btnbaja = new DataGridViewButtonColumn();
            btnbaja.HeaderText = "B";
            btnbaja.Name = "bAJA";
            btnbaja.Text = "";
            btnbaja.UseColumnTextForButtonValue = true;
            btnbaja.Width = 20;
            dataGridView1.Columns.Add(btnbaja);

            // Add a CellClick handler to handle clicks in the button column.
            //no se puede borrar todos los handlers asociados. Asi que trato de quitar el handler viejo aunque no este.
            dataGridView1.CellClick -= new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            List<Hotel> lista = new List<Hotel>();

            StringBuilder query = new StringBuilder();
            query.Append("select distinct hotel.*, pais.nombre as pais from GAME_OF_QUERYS.hotel ");
            query.Append(" left join GAME_OF_QUERYS.pais on pais.id = hotel.pais_id ");
            query.Append(" where 1=1 ");

            if (textBox1.Text != "")
                query.Append("and hotel.nombre like '%" + textBox1.Text + "%'");
            
            if (textBox2.Text != "")
                query.Append("and hotel.calle like '%" + textBox2.Text + "%'");
            
            if (textBox3.Text != "")
                query.Append("and hotel.nro_calle like '%" + textBox3.Text + "%'");
            
            if (textBox4.Text != "")
                query.Append("and hotel.ciudad like '%" + textBox4.Text + "%'");

            if (textBox6.Text != "")
                query.Append("and hotel.tel like '%" + textBox6.Text + "%'");

            if (textBox7.Text != "")
                query.Append("and hotel.cantidad_estrella like '%" + textBox7.Text + "%'");

            if (textBox5.Text != "")
                query.Append("and hotel.recarga_estrella like '%" + textBox5.Text + "%'");

            if (textBox8.Text != "")
                query.Append("and hotel.mail like '%" + textBox8.Text + "%'");

            if (checkBox2.Checked)
                query.Append("and hotel.fecha_creacion = '" + dateTimePicker1.Value.Date + "'");

            if (checkBox3.Checked)
                query.Append("and hotel.pais_id = '" + ((Pais)comboBox1.SelectedItem).id +"'");


            SqlCommand objComando = new SqlCommand(query.ToString(), connect);
            connect.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                Hotel hotel = new Hotel();
                hotel.id = (int)objReader["id"];
                hotel.nombre = objReader["nombre"] as string;
                hotel.calle = objReader["calle"] as string;
                hotel.nro_calle = objReader["nro_calle"] as int?;
                hotel.ciudad = objReader["ciudad"] as string;
                hotel.tel = objReader["tel"] as int?;
                hotel.cantidad_estrella = (int)objReader["cantidad_estrella"];
                hotel.recarga_estrella = (int) objReader["recarga_estrella"];
                hotel.fecha_creacion = objReader["fecha_creacion"] as DateTime?;
                hotel.mail = objReader["mail"] as string;

                Pais pais = new Pais();
                pais.nombre = objReader["pais"] as string;
                hotel.pais = pais;

                lista.Add(hotel);
            }
            connect.Close();
            dataGridView1.DataSource = lista;    
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 || 
                ( e.ColumnIndex != dataGridView1.Columns["mODIFICAR"].Index && 
                e.ColumnIndex != dataGridView1.Columns["bAJA"].Index )
                )
                return;

            // Retrieve the hotel_id object from the "id" cell.
            int hotel_id = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

            if (e.ColumnIndex == dataGridView1.Columns["mODIFICAR"].Index)
            {
                ABM_de_Hotel.altaHotel modif = new ABM_de_Hotel.altaHotel(hotel_id);
                modif.Owner = this;
                modif.ShowDialog();
            }
            if (e.ColumnIndex == dataGridView1.Columns["bAJA"].Index)
            {
                ABM_de_Hotel.frmMantenimiento frmMante = new ABM_de_Hotel.frmMantenimiento(hotel_id);
                frmMante.Owner = this;
                frmMante.ShowDialog();
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

        private void llenarComboPais()
        {
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";

            List<Pais> lista = new List<Pais>();

            SqlCommand query = new SqlCommand("select id, nombre from GAME_OF_QUERYS.pais", connect);

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
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.textBox5.Text = string.Empty;
            this.textBox6.Text = string.Empty;
            this.textBox7.Text = string.Empty;
            this.textBox8.Text = string.Empty;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
            this.dateTimePicker1.Value = DateTime.Today;
            this.dataGridView1.Columns.Clear();
            this.comboBox1.SelectedValue = 0;
        }
    }
}
