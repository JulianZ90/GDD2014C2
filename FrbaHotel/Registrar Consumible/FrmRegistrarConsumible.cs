using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class FrmRegistrarConsumible : Form
    {
        LoginId Log = null;
        SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        SqlCommand query = null;
        SqlDataReader objReader = null;


        public FrmRegistrarConsumible(LoginId LogUser)
        {
            InitializeComponent();
            Log = LogUser;
            this.LlenarConsumibles();
        }


        public void LlenarConsumibles()
        {
            List<consumible> lstConsumibles = new List<consumible>();

            query = new SqlCommand("SELECT * FROM GAME_OF_QUERYS.consumible", objConexion);
            objConexion.Open();
            objReader = query.ExecuteReader();
            while (objReader.Read())
            {
                consumible Consumible = new consumible();
                Consumible.id = (int)objReader["id"];
                Consumible.descripcion = (string)objReader["descripcion"];
                Consumible.precio = (decimal)objReader["precio"];
                lstConsumibles.Add(Consumible);
            }
            objConexion.Close();

            //agregar un consumible generico como default
            consumible Default = new consumible();
            Default.id = 0;
            Default.descripcion = "--Select--";
            lstConsumibles.Insert(0, Default);

            this.cmbBxConsumibles.DataSource = lstConsumibles;
            this.cmbBxConsumibles.ValueMember = "id";
            this.cmbBxConsumibles.DisplayMember = "descripcion";
        }

        private void txtBxHabitacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo ingresar números");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            this.txtBxHabitacion.Text = string.Empty;
            this.numUpDownCantidad.Value = 1;
            this.cmbBxConsumibles.SelectedValue = 0;
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtBxHabitacion.Text == string.Empty || (int)cmbBxConsumibles.SelectedValue == 0)
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                StringBuilder SBquery = new StringBuilder();
                SBquery.Append("SELECT reserva_id FROM GAME_OF_QUERYS.reserva_habitacion JOIN GAME_OF_QUERYS.reserva ON (reserva.id = reserva_habitacion.reserva_id) ");
                SBquery.Append("WHERE hotel_id = @hotel AND estado_id = 6 AND check_in IS NOT NULL AND check_out IS NULL AND habitacion_id = @habitacion");

                query = new SqlCommand(SBquery.ToString(), objConexion);    //primero busco el id de la reserva
                query.Parameters.AddWithValue("@hotel", Log.Hotel_Id);
                query.Parameters.AddWithValue("@habitacion", this.txtBxHabitacion.Text);

                objConexion.Open();
                objReader = query.ExecuteReader();
                if (objReader.Read())
                {
                    int ReservaId = (int)objReader["reserva_id"];
                    objConexion.Close();

                    //inserto el registro del consumible
                    query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.consumible_reserva(consumible_id, reserva_id, cantidad) VALUES (@consumible, @reserva, @cantidad)", objConexion);
                    query.Parameters.AddWithValue("@consumible", (int)cmbBxConsumibles.SelectedValue);
                    query.Parameters.AddWithValue("@reserva", ReservaId);
                    query.Parameters.AddWithValue("@cantidad", this.numUpDownCantidad.Value);
                    objConexion.Open();
                    query.ExecuteNonQuery();
                    objConexion.Close();


                    if (MessageBox.Show("Desea registrar otro consumible?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Limpiar();
                    }
                    else
                    {
                        this.Close();
                    }

                }
                else
                {
                    objConexion.Close();
                    MessageBox.Show("Nro de habitación incorrecto");
                }

            }

        }

    }
}
