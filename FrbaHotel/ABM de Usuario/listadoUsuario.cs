using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class listadoUsuario : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");

        public listadoUsuario()
        {
            InitializeComponent();
            /*SqlDataAdapter dataadapter = new SqlDataAdapter("select usuario.*, tipo_identidad.nombre as tipo from GAME_OF_QUERYS.usuario left join GAME_OF_QUERYS.tipo_identidad on tipo_identidad.id = usuario.id", connect);
            DataSet ds = new DataSet();
            connect.Open();
            dataadapter.Fill(ds, "USUARIOS");
            connect.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "USUARIOS";
            */

            llenarComboIdentidad();
            llenarComboHotel();
            llenarComboRol();

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
            query.Append(" where 1=1 ");

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

            if (checkBox4.Checked)
                query.Append("and hotel_usuario_rol.hotel_id = '" + ((Hotel)comboBox2.SelectedItem).id + "'");

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
                user.tel = objReader["tel"] as int?;
                user.direccion = objReader["direccion"] as string;
                user.fecha_nac = objReader["fecha_nac"] as DateTime?;
                user.estado = (bool)objReader["estado"]; 
                user.nro_identidad = objReader["nro_identidad"] as int?;

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

            if (e.ColumnIndex == dataGridView1.Columns["mODIFICAR"].Index)
            {

                
            }
            if (e.ColumnIndex == dataGridView1.Columns["bAJA"].Index)
            {
                string query = "update GAME_OF_QUERYS.usuario set estado=0 where id=@user_id ";
                SqlCommand command = new SqlCommand(query,connect);
                command.Parameters.AddWithValue("@user_id", user_id);
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                dataGridView1.Rows[e.RowIndex].Cells["estado"].Value = false;

                ((FrmPrincipal)MdiParent).setStatus("Usuario con id="+ user_id + " borrado con exito");
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

        private void llenarComboHotel()
        {
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "id";

            List<Hotel> lista = new List<Hotel>();

            SqlCommand query = new SqlCommand("select id, nombre from GAME_OF_QUERYS.hotel", connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Hotel Item = new Hotel();
                Item.id = (int)objReader["id"];
                Item.nombre = (string)objReader["nombre"];
                lista.Add(Item);
            }

            connect.Close();
            comboBox2.DataSource = lista;
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
                Rol Item = new Rol();
                Item.Id = (int)objReader["id"];
                Item.Descripcion = (string)objReader["descripcion"];
                lista.Add(Item);
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                comboBox2.Enabled = true;
            else
                comboBox2.Enabled = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                comboBox3.Enabled = true;
            else
                comboBox3.Enabled = false;
        }

      
    }
}
