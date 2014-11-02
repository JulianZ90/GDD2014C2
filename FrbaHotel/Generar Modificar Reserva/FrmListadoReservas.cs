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
            this.lblBaja.Hide();
            this.txtBxMotivos.Hide();
            this.btnCancelar.Hide();
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
                StringBuilder SBquery = new StringBuilder();
                SBquery.Append("SELECT reserva.id, reserva.fecha_inicio, reserva.fecha_fin, cliente.nombre + ' ' + cliente.apellido AS cliente, regimen.descripcion AS regimen, estado_reserva.descripcion AS estado ");
                SBquery.Append("FROM GAME_OF_QUERYS.reserva JOIN GAME_OF_QUERYS.regimen ON (reserva.regimen_id = regimen.id) ");
                SBquery.Append("JOIN GAME_OF_QUERYS.estado_reserva ON (reserva.estado_id = estado_reserva.id) ");
                SBquery.Append("JOIN GAME_OF_QUERYS.cliente ON (cliente.id = reserva.cliente_id) ");
                SBquery.Append("WHERE reserva.id = @ReservaId AND (reserva.estado_id = 1 OR reserva.estado_id = 2)");

                query = new SqlCommand(SBquery.ToString(), objConexion);

            }
        }
    }
}
