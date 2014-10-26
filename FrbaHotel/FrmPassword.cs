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

namespace FrbaHotel
{
    public partial class FrmPassword : Form
    {
        int userId;

        public FrmPassword(LoginId IdLog)
        {
            InitializeComponent();
            userId = IdLog.Usuario_Id;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtPass1.Text == string.Empty || this.txtPass2.Text == string.Empty || this.txtPass1.Text != this.txtPass2.Text)
            {
                this.lblError.Show();
                this.txtPass1.Text = string.Empty;
                this.txtPass2.Text = string.Empty;
            }
            else
            {
                this.lblError.Hide();

                //hasheo la contraseña que se ingreso
                StringBuilder Sb = new StringBuilder();
                using (SHA256 hash = SHA256Managed.Create())
                {
                    Encoding enc = Encoding.UTF8;
                    Byte[] result = hash.ComputeHash(enc.GetBytes(this.txtPass1.Text));
                    foreach (Byte b in result)
                        Sb.Append(b.ToString("x2"));
                }
                string claveHash = Sb.ToString();


                SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
                SqlCommand query = new SqlCommand("UPDATE GAME_OF_QUERYS.usuario SET password = @newPass WHERE id = @idUser", objConexion);
                query.Parameters.AddWithValue("@newPass", claveHash);
                query.Parameters.AddWithValue("@idUser", userId);
                objConexion.Open();
                query.ExecuteNonQuery();
                objConexion.Close();
            }
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {
            this.lblError.Hide();
        }
    }
}
