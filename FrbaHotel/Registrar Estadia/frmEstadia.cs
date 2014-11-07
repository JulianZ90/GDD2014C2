using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class frmEstadia : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        Reserva reserva;
        bool checkout = false;
        string consultaBase = @"select reserva.*, regimen.descripcion as regimen, estado_reserva.descripcion as estado,
                cliente.id as cliente_id, cliente.nombre, cliente.apellido, cliente.nro_identidad,cliente.tipo_identidad_id as tipo_id , 
                tipo_identidad.nombre as tipo,
                usuario.username

                from GAME_OF_QUERYS.reserva
                join GAME_OF_QUERYS.regimen on reserva.regimen_id = regimen.id
                left join GAME_OF_QUERYS.estado_reserva on reserva.estado_id = estado_reserva.id
                join GAME_OF_QUERYS.cliente on reserva.cliente_id = cliente.id
                join GAME_OF_QUERYS.tipo_identidad on cliente.tipo_identidad_id = tipo_identidad.id
                left join GAME_OF_QUERYS.usuario on reserva.usuario_ultima_modif_id = usuario.id
                ";

        public frmEstadia()
        {
            //checkin
            InitializeComponent();
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            dateTimePicker1.Hide();
        }

        public frmEstadia(string s)
        {
            //checkout
            InitializeComponent();
            checkout = true;
            panel1.Hide();
            panel2.Show();
            groupBox2.Show();
            button2.Text = "Registrar Checkout y facturar";
            button3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            getReserva(Int32.Parse(textBox1.Text));

            if (reserva == null) return;
            completarFormConReserva();

            if (!reserva.tieneIngreso())
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "") return;
            getReserva(textBox13.Text);

            if (reserva == null) return;
            completarFormConReserva();

            button5.Enabled = true;
        }

        private void getReserva(int id)
        {
            string query_str = consultaBase + @"where reserva.id=@reserva and reserva.hotel_id=@hotel ";
            SqlCommand query = new SqlCommand(query_str, connect);
            string q = query.CommandText;
            query.Parameters.AddWithValue("reserva", id);
            query.Parameters.AddWithValue("hotel", ((FrmPrincipal)this.MdiParent).Log.Hotel_Id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            procesarResultadosBusqueda(objReader);
            connect.Close();
        }

        private void getReserva(string habitaciones)
        {
            string query_str = consultaBase + @"join GAME_OF_QUERYS.reserva_habitacion on reserva.id = reserva_habitacion.reserva_id
                                                join GAME_OF_QUERYS.habitacion on reserva_habitacion.habitacion_id = habitacion.id
                                                where reserva.id=(select MAX(reserva.id) from GAME_OF_QUERYS.reserva ) 
                                                and habitacion.nro in (@nro) and reserva.hotel_id=@hotel and reserva.estado_id=6 ";
            SqlCommand query = new SqlCommand(query_str, connect);
            string q = query.CommandText;
            query.Parameters.AddWithValue("nro", habitaciones);
            query.Parameters.AddWithValue("hotel", ((FrmPrincipal)this.MdiParent).Log.Hotel_Id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            procesarResultadosBusqueda(objReader);
            connect.Close();
        }

        private void procesarResultadosBusqueda(SqlDataReader objReader)
        {
            if (objReader.HasRows)
            {
                objReader.Read();
                reserva = new Reserva();
                List<Habitacion> habs = new List<Habitacion>();
                List<Cliente> huespedes = new List<Cliente>();
                reserva.Habitaciones = habs;
                reserva.huespedes = huespedes;


                reserva.Id = (int)objReader["id"];

                if (objReader["cliente_id"] != DBNull.Value)
                {
                    reserva.Cliente = new Cliente();
                    reserva.Cliente.id = (int)objReader["cliente_id"];
                    reserva.Cliente.nombre = objReader["nombre"] as string;
                    reserva.Cliente.apellido = objReader["apellido"] as string;
                    reserva.Cliente.nro_identidad = (int) objReader["nro_identidad"];

                    if (objReader["tipo_id"] != DBNull.Value)
                    {
                        TipoIdentidad tipo = new TipoIdentidad();
                        tipo.nombre = objReader["tipo"] as string;
                        reserva.Cliente.tipo_identidad = tipo;
                    }
                    else
                        reserva.Cliente.tipo_identidad = null;
                }
                else
                    reserva.Cliente = null;



                if (objReader["estado_id"] != DBNull.Value)
                {
                    EstadoReserva estado = new EstadoReserva();
                    estado.Descripcion = objReader["estado"] as string;
                    reserva.Estado = estado;
                }
                else
                    reserva.Estado = null;



                if (objReader["regimen_id"] != DBNull.Value)
                {
                    Regimen regimen = new Regimen();
                    regimen.descripcion = objReader["regimen"] as string;
                    reserva.Regimen = regimen;
                }
                else
                    reserva.Regimen = null;


                if (objReader["fecha_realizacion"] != DBNull.Value)
                    reserva.FechaRealizacion = objReader["fecha_realizacion"] as DateTime?;
                else
                    reserva.FechaRealizacion = null;


                reserva.FechaInicio = (DateTime)objReader["fecha_inicio"];
                reserva.FechaFin = (DateTime)objReader["fecha_fin"];

                if (objReader["usuario_ultima_modif_id"] != DBNull.Value)
                {
                    Usuario user = new Usuario();
                    user.username = objReader["username"] as string;
                    reserva.UltimoUsuario = user;
                }
                else
                    reserva.UltimoUsuario = null;


                reserva.CancelMotivo = objReader["cancel_motivo"] as string;
                if (objReader["cancel_fecha"] != DBNull.Value)
                    reserva.CancelFecha = objReader["cancel_fecha"] as DateTime?;
                else
                    reserva.CancelFecha = null; 
            }
        }

        private void completarFormConReserva()
        {
            textBox2.Text = reserva.Cliente.nombre + " " + reserva.Cliente.apellido;
            textBox12.Text = reserva.Cliente.tipo_identidad == null ? "" : reserva.Cliente.tipo_identidad.ToString();
            textBox11.Text = reserva.Cliente.nro_identidad.ToString();

            if (reserva.Estado != null)
            {
                textBox4.Text = reserva.Estado.ToString();
                if (reserva.isCancel())
                {
                    groupBox2.Enabled = true;
                    textBox4.BackColor = Color.Salmon;
                }
            }

            textBox3.Text = reserva.Regimen == null ? "" : reserva.Regimen.ToString();
            textBox7.Text = reserva.FechaRealizacion == null ? "" : reserva.FechaRealizacion.Value.ToShortDateString();
            textBox5.Text = reserva.UltimoUsuario == null ? "" : reserva.UltimoUsuario.username;
            textBox8.Text = reserva.FechaInicio.ToShortDateString();
            textBox9.Text = reserva.FechaFin.ToShortDateString();
            monthCalendar1.SelectionStart = reserva.FechaInicio;
            monthCalendar1.SelectionEnd = reserva.FechaFin;
            textBox6.Text = reserva.CancelMotivo;
            textBox10.Text = reserva.CancelFecha == null ? "" : reserva.CancelFecha.Value.ToShortDateString();

            getHabitaciones();
            getHuespedes();

            refrescarListaHabitaciones();
            refrescarListaHuespedes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkout)
            {
                reserva.checkin = DateTime.Today.Date;
                reserva.hacerCheckin();
            }
            else
            {
                reserva.checkout = dateTimePicker1.Value.Date;
                reserva.hacerCheckout();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (ABM_de_Cliente.listadoClientes busca = new ABM_de_Cliente.listadoClientes("buscar"))
            {
                if (busca.ShowDialog(this) == DialogResult.OK)
                {
                    Cliente h = busca.getClienteSeleccionado();
                    reserva.huespedes.Add(h);
                    refrescarListaHuespedes();
                }
            }
        }

        private void refrescarListaHabitaciones()
        {
            dataGridView1.Rows.Clear();
            foreach (Habitacion hab in reserva.Habitaciones)
            {
                string[] row = new string[] { hab.Numero.ToString(), hab.Tipo.ToString() };
                dataGridView1.Rows.Add(row);
            }
        }

        private void refrescarListaHuespedes()
        {
            dataGridView2.Rows.Clear();
            foreach (Cliente h in reserva.huespedes)
            {
                string[] row = new string[] { h.tipo_identidad.ToString(), h.nro_identidad.ToString(), h.nombre, h.apellido };
                dataGridView2.Rows.Add(row);
            }
        }

        private void frmEstadia_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Nro";
            dataGridView1.Columns[1].Name = "Tipo";

            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].Name = "Tipo";
            dataGridView2.Columns[1].Name = "Id";
            dataGridView2.Columns[2].Name = "Nombre";
            dataGridView2.Columns[3].Name = "Apellido";

            dataGridView3.ColumnCount = 3;
            dataGridView3.Columns[0].Name = "Descripcion";
            dataGridView3.Columns[1].Name = "Precio";
            dataGridView3.Columns[2].Name = "Cantidad";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (Registrar_Consumible.listadoConsumibles busca = new Registrar_Consumible.listadoConsumibles("buscar"))
            {
                if (busca.ShowDialog(this) == DialogResult.OK)
                {
                    consumible h = busca.getConsumibleSeleccionado();
                    reserva.consumibles.Add(h);
                    refrescarListaConsumibles();
                }
            }
        }

        private void refrescarListaConsumibles()
        {
            dataGridView3.Rows.Clear();
            foreach (consumible h in reserva.consumibles)
            {
                string[] row = new string[] { h.descripcion, h.precio.ToString(), "1" };
                dataGridView2.Rows.Add(row);
            }
        }

        private void getHabitaciones()
        {
            string query_str = @"select reserva_habitacion.habitacion_id,
                                habitacion.nro as hab_nro,tipo_habitacion.descripcion as hab_tipo
                                from GAME_OF_QUERYS.reserva_habitacion
                                join GAME_OF_QUERYS.habitacion on reserva_habitacion.habitacion_id = habitacion.id
                                left join GAME_OF_QUERYS.tipo_habitacion on habitacion.tipo_hab_id = tipo_habitacion.id
                                where reserva_habitacion.reserva_id = @reserva";
            SqlCommand query = new SqlCommand(query_str, connect);
            string q = query.CommandText;
            query.Parameters.AddWithValue("reserva", reserva.Id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Habitacion hab = new Habitacion();
                hab.Id = (int)objReader["habitacion_id"];
                hab.Numero = (int)objReader["hab_nro"];
                TipoHabitacion tipo = new TipoHabitacion();
                tipo.Descripcion = objReader["hab_tipo"] as string;
                hab.Tipo = tipo;

                reserva.Habitaciones.Add(hab);
            }
            connect.Close();
        }

        private void getHuespedes()
        {
            string query_str = @"select tipo_identidad.nombre as tipo, cliente.nro_identidad, cliente.nombre, cliente.apellido
                                from GAME_OF_QUERYS.cliente_reserva
                                join GAME_OF_QUERYS.cliente on cliente.id = cliente_reserva.cliente_id
                                join GAME_OF_QUERYS.tipo_identidad on cliente.tipo_identidad_id = tipo_identidad.id
                                where cliente_reserva.reserva_id = @reserva";
            SqlCommand query = new SqlCommand(query_str, connect);
            string q = query.CommandText;
            query.Parameters.AddWithValue("reserva", reserva.Id);
            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            while (objReader.Read())
            {
                Cliente cli = new Cliente();
                cli.nro_identidad = (int)objReader["nro_identidad"];
                cli.nombre = objReader["nombre"] as string;
                cli.apellido = objReader["apellido"] as string;
                TipoIdentidad tipo = new TipoIdentidad();
                tipo.nombre = objReader["tipo"] as string;
                cli.tipo_identidad = tipo;

                reserva.huespedes.Add(cli);
            }
            connect.Close();
        }
        
    }
}
