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
        SqlDataReader objReader = null;

        public FrmListados()
        {
            InitializeComponent();
            this.ComboListados();
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
            if (txtBxYear.Text == string.Empty)
            {
                MessageBox.Show("Ingrese el año deseado");
            }
            else
            {
                int index = ((KeyValuePair<int, string>)cmbBxListados.SelectedItem).Key;
                //falta esto
                switch (index)
                {
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                }
            }
        }
    }
}
