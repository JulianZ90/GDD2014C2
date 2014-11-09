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


namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class FrmListadoHabitacion : Form
    {
        LoginId Log = null;
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        SqlCommand query = null;
        SqlDataReader objReader = null;


        public FrmListadoHabitacion(LoginId LogUser)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.cmbBxTipoHab.Enabled = false;
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
            dataGridView.Columns.Clear();

            // Add a button column MODIFICAR. 
            DataGridViewButtonColumn btnModific = new DataGridViewButtonColumn();
            btnModific.HeaderText = " ";
            btnModific.Name = "Modificar";
            btnModific.Text = "Modificar";
            btnModific.UseColumnTextForButtonValue = true;
            btnModific.Width = 20;
            dataGridView.Columns.Add(btnModific);

            // Add a button column BAJA. 
            DataGridViewButtonColumn btnbaja = new DataGridViewButtonColumn();
            btnbaja.HeaderText = " ";
            btnbaja.Name = "Baja";
            btnbaja.Text = "Baja";
            btnbaja.UseColumnTextForButtonValue = true;
            btnbaja.Width = 20;
            dataGridView.Columns.Add(btnbaja);

            // Add a CellClick handler to handle clicks in the button column.
            //no se puede borrar todos los handlers asociados. Asi que trato de quitar el handler viejo aunque no este.
            dataGridView.CellClick -= new DataGridViewCellEventHandler(dataGridView_CellClick);
            dataGridView.CellClick += new DataGridViewCellEventHandler(dataGridView_CellClick);
            
            
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

            if (checkBxExterior.Checked)
                SBquery.Append(" AND habitacion.ubicacion = 'N'");

            if (checkBxInterior.Checked)
                SBquery.Append(" AND habitacion.ubicacion = 'S'");

            if (checkBxDisp.Checked)
                SBquery.Append(" AND habitacion.estado_habitacion = '1'");

            if (checkBxNoDisp.Checked)
                SBquery.Append(" AND habitacion.estado_habitacion = '0'");

            SBquery.Append(" ORDER BY habitacion.nro");

            query = new SqlCommand(SBquery.ToString(), objConexion);

            objConexion.Open();
            objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Habitacion habitacion = new Habitacion();
                habitacion.Id = (int)objReader["id"];
                Hotel HotelHabitacion = new Hotel();
                HotelHabitacion.id = (int)objReader["hotel_id"];
                habitacion.Hotel = HotelHabitacion;
                habitacion.Numero = (int)objReader["nro"];
                habitacion.Piso = (int)objReader["piso"];
                habitacion.Ubicacion = (string)objReader["ubicacion"];
                habitacion.Descripcion = objReader["descripcion"] as string;
                habitacion.Estado = (bool)objReader["estado_habitacion"];

                TipoHabitacion TipoHabitacion = new TipoHabitacion();
                TipoHabitacion.Id = (int)objReader["tipo_hab_id"];
                TipoHabitacion.Descripcion = (string)objReader["tipo"];

                habitacion.Tipo = TipoHabitacion;
                
                lstHabitaciones.Add(habitacion);
            }

            objConexion.Close();
            dataGridView.DataSource = lstHabitaciones;


            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["hotel_id"].Visible = false;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            this.txtBxNroHab.Text = string.Empty;
            this.txtBxPiso.Text = string.Empty;
            this.checkBxInterior.Checked = false;
            this.checkBxExterior.Checked = false;
            this.checkBxTipo.Checked = false;
            this.checkBxNoDisp.Checked = false;
            this.checkBxDisp.Checked = false;
        }

        private void checkBxTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxTipo.Checked)
                cmbBxTipoHab.Enabled = true;
            else
                cmbBxTipoHab.Enabled = false;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 ||
                (e.ColumnIndex != dataGridView.Columns[0].Index &&
                e.ColumnIndex != dataGridView.Columns[1].Index)
                )
                return;

            // Retrieve the user_id object from the "id" cell.
            int habitacion_id = (int)dataGridView.Rows[e.RowIndex].Cells["id"].Value;

            if (e.ColumnIndex == dataGridView.Columns[0].Index)   //Boton modificar
            {
                new ABM_de_Habitacion.FrmHabitacion(habitacion_id).ShowDialog();
                this.Close();
                
            }
            if (e.ColumnIndex == dataGridView.Columns[1].Index)     //Boton eliminar
            {
                query = new SqlCommand("update GAME_OF_QUERYS.habitacion set estado_habitacion = 0 where id = @habId", objConexion);
                query.Parameters.AddWithValue("@habId", (int)dataGridView.Rows[e.RowIndex].Cells["id"].Value);
                objConexion.Open();
                query.ExecuteNonQuery();
                objConexion.Close();

                dataGridView.Rows[e.RowIndex].Cells["Estado"].Value = false;
                
            }

        }

        private void checkBxNoDisp_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxNoDisp.Checked)
            {
                if (checkBxDisp.Checked)
                {
                    MessageBox.Show("Primero desmarque la opción de 'Habitación Disponible'");
                    checkBxNoDisp.Checked = false;
                }
            }
            
        }

        private void checkBxDisp_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxDisp.Checked)
            {
                if (checkBxNoDisp.Checked)
                {
                    MessageBox.Show("Primero desmarque la opción de 'Habitación No Disponible'");
                    checkBxDisp.Checked = false;
                }
            }
        }

        private void checkBxExterior_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxExterior.Checked)
            {
                if (checkBxInterior.Checked)
                {
                    MessageBox.Show("Primero desmarque la opción de 'Ubicación Interna'");
                    checkBxExterior.Checked = false;
                }
            }
        }

        private void checkBxInterior_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxInterior.Checked)
            {
                if (checkBxExterior.Checked)
                {
                    MessageBox.Show("Primero desmarque la opción de 'Ubicación Externa'");
                    checkBxInterior.Checked = false;
                }
            }
        }

    }
}
