using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FrmReserva : Form
    {

        SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        SqlCommand query = null;
        SqlDataReader objReader = null;
        bool guest = false;
        LoginId Log = null;
        int index;
        int rowIndex = 1;


        public FrmReserva(LoginId LogUser)  //un empleado del hotel genera la reserva
        {
            InitializeComponent();
            this.lblHotel.Hide();
            this.cmbBxHoteles.Hide();
            this.CondicionesIniciales();
            Log = LogUser;

        }


        public FrmReserva(int GuestId)  //un guesta genera la reserva
        {
            InitializeComponent();
            guest = true;
            this.CondicionesIniciales();

            //llenar comboBox de hoteles
            List<Hotel> lstHoteles = new List<Hotel>();

            query = new SqlCommand("SELECT id, nombre, cantidad_estrella, recarga_estrella FROM GAME_OF_QUERYS.hotel", objConexion);
            objConexion.Open();
            objReader = query.ExecuteReader();
            while (objReader.Read())
            {
                Hotel Hotel = new Hotel();
                Hotel.id = (int)objReader["id"];
                Hotel.nombre = (string)objReader["nombre"];
                Hotel.cantidad_estrella = (int)objReader["cantidad_estrella"];
                Hotel.recarga_estrella = (int)objReader["recarga_estrella"];
                lstHoteles.Add(Hotel);
            }
            objConexion.Close();

            cmbBxHoteles.DataSource = lstHoteles;
            cmbBxHoteles.DisplayMember = "nombre";
            cmbBxHoteles.ValueMember = "id";
        }



        public void CondicionesIniciales()
        {
            this.dataGridViewRegimen.Hide();
            this.lblCosto.Hide();
            this.txtBxCostoTotal.Hide();
            this.btnReservar.Hide();
            this.AddRow();
            this.StartPosition = FormStartPosition.CenterParent;
        }


        public void LlenarComboBoxTipoHabitacion(ComboBox Combo)
        {
            List<TipoHabitacion> lstTipoHabitacion = new List<TipoHabitacion>();

            query = new SqlCommand("SELECT * FROM GAME_OF_QUERYS.tipo_habitacion", objConexion);
            objConexion.Open();
            objReader = query.ExecuteReader();
            while (objReader.Read())
            {
                TipoHabitacion TipoHabitacion = new TipoHabitacion();
                TipoHabitacion.Id = (int)objReader["id"];
                TipoHabitacion.Descripcion = (string)objReader["descripcion"];
                TipoHabitacion.Porcenual = (decimal)objReader["porcentual"];
                lstTipoHabitacion.Add(TipoHabitacion);
            }
            objConexion.Close();

            Combo.DataSource = lstTipoHabitacion;
            Combo.DisplayMember = "Descripcion";
            Combo.ValueMember = "Id";
        }

        private void tbnMostrarRegimen_Click(object sender, EventArgs e)
        {

            //muestro el datagridview
            this.dataGridViewRegimen.Show();

            //lleno el datagridview de regimenes
            this.CompletarDataGridViewRegimenes(this.dataGridViewRegimen);
        }


        private void CompletarDataGridViewRegimenes(DataGridView DataGridView)
        {
            List<Regimen> lstRegimenes = new List<Regimen>();

            query = new SqlCommand("SELECT regimen.id, regimen.descripcion, regimen.precio_base FROM GAME_OF_QUERYS.hotel_reg JOIN GAME_OF_QUERYS.regimen ON (regimen.id = hotel_reg.reg_id) where hotel_id = @hotelId AND regimen.estado = 1", objConexion);

            if (guest)   //el id del hotel lo saco del cmbBxHotel
                query.Parameters.AddWithValue("@hotelId", cmbBxHoteles.DisplayMember);
            else    //cuando es empleado del hotel ya tengo el id del hotel en la clase LoginId
                query.Parameters.AddWithValue("@hotelId", Log.Hotel_Id);

            objConexion.Open();
            objReader = query.ExecuteReader();
            while (objReader.Read())
            {
                Regimen Regimen = new Regimen();
                Regimen.id = (int)objReader["id"];
                Regimen.precio_base = (decimal)objReader["precio_base"];
                Regimen.descripcion = (string)objReader["descripcion"];
                Regimen.estado = true;
                lstRegimenes.Add(Regimen);
            }
            objConexion.Close();

            DataGridView.RowHeadersVisible = false;
            DataGridView.DataSource = lstRegimenes;
            DataGridView.Columns["id"].Visible = false;
            DataGridView.Columns["precio_base"].Visible = false;
            DataGridView.Columns["estado"].Visible = false;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.AllowUserToResizeRows = false;
            DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DataGridView.MultiSelect = false;
            DataGridView.ReadOnly = true;

        }


        private void dataGridViewRegimen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewRegimen.Rows[e.RowIndex];

            this.txtBxRegimen.Text = (string)row.Cells["descripcion"].Value;
        }

        private void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {
            this.AddRow();
        }

        private int AddTableRow()
        {
            index = tableHabitaciones.RowCount++;
            tableHabitaciones.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            return index;
        }

        private void AddRow()
        {
            if (tableHabitaciones.RowCount <= 9)
            {
                rowIndex = AddTableRow();

                //Agrega label de "Tipo de Habitacion"
                Label label = new Label();
                label.Text = "Tipo de habitación";
                label.Anchor = AnchorStyles.Left;
                label.Anchor = AnchorStyles.Right;
                label.Anchor = AnchorStyles.Top;
                label.Width = 114;
                label.Height = 13;
                tableHabitaciones.Controls.Add(label, 0, rowIndex);

                //Agregar combo box de Tipo de Habitacion y llenarlo
                ComboBox combo = new ComboBox();
                combo.Anchor = AnchorStyles.Left;
                combo.Anchor = AnchorStyles.Right;
                combo.Anchor = AnchorStyles.Top;
                combo.Width = 150;
                combo.Height = 21;
                tableHabitaciones.Controls.Add(combo, 1, rowIndex);
                LlenarComboBoxTipoHabitacion(combo);

                //Agregar label de "Costo por día"
                Label label2 = new Label();
                label2.Text = "Costo por día";
                label2.Anchor = AnchorStyles.Left;
                label2.Anchor = AnchorStyles.Right;
                label2.Anchor = AnchorStyles.Top;
                label2.Width = 90;
                label2.Height = 13;
                tableHabitaciones.Controls.Add(label2, 2, rowIndex);

                //Agregat text box para el costo diario
                TextBox textBox = new TextBox();
                textBox.Anchor = AnchorStyles.Left;
                textBox.Anchor = AnchorStyles.Right;
                textBox.Anchor = AnchorStyles.Top;
                textBox.Width = 96;
                textBox.Height = 20;
                tableHabitaciones.Controls.Add(textBox, 3, rowIndex);
            }
            else
            {
                MessageBox.Show("Límite de habitaciones por reserva alcanzado");
            }              
        }


        private void cmbBxHoteles_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CompletarDataGridViewRegimenes(dataGridViewRegimen);
        }

    }
}
