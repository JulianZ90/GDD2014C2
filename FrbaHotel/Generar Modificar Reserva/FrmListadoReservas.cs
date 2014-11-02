using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FrmListadoReservas : Form
    {
        SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        SqlCommand query = null;
        SqlDataReader objReader = null;

        public FrmListadoReservas(int UserId)
        {
            InitializeComponent();
            CargarFuncionalidades();
        }

        public FrmListadoReservas(LoginId Log)
        {
            InitializeComponent();
            CargarFuncionalidades();
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
                List<Reserva> lstReserva = new List<Reserva>();
                Reserva Reserva = new Reserva();
                Regimen RegimenReserva = new Regimen();
                EstadoReserva EstadoReserva = new EstadoReserva();

                StringBuilder SBquery = new StringBuilder();
                SBquery.Append("SELECT reserva.id, reserva.fecha_inicio, reserva.fecha_fin, regimen.descripcion AS regimen, reserva.regimen_id, estado_reserva.descripcion AS estado, reserva.estado_id ");
                SBquery.Append("FROM GAME_OF_QUERYS.reserva JOIN GAME_OF_QUERYS.regimen ON (reserva.regimen_id = regimen.id) ");
                SBquery.Append("JOIN GAME_OF_QUERYS.estado_reserva ON (reserva.estado_id = estado_reserva.id) ");
                SBquery.Append("JOIN GAME_OF_QUERYS.cliente ON (cliente.id = reserva.cliente_id) ");
                SBquery.Append("WHERE reserva.id = @ReservaId AND (reserva.estado_id = 1 OR reserva.estado_id = 2)");

                query = new SqlCommand(SBquery.ToString(), objConexion);
                query.Parameters.AddWithValue("@ReservaId", Convert.ToInt32(this.txtBxNroReserva.Text));
                objConexion.Open();
                objReader = query.ExecuteReader();       //que pasa si no encuentra la reserva?
                if (objReader.Read())
                {
                    Reserva.Id = (int)objReader["id"];
                    Reserva.FechaInicio = (DateTime)objReader["fecha_inicio"];
                    Reserva.FechaFin = (DateTime)objReader["fecha_fin"];
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
                }
                else
                {
                    MessageBox.Show("No se encontro reserva. Por favor ingrese nuevamente el código.");
                    this.txtBxNroReserva.Text = string.Empty;
                }


            }
        }
    }
}
