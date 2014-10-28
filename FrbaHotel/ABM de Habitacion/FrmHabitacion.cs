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
    public partial class FrmHabitacion : Form
    {
        LoginId Log;
        SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        SqlCommand query = null;
        SqlDataReader objReader = null;
        string vista = null;
        string descripcion = null;


        public FrmHabitacion(LoginId LogUser)
        {
            InitializeComponent();
            Log = LogUser;
            this.CargarFuncionalidades();
        }

        private void CargarFuncionalidades()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            List<TipoHabitacion> lstTipoHabitacion = new List<TipoHabitacion>();

            //cargar combo box de los tipos de habitacion
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

            this.cmbBoxTipoHab.DataSource = lstTipoHabitacion;
            this.cmbBoxTipoHab.DisplayMember = "Descripcion";
            this.cmbBoxTipoHab.ValueMember = "Id";

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.numUDHabitacion.Value = this.numUDHabitacion.Minimum;
            this.numUDPiso.Value = this.numUDPiso.Minimum;
            this.txtBoxDescripcion.Text = string.Empty;
            this.checkBxDisponible.Checked = false;
            this.radBtnExterior.Checked = false;
            this.radBtnInterna.Checked = false;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            query = new SqlCommand("SELECT COUNT(*) AS cantidad FROM GAME_OF_QUERYS.habitacion WHERE hotel_id = @idHotel AND nro = @nroHab", objConexion);
            query.Parameters.AddWithValue("@idHotel", Log.Hotel_Id);
            query.Parameters.AddWithValue("@nroHab", this.numUDHabitacion.Value);
            objConexion.Open();
            objReader = query.ExecuteReader();
            objReader.Read();
            int cant = (int)objReader["cantidad"];
            objConexion.Close();

            if (cant != 0)  //ya existe esa habitacion en el hotel
            {
                MessageBox.Show("Ya existe este número de habitación en el hotel");
            }
            else
            {
                if(this.radBtnExterior.Checked)
                    vista = "N";
                else
                {
                    if(this.radBtnInterna.Checked)
                        vista = "S";
                }

                if (this.txtBoxDescripcion.Text != string.Empty)
                    descripcion = this.txtBoxDescripcion.Text;


                query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.habitacion (hotel_id, nro, piso, ubicacion, tipo_hab_id, descripcion, estado_habitacion) VALUES (@hotelId, @habNro, @habPiso, @habVista, @habTipoId, @habDesc, @habEstado)", objConexion);
                query.Parameters.AddWithValue("@hotelId", Log.Hotel_Id);
                query.Parameters.AddWithValue("@habNro", this.numUDHabitacion.Value);
                query.Parameters.AddWithValue("@habPiso", this.numUDPiso.Value);
                query.Parameters.AddWithValue("@habVista", vista);
                query.Parameters.AddWithValue("@habTipoId", (int)this.cmbBoxTipoHab.SelectedValue);
                query.Parameters.AddWithValue("@habDesc", descripcion);
                query.Parameters.AddWithValue("@habEstado", this.checkBxDisponible.Checked);

                objConexion.Open();
                query.ExecuteNonQuery();
                objConexion.Close();

                this.Close();
            }

        }

    }
}
