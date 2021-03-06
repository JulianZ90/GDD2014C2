﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmFactura : Form
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        Factura factura;

        public frmFactura(Reserva r)
        {
            InitializeComponent();

            llenarMedioPago();

            factura = new Factura(r);

            textBox1.Text = r.Id.ToString();
            textBox2.Text = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]).ToShortDateString();

            txtDetalles.Clear();
            txtDetalles.Text += string.Format("{0} {1}                        {2}:{3}\r\n", factura.reserva.Cliente.nombre, factura.reserva.Cliente.apellido, factura.reserva.Cliente.tipo_identidad.ToString(), factura.reserva.Cliente.nro_identidad);
            txtDetalles.Text += string.Format("{0} {1} {2} {3} {4}\r\n", factura.reserva.Cliente.calle, factura.reserva.Cliente.nro_calle, factura.reserva.Cliente.piso, factura.reserva.Cliente.depto, factura.reserva.Cliente.ciudad);

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[1].Width = 80;

            dataGridView1.Rows.Clear();
            string[] row = new string[] {"cant.", "Desc.", "Precio unit.", "Importe" };
            dataGridView1.Rows.Add(row);

            foreach (Factura.Item i in factura.items)
            {
                row = new string[] { i.cant.ToString(), i.desc, i.precio.ToString(), i.importe().ToString() };
                dataGridView1.Rows.Add(row);
            }

            row = new string[] { "", "", "", "" };
            dataGridView1.Rows.Add(row);

            row = new string[] { "", "", "Total $", factura.total().ToString() };
            dataGridView1.Rows.Add(row);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            factura.fecha = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
            factura.medios_de_pagos = (MedioPago) comboBox1.SelectedItem;
            
            if (textBox3.Text!="")
                factura.tarjeta = long.Parse(textBox3.Text);

            factura.insert();
            button1.Enabled = false;

            MessageBox.Show("Factura registrada");
        }

        private void llenarMedioPago()
        {
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";

            List<MedioPago> lista = new List<MedioPago>();

            SqlCommand query = new SqlCommand("select id, nombre from GAME_OF_QUERYS.medio_de_pago", connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                MedioPago m = new MedioPago();
                m.id = (int)objReader["id"];
                m.nombre = (string)objReader["nombre"];
                lista.Add(m);
            }

            connect.Close();
            comboBox1.DataSource = lista;

            comboBox1.SelectedIndex = 0;
        }
    }
}
