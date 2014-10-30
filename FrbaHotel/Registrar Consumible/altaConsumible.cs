﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.Registrar_Consumible
{
    public partial class altaConsumible : Form
    {
        LoginId Log;
        int IdConsumible;
        SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        SqlCommand query = null;
        SqlDataReader objReader = null;
        string descripcion;
        decimal precio;
        

        public altaConsumible(LoginId LogUser)
        {
            InitializeComponent();
            Log = LogUser;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != string.Empty && richTextBox1.Text != string.Empty)     //campos completos
            {
                query = new SqlCommand("SELECT COUNT(*) AS cantidad FROM GAME_OF_QUERYS.consumible WHERE descripcion = @descripcion AND precio = @precio", objConexion);

                query.Parameters.AddWithValue("@descripcion", this.richTextBox1.Text);
                query.Parameters.AddWithValue("@precio", this.textBox1.Text);
                objConexion.Open();
                objReader = query.ExecuteReader();
                objReader.Read();
                int cant = (int)objReader["cantidad"];
                objConexion.Close();

                if (cant == 0) 
                {

                        query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.comsumible ( precio, descripcion) VALUES (@precio, @Desc)", objConexion);
                        query.Parameters.AddWithValue("@descripcion", this.richTextBox1.Text);
                        query.Parameters.AddWithValue("@precio", this.textBox1.Text);
                        objConexion.Open();
                        query.ExecuteNonQuery();
                        objConexion.Close();
                    }
                    
                    this.Close();
                }
            else
            {
                MessageBox.Show("Por favor complete los campos obligatorios");
            }

        }
    }
}
