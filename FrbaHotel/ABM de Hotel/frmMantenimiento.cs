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

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class frmMantenimiento : Form
    {
        SqlConnection connect = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        Hotel hotel;

        public frmMantenimiento(int hotel_id)
        {
            InitializeComponent();
            hotel = new Hotel();
            hotel.id = hotel_id;
        }

        private void reload()
        {
            dataGridView1.Columns.Clear();
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

            List<Mantenimiento> lista = new List<Mantenimiento>();
            SqlCommand query = new SqlCommand("select * from GAME_OF_QUERYS.mantenimiento where hotel_id=@id", connect);
            query.Parameters.AddWithValue("id", hotel.id);

            connect.Open();
            SqlDataReader objReader = query.ExecuteReader();

            if (objReader.HasRows)
            {
                while (objReader.Read())
                {
                    Mantenimiento Item = new Mantenimiento();
                    Item.id = (int)objReader["id"];
                    Item.fecha_inicio = (DateTime)objReader["fecha_inicio"];
                    Item.fecha_fin = (DateTime)objReader["fecha_fin"];
                    Item.descripcion = objReader["descripcion"] as string;
                    lista.Add(Item);
                }
                dataGridView1.DataSource = lista;
                dataGridView1.Columns.Remove(dataGridView1.Columns["hotel"]);
            }
            else
                dataGridView1.Columns.Clear();

            connect.Close();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Mantenimiento mant = new Mantenimiento();
            mant.hotel = hotel;
            mant.fecha_inicio = dateTimePicker1.Value.Date;
            mant.fecha_fin = dateTimePicker2.Value.Date;
            mant.descripcion = textBox1.Text;


            if (mant.fecha_inicio >= DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]))
            {
                if (hotel.hotelDisponible(mant.fecha_inicio, mant.fecha_fin, hotel.id))
                {
                    mant.insert();
                    reload();
                }
                else
                {
                    MessageBox.Show("Hay reservas para ese periodo");
                }
            }
            else
            {
                MessageBox.Show("No se puede ingresar un mantenimiento con fecha anterior al dia de hoy");
            }
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 ||  e.ColumnIndex != dataGridView1.Columns["bAJA"].Index)
                return;

            // Retrieve the hotel_id object from the "id" cell.
            int mant_id = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;
            DateTime mant_fecha_inicio = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["fecha_inicio"].Value;

            if (e.ColumnIndex == dataGridView1.Columns["bAJA"].Index)
            {
                Mantenimiento mant = new Mantenimiento();
                mant.id = mant_id;
                mant.fecha_inicio = mant_fecha_inicio;

                bool elimino = mant.delete();

                if (!elimino)
                    MessageBox.Show("No se puede eliminar mantenimientos en curso");

                reload();
            }
        }

        private void frmMantenimiento_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]); 
            dateTimePicker2.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
            monthCalendar1.TodayDate = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
            reload();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            seleccionarEnCalendario();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            seleccionarEnCalendario();
        }

        private void seleccionarEnCalendario() {
            monthCalendar1.SelectionStart = dateTimePicker1.Value;
            monthCalendar1.SelectionEnd = dateTimePicker2.Value;
        }

        private void setDesdeHasta(object sender, DateRangeEventArgs e)
        {
            this.dateTimePicker1.ValueChanged -= new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker2.ValueChanged -= new System.EventHandler(this.dateTimePicker2_ValueChanged);

            dateTimePicker1.Value = monthCalendar1.SelectionStart;
            dateTimePicker2.Value = monthCalendar1.SelectionEnd;

            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
        }

        /*private void setDesdeHasta(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ) return;
            monthCalendar1.SelectionStart   = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["fecha_inicio"].Value;
            monthCalendar1.SelectionEnd     = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["fecha_fin"].Value;
        }*/

    }
}
