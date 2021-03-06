﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class listadoUsuario : Form
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        LoginId Log = null;
        bool asignarRol = false;

        public listadoUsuario(LoginId Login)
        {
            InitializeComponent();
            llenarComboIdentidad();
            llenarComboRol();
            Log = Login;
        }

        public listadoUsuario(LoginId Login, bool existe)
        {
            InitializeComponent();
            llenarComboIdentidad();
            llenarComboRol();
            Log = Login;
            label12.Visible = false;
            comboBox3.Visible = false;
            checkBox5.Visible = false;
            asignarRol = true;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            // Add a button column ALTA. 
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "M";
            buttonColumn.Name = "mODIFICAR";
            buttonColumn.Text = "";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Width = 20;
            dataGridView1.Columns.Add(buttonColumn);

            // Add a button column BAJA. 
            DataGridViewButtonColumn btnbaja = new DataGridViewButtonColumn();
            btnbaja.HeaderText = "B";
            btnbaja.Name = "bAJA";
            btnbaja.Text = "";
            btnbaja.UseColumnTextForButtonValue = true;
            btnbaja.Width = 20;
            dataGridView1.Columns.Add(btnbaja);

            // Add a CellClick handler to handle clicks in the button column.
            //no se puede borrar todos los handlers asociados. Asi que trato de quitar el handler viejo aunque no este.
            dataGridView1.CellClick -= new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);


            List<Usuario> lista = new List<Usuario>();

            StringBuilder query = new StringBuilder();
            query.Append("select distinct usuario.*, tipo_identidad.nombre as tipo from GAME_OF_QUERYS.usuario ");
            query.Append(" left join GAME_OF_QUERYS.tipo_identidad on tipo_identidad.id = usuario.tipo_identidad_id ");
            query.Append(" left join GAME_OF_QUERYS.hotel_usuario_rol on hotel_usuario_rol.usuario_id= usuario.id ");

            if (!asignarRol)
            {
                //no importa si es admin o administrador, solo se le listan los usuarios del hotel de la sesion actual
                query.Append(" where hotel_usuario_rol.hotel_id =" + Log.Hotel_Id);
            }
            else //listo los usuarios de los otros hoteles para asignarles roles
            {
                query.Append(" where hotel_usuario_rol.hotel_id !=" + Log.Hotel_Id);
            }

            if (textBox1.Text != "")
                query.Append("and usuario.username like '%" + textBox1.Text + "%'");

            /*if (textBox2.Text != "")
                query.Append("and usuario.username like '%" + textBox1.Text + "%'");*/

            if (textBox3.Text != "")
                query.Append("and usuario.nombre like '%" + textBox3.Text + "%'");

            if (textBox4.Text != "")
                query.Append("and usuario.apellido like '%" + textBox4.Text + "%'");

            if (textBox5.Text != "")
                query.Append("and usuario.mail like '%" + textBox1.Text + "%'");

            if (textBox6.Text != "")
                query.Append("and usuario.tel like '%" + textBox6.Text + "%'");

            if (textBox7.Text != "")
                query.Append("and usuario.direccion like '%" + textBox7.Text + "%'");

            if (checkBox2.Checked)
                query.Append("and usuario.fecha_nac = '" + dateTimePicker1.Value.Date + "'");

            if (checkBox3.Checked)
                query.Append("and usuario.tipo_identidad_id = '" + ((TipoIdentidad)comboBox1.SelectedItem).id+ "'");

            if (textBox9.Text != "")
                query.Append("and usuario.nro_identidad like '%" + textBox9.Text + "%'");

            if (checkBox5.Checked)
                query.Append("and hotel_usuario_rol.rol_id = '" + ((Rol)comboBox3.SelectedItem).Id + "'");


            SqlCommand objComando = new SqlCommand(query.ToString(), connect);

            connect.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                Usuario user = new Usuario();
                user.id = (int)objReader["id"];
                user.username = objReader["username"] as string;
                user.password = objReader["password"] as string;
                user.nombre = objReader["nombre"] as string;
                user.apellido = objReader["apellido"] as string;
                user.mail = objReader["mail"] as string;
                user.tel = objReader["tel"] as long?;
                user.direccion = objReader["direccion"] as string;
                user.fecha_nac = objReader["fecha_nac"] as DateTime?;
                user.estado = (bool)objReader["estado"]; 
                user.nro_identidad = objReader["nro_identidad"] as long?;

                TipoIdentidad tipo = new TipoIdentidad();
                tipo.nombre = objReader["tipo"] as string;
                user.tipo_identidad = tipo;

                lista.Add(user);
            }
            connect.Close();
            dataGridView1.DataSource = lista;            
        }
 
        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 || 
                ( e.ColumnIndex != dataGridView1.Columns["mODIFICAR"].Index && 
                e.ColumnIndex != dataGridView1.Columns["bAJA"].Index )
                ) 
                return;

            // Retrieve the user_id object from the "id" cell.
            int user_id = (int) dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

            if (user_id == 1 || user_id == 2)
            {
                MessageBox.Show("Admin o guest no son modificables");
                return;
            }

            if (e.ColumnIndex == dataGridView1.Columns["mODIFICAR"].Index)
            {
                if (!asignarRol)
                {
                    ABM_de_Usuario.altaUsuario modif = new ABM_de_Usuario.altaUsuario(user_id, Log);
                    modif.Owner = this;
                    modif.ShowDialog();
                }
                else
                {
                    ABM_de_Usuario.altaUsuario modif = new ABM_de_Usuario.altaUsuario(user_id, Log, asignarRol);
                    modif.Owner = this;
                    modif.ShowDialog();
                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["bAJA"].Index)
            {
                if (asignarRol)
                {
                    MessageBox.Show("Imposible dar de baja a un usuario de otro hotel");
                    return;
                }
                string query = "update GAME_OF_QUERYS.usuario set estado=0 where id=@user_id ";
                SqlCommand command = new SqlCommand(query,connect);
                command.Parameters.AddWithValue("@user_id", user_id);
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                dataGridView1.Rows[e.RowIndex].Cells["estado"].Value = false;
                
                MessageBox.Show("Usuario con id="+ user_id + " inhabilitado");
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
                dateTimePicker1.Enabled = true;
            else
                dateTimePicker1.Enabled = false;
        }


        private void llenarComboIdentidad()
        {
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";

            List<TipoIdentidad> lista = new List<TipoIdentidad>();

            SqlCommand query = new SqlCommand("select id, nombre from GAME_OF_QUERYS.tipo_identidad", connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                TipoIdentidad Item = new TipoIdentidad();
                Item.id = (int)objReader["id"];
                Item.nombre = (string)objReader["nombre"];
                lista.Add(Item);
            }

            connect.Close();
            comboBox1.DataSource = lista;
        }


        private void llenarComboRol()
        {
            comboBox3.DisplayMember = "Descripcion";
            comboBox3.ValueMember = "Id";

            List<Rol> lista = new List<Rol>();

            SqlCommand query = new SqlCommand("select id, descripcion from GAME_OF_QUERYS.rol", connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                if ((string)objReader["descripcion"] != "Guest" && (string)objReader["descripcion"] != "admin")
                {
                    Rol Item = new Rol();
                    Item.Id = (int)objReader["id"];
                    Item.Descripcion = (string)objReader["descripcion"];
                    lista.Add(Item);
                }
            }

            connect.Close();
            comboBox3.DataSource = lista;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                comboBox1.Enabled = true;
            else
                comboBox1.Enabled = false;
        }


        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                comboBox3.Enabled = true;
            else
                comboBox3.Enabled = false;
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | (e.KeyChar == ' ')) //Al pulsar una letra o espacio
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | (e.KeyChar == ' ')) //Al pulsar una letra o espacio
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) //Al pulsar un numero
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) //Al pulsar un numero
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.textBox5.Text = string.Empty;
            this.textBox6.Text = string.Empty;
            this.textBox7.Text = string.Empty;
            this.textBox9.Text = string.Empty;
            this.dataGridView1.Columns.Clear();       
            this.comboBox1.SelectedValue = 0;
            this.comboBox3.SelectedValue = 0;
            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
            this.checkBox5.Checked = false;
        }

        private void listadoUsuario_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
        }
    }
}
