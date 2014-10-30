using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel
{
    public partial class FrmGuest : Form
    {
        SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        SqlCommand query = null;
        SqlDataReader objReader = null;


        public FrmGuest()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnGenerarReserva_Click(object sender, EventArgs e)
        {
            int idUser;
            query = new SqlCommand("SELECT id FROM GAME_OF_QUERYS.usuario WHERE username = 'guest'", objConexion);
            objConexion.Open();
            objReader = query.ExecuteReader();
            objReader.Read();
            idUser = (int)objReader["id"];
            objConexion.Close();

            new Generar_Modificar_Reserva.FrmReserva(idUser).ShowDialog();
        }

    }
}
