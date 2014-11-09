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


namespace FrbaHotel
{
    public partial class FrmGuest : Form
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        SqlCommand query = null;
        SqlDataReader objReader = null;
        int idUser;

        public FrmGuest()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnGenerarReserva_Click(object sender, EventArgs e)
        {
            new Generar_Modificar_Reserva.FrmReserva(idUser).ShowDialog();
        }

        private void FrmGuest_Load(object sender, EventArgs e)
        {
            query = new SqlCommand("SELECT id FROM GAME_OF_QUERYS.usuario WHERE username = 'guest'", objConexion);
            objConexion.Open();
            objReader = query.ExecuteReader();
            objReader.Read();
            idUser = (int)objReader["id"];
            objConexion.Close();
        }

        private void btnModificarReserva_Click(object sender, EventArgs e)
        {
            new Generar_Modificar_Reserva.FrmListadoReservas(idUser).ShowDialog();
        }

    }
}
