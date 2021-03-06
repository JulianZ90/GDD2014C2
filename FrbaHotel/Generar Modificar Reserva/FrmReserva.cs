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
using System.Globalization;


namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FrmReserva : Form
    {

        SqlConnection objConexion = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        SqlCommand query = null;
        SqlDataReader objReader = null;
        bool guest = false;
        bool modificacion = false;
        LoginId Log = null;
        Reserva Reserva = null;
        int IdGuest;
        List<Regimen> lstRegimenes = new List<Regimen>();
        List<TipoHabitacion> lstHabitacionesReserva = new List<TipoHabitacion>();
        StringBuilder SBDetalle = new StringBuilder();
        decimal sumCostoDiario = 0;
        int HotelId;
        int RegimenId;
        int ingreso = 0;
        bool fechasValidas = false;
        List<Habitacion> lstHabitacionesConfirmadas = new List<Habitacion>();
        bool hayHabitaciones = false;
        bool habitacionesModificadas = false;
        int IdHotelReserva;



        public FrmReserva(LoginId LogUser)  //un empleado del hotel genera la reserva
        {
            InitializeComponent();
            this.lblHotel.Hide();
            this.cmbBxHoteles.Hide();
            this.CondicionesIniciales();
            Log = LogUser;
            HotelId = LogUser.Hotel_Id;
            this.CompletarDataGridViewRegimenes(this.dataGridViewRegimen);
        }


        public FrmReserva(int GuestId)  //un guesta genera la reserva
        {
            InitializeComponent();
            guest = true;
            IdGuest = GuestId;
            this.LlenarComboBoxHoteles(this.cmbBxHoteles);
            this.CondicionesIniciales();
        }


        public FrmReserva(Reserva ReservaModific, int UserId)
        {
            InitializeComponent();
            IdGuest = UserId;
            HotelId = ReservaModific.hotel.id;
            IdHotelReserva = ReservaModific.hotel.id; 
            Reserva = ReservaModific;
            guest = true;
            modificacion = true;
            this.LlenarComboBoxHoteles(this.cmbBxHoteles);
            this.CondicionesIniciales();
            this.LlenarFormulario(ReservaModific, ReservaModific.hotel.id);
        }


        public FrmReserva(Reserva ReservaModific, LoginId LogUser)
        {
            InitializeComponent();
            Log = LogUser;
            Reserva = ReservaModific;
            HotelId = LogUser.Hotel_Id;
            IdHotelReserva = LogUser.Hotel_Id;
            this.lblHotel.Hide();
            this.cmbBxHoteles.Hide();
            modificacion = true;
            this.CondicionesIniciales();
            this.LlenarFormulario(ReservaModific, LogUser.Hotel_Id);
        }


        public void LlenarFormulario(Reserva Reserva, int HotelId)
        {
            if (guest)
                this.cmbBxHoteles.SelectedValue = HotelId;
            this.txtBxRegimen.Text = Reserva.Regimen.descripcion;
            this.dateTimeInicio.Value = Reserva.FechaInicio;
            this.dateTimeFin.Value = Reserva.FechaFin;
            this.CompletarDataGridViewRegimenes(this.dataGridViewRegimen);
        }



        public void CondicionesIniciales()
        {
            this.dataGridViewRegimen.Hide();
            this.lblCosto.Hide();
            this.txtBxCostoTotal.Hide();
            this.btnReservar.Hide();
            if (!modificacion)
            {
                this.lblModific.Hide();
                this.btnModificar.Hide();
            }
            else
            {
                this.btnDisponibilidad.Hide();
                this.btnReservar.Hide();
            }
            this.StartPosition = FormStartPosition.CenterParent;
            this.dateTimeInicio.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
            this.dateTimeFin.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]).AddDays(1);
            this.LlenarComboBoxTipoHabitacion(this.cmbBxTipoHab);
            this.txtBxCostoTotal.ReadOnly = true;
            this.txtBxCostoDiario.ReadOnly = true;
            this.txtBxDetalle.ReadOnly = true;
            this.dataGridViewRegimen.RowHeadersVisible = false;
            this.dataGridViewRegimen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRegimen.AllowUserToResizeRows = false;
            this.dataGridViewRegimen.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewRegimen.MultiSelect = false;
            this.dataGridViewRegimen.ReadOnly = true;
        }


        public void LlenarComboBoxHoteles(ComboBox Combo)
        {
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
            List<Regimen> lstDataGrid = new List<Regimen>();
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
                lstDataGrid.Add(Regimen);
            }
            objConexion.Close();

            DataGridView.DataSource = lstDataGrid;//lstRegimenes;
            DataGridView.Columns["id"].Visible = false;
            DataGridView.Columns["estado"].Visible = false;          
        }



        private void dataGridViewRegimen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewRegimen.Rows[e.RowIndex];

            if (this.lstHabitacionesReserva.Count > 0 && (int)row.Cells["id"].Value != RegimenId)  //ya hay habtaciones en la reserva
            {
                MessageBox.Show("No se puede elegir distintos régimenes en una reserva. Si desea comenzar de nuevo haga click en 'Eliminar todas las habitaciones'");
                foreach (Regimen Item in lstRegimenes)
                {
                    if (Item.id == RegimenId)
                    {
                        this.txtBxRegimen.Text = Item.descripcion;
                        break;
                    }
                }
            }
            else
            {
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
                HotelId = ((Hotel)this.cmbBxHoteles.SelectedItem).id;

                if (((Hotel)this.cmbBxHoteles.SelectedItem).id == 0)
                {
                    this.dataGridViewRegimen.Columns.Clear();
                    this.dataGridViewRegimen.Hide();
                }
                else
                {
                    this.CompletarDataGridViewRegimenes(this.dataGridViewRegimen);
                }
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.dateTimeInicio.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
            this.dateTimeFin.Value = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]).AddDays(1);
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
                    if(string.Compare(Item.descripcion, txtBxRegimen.Text, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                    {
                        valido = true;
                        precioBase = Item.precio_base;
                        break;
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
                if (modificacion)
                    habitacionesModificadas = true;

                if (this.lstHabitacionesReserva.Count > 0)  //ya hay habtaciones en la reserva
                {
                    foreach (Regimen Item in lstRegimenes)
                    {
                        if (string.Compare(Item.descripcion, txtBxRegimen.Text, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                        {
                            if (Item.id == RegimenId)
                            {
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No se puede elegir distintos régimenes en una reserva. Si desea comenzar de nuevo haga click en 'Eliminar todas las habitaciones'");
                                foreach (Regimen Regimen in lstRegimenes)
                                {
                                    if (Regimen.id == RegimenId)
                                    {
                                        this.txtBxRegimen.Text = Regimen.descripcion;
                                        break;
                                    }
                                }
                                return;
                            }
                        }
                    }                   
                }

                this.txtBxDetalle.Text = txtBxDetalle.Text + "Tipo de Habitación: " + ((TipoHabitacion)this.cmbBxTipoHab.SelectedItem).Descripcion + "  -   Costo Diario: " + txtBxCostoDiario.Text + " ; \r\n";
                lstHabitacionesReserva.Add((TipoHabitacion)this.cmbBxTipoHab.SelectedItem);     //agrego la habitacion a las que se quiere en la reserva
                sumCostoDiario = sumCostoDiario + Convert.ToDecimal(txtBxCostoDiario.Text);
                this.txtBxCostoDiario.Text = string.Empty;
                this.cmbBxTipoHab.SelectedValue = 0;
                foreach (Regimen Item in lstRegimenes)
                {
                    if(string.Compare(Item.descripcion, txtBxRegimen.Text, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
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
            if (modificacion)
                habitacionesModificadas = false;

            this.txtBxDetalle.Text = string.Empty;
            this.lstHabitacionesReserva.Clear();
            this.txtBxCostoTotal.Text = string.Empty;
            this.sumCostoDiario = 0;
            this.txtBxCostoDiario.Text = string.Empty;
            this.cmbBxTipoHab.SelectedValue = 0;
        }

        private void btnDisponibilidad_Click(object sender, EventArgs e)
        {
            if ((this.dateTimeInicio.Value >= DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"])) && (this.dateTimeFin.Value >= DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]).AddDays(1)) && (this.dateTimeFin.Value > this.dateTimeInicio.Value))
            {
                query = new SqlCommand("SELECT COUNT(*) FROM GAME_OF_QUERYS.mantenimiento WHERE hotel_id = @hotel  AND ((fecha_inicio <= @fechaFin AND fecha_fin >= @fechaFin) OR (fecha_inicio <= @fechaInicio AND fecha_fin >= @fechaInicio))", objConexion);
                query.Parameters.AddWithValue("@hotel", HotelId);
                query.Parameters.AddWithValue("@fechaInicio", this.dateTimeInicio.Value);
                query.Parameters.AddWithValue("@fechaFin", this.dateTimeFin.Value);
                objConexion.Open();
                int cantidad = (int)query.ExecuteScalar();
                objConexion.Close();

                if (cantidad >= 1)
                {
                    MessageBox.Show("Hotel en mantenimiento en las fechas indicadas");
                }
                else
                {
                    fechasValidas = true;
                }
            }
            else
            {
                MessageBox.Show("Fechas inválidas");
            }

            if (lstHabitacionesReserva.Count > 0)
            {
                hayHabitaciones = true;
            }
            else
            {
                MessageBox.Show("Ingrese por lo menos una habitación");
            }

            if (fechasValidas && hayHabitaciones)
            {                
                //selecciona las haitaciones de un determinado hotel que esten disponibles
                StringBuilder SBquery = new StringBuilder();

                SBquery.Append("SELECT id, tipo_hab_id FROM GAME_OF_QUERYS.habitacion WHERE hotel_id = @hotelId AND estado_habitacion = 1 AND id NOT IN ");
                SBquery.Append("(SELECT DISTINCT habitacion_id FROM GAME_OF_QUERYS.reserva_habitacion JOIN GAME_OF_QUERYS.reserva ON (reserva.id = reserva_habitacion.reserva_id) ");
                SBquery.Append("JOIN GAME_OF_QUERYS.estadia ON (reserva.id = estadia.reserva_id) ");
                SBquery.Append("WHERE hotel_id = @hotelId AND ((estado_id IN (1, 2) AND ((fecha_inicio <= @fechaInicio AND @fechaInicio <= fecha_fin) OR (fecha_inicio <= @fechaFin AND @fechaFin <= fecha_fin))) ");
                SBquery.Append("OR (estado_id = 6 AND check_in IS NOT NULL AND check_out IS NULL AND (check_in <= @fechaInicio AND @fechaInicio <= fecha_fin))))");

                query = new SqlCommand(SBquery.ToString(), objConexion);
                query.Parameters.AddWithValue("@hotelId", HotelId);
                query.Parameters.AddWithValue("@fechaInicio", this.dateTimeInicio.Value);
                query.Parameters.AddWithValue("@fechaFin", this.dateTimeFin.Value);

                objConexion.Open();
                objReader = query.ExecuteReader();

                while (objReader.Read())
                {
                    if (lstHabitacionesReserva.Count > 0)
                    {
                        foreach (TipoHabitacion Item in lstHabitacionesReserva)
                        {
                            if (Item.Id == (int)objReader["tipo_hab_id"])
                            {
                                Habitacion Habitacion = new Habitacion();
                                Habitacion.Id = (int)objReader["id"];

                                this.lstHabitacionesConfirmadas.Add(Habitacion);
                                this.lstHabitacionesReserva.Remove(Item);
                                break;  //si hubo un match entre la habitacion de la base y la de la lista entonces sale del foreach
                            }
                        }
                    }
                    else
                    {
                        break;  //dejo de leer porque ya tengo todas las habitaciones de la reserva
                    }
                }
                objConexion.Close();

                if (lstHabitacionesReserva.Count > 0)   //quedaron habitaciones sin disponibilidad
                {
                    //si no se puede reservar: se muestra en un messageBox, se vacia la lista de habitaciones reserva, se pone fechasValidas y hayHabitaciones en false, se vacia el txtBxDetalle y se vacia lstHabitaciones si ya se puso alguna
                    MessageBox.Show("No hay disponibilidad en el hotel");
                    lstHabitacionesConfirmadas.Clear();
                    lstHabitacionesReserva.Clear();
                    this.txtBxDetalle.Text = string.Empty;
                    this.txtBxCostoDiario.Text = string.Empty;
                    this.cmbBxTipoHab.SelectedValue = 0;
                }
                else
                {
                    //disponibilidad ok, hacerle disable a todo, tirar un messageBox que le diga que esta todo ok y calcular el costo total (mostrar lo de costo total) y mostrar el boton de realizar reserva
                    MessageBox.Show("Hay disponibilidad");
                    this.cmbBxHoteles.Enabled = false;
                    this.dataGridViewRegimen.Enabled = false;
                    this.txtBxRegimen.Enabled = false;
                    this.dateTimeInicio.Enabled = false;
                    this.dateTimeFin.Enabled = false;
                    this.cmbBxTipoHab.Enabled = false;
                    this.txtBxCostoDiario.Enabled = false;
                    this.lblCosto.Show();
                    this.txtBxCostoTotal.Show();
                    this.btnReservar.Show();
                    this.btnLimpiar.Hide();
                    this.btnDisponibilidad.Hide();
                    this.btnAgregarHabitacion.Enabled = false;
                    this.btnEliminarHab.Enabled = false;

                    int cantidadNoches = (this.dateTimeFin.Value - this.dateTimeInicio.Value).Days;
                    this.txtBxCostoTotal.Text = Convert.ToString(sumCostoDiario * cantidadNoches);                  
                }
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            Reserva NuevaReserva = new Reserva();
            Hotel HotelReserva = new Hotel();
            if (guest)
                HotelReserva.id = HotelId;
            else
                HotelReserva.id = Log.Hotel_Id;
            NuevaReserva.hotel = HotelReserva;
            EstadoReserva EstadoReserva = new EstadoReserva();
            EstadoReserva.Id = 1;
            NuevaReserva.Estado = EstadoReserva;
            NuevaReserva.FechaInicio = this.dateTimeInicio.Value;
            NuevaReserva.FechaFin = this.dateTimeFin.Value;
            NuevaReserva.FechaRealizacion = DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]);
            Regimen RegimenReserva = new Regimen();
            RegimenReserva.id = RegimenId;
            NuevaReserva.Regimen = RegimenReserva;
            Usuario UsiarioReserva = new Usuario();

            if (guest)
                UsiarioReserva.id = IdGuest;
            else
                UsiarioReserva.id = Log.Usuario_Id;

            NuevaReserva.UltimoUsuario = UsiarioReserva;
            NuevaReserva.Habitaciones = lstHabitacionesConfirmadas;

            if (MessageBox.Show("Es un nuevo cliente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new ABM_de_Cliente.altaCliente(NuevaReserva).ShowDialog();
                this.Close();
            }
            else
            {
                new ABM_de_Cliente.listadoClientes(NuevaReserva).ShowDialog();
                this.Close();
            }

        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            foreach (Regimen Item in lstRegimenes)
            {
                if (string.Compare(Item.descripcion, txtBxRegimen.Text, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                    RegimenId = Item.id;
            }

            if (habitacionesModificadas || (RegimenId != Reserva.Regimen.id) || (this.dateTimeInicio.Value != Reserva.FechaInicio) || (this.dateTimeFin.Value != Reserva.FechaFin) || (HotelId != IdHotelReserva))  //cambio algo?
            {
                if ((RegimenId != Reserva.Regimen.id) && !habitacionesModificadas && (this.dateTimeInicio.Value == Reserva.FechaInicio) && (this.dateTimeFin.Value == Reserva.FechaFin) && (HotelId == IdHotelReserva))     //solo cambio el regimen? lo distingo porque es el unico que no tengo que chequear disponibilidad
                {
                    if (MessageBox.Show("Esta seguro que quiere modificar su reserva?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = new SqlCommand("UPDATE GAME_OF_QUERYS.reserva SET regimen_id = @nuevoRegimen, estado_id = @nuevoEstado, usuario_ultima_modif_id = @usuarioModif WHERE id = @idReserva", objConexion);
                        query.Parameters.AddWithValue("@nuevoRegimen", RegimenId);
                        query.Parameters.AddWithValue("@nuevoEstado", 2);
                        if (guest)
                            query.Parameters.AddWithValue("@usuarioModif", IdGuest);
                        else
                            query.Parameters.AddWithValue("@usuarioModif", Log.Usuario_Id);
                        query.Parameters.AddWithValue("@idReserva", Reserva.Id);
                        objConexion.Open();
                        query.ExecuteNonQuery();
                        objConexion.Close();
                        this.Close();
                    }
                    else
                    {
                        this.txtBxRegimen.Text = Reserva.Regimen.descripcion;
                    }

                }

                else    //se modifico algun campo que necesita verificar la disponibilidad de habitaciones antes de modificar
                {
                    //1ro elimino las habitaciones reservadas hasta ahora
                    query = new SqlCommand("DELETE FROM GAME_OF_QUERYS.reserva_habitacion WHERE reserva_id = @reservaId", objConexion);
                    query.Parameters.AddWithValue("@reservaId", Reserva.Id);
                    objConexion.Open();
                    query.ExecuteNonQuery();
                    objConexion.Close();

                    if (!habitacionesModificadas)
                    {
                        foreach (Habitacion Item in Reserva.Habitaciones)
                            lstHabitacionesReserva.Add(Item.Tipo);
                    }

                    //hay disponibilidad?
                    if ((this.dateTimeInicio.Value >= DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"])) && (this.dateTimeFin.Value >= DateTime.Parse(ConfigurationSettings.AppSettings["fechaHoy"]).AddDays(1)) && (this.dateTimeFin.Value > this.dateTimeInicio.Value))
                    {
                        query = new SqlCommand("SELECT COUNT(*) FROM GAME_OF_QUERYS.mantenimiento WHERE hotel_id = @hotel  AND ((fecha_inicio <= @fechaFin AND fecha_fin >= @fechaFin) OR (fecha_inicio <= @fechaInicio AND fecha_fin >= @fechaInicio))", objConexion);
                        query.Parameters.AddWithValue("@hotel", HotelId);
                        query.Parameters.AddWithValue("@fechaInicio", this.dateTimeInicio.Value);
                        query.Parameters.AddWithValue("@fechaFin", this.dateTimeFin.Value);
                        objConexion.Open();
                        int cantidad = (int)query.ExecuteScalar();
                        objConexion.Close();

                        if (cantidad >= 1)
                        {
                            MessageBox.Show("Hotel en mantenimiento en las fechas indicadas");
                        }
                        else
                        {
                            fechasValidas = true;
                        }
                    }       
                    else
                        MessageBox.Show("Fechas inválidas");

                    if (fechasValidas)
                    {
                        //selecciona las haitaciones de un determinado hotel que esten disponibles
                        StringBuilder SBquery = new StringBuilder();

                        SBquery.Append("SELECT id, tipo_hab_id FROM GAME_OF_QUERYS.habitacion WHERE hotel_id = @hotelId AND estado_habitacion = 1 AND id NOT IN ");
                        SBquery.Append("(SELECT DISTINCT habitacion_id FROM GAME_OF_QUERYS.reserva_habitacion JOIN GAME_OF_QUERYS.reserva ON (reserva.id = reserva_habitacion.reserva_id) ");
                        SBquery.Append("JOIN GAME_OF_QUERYS.estadia ON (reserva.id = estadia.reserva_id) ");
                        SBquery.Append("WHERE hotel_id = @hotelId AND ((estado_id IN (1, 2) AND ((fecha_inicio <= @fechaInicio AND @fechaInicio <= fecha_fin) OR (fecha_inicio <= @fechaFin AND @fechaFin <= fecha_fin))) ");
                        SBquery.Append("OR (estado_id = 6 AND check_in IS NOT NULL AND check_out IS NULL AND (check_in <= @fechaInicio AND @fechaInicio <= fecha_fin))))");

                        query = new SqlCommand(SBquery.ToString(), objConexion);
                        query.Parameters.AddWithValue("@hotelId", HotelId);
                        query.Parameters.AddWithValue("@fechaInicio", this.dateTimeInicio.Value);
                        query.Parameters.AddWithValue("@fechaFin", this.dateTimeFin.Value);

                        objConexion.Open();
                        objReader = query.ExecuteReader();

                        while (objReader.Read())
                        {
                            if (lstHabitacionesReserva.Count > 0)
                            {
                                foreach (TipoHabitacion Item in lstHabitacionesReserva)
                                {
                                    if (Item.Id == (int)objReader["tipo_hab_id"])
                                    {
                                        Habitacion Habitacion = new Habitacion();
                                        Habitacion.Id = (int)objReader["id"];

                                        this.lstHabitacionesConfirmadas.Add(Habitacion);
                                        this.lstHabitacionesReserva.Remove(Item);
                                        break;  //si hubo un match entre la habitacion de la base y la de la lista entonces sale del foreach
                                    }
                                }
                            }
                            else
                            {
                                break;  //dejo de leer porque ya tengo todas las habitaciones de la reserva
                            }
                        }
                        objConexion.Close();

                        if (lstHabitacionesReserva.Count > 0)   //quedaron habitaciones sin disponibilidad
                        {
                            //si no se puede reservar: se muestra en un messageBox, se vacia la lista de habitaciones reserva, se pone fechasValidas y hayHabitaciones en false, se vacia el txtBxDetalle y se vacia lstHabitaciones si ya se puso alguna
                            MessageBox.Show("No hay disponibilidad en el hotel");
                            lstHabitacionesConfirmadas.Clear();
                            lstHabitacionesReserva.Clear();
                            fechasValidas = false;
                            this.txtBxDetalle.Text = string.Empty;
                            this.txtBxCostoDiario.Text = string.Empty;
                            this.cmbBxTipoHab.SelectedValue = 0;
                        }
                        else
                        {
                            //disponibilidad ok
                            if (MessageBox.Show("Hay disponibilidad. Esta seguro que quiere modificar su reserva?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                query = new SqlCommand("UPDATE GAME_OF_QUERYS.reserva SET regimen_id = @nuevoRegimen, hotel_id = @nuevoHotel, estado_id = @nuevoEstado, fecha_inicio = @nuevaFechaInicio, fecha_fin = @nuevaFechaFin, usuario_ultima_modif_id = @ultimoUser WHERE id = @idReserva", objConexion);
                                query.Parameters.AddWithValue("@nuevoRegimen", RegimenId);
                                query.Parameters.AddWithValue("@nuevoHotel", HotelId);
                                query.Parameters.AddWithValue("@nuevoEstado", 2);
                                query.Parameters.AddWithValue("@nuevaFechaInicio", this.dateTimeInicio.Value);
                                query.Parameters.AddWithValue("@nuevaFechaFin", this.dateTimeFin.Value);
                                if (guest)
                                    query.Parameters.AddWithValue("@ultimoUser", IdGuest);
                                else
                                    query.Parameters.AddWithValue("@ultimoUser", Log.Usuario_Id);
                                query.Parameters.AddWithValue("@idReserva", Reserva.Id);

                                objConexion.Open();
                                query.ExecuteNonQuery();    //hice el update en la tabla reservas, ahora falta agregar las habitaciones
                                objConexion.Close();

                                foreach(Habitacion Item in lstHabitacionesConfirmadas)
                                {
                                    query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.reserva_habitacion(reserva_id, habitacion_id) VALUES (@idReserva, @idHab)", objConexion);
                                    query.Parameters.AddWithValue("@idReserva", Reserva.Id);
                                    query.Parameters.AddWithValue("@idHab", Item.Id);
                                    objConexion.Open();
                                    query.ExecuteNonQuery();
                                    objConexion.Close();
                                }

                                this.Close();

                            }
                            else
                            {
                                lstHabitacionesConfirmadas.Clear();
                                this.txtBxDetalle.Text = string.Empty;
                                this.txtBxCostoDiario.Text = string.Empty;
                                this.cmbBxTipoHab.SelectedValue = 0;
                            }

                        }
                    }

                    
                }

            }
            else
            {
                MessageBox.Show("No se modifico ningun campo");
            }
        }

        private void FrmReserva_Load(object sender, EventArgs e)
        {

        }


    }
}
