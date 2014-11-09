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

namespace FrbaHotel.Login
{
    public partial class FrmElegirRolHotel : Form
    {
        SqlConnection objConexion = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        SqlCommand query = null;
        SqlDataReader objReader = null;
        LoginId LoginId = new LoginId();

        public FrmElegirRolHotel(int Id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.lblError.Hide();
            this.ShowInTaskbar = false;

            LoginId.Usuario_Id = Id;

            //cargar comboBoxRoles
            List<Rol> lstRoles = new List<Rol>();

            query = new SqlCommand("SELECT DISTINCT id, descripcion FROM GAME_OF_QUERYS.rol r JOIN GAME_OF_QUERYS.hotel_usuario_rol hur ON (r.id = hur.rol_id) WHERE hur.usuario_id = @idUser AND r.estado = 1", objConexion);
            query.Parameters.AddWithValue("@idUser", Id);
            objConexion.Open();
            objReader = query.ExecuteReader();
            while (objReader.Read())
            {
                Rol Rol = new Rol();
                Rol.Id = (int)objReader["id"];
                Rol.Descripcion = (string)objReader["descripcion"];
                lstRoles.Add(Rol);
            }
            objConexion.Close();

            this.cmbBoxRol.DataSource = lstRoles;
            this.cmbBoxRol.ValueMember = "Id";
            this.cmbBoxRol.DisplayMember = "Descripcion";

            //cargar comboBoxHoteles
            List<Hotel> lstHoteles = new List<Hotel>();

            query = new SqlCommand("SELECT DISTINCT id, nombre FROM GAME_OF_QUERYS.hotel h JOIN GAME_OF_QUERYS.hotel_usuario_rol hur ON (h.id = hur.hotel_id) WHERE hur.usuario_id = @idUser", objConexion);
            query.Parameters.AddWithValue("@idUser", Id);
            objConexion.Open();
            objReader = query.ExecuteReader();
            while (objReader.Read())
            {
                Hotel Hotel = new Hotel();
                Hotel.id = (int)objReader["id"];
                Hotel.nombre = (string)objReader["nombre"];
                lstHoteles.Add(Hotel);
            }
            objConexion.Close();

            this.cmbBoxHotel.DataSource = lstHoteles;
            this.cmbBoxHotel.ValueMember = "id";
            this.cmbBoxHotel.DisplayMember = "nombre";

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            LoginId.Rol_Id = (int)this.cmbBoxRol.SelectedValue;
            LoginId.Hotel_Id = (int)this.cmbBoxHotel.SelectedValue;

            query = new SqlCommand("SELECT COUNT(*) AS cantidad FROM GAME_OF_QUERYS.hotel_usuario_rol WHERE rol_id = @rolId AND usuario_id = @usuarioId AND hotel_id = @hotelId", objConexion);
            query.Parameters.AddWithValue("@rolId", LoginId.Rol_Id);
            query.Parameters.AddWithValue("@usuarioId", LoginId.Usuario_Id);
            query.Parameters.AddWithValue("@hotelId", LoginId.Hotel_Id);
            objConexion.Open();
            objReader = query.ExecuteReader();
            objReader.Read();
            int cant = (int)objReader["cantidad"];
            objConexion.Close();

            if (cant == 1)  //el usuario tiene ese rol en ese hotel
            {
                new FrmPrincipal(LoginId).ShowDialog();
                this.Close();
            }
            else    //el usuario no tiene ese rol en ese hotel
            {
                lblError.Show();
            }


        }
    }
}
