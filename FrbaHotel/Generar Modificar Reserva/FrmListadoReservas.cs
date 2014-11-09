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

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FrmListadoReservas : Form
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        SqlCommand query = null;
        SqlDataReader objReader = null;
        List<Reserva> lstReserva = new List<Reserva>();
        int UserId;
        LoginId Log;
        bool guest = false;
        int idReserva = 0;

        public FrmListadoReservas(int GuestId)
        {
            InitializeComponent();
            CargarFuncionalidades();
            UserId = GuestId;
            guest = true;
        }

        public FrmListadoReservas(LoginId LoginId)
        {
            InitializeComponent();
            CargarFuncionalidades();
            Log = LoginId;
        }


        public void CargarFuncionalidades()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.lblBaja.Hide();
            this.txtBxMotivos.Hide();
            this.btnCancelar.Hide();
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.MultiSelect = false;
        }


        private void txtBxNroReserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo ingresar números");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.txtBxNroReserva.Text == string.Empty)
                MessageBox.Show("Por favor ingrese un número de reserva válido");
            else
            {
                dataGridView1.Columns.Clear();                
                Reserva Reserva = new Reserva();
                Regimen RegimenReserva = new Regimen();
                EstadoReserva EstadoReserva = new EstadoReserva();
                Cliente ClienteReserva = new Cliente();
                Hotel HotelReserva = new Hotel();
                StringBuilder SBquery = new StringBuilder();

                // Add a button column MODIFICAR. 
                DataGridViewButtonColumn btnModific = new DataGridViewButtonColumn();
                btnModific.HeaderText = " ";
                btnModific.Name = "Modificar";
                btnModific.Text = "Modificar";
                btnModific.UseColumnTextForButtonValue = true;
                btnModific.Width = 10;
                dataGridView1.Columns.Add(btnModific);

                // Add a button column BAJA. 
                DataGridViewButtonColumn btnbaja = new DataGridViewButtonColumn();
                btnbaja.HeaderText = " ";
                btnbaja.Name = "Baja";
                btnbaja.Text = "Baja";
                btnbaja.UseColumnTextForButtonValue = true;
                btnbaja.Width = 10;
                dataGridView1.Columns.Add(btnbaja);

                // Add a CellClick handler to handle clicks in the button column.
                //no se puede borrar todos los handlers asociados. Asi que trato de quitar el handler viejo aunque no este.
                dataGridView1.CellClick -= new DataGridViewCellEventHandler(dataGridView1_CellClick);
                dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            


                SBquery.Append("SELECT DISTINCT reserva.id, reserva.hotel_id, hotel.nombre, reserva.fecha_inicio, reserva.fecha_fin, reserva.cliente_id, regimen.descripcion AS regimen, reserva.regimen_id, estado_reserva.descripcion AS estado, reserva.estado_id ");
                SBquery.Append("FROM GAME_OF_QUERYS.reserva JOIN GAME_OF_QUERYS.regimen ON (reserva.regimen_id = regimen.id) ");
                SBquery.Append("JOIN GAME_OF_QUERYS.estado_reserva ON (reserva.estado_id = estado_reserva.id) ");
                SBquery.Append("JOIN GAME_OF_QUERYS.hotel ON (reserva.hotel_id = hotel.id) ");
                SBquery.Append("WHERE reserva.id = @ReservaId AND reserva.estado_id IN (1,2)");              

                query = new SqlCommand(SBquery.ToString(), objConexion);
                query.Parameters.AddWithValue("@ReservaId", Convert.ToInt32(this.txtBxNroReserva.Text));
                objConexion.Open();
                objReader = query.ExecuteReader();
                if (objReader.Read())
                {
                    Reserva.Id = (int)objReader["id"];
                    Reserva.FechaInicio = (DateTime)objReader["fecha_inicio"];
                    Reserva.FechaFin = (DateTime)objReader["fecha_fin"];
                    HotelReserva.id = (int)objReader["hotel_id"];
                    HotelReserva.nombre = (string)objReader["nombre"];
                    Reserva.hotel = HotelReserva;
                    ClienteReserva.id = (int)objReader["cliente_id"];
                    Reserva.Cliente = ClienteReserva;
                    RegimenReserva.descripcion = (string)objReader["regimen"];
                    RegimenReserva.id = (int)objReader["regimen_id"];
                    Reserva.Regimen = RegimenReserva;
                    EstadoReserva.Descripcion = (string)objReader["estado"];
                    EstadoReserva.Id = (int)objReader["estado_id"];
                    Reserva.Estado = EstadoReserva;

                    lstReserva.Add(Reserva);

                    objConexion.Close();

                    dataGridView1.DataSource = lstReserva;
                    
                    this.dataGridView1.Columns["Cliente"].Visible = false;
                    this.dataGridView1.Columns["FechaRealizacion"].Visible = false;
                    this.dataGridView1.Columns["UltimoUsuario"].Visible = false;
                    this.dataGridView1.Columns["CancelMotivo"].Visible = false;
                    this.dataGridView1.Columns["CancelFecha"].Visible = false;
                    this.dataGridView1.Columns["checkin"].Visible = false;
                    this.dataGridView1.Columns["checkout"].Visible = false;
                    this.dataGridView1.Columns["user_checkin"].Visible = false;
                    this.dataGridView1.Columns["user_checkout"].Visible = false;
                    if(!guest)
                        this.dataGridView1.Columns["hotel"].Visible = false;

                }
                else
                {
                    objConexion.Close();
                    MessageBox.Show("No se encontro reserva. Por favor ingrese nuevamente el código.");
                    this.dataGridView1.Columns.Clear();
                    this.txtBxNroReserva.Text = string.Empty;
                }


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 ||
                (e.ColumnIndex != dataGridView1.Columns[0].Index &&
                e.ColumnIndex != dataGridView1.Columns[1].Index)
                )
                return;

            if (e.ColumnIndex == dataGridView1.Columns[0].Index)   //Boton modificar
            {
                Reserva Reserva = null;
                List<Habitacion> lstHabitaciones = new List<Habitacion>();

                foreach (Reserva Item in lstReserva)
                    Reserva = Item;

                query = new SqlCommand("SELECT habitacion_id, tipo_hab_id FROM GAME_OF_QUERYS.reserva_habitacion JOIN GAME_OF_QUERYS.habitacion ON (habitacion.id = reserva_habitacion.habitacion_id) WHERE reserva_id = @id", objConexion);
                query.Parameters.AddWithValue("@id", Reserva.Id);
                objConexion.Open();
                objReader = query.ExecuteReader();
                while (objReader.Read())
                {
                    Habitacion Habitacion = new Habitacion();
                    Habitacion.Id = (int)objReader["habitacion_id"];
                    TipoHabitacion TipoHabitacion = new TipoHabitacion();
                    TipoHabitacion.Id = (int)objReader["tipo_hab_id"];
                    Habitacion.Tipo = TipoHabitacion;

                    lstHabitaciones.Add(Habitacion);
                }
                objConexion.Close();

                Reserva.Habitaciones = lstHabitaciones;

                if (guest)
                    new Generar_Modificar_Reserva.FrmReserva(Reserva, UserId).ShowDialog();
                else
                    new Generar_Modificar_Reserva.FrmReserva(Reserva, Log).ShowDialog();

                this.Close();
            }


            if (e.ColumnIndex == dataGridView1.Columns[1].Index)     //Boton eliminar
            {
                if (MessageBox.Show("Esta seguro que quiere cancelar la reserva?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                   
                    foreach (Reserva Item in lstReserva)
                        idReserva = Item.Id;
                    this.lblBaja.Show();
                    this.txtBxMotivos.Show();
                    this.btnCancelar.Show();
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            query = new SqlCommand("update GAME_OF_QUERYS.reserva set estado_id = @estadoId, cancel_motivo = @motivo, cancel_fecha = @fecha, usuario_ultima_modif_id = @usuarioId where id = @Id", objConexion);
            query.Parameters.AddWithValue("@Id", idReserva);
            if (guest)
                query.Parameters.AddWithValue("@estadoId", 4);
            else
                query.Parameters.AddWithValue("@estadoId", 3);
            if (this.txtBxMotivos.Text == string.Empty)
                query.Parameters.AddWithValue("@motivo", DBNull.Value);
            else
                query.Parameters.AddWithValue("@motivo", this.txtBxMotivos.Text);
            query.Parameters.AddWithValue("@fecha", DateTime.Today);
            if (guest)
                query.Parameters.AddWithValue("@usuarioId", UserId);
            else
                query.Parameters.AddWithValue("@usuarioId", Log.Usuario_Id);

            objConexion.Open();
            query.ExecuteNonQuery();
            objConexion.Close();
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtBxMotivos.Text = string.Empty;
            this.txtBxMotivos.Hide();
            this.txtBxNroReserva.Text = string.Empty;
            this.dataGridView1.Columns.Clear();
            this.lblBaja.Hide();
            this.btnCancelar.Hide();
        }
    }
}
