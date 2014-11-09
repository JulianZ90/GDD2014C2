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
    public partial class FrmHabitacion : Form
    {
        LoginId Log;
        int IdHabitacion;
        int IdHotel;
        string nroHabitacion;
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        SqlCommand query = null;
        SqlDataReader objReader = null;
        string vista = null;
        string descripcion = null;
        bool nuevo = false;


        public FrmHabitacion(LoginId LogUser)
        {
            InitializeComponent();
            Log = LogUser;
            this.CargarFuncionalidades();
            this.Text = "Nueva Habitación";
            nuevo = true;
        }

        public FrmHabitacion(int HabId)
        {
            InitializeComponent();
            this.CargarFuncionalidades();
            this.Text = "Modificar Habitación";
            IdHabitacion = HabId;
            this.cmbBoxTipoHab.Enabled = false;
            this.label8.Hide();

            //completar el formulario
            query = new SqlCommand("SELECT * FROM GAME_OF_QUERYS.habitacion WHERE id = @Id", objConexion);
            query.Parameters.AddWithValue("@Id", HabId);
            objConexion.Open();
            objReader = query.ExecuteReader();
            objReader.Read();
            
            this.txtBxNroHab.Text = Convert.ToString(objReader["nro"]);
            nroHabitacion = this.txtBxNroHab.Text;
            this.txtBxPiso.Text = Convert.ToString(objReader["piso"]);
            if ((string)objReader["ubicacion"] == "N")
            {
                this.radBtnExterior.Checked = true;
            }
            else
            {
                if ((string)objReader["ubicacion"] == "S")
                    this.radBtnInterna.Checked = true;
            }
            this.cmbBoxTipoHab.SelectedValue = (int)objReader["tipo_hab_id"];
            if ((objReader["descripcion"] as string) == null)
                this.txtBoxDescripcion.Text = string.Empty;
            else
                this.txtBoxDescripcion.Text = (string)objReader["descripcion"];
            this.checkBxDisponible.Checked = (bool)objReader["estado_habitacion"];
            IdHotel = (int)objReader["hotel_id"];
            objConexion.Close();


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
            this.txtBxNroHab.Text = string.Empty;
            this.txtBxPiso.Text = string.Empty;
            this.txtBoxDescripcion.Text = string.Empty;
            this.checkBxDisponible.Checked = false;
            this.radBtnExterior.Checked = false;
            this.radBtnInterna.Checked = false;
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtBxNroHab.Text != string.Empty && txtBxPiso.Text != string.Empty)     //campos obligatorios completos?
            {
              query = new SqlCommand("SELECT COUNT(*) AS cantidad FROM GAME_OF_QUERYS.habitacion WHERE hotel_id = @idHotel AND nro = @nroHab", objConexion);
              if (nuevo)
              {
                  query.Parameters.AddWithValue("@idHotel", Log.Hotel_Id);
              }
              else
              {
                  query.Parameters.AddWithValue("@idHotel", IdHotel);
              }
              query.Parameters.AddWithValue("@nroHab", this.txtBxNroHab.Text);
              objConexion.Open();
              objReader = query.ExecuteReader();
              objReader.Read();
              int cant = (int)objReader["cantidad"];
              objConexion.Close();

              if ((nuevo && (cant != 0)) || (!nuevo && (nroHabitacion != this.txtBxNroHab.Text) && (cant != 0)))  //ya existe esa habitacion en el hotel cuando es nuevo o si la quiero modificar por una habitacion ya existente
              {
                MessageBox.Show("Ya existe este número de habitación en el hotel");
              }
              else
              {
                    if (this.radBtnExterior.Checked)
                        vista = "N";
                    else
                    {
                        if (this.radBtnInterna.Checked)
                            vista = "S";
                    }

                    if (this.txtBoxDescripcion.Text != string.Empty)
                        descripcion = this.txtBoxDescripcion.Text;

                    if (nuevo)  //nueva habitacion
                    {
                        query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.habitacion (hotel_id, nro, piso, ubicacion, tipo_hab_id, descripcion, estado_habitacion) VALUES (@hotelId, @habNro, @habPiso, @habVista, @habTipoId, @habDesc, @habEstado)", objConexion);
                        query.Parameters.AddWithValue("@hotelId", Log.Hotel_Id);
                        query.Parameters.AddWithValue("@habNro", this.txtBxNroHab.Text);
                        query.Parameters.AddWithValue("@habPiso", this.txtBxPiso.Text);
                        if (vista == null)
                            query.Parameters.AddWithValue("@habVista", DBNull.Value);
                        else
                            query.Parameters.AddWithValue("@habVista", vista);
                        query.Parameters.AddWithValue("@habTipoId", (int)this.cmbBoxTipoHab.SelectedValue);
                        if (descripcion == null)
                            query.Parameters.AddWithValue("@habDesc", DBNull.Value);
                        else
                            query.Parameters.AddWithValue("@habDesc", descripcion);
                        query.Parameters.AddWithValue("@habEstado", this.checkBxDisponible.Checked);

                        objConexion.Open();
                        query.ExecuteNonQuery();
                        objConexion.Close();
                    }
                    else    //modificar la habitacion
                    {
                        query = new SqlCommand("UPDATE GAME_OF_QUERYS.habitacion SET nro = @nroHab, piso = @pisoHab, ubicacion = @ubicHab, descripcion = @descHab, estado_habitacion = @estadoHab WHERE id = @idHab", objConexion);
                        query.Parameters.AddWithValue("@nroHab", this.txtBxNroHab.Text);
                        query.Parameters.AddWithValue("@pisoHab", this.txtBxPiso.Text);
                        if (vista == null)
                            query.Parameters.AddWithValue("@ubicHab", DBNull.Value);
                        else
                            query.Parameters.AddWithValue("@ubicHab", vista);
                        if (descripcion == null)
                            query.Parameters.AddWithValue("@descHab", DBNull.Value);
                        else
                            query.Parameters.AddWithValue("@descHab", descripcion);
                        query.Parameters.AddWithValue("estadoHab", this.checkBxDisponible.Checked);
                        query.Parameters.AddWithValue("@idHab", IdHabitacion);

                        objConexion.Open();
                        query.ExecuteNonQuery();
                        objConexion.Close();

                    }

                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Por favor complete los campos obligatorios");
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

        private void txtBxPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo ingresar números");
            }
        }


    }
}
