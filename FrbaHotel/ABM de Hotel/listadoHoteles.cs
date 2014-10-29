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
    public partial class listadoHoteles : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");

        public listadoHoteles()
        {
            InitializeComponent();
            llenarComboPais();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            // Add a button column ALTA. 
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "M";
            buttonColumn.Name = "mODIFICAR";
            buttonColumn.Text = "";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Width = 20;
            dataGridView1.Columns.Add(buttonColumn);

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
                query.Append("and hotel.telefono like '%" + textBox6.Text + "%'");

            if (textBox7.Text != "")
                query.Append("and hotel.cantidad_estrella like '%" + textBox7.Text + "%'");

            if (textBox5.Text != "")
                query.Append("and hotel.recarga_estrella like '%" + textBox5.Text + "%'");

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
                hotel.nro_calle = objReader["nombre"] as int?;
                hotel.ciudad = objReader["ciudad"] as string;
                hotel.tel = objReader["tel"] as int?;
                hotel.cantidad_estrella = objReader["cantidad_estrella"] as int?;
                hotel.recarga_estrella = objReader["recarga_estrella"] as int?;
                hotel.fecha_creacion = objReader["fecha_creacion"] as DateTime?;

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
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["mODIFICAR"].Index)
                return;

            // Retrieve the hotel_id object from the "id" cell.
            int hotel_id = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

            if (e.ColumnIndex == dataGridView1.Columns["mODIFICAR"].Index)
            {
                ABM_de_Hotel.altaHotel modif = new ABM_de_Hotel.altaHotel(hotel_id);
                modif.Owner = this;
                modif.ShowDialog();
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
    }
}
