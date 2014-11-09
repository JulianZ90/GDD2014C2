using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
namespace FrbaHotel.Login
{
    public partial class FrmLogin : Form
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);

        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.lblIncorrecta.Hide();
            this.lblInhabilitado.Hide();
            this.lblUserIncorrecto.Hide();
        }
        private void btnGuest_Click(object sender, EventArgs e)
        {
            new FrmGuest().ShowDialog();
        }
        int accesos = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand queryValidation = new SqlCommand("SELECT COUNT (*) AS cant FROM GAME_OF_QUERYS.usuario WHERE username = @username", objConexion);
            queryValidation.Parameters.AddWithValue("@username", this.txtBoxUser.Text);
            objConexion.Open();
            SqlDataReader objReader = queryValidation.ExecuteReader();
            objReader.Read();
            int cantidad = (int)objReader["cant"];
            objConexion.Close();

            if (cantidad == 0)
            {
                this.txtBoxUser.Text = string.Empty;
                this.txtBoxPass.Text = string.Empty;
                this.lblUserIncorrecto.Show();
            }
            else
            {                
                SqlCommand query = new SqlCommand("SELECT id, password, estado FROM GAME_OF_QUERYS.usuario WHERE username = @username", objConexion);
                query.Parameters.AddWithValue("@username", this.txtBoxUser.Text);
                objConexion.Open();
                objReader = query.ExecuteReader();
                objReader.Read();
                string pass = (string)objReader["password"];
                bool estado = (bool)objReader["estado"];
                int id = (int)objReader["id"];
                objConexion.Close();
                //usuario inhabilitado?
                if (estado)
                {
                    //hasheo la contraseña que se ingreso y comparo los hashes
                    StringBuilder Sb = new StringBuilder();
                    using (SHA256 hash = SHA256Managed.Create())
                    {
                        Encoding enc = Encoding.UTF8;
                        Byte[] result = hash.ComputeHash(enc.GetBytes(this.txtBoxPass.Text));
                        foreach (Byte b in result)
                            Sb.Append(b.ToString("x2"));
                    }
                    string claveHash = Sb.ToString();

                    if (pass == claveHash)  //contraseña correcta
                    {
                        accesos = 0;
                        this.lblIncorrecta.Hide();
                        //mas de un rol?
                        //mas de un hotel?

                        query = new SqlCommand("SELECT COUNT(*) AS cant FROM GAME_OF_QUERYS.hotel_usuario_rol WHERE usuario_id = @UserId", objConexion);
                        query.Parameters.AddWithValue("@UserId", id);
                        objConexion.Open();
                        objReader = query.ExecuteReader();
                        objReader.Read();
                        cantidad = (int)objReader["cant"];
                        objConexion.Close();


                        if (cantidad == 1)  //solo un rol en un unico hotel
                        {
                            LoginId Log = new LoginId();
                            Log.Usuario_Id = id;

                            query = new SqlCommand("SELECT rol_id, hotel_id FROM GAME_OF_QUERYS.hotel_usuario_rol WHERE usuario_id = @idUser", objConexion);    //sigo sin tener en cuenta mas de un hotel y rol, esta query se va a tener que modificar por el valor que tomen los comboBox
                            query.Parameters.AddWithValue("@idUser", id);
                            objConexion.Open();
                            objReader = query.ExecuteReader();
                            objReader.Read();
                            Log.Rol_Id = (int)objReader["rol_id"];
                            Log.Hotel_Id = (int)objReader["hotel_id"];
                            objConexion.Close();

                            new FrmPrincipal(Log).ShowDialog();
                        }
                        else //mas de un registro en la tabla hotel_usuario_rol
                        {
                            new Login.FrmElegirRolHotel(id).ShowDialog();
                        }


                        this.txtBoxPass.Text = string.Empty;
                        this.txtBoxUser.Text = string.Empty;
                    }

                    else    //contraseña incorrecta
                    {
                        accesos++;
                        this.lblIncorrecta.Show();
                        this.txtBoxPass.Text = string.Empty;
                        if (accesos == 3)
                        {
                            //inhabilitar el usuario: 1 habilitado - 0 inhabilitado
                            query = new SqlCommand("UPDATE GAME_OF_QUERYS.usuario SET estado = 1 WHERE id = @id", objConexion); //esto se podria hacer con el username
                            query.Parameters.AddWithValue("@id", id);
                            objConexion.Open();
                            query.ExecuteNonQuery();
                            objConexion.Close();
                            this.lblInhabilitado.Show();
                            this.txtBoxUser.Text = string.Empty;
                            accesos = 0;
                        }
                    }
                }
                else
                {
                    this.lblInhabilitado.Show();
                }
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}