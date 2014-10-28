using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class FrmPrincipal : Form
    {
        private int childFormNumber = 0;
        LoginId Log = null;

        public FrmPrincipal(LoginId IdLog)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Log = IdLog;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }


        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
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


    }
}
