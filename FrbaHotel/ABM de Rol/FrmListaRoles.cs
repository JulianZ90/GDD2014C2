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


namespace FrbaHotel.ABM_de_Rol
{
    public partial class FrmListaRoles : Form
    {
        SqlConnection objConexion = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        SqlCommand query = null;

        public FrmListaRoles()
        {
            InitializeComponent();

            List<Rol> LstRoles = new List<Rol>();

            query = new SqlCommand("SELECT id, descripcion, estado FROM GAME_OF_QUERYS.rol", objConexion);
            objConexion.Open();
            SqlDataReader objReader = query.ExecuteReader();
            while (objReader.Read())     //genero lista de roles
            {
                Rol Item = new Rol();
                Item.Id = (int)objReader["id"];
                Item.Descripcion = (string)objReader["descripcion"];
                Item.Estado = (bool)objReader["estado"];
                LstRoles.Add(Item);
            }
            objConexion.Close();

            this.dataGridView1.DataSource = LstRoles;
            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["Estado"].Visible = false;
            this.dataGridView1.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            Rol RolSelec = new Rol();
            RolSelec.Id = (int)row.Cells["Id"].Value;
            RolSelec.Descripcion = (string)row.Cells["Descripcion"].Value;
            RolSelec.Estado = (bool)row.Cells["Estado"].Value;

            query = new SqlCommand("SELECT funcionalidad_id, descripcion FROM GAME_OF_QUERYS.rol_funcionalidad rf JOIN GAME_OF_QUERYS.funcionalidad f ON (f.id = rf.funcionalidad_id) WHERE rol_id = @idRol", objConexion);
            query.Parameters.AddWithValue("@idRol", RolSelec.Id);
            objConexion.Open();
            SqlDataReader objReader = query.ExecuteReader();
            while (objReader.Read())     //genero lista de funcionalidades del rol
            {
                Funcionalidad Item = new Funcionalidad();
                Item.Id = (int)objReader["funcionalidad_id"];
                Item.Descripcion = (string)objReader["descripcion"];
                RolSelec.Funcionalidades.Add(Item);
            }
            objConexion.Close();

            new ABM_de_Rol.FrmRol(RolSelec).ShowDialog();
            this.Close();
        }


    }
}
