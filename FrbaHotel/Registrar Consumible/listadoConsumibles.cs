using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class listadoConsumibles : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
		consumible consumibleSeleccionado;
        bool seleccionar = false;

        public listadoConsumibles()
        {
            InitializeComponent();
        }

        public listadoConsumibles(string s)
        {
            InitializeComponent();
            seleccionar = true;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            if (seleccionar)
            {
                // Add a button column ALTA. 
                DataGridViewButtonColumn buttonColumnSel = new DataGridViewButtonColumn();
                buttonColumnSel.HeaderText = "S";
                buttonColumnSel.Name = "sELECCIONAR";
                buttonColumnSel.Text = "Seleccionar";
                buttonColumnSel.UseColumnTextForButtonValue = true;
                buttonColumnSel.Width = 70;
                dataGridView1.Columns.Add(buttonColumnSel);
            }
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

            List<consumible> lista = new List<consumible>();

            StringBuilder query = new StringBuilder();
            query.Append("select distinct * from GAME_OF_QUERYS.consumible ");
            query.Append(" where 1=1 ");

            if (textBox9.Text != "")
                query.Append("and consumible.descripcion like '%" + textBox9.Text + "%'");
            if (textBox1.Text != "")
                query.Append("and consumible.precio like '%" + textBox1.Text + "%'");
            SqlCommand objComando = new SqlCommand(query.ToString(), connect);

            connect.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                consumible consumible = new consumible();
                consumible.id = (int)objReader["id"];
                consumible.precio = objReader["precio"] as decimal?;
                consumible.descripcion = objReader["descripcion"] as string;
              
                lista.Add(consumible);
            }
            connect.Close();
            dataGridView1.DataSource = lista;
        }
        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 ||
                    (e.ColumnIndex != dataGridView1.Columns["mODIFICAR"].Index &&
                    e.ColumnIndex != dataGridView1.Columns["sELECCIONAR"].Index)
                    )
                return;

            // Retrieve the consumible_id object from the "id" cell.
            int consumible_id = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

            if (e.ColumnIndex == dataGridView1.Columns["mODIFICAR"].Index)
            {
                Registrar_Consumible.altaConsumible modif = new Registrar_Consumible.altaConsumible(consumible_id);
                modif.Owner = this;
                modif.ShowDialog();
            }
            if (e.ColumnIndex == dataGridView1.Columns["sELECCIONAR"].Index)
            {
                consumibleSeleccionado = ((List<consumible>)dataGridView1.DataSource).ElementAt(e.RowIndex);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox9.Text = string.Empty;
            this.textBox1.Text = string.Empty;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | (e.KeyChar == ',') | (e.KeyChar == '.')) //Al pulsar un numero o coma o punto 
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

        public consumible getConsumibleSeleccionado()
        {
            return consumibleSeleccionado;
        }
    }
}
