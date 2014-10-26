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

            llenarCombo(comboBox1, "nombre", "id", "select id, nombre from GAME_OF_QUERYS.tipo_identidad");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Usuario> lista = new List<Usuario>();

            StringBuilder query = new StringBuilder();
            query.Append("select usuario.*, tipo_identidad.nombre as tipo from GAME_OF_QUERYS.usuario left join GAME_OF_QUERYS.tipo_identidad on tipo_identidad.id = usuario.tipo_identidad_id where 1=1 ");

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
                user.estado= (bool)objReader["estado"];
                user.nro_identidad = objReader["nro_identidad"] as int?;

                TipoIdentidad tipo = new TipoIdentidad();
                tipo.nombre = objReader["tipo"] as string;
                user.tipo_identidad = tipo;

                lista.Add(user);
            }
            connect.Close();
            dataGridView1.DataSource = lista; 
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
                dateTimePicker1.Enabled = true;
            else
                dateTimePicker1.Enabled = false;
        }


        private void llenarCombo(ComboBox combo, string desc, string id, string sql )
        {
            combo.DisplayMember = desc;
            combo.ValueMember = id;

            List<TipoIdentidad> lista = new List<TipoIdentidad>();

            SqlCommand query = new SqlCommand(sql , connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                TipoIdentidad Item = new TipoIdentidad();
                Item.id = (int)objReader[id];
                Item.nombre = (string)objReader[desc];
                lista.Add(Item);
            }

            connect.Close();
            combo.DataSource = lista;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                comboBox1.Enabled = true;
            else
                comboBox1.Enabled = false;
        }

      
    }
}
