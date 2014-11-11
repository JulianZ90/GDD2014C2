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

namespace FrbaHotel
{
    public partial class FrmConsultas : Form
    {
        SqlConnection objConexion = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        SqlCommand query = null;
        SqlDataReader objReader = null;
        LoginId Log = null;
        bool listado = false;


        public FrmConsultas(int id, LoginId Login)
        {
            InitializeComponent();
            Log = Login;

            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.MultiSelect = false;

            switch (id)
            {
                case 1:
                    {
                        //habitaciones ocupadas actualmente
                        this.grpBxConsulta.Hide();

                        List<Habitacion> lstHabitaciones = new List<Habitacion>();
                        StringBuilder SBquery = new StringBuilder();
                        SBquery.Append("SELECT nro FROM GAME_OF_QUERYS.reserva JOIN GAME_OF_QUERYS.reserva_habitacion ON (reserva.id = reserva_habitacion.reserva_id) ");
                        SBquery.Append("JOIN GAME_OF_QUERYS.habitacion ON (reserva_habitacion.habitacion_id = habitacion.id) ");
                        SBquery.Append("WHERE estado_id = 6 AND check_in IS NOT NULL AND check_out IS NULL AND reserva.hotel_id = @hotel");

                        query = new SqlCommand(SBquery.ToString(), objConexion);
                        query.Parameters.AddWithValue("@hotel", Log.Hotel_Id);

                        objConexion.Open();
                        objReader = query.ExecuteReader();

                        while (objReader.Read())
                        {
                            Habitacion Habitacion = new Habitacion();
                            Habitacion.Numero = (int)objReader["nro"];
                            lstHabitaciones.Add(Habitacion);
                        }
                        objConexion.Close();
                        this.dataGridView1.DataSource = lstHabitaciones;
                        this.propiedadesDataGrid();

                        break;
                    }
                case 2:
                    {
                        listado = true;
                        this.lblHabitacion.Hide();
                        this.txtBxHabitacion.Hide();
                        break;
                    }
                case 3:
                    {
                        this.panel1.Hide();
                        this.txtBxReserva.ReadOnly = true;
                        break;
                    }
            }            
        }

        public void propiedadesDataGrid()
        {
            this.dataGridView1.Columns["Hotel"].Visible = false;
            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["Piso"].Visible = false;
            this.dataGridView1.Columns["Ubicacion"].Visible = false;
            this.dataGridView1.Columns["Tipo"].Visible = false;
            this.dataGridView1.Columns["Descripcion"].Visible = false;
            this.dataGridView1.Columns["Estado"].Visible = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (listado)
            {
                this.dataGridView1.Columns.Clear();

                if (this.txtBxReserva.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese un codigo de reserva valido");
                    return;
                }

                List<Habitacion> lstHabitaciones = new List<Habitacion>();
                StringBuilder SBquery = new StringBuilder();
                SBquery.Append("SELECT nro FROM GAME_OF_QUERYS.reserva JOIN GAME_OF_QUERYS.reserva_habitacion ON (reserva.id = reserva_habitacion.reserva_id) ");
                SBquery.Append("JOIN GAME_OF_QUERYS.habitacion ON (reserva_habitacion.habitacion_id = habitacion.id) ");
                SBquery.Append("WHERE estado_id = 6 AND check_in IS NOT NULL AND check_out IS NULL AND reserva.hotel_id = @hotel AND reserva.id = @reserva");

                query = new SqlCommand(SBquery.ToString(), objConexion);
                query.Parameters.AddWithValue("@hotel", Log.Hotel_Id);
                query.Parameters.AddWithValue("@reserva", this.txtBxReserva.Text);

                objConexion.Open();
                objReader = query.ExecuteReader();

                while (objReader.Read())
                {
                    Habitacion Habitacion = new Habitacion();
                    Habitacion.Numero = (int)objReader["nro"];
                    lstHabitaciones.Add(Habitacion);
                }
                objConexion.Close();
                this.dataGridView1.DataSource = lstHabitaciones;
                this.propiedadesDataGrid();

            }
            else
            {
                this.txtBxReserva.Text = string.Empty;
                StringBuilder SBquery = new StringBuilder();
                SBquery.Append("SELECT reserva.id FROM GAME_OF_QUERYS.reserva JOIN GAME_OF_QUERYS.reserva_habitacion ON (reserva.id = reserva_habitacion.reserva_id) ");
                SBquery.Append("JOIN GAME_OF_QUERYS.habitacion ON (habitacion.id = reserva_habitacion.habitacion_id) ");
                SBquery.Append("WHERE estado_id = 6 AND check_in IS NOT NULL AND check_out IS NULL AND reserva.hotel_id = @hotel AND nro = @nro");

                query = new SqlCommand(SBquery.ToString(), objConexion);
                query.Parameters.AddWithValue("@hotel", Log.Hotel_Id);
                query.Parameters.AddWithValue("@nro", this.txtBxHabitacion.Text);

                objConexion.Open();
                objReader = query.ExecuteReader();
                while (objReader.Read())
                {
                    this.txtBxReserva.Text = objReader["id"].ToString();
                }
                objConexion.Close();
            }
        }

        private void txtBxHabitacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo ingresar números");
            }
        }

        private void txtBxReserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo ingresar números");
            }
        }

    }
}
