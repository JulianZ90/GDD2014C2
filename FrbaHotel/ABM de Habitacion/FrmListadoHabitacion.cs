using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class FrmListadoHabitacion : Form
    {
        LoginId Log = null;
        SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        SqlCommand query = null;
        SqlDataReader objReader = null;


        public FrmListadoHabitacion(LoginId LogUser)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Log = LogUser;

            //Cargar combo box de tipo de habitacion
            List<TipoHabitacion> lstTipoHabitacion = new List<TipoHabitacion>();

            query = new SqlCommand("SELECT id, descripcion FROM GAME_OF_QUERYS.tipo_habitacion", objConexion);
            objConexion.Open();
            objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                TipoHabitacion TipoHabitacion = new TipoHabitacion();
                TipoHabitacion.Id = (int)objReader["id"];
                TipoHabitacion.Descripcion = (string)objReader["descripcion"];
                lstTipoHabitacion.Add(TipoHabitacion);
            }
            objConexion.Close();

            this.cmbBxTipoHab.DataSource = lstTipoHabitacion;
            this.cmbBxTipoHab.DisplayMember = "Descripcion";
            this.cmbBxTipoHab.ValueMember = "Id";

        }


        private void txtBxPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo ingresar números");
            }
        }

        private void txtBxNroHab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo ingresar números");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Habitacion> lstHabitaciones = new List<Habitacion>();

            StringBuilder SBquery = new StringBuilder();
            SBquery.Append("SELECT DISTINCT habitacion.*, tipo_habitacion.descripcion AS tipo FROM GAME_OF_QUERYS.habitacion JOIN GAME_OF_QUERYS.tipo_habitacion ON (habitacion.tipo_hab_id = tipo_habitacion.id) ");
            SBquery.Append("WHERE habitacion.hotel_id = '" + Log.Hotel_Id + "'");

            if (txtBxNroHab.Text != string.Empty)
                SBquery.Append(" AND habitacion.nro = '" + txtBxNroHab.Text + "'");

            if (txtBxPiso.Text != string.Empty)
                SBquery.Append(" AND habitacion.piso = '" + txtBxPiso.Text + "'");

            if (checkBxTipo.Checked)
                SBquery.Append(" AND tipo_habitacion.id = '" + (int)this.cmbBxTipoHab.SelectedValue + "'");

            if (radBtnInterior.Checked)
                SBquery.Append(" AND habitacion.ubicacion = 'S'");

            if (radBtnExterior.Checked)
                SBquery.Append(" AND habitacion.ubicacion = 'N'");

            if (radBtnDisp.Checked)
                SBquery.Append(" AND habitacion.estado_habitacion = '1'");

            if (radBtnNoDisp.Checked)
                SBquery.Append(" AND habitacion.estado_habitacion = '0'");

            query = new SqlCommand(SBquery.ToString(), objConexion);

            objConexion.Open();
            objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Habitacion habitacion = new Habitacion();
                habitacion.Id = (int)objReader["id"];
                habitacion.Hotel_id = (int)objReader["hotel_id"];
                habitacion.Numero = (int)objReader["nro"];
                habitacion.Piso = (int)objReader["piso"];
                habitacion.Ubicacion = (string)objReader["ubicacion"];
                habitacion.Descripcion = objReader["descripcion"] as string;
                habitacion.Estado = (bool)objReader["estado_habitacion"];
                habitacion.Tipo = (string)objReader["tipo"];
                
                lstHabitaciones.Add(habitacion);
            }

            objConexion.Close();
            dataGridView.DataSource = lstHabitaciones;


            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["hotel_id"].Visible = false;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

    }
}
