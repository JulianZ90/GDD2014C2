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

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class listadoClientes : Form
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        bool reserva = false;
        Reserva Reserva = null;
        bool seleccionar = false;
        Cliente clienteSeleccionado;


        public listadoClientes()
        {
            InitializeComponent();
            llenarTipoDoc();
            llenarPais();
        }

        public listadoClientes(Reserva NuevaReserva)
        {
            InitializeComponent();
            llenarTipoDoc();
            llenarPais();
            reserva = true;
            Reserva = NuevaReserva;
            this.button3.Hide();
        }

        public listadoClientes(string s)
        {
            InitializeComponent();
            llenarTipoDoc();
            llenarPais();
            seleccionar = true;
        }

        public Cliente getClienteSeleccionado()
        {
            return clienteSeleccionado;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

            if (!reserva)
            {
                if (seleccionar) {
                    // Add a button column ALTA. 
                    DataGridViewButtonColumn buttonColumnSel = new DataGridViewButtonColumn();
                    buttonColumnSel.HeaderText = "S";
                    buttonColumnSel.Name = "sELECCIONAR";
                    buttonColumnSel.Text = "Seleccionar";
                    buttonColumnSel.UseColumnTextForButtonValue = true;
                    buttonColumnSel.Width = 70;
                    dataGridView1.Columns.Add(buttonColumnSel);
                }

                // Add a button column ALTA. 
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "M";
                buttonColumn.Name = "mODIFICAR";
                buttonColumn.Text = "";
                buttonColumn.UseColumnTextForButtonValue = true;
                buttonColumn.Width = 20;
                dataGridView1.Columns.Add(buttonColumn);
            }
            else
            {
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView1.MultiSelect = false;
            }

            // Add a CellClick handler to handle clicks in the button column.
            //no se puede borrar todos los handlers asociados. Asi que trato de quitar el handler viejo aunque no este.
            dataGridView1.CellClick -= new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick); 
            

            List<Cliente> lista = new List<Cliente>();

            StringBuilder query = new StringBuilder();
            query.Append("select distinct cliente.*, tipo_identidad.nombre as tipo, pais.nombre as pais from GAME_OF_QUERYS.cliente ");
            query.Append(" left join GAME_OF_QUERYS.tipo_identidad on tipo_identidad.id = cliente.tipo_identidad_id ");
            query.Append(" left join GAME_OF_QUERYS.pais on pais.id= cliente.pais_origen_id ");
            query.Append(" where 1=1 ");

            if (checkBox3.Checked)
                query.Append("and cliente.tipo_identidad_id = '" + ((TipoIdentidad)comboBox1.SelectedItem).id + "'");

            if (textBox9.Text != "")
                query.Append("and cliente.nro_identidad like '%" + textBox9.Text + "%'");
            
            if (textBox1.Text != "")
                query.Append("and cliente.apellido like '%" + textBox1.Text + "%'");

            if (textBox2.Text != "")
                query.Append("and cliente.nombre like '%" + textBox2.Text + "%'");

            if (checkBox2.Checked)
                query.Append("and cliente.fecha_nac = '" + dateTimePicker1.Value.Date + "'");
            
            if (textBox3.Text != "")
                query.Append("and cliente.mail like '%" + textBox3.Text + "%'");

            if (textBox4.Text != "")
                query.Append("and cliente.tel like '%" + textBox4.Text + "%'");

            if (textBox5.Text != "")
                query.Append("and cliente.calle like '%" + textBox1.Text + "%'");

            if (textBox6.Text != "")
                query.Append("and cliente.nro_calle like '%" + textBox6.Text + "%'");

            if (textBox11.Text != "")
                query.Append("and cliente.piso like '%" + textBox11.Text + "%'");
            
            if (textBox7.Text != "")
                query.Append("and cliente.depto like '%" + textBox7.Text + "%'");
            
            if (textBox8.Text != "")
                query.Append("and cliente.ciudad like '%" + textBox8.Text + "%'");
            
            if (textBox10.Text != "")
                query.Append("and cliente.nacionalidad like '%" + textBox10.Text + "%'");

            if (checkBox4.Checked)
                query.Append("and cliente.pais_origen_id = '" + ((Pais)comboBox2.SelectedItem).id + "'");

            SqlCommand objComando = new SqlCommand(query.ToString(), connect);

            connect.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            while (objReader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.id = (int)objReader["id"];
                cliente.nombre = objReader["nombre"] as string;
                cliente.apellido = objReader["apellido"] as string;
                cliente.fecha_nac = objReader["fecha_nac"] as DateTime?;
                cliente.mail = objReader["mail"] as string;
                cliente.tel = objReader["tel"] as int?;
                cliente.calle = objReader["calle"] as string;
                cliente.nro_calle = objReader["nro_calle"] as int?;
                cliente.piso = objReader["piso"] as int?;
                cliente.depto = objReader["depto"].ToString();
                cliente.ciudad = objReader["ciudad"] as string;
                cliente.nacionalidad = objReader["nacionalidad"] as string;
                cliente.nro_identidad = objReader["nro_identidad"] as int?;

                TipoIdentidad tipo = new TipoIdentidad();
                tipo.nombre = objReader["tipo"] as string;
                cliente.tipo_identidad = tipo;

                Pais pais = new Pais();
                pais.id = (int)objReader["pais_origen_id"];
                cliente.pais = pais;

                lista.Add(cliente);
            }
            connect.Close();
            dataGridView1.DataSource = lista;
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cliente_id;
            if (!reserva)
            {
                // Ignore clicks that are not on button cells.  
                if (e.RowIndex < 0 ||
                    (e.ColumnIndex != dataGridView1.Columns["mODIFICAR"].Index)
                    )
                    return;

                if (seleccionar)
                {
                    if (e.RowIndex < 0 ||
                        (
                        e.ColumnIndex != dataGridView1.Columns["sELECCIONAR"].Index)
                        )
                        return;
                }

                // Retrieve the cliente_id object from the "id" cell.
                cliente_id = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

                if (e.ColumnIndex == dataGridView1.Columns["mODIFICAR"].Index)
                {
                    ABM_de_Cliente.altaCliente modif = new ABM_de_Cliente.altaCliente(cliente_id);
                    modif.Owner = this;
                    modif.ShowDialog();
                }

                if (seleccionar)
                {
                    if (e.ColumnIndex == dataGridView1.Columns["sELECCIONAR"].Index)
                    {
                        clienteSeleccionado = ((List<Cliente>)dataGridView1.DataSource).ElementAt(e.RowIndex);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
            {
                cliente_id = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

                SqlCommand query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.reserva(hotel_id, cliente_id, regimen_id, estado_id, fecha_realizacion, fecha_inicio, fecha_fin, usuario_ultima_modif_id) VALUES (@hotel, @cliente, @regimen, @estado, @fechaHoy, @fechaInicio, @fechaFin, @usuario); SELECT SCOPE_IDENTITY()", connect);
                query.Parameters.AddWithValue("@hotel", Reserva.hotel.id);
                query.Parameters.AddWithValue("@cliente", cliente_id);
                query.Parameters.AddWithValue("@regimen", Reserva.Regimen.id);
                query.Parameters.AddWithValue("@estado", Reserva.Estado.Id);
                query.Parameters.AddWithValue("@fechaHoy", Reserva.FechaRealizacion);
                query.Parameters.AddWithValue("@fechaInicio", Reserva.FechaInicio);
                query.Parameters.AddWithValue("@fechaFin", Reserva.FechaFin);
                query.Parameters.AddWithValue("@usuario", Reserva.UltimoUsuario.id);

                connect.Open();
                int reserva_id = Convert.ToInt32(query.ExecuteScalar());    //me devuelve el id de la reserva que se inserto
                connect.Close();
                //agrego las habitaciones a reserva_habitacion
                foreach (Habitacion Item in Reserva.Habitaciones)
                {
                    query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.reserva_habitacion(reserva_id, habitacion_id) VALUES (@reserva, @habitacion)", connect);
                    query.Parameters.AddWithValue("@reserva", reserva_id);
                    query.Parameters.AddWithValue("@habitacion", Item.Id);
                    connect.Open();
                    query.ExecuteNonQuery();
                    connect.Close();
                }

                //agrego el cliente id y reserva id a la tabla cliente_reserva
                query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.cliente_reserva(cliente_id, reserva_id) VALUES(@clienteId, @reservaId)", connect);
                query.Parameters.AddWithValue("@clienteId", cliente_id);
                query.Parameters.AddWithValue("@reservaId", reserva_id);
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();

                MessageBox.Show("Su código de reserva es: " + reserva_id + ". Recuerde que necesitará este código para modificar o cancelar su reserva.");
                this.Close();

            }
        }

        private void llenarTipoDoc()
        {
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";

            List<TipoIdentidad> lista = new List<TipoIdentidad>();

            SqlCommand query = new SqlCommand("select * from GAME_OF_QUERYS.tipo_identidad", connect);

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

        private void llenarPais()
        {
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "id";

            List<Pais> lista = new List<Pais>();

            SqlCommand query = new SqlCommand("select * from GAME_OF_QUERYS.pais", connect);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Pais Item = new Pais();
                Item.id = (int)objReader["id"];
                Item.nombre = (string)objReader["nombre"];
                lista.Add(Item);
            }

            connect.Close();
            comboBox2.DataSource = lista;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                comboBox2.Enabled = true;
            else
                comboBox2.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                comboBox1.Enabled = true;
            else
                comboBox1.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                dateTimePicker1.Enabled = true;
            else
                dateTimePicker1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ABM_de_Cliente.altaCliente().ShowDialog();
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
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) //Al pulsar un numero
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
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) //Al pulsar un numero
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
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) //Al pulsar un numero
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
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) //Al pulsar un numero
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
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) //Al pulsar un numero
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.textBox5.Text = string.Empty;
            this.textBox6.Text = string.Empty;
            this.textBox7.Text = string.Empty;
            this.textBox8.Text = string.Empty;
            this.textBox9.Text = string.Empty;
            this.textBox10.Text = string.Empty;
            this.textBox11.Text = string.Empty;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
            this.checkBox4.Checked = false;
            this.dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
            this.dataGridView1.Columns.Clear();
            this.comboBox1.SelectedValue = 0;
            this.comboBox2.SelectedValue = 0;
        }

        private void listadoClientes_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
        }
    }
}
