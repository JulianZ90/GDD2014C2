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
    public partial class listadoClientes : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");

        public listadoClientes()
        {
            InitializeComponent();
            llenarTipoDoc();
            llenarPais();
        }

        private void button1_Click(object sender, EventArgs e)
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

            List<Cliente> lista = new List<Cliente>();

            StringBuilder query = new StringBuilder();
            query.Append("select distinct cliente.*, tipo_identidad.nombre as tipo, pais.nombre as pais from GAME_OF_QUERYS.cliente ");
            query.Append(" left join GAME_OF_QUERYS.tipo_identidad on tipo_identidad.id = cliente.tipo_identidad_id ");
            query.Append(" left join GAME_OF_QUERYS.pais on pais.id= cliente.id ");
            query.Append(" where 1=1 ");

            if (checkBox3.Checked)
                query.Append("and cliente.tipo_identidad_id = '" + ((TipoIdentidad)comboBox1.SelectedItem).id + "'");

            if (textBox9.Text != "")
                query.Append("and cliente.nro_identidad like '%" + textBox9.Text + "%'");
            
            if (textBox1.Text != "")
                query.Append("and cliente.apellido like '%" + textBox1.Text + "%'");

            if (textBox2.Text != "")
                query.Append("and cliente.nombre like '%" + textBox2.Text + "%'");

            if (checkBox2.Checked)
                query.Append("and cliente.fecha_nac = '" + dateTimePicker1.Value.Date + "'");
            
            if (textBox3.Text != "")
                query.Append("and cliente.mail like '%" + textBox3.Text + "%'");

            if (textBox4.Text != "")
                query.Append("and cliente.tel like '%" + textBox4.Text + "%'");

            if (textBox5.Text != "")
                query.Append("and cliente.calle like '%" + textBox1.Text + "%'");

            if (textBox6.Text != "")
                query.Append("and cliente.nro_calle like '%" + textBox6.Text + "%'");

            if (textBox11.Text != "")
                query.Append("and cliente.piso like '%" + textBox11.Text + "%'");
            
            if (textBox7.Text != "")
                query.Append("and cliente.depto like '%" + textBox7.Text + "%'");
            
            if (textBox8.Text != "")
                query.Append("and cliente.ciudad like '%" + textBox8.Text + "%'");
            
            if (textBox10.Text != "")
                query.Append("and cliente.nacionalidad like '%" + textBox10.Text + "%'");

            if (checkBox4.Checked)
                query.Append("and cliente.pais_origen_id = '" + ((Pais)comboBox2.SelectedItem).id + "'");

            SqlCommand objComando = new SqlCommand(query.ToString(), connect);

            connect.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.id = (int)objReader["id"];
                cliente.nombre = objReader["nombre"] as string;
                cliente.apellido = objReader["apellido"] as string;
                cliente.fecha_nac = objReader["fecha_nac"] as DateTime?;
                cliente.mail = objReader["mail"] as string;
                cliente.tel = objReader["tel"] as int?;
                cliente.calle = objReader["calle"] as string;
                cliente.nro_calle = objReader["nro_calle"] as int?;
                cliente.piso = objReader["piso"] as int?;
                cliente.depto = objReader["depto"].ToString()[0];
                cliente.ciudad = objReader["ciudad"] as string;
                cliente.nacionalidad = objReader["nacionalidad"] as string;
                cliente.nro_identidad = objReader["nro_identidad"] as long?; // TODO esto no anda

                TipoIdentidad tipo = new TipoIdentidad();
                tipo.nombre = objReader["tipo"] as string;
                cliente.tipo_identidad = tipo;

                lista.Add(cliente);
            }
            connect.Close();
            dataGridView1.DataSource = lista;
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["mODIFICAR"].Index)
                return;

            // Retrieve the cliente_id object from the "id" cell.
            int cliente_id = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

            if (e.ColumnIndex == dataGridView1.Columns["mODIFICAR"].Index)
            {
                ABM_de_Cliente.altaCliente modif = new ABM_de_Cliente.altaCliente(cliente_id);
                modif.Owner = this;
                modif.ShowDialog();
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                comboBox2.Enabled = true;
            else
                comboBox2.Enabled = false;
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

        



        
    }
}
