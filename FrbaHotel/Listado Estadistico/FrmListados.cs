using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class FrmListados : Form
    {
        SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        SqlCommand query = null;

        public FrmListados()
        {
            InitializeComponent();
            this.ComboListados();
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
        }

        private void txtBxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo ingresar números");
            }
        }

        public void ComboListados()
        {
            Dictionary<int, string> listados = new Dictionary<int, string>();
            listados.Add(1, "Hoteles con mayor cantidad de reservas canceladas");
            listados.Add(2, "Hoteles con mayor cantidad de consumibles facturados");
            listados.Add(3, "Hoteles con mayor cantidad de días fuera de servicio");
            listados.Add(4, "Habitaciones con mayor cantidad de días que fueron ocupadas");
            listados.Add(5, "Clientes con mayor cantidad de puntos");

            this.cmbBxListados.DataSource = new BindingSource(listados, null);
            this.cmbBxListados.DisplayMember = "Value";
            this.cmbBxListados.ValueMember = "Key";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();
            this.txtBxYear.Text = string.Empty;
            this.numUpDownTrim.Value = 1;
            this.cmbBxListados.SelectedValue = 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();

            if (txtBxYear.Text == string.Empty)
            {
                MessageBox.Show("Ingrese el año deseado");
            }
            else
            {
                int year = Convert.ToInt32(this.txtBxYear.Text);
                int trimInicio = 0;
                int trimFin = 0;

                switch ((int)this.numUpDownTrim.Value)
                {
                    case 1:
                        {
                            trimInicio = 1;
                            trimFin = 4;
                            break;
                        }
                    case 2:
                        {
                            trimInicio = 5;
                            trimFin = 8;
                            break;
                        }
                    case 3:
                        {
                            trimInicio = 9;
                            trimFin = 12;
                            break;
                        }
                }

                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                int index = ((KeyValuePair<int, string>)cmbBxListados.SelectedItem).Key;
                //falta esto
                switch (index)
                {
                    case 1:
                        {
                            query = new SqlCommand("GAME_OF_QUERYS.mayoresCancelaciones", objConexion);
                            break;
                        }
                    case 2:
                        {
                            query = new SqlCommand("GAME_OF_QUERYS.mayoresConsumibles", objConexion);
                            break;
                        }
                    case 3:
                        {
                            query = new SqlCommand("GAME_OF_QUERYS.mayoresMantenimiento", objConexion);
                            break;
                        }
                    case 4:
                        {
                            query = new SqlCommand("GAME_OF_QUERYS.habitacionesOcupadas", objConexion);
                            break;
                        }
                    case 5:
                        {
                            query = new SqlCommand("GAME_OF_QUERYS.puntosCliente", objConexion);
                            break;
                        }
                }

                query.Parameters.AddWithValue("@year", year);
                query.Parameters.AddWithValue("@trimestreInicio", trimInicio);
                query.Parameters.AddWithValue("@trimestreFin", trimFin);
                query.CommandType = CommandType.StoredProcedure;

                objConexion.Open();
                da.SelectCommand = query;
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                objConexion.Close();
            }
        }
    }
}
