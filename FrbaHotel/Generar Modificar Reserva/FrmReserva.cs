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
        List<Regimen> lstRegimenes = new List<Regimen>();
        List<TipoHabitacion> lstHabitacionesReserva = new List<TipoHabitacion>();
        StringBuilder SBDetalle = new StringBuilder();
        decimal sumCostoDiario = 0;
        int HotelId;
        int RegimenId;
        int ingreso = 0;


        public FrmReserva(LoginId LogUser)  //un empleado del hotel genera la reserva
        {
            InitializeComponent();
            this.lblHotel.Hide();
            this.cmbBxHoteles.Hide();
            this.CondicionesIniciales();
            Log = LogUser;
            this.CompletarDataGridViewRegimenes(this.dataGridViewRegimen);

        }


        public FrmReserva(int GuestId)  //un guesta genera la reserva
        {
            InitializeComponent();
            guest = true;

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
            //agregar un hotel generico como default
            Hotel Default = new Hotel();
            Default.id = 0;
            Default.nombre = "--Select--";
            lstHoteles.Insert(0, Default);

            cmbBxHoteles.DataSource = lstHoteles;
            cmbBxHoteles.DisplayMember = "nombre";
            cmbBxHoteles.ValueMember = "id";


            this.CondicionesIniciales();
        }


        public void CondicionesIniciales()
        {
            this.dataGridViewRegimen.Hide();
            this.lblCosto.Hide();
            this.txtBxCostoTotal.Hide();
            this.btnReservar.Hide();
            this.StartPosition = FormStartPosition.CenterParent;
            this.dateTimeInicio.Value = DateTime.Today;
            this.dateTimeFin.Value = DateTime.Today.AddDays(1);
            this.LlenarComboBoxTipoHabitacion(this.cmbBxTipoHab);
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
                TipoHabitacion.Porcentual = (decimal)objReader["porcentual"];
                lstTipoHabitacion.Add(TipoHabitacion);
            }
            objConexion.Close();

            //agregar un tipo de habitacion generico como default
            TipoHabitacion Default = new TipoHabitacion();
            Default.Id = 0;
            Default.Descripcion = "--Select--";
            lstTipoHabitacion.Insert(0, Default);

            Combo.DataSource = lstTipoHabitacion;
            Combo.DisplayMember = "Descripcion";
            Combo.ValueMember = "Id";
         
        }


        private void tbnMostrarRegimen_Click(object sender, EventArgs e)
        {
            if (guest && (((Hotel)this.cmbBxHoteles.SelectedItem).id == 0))
            {
                MessageBox.Show("Debe elegir el hotel primero");
            }
            else
            {
                this.dataGridViewRegimen.Show();
                //lleno el datagridview de regimenes
                this.CompletarDataGridViewRegimenes(this.dataGridViewRegimen);
            }           
        }


        private void CompletarDataGridViewRegimenes(DataGridView DataGridView)
        {
            lstRegimenes.Clear();

            query = new SqlCommand("SELECT regimen.id, regimen.descripcion, regimen.precio_base FROM GAME_OF_QUERYS.hotel_reg JOIN GAME_OF_QUERYS.regimen ON (regimen.id = hotel_reg.reg_id) where hotel_id = @hotelId AND regimen.estado = 1", objConexion);

            if (guest)   //el id del hotel lo saco del cmbBxHotel
                query.Parameters.AddWithValue("@hotelId", ((Hotel)cmbBxHoteles.SelectedItem).id);
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
            if (this.lstHabitacionesReserva.Count > 0)  //ya hay habtaciones en la reserva
            {
                MessageBox.Show("No se puede elegir distintos régimenes en una reserva. Si desea comenzar de nuevo haga click en 'Eliminar todas las habitaciones'");
                foreach (Regimen Item in lstRegimenes)
                {
                    if (Item.id == RegimenId)
                        this.txtBxRegimen.Text = Item.descripcion;
                }
            }
            else
            {
                DataGridViewRow row = dataGridViewRegimen.Rows[e.RowIndex];
                this.txtBxRegimen.Text = (string)row.Cells["descripcion"].Value;

                if (((TipoHabitacion)this.cmbBxTipoHab.SelectedItem).Id != 0)
                    this.calcularColstoDiario();
            }
        }



        private void cmbBxHoteles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstHabitacionesReserva.Count > 0)
            {
                MessageBox.Show("No se puede elegir más de un hotel en la misma reserva. Haga click en 'Eliminar todas las habitaciones' antes de elegir un nuevo hotel'");
                this.cmbBxHoteles.SelectedValue = HotelId;
            }
            else
            {
                //HotelId = ((Hotel)this.cmbBxHoteles.SelectedItem).id;

                if (((Hotel)this.cmbBxHoteles.SelectedItem).id == 0)
                {
                    this.dataGridViewRegimen.Columns.Clear();
                    this.dataGridViewRegimen.Hide();
                }
                else
                    this.CompletarDataGridViewRegimenes(this.dataGridViewRegimen);
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.dateTimeInicio.Value = DateTime.Today;
            this.dateTimeFin.Value = DateTime.Today.AddDays(1);
            this.txtBxRegimen.Text = string.Empty;
            this.dataGridViewRegimen.Columns.Clear();
            this.dataGridViewRegimen.Hide();
            lstHabitacionesReserva.Clear();
            this.cmbBxHoteles.SelectedValue = 0;
            this.cmbBxTipoHab.SelectedValue = 0;
            this.txtBxCostoDiario.Text = string.Empty;
            this.txtBxDetalle.Text = string.Empty;
            this.txtBxCostoTotal.Text = string.Empty;
            this.lblCosto.Hide();
            this.sumCostoDiario = 0;
        }

        private void cmbBxTipoHab_SelectedValueChanged(object sender, EventArgs e)
        {
            if (guest && (((Hotel)this.cmbBxHoteles.SelectedItem).id == 0))
            {
                this.cmbBxTipoHab.SelectedIndex = 0;
                if (ingreso >= 2)
                {
                    MessageBox.Show("Primero seleccione un hotel"); 
                }
                ingreso++;
            }
            else
            {
                if (((TipoHabitacion)this.cmbBxTipoHab.SelectedItem).Id == 0)   //selecciono el "--select--"
                {
                    this.txtBxCostoDiario.Text = string.Empty;
                }
                else
                {
                    this.calcularColstoDiario();
                }
            }
        }



        private void calcularColstoDiario()
        {
            bool valido = false;
            decimal precioBase = 0;


            if (txtBxRegimen.Text != string.Empty)
            {
                foreach (Regimen Item in lstRegimenes)
                {
                    if (Item.descripcion == txtBxRegimen.Text)
                    {
                        valido = true;
                        precioBase = Item.precio_base;
                    }
                }
            }

            //controlar que, si es guest, este el hotel elegido
            if ((this.txtBxRegimen.Text != string.Empty) && valido)  //regimen ingresado es valido?
            {
                //calcular costo diario
                decimal porcentual = ((TipoHabitacion)this.cmbBxTipoHab.SelectedItem).Porcentual;
                int cantEstrellas;
                int recargoEstrella;
                if (guest)
                {
                    cantEstrellas = (int)((Hotel)this.cmbBxHoteles.SelectedItem).cantidad_estrella;
                    recargoEstrella = (int)((Hotel)this.cmbBxHoteles.SelectedItem).recarga_estrella;
                }
                else
                {
                    //buscar la cantidad de estrellas del hotel y el recargo de estrella
                    query = new SqlCommand("SELECT cantidad_estrella, recarga_estrella FROM GAME_OF_QUERYS.hotel WHERE id = @hotelId", objConexion);
                    query.Parameters.AddWithValue("@hotelId", Log.Hotel_Id);
                    objConexion.Open();
                    objReader = query.ExecuteReader();
                    objReader.Read();
                    cantEstrellas = (int)objReader["cantidad_estrella"];
                    recargoEstrella = (int)objReader["recarga_estrella"];
                    objConexion.Close();
                }

                    this.txtBxCostoDiario.Text = Convert.ToString(precioBase * porcentual + cantEstrellas * recargoEstrella);
                }
                else
                {
                    this.cmbBxTipoHab.SelectedValue = 0;
                    MessageBox.Show("Ingrese un régimen válido");
                }
        }



        private void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {
            if (((TipoHabitacion)this.cmbBxTipoHab.SelectedItem).Id != 0)
            {
                this.txtBxDetalle.Text = txtBxDetalle.Text + "Tipo de Habitación: " + ((TipoHabitacion)this.cmbBxTipoHab.SelectedItem).Descripcion + "  -   Costo Diario: " + txtBxCostoDiario.Text + " ; \r\n";
                lstHabitacionesReserva.Add((TipoHabitacion)this.cmbBxTipoHab.SelectedItem);     //agrego la habitacion a las que se quiere en la reserva
                sumCostoDiario = sumCostoDiario + Convert.ToDecimal(txtBxCostoDiario.Text);
                this.txtBxCostoDiario.Text = string.Empty;
                this.cmbBxTipoHab.SelectedValue = 0;
                foreach (Regimen Item in lstRegimenes)
                {
                    if (Item.descripcion == this.txtBxRegimen.Text)
                        RegimenId = Item.id;
                }
                if (guest)
                    HotelId = ((Hotel)this.cmbBxHoteles.SelectedItem).id;
                else
                    HotelId = this.Log.Hotel_Id;
            }
            else
            {
                MessageBox.Show("Ingrese una habitación");
            }
        }



        private void btnEliminarHab_Click(object sender, EventArgs e)
        {
            this.txtBxDetalle.Text = string.Empty;
            this.lstHabitacionesReserva.Clear();
            this.txtBxCostoTotal.Text = string.Empty;
            this.sumCostoDiario = 0;
            this.txtBxCostoDiario.Text = string.Empty;
            this.cmbBxTipoHab.SelectedValue = 0;
        }


    }
}
