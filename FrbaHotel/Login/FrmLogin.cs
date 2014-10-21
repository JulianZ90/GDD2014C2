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

namespace FrbaHotel.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.lblIncorrecta.Hide();
            this.lblInhabilitado.Hide();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            new FrmPrincipal().ShowDialog();
        }

        int accesos = 0;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");

            SqlCommand query = new SqlCommand("SELECT id, password, estado FROM GAME_OF_QUERYS.usuario WHERE username = @username", objConexion);
            query.Parameters.AddWithValue("@username", this.txtBoxUser.Text);

            objConexion.Open();
            SqlDataReader objReader = query.ExecuteReader();
            objReader.Read();

            //todavia no estoy tomando en cuenta que el username no exista
            string pass = (string)objReader["password"];
            bool estado = (bool)objReader["estado"];
            decimal id = (decimal)objReader["id"];      //no es medio raro que el "id" sea un decimal?

            objConexion.Close();

            //usuario inhabilitado?
            if (estado)    //false: inhabilitado - true: habilitado
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


                if (pass == claveHash)
                {
                    accesos = 0;
                    this.lblIncorrecta.Hide();
                    //mas de un rol?
                    //mas de un hotel?
                    new FrmPrincipal().ShowDialog();
                    this.txtBoxPass.Text = string.Empty;
                    this.txtBoxUser.Text = string.Empty;
                }
                else
                {
                    accesos++;
                    this.lblIncorrecta.Show();
                    this.txtBoxPass.Text = string.Empty;

                    if (accesos == 3)
                    {
                        //inhabilitar el usuario: 1 habilitado - 0 inhabilitado
                        query = new SqlCommand("UPDATE GAME_OF_QUERYS.usuario SET estado = 1 WHERE id = @id", objConexion);     //esto se podria hacer con el username
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
}
