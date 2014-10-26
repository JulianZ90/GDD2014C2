﻿using System;
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
            SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
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
                    if (pass == claveHash)
                    {
                        accesos = 0;
                        this.lblIncorrecta.Hide();
                        //mas de un rol?
                        //mas de un hotel?
                        //new ABM_de_Rol.altaRol().ShowDialog();        //lo uso para probar el altaRol, ni bien ingresa va a ese formulario

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