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


        public FrmReserva(LoginId LogUser)  //un empleado del hotel genera la reserva
        {
            InitializeComponent();
            this.lblHotel.Hide();
            this.cmbBxHoteles.Hide();
            this.CondicionesIniciales();

        }


        public FrmReserva(int GuestId)  //un guesta genera la reserva
        {
            InitializeComponent();
            guest = true;
            this.CondicionesIniciales();

            //llenar comboBox de hoteles

        }

        public void CondicionesIniciales()
        {
            this.dataGridViewRegimen.Hide();
            this.lblCosto.Hide();
            this.txtBxCostoTotal.Hide();
            this.btnReservar.Hide();
            this.LlenarComboBoxTipoHabitacion(cmbBxTipoHab);
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


    }
}
