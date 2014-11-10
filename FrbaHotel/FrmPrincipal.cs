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
    public partial class FrmPrincipal : Form
    {
        private int childFormNumber = 0;
        public LoginId Log = null;
        SqlConnection objConexion = new SqlConnection(ConfigurationSettings.AppSettings["conexionString"]);
        

        public FrmPrincipal(LoginId IdLog)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Log = IdLog;
            this.MostrarFuncionalidades();
            setStatus("Fecha actual de hoy " + ConfigurationSettings.AppSettings["fechaHoy"]);
        }

        private void MostrarFuncionalidades()
        {
            ToolStripItemCollection collection = fileMenu.DropDownItems;
            int idFuncionalidad;   
            SqlCommand query = new SqlCommand("SELECT id FROM GAME_OF_QUERYS.funcionalidad WHERE id NOT IN (SELECT funcionalidad_id FROM GAME_OF_QUERYS.rol_funcionalidad WHERE rol_id = @id) ORDER BY 1", objConexion);
            query.Parameters.AddWithValue("@id", Log.Rol_Id);
            objConexion.Open();
            SqlDataReader objReader = query.ExecuteReader();
            while (objReader.Read())
            {
                idFuncionalidad = (int)objReader["id"];
                collection[idFuncionalidad].Visible = false;
            }
            objConexion.Close();
            
        }


        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //alta usuario form
            Form childForm = new ABM_de_Usuario.altaUsuario();
            childForm.MdiParent = this;
            childForm.Show();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //listar usuarios
            Form childForm = new ABM_de_Usuario.listadoUsuario();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmPassword(Log).ShowDialog();
        }

        private void nuevoRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ABM_de_Rol.FrmRol().ShowDialog();

        }

        private void modificarOEliminarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ABM_de_Rol.FrmListaRoles().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setStatus(string str){

            toolStripStatusLabel.Text = str;
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ABM_de_Habitacion.FrmHabitacion(Log).ShowDialog();
        }

        private void listarHabitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ABM_de_Habitacion.FrmListadoHabitacion(Log).ShowDialog();
        }

        private void altaHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new ABM_de_Hotel.altaHotel();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void listadoHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new ABM_de_Hotel.listadoHoteles();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void nuevaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Generar_Modificar_Reserva.FrmReserva(Log).ShowDialog();
        }

        private void nuevoConsumibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registrar_Consumible.altaConsumible(Log).ShowDialog();
        }

        private void altaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new ABM_de_Cliente.altaCliente();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new ABM_de_Cliente.listadoClientes();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void modificarOCancelarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Generar_Modificar_Reserva.FrmListadoReservas(Log).ShowDialog();
        }

        private void modificarConsumibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Registrar_Consumible.listadoConsumibles();
            childForm.MdiParent = this;
            childForm.Show();
        
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Registrar_Estadia.frmEstadia();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Registrar_Estadia.frmEstadia("checkout");
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void registrarConsumibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registrar_Consumible.FrmRegistrarConsumible(Log).ShowDialog();
        }

        private void listadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Listado_Estadistico.FrmListados().ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        



    }
}
