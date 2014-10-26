using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class FrmRol : Form
    {
        SqlConnection objConexion = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        List<Funcionalidad> LstCheckedFunc = new List<Funcionalidad>();


        public FrmRol()
        {
            InitializeComponent();

        }

        public FrmRol(Rol RolModific)
        {
            InitializeComponent();
        }

        private void altaRol_Load(object sender, EventArgs e)
        {
            this.lblExiste.Hide();

            List<Funcionalidad> LstFuncionalidad = new List<Funcionalidad>();

            SqlCommand query = new SqlCommand("SELECT * FROM GAME_OF_QUERYS.funcionalidad", objConexion);
            objConexion.Open();
            SqlDataReader objReader = query.ExecuteReader();
            while(objReader.Read())     //genero lista de funcionalidades
            {
                Funcionalidad Item = new Funcionalidad();
                Item.Id = (int)objReader["id"];
                Item.Descripcion = (string)objReader["descripcion"];
                LstFuncionalidad.Add(Item);
            }
            objConexion.Close();

            ((ListBox)this.ChLstBxFunc).DataSource = LstFuncionalidad;
            ((ListBox)this.ChLstBxFunc).ValueMember = "Id";
            ((ListBox)this.ChLstBxFunc).DisplayMember = "Descripcion";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("SELECT COUNT(*) AS cant FROM GAME_OF_QUERYS.rol WHERE descripcion = @NombreRol", objConexion);
            query.Parameters.AddWithValue("@NombreRol", this.txtBxRol.Text);
            objConexion.Open();
            SqlDataReader objReader = query.ExecuteReader();
            objReader.Read();
            int cantidad = (int)objReader["cant"];
            objConexion.Close();

            if (cantidad != 0)
            {
                this.lblExiste.Show();
                this.txtBxRol.Text = string.Empty;
            }

            else
            {
                this.lblExiste.Hide();
                query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.rol (descripcion, estado) VALUES (@desc, @estado); SELECT SCOPE_IDENTITY()", objConexion);
                query.Parameters.AddWithValue("@desc", this.txtBxRol.Text);
                query.Parameters.AddWithValue("@estado", this.checkBxEstado.Checked);
                objConexion.Open();
                int idRol = Convert.ToInt32(query.ExecuteScalar());
                objConexion.Close();

                foreach (Funcionalidad Item in LstCheckedFunc)
                {
                    query = new SqlCommand("INSERT INTO GAME_OF_QUERYS.rol_funcionalidad (rol_id, funcionalidad_id) VALUES (@idRol, @idFunc)", objConexion);    //falta verificar si ese rol puede realizar todas las funcionalidades
                    query.Parameters.AddWithValue("@idRol", idRol);                                                                                             //capaz habria que hacer un trigger que no deje insertar las que son si o si del administrador
                    query.Parameters.AddWithValue("@idFunc", Item.Id);
                    objConexion.Open();
                    query.ExecuteNonQuery();
                    objConexion.Close();
                }

                this.Close();
            }
            
        }

        private void ChLstBxFunc_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                LstCheckedFunc.Add((Funcionalidad)ChLstBxFunc.Items[e.Index]);
            else
                LstCheckedFunc.Remove((Funcionalidad)ChLstBxFunc.Items[e.Index]);
            
        }
    }
}
