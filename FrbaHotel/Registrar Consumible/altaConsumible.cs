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
    public partial class altaConsumible : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD2C2014;User Id=gd;Password=gd2014;");
        consumible consumible;
        
        //alta
        public altaConsumible(LoginId LogUser)
        {
            InitializeComponent();
            consumible = new consumible();

        }
        //modificacion
        public altaConsumible(int id)
        {
            InitializeComponent();
            consumible = new consumible(id);
            cargarConConsumible(consumible);
        }

        private void button1_Click(object sender, EventArgs e)
        {
                consumible.precio = Convert.ToDecimal(textBox1.Text);
                consumible.descripcion = richTextBox1.Text;

                if (consumible.id < 1)
                {
                    // no tiene id todavia, es un alta
                    consumible.insert();
                   // ((FrmPrincipal)this.MdiParent).setStatus("consumible creado");
                }
                else
                {
                    consumible.update();
                    ((FrmPrincipal)this.Owner.MdiParent).setStatus("consumible id=" + consumible.id.ToString() + " modificado");
                    this.Close();
                }
           }
          
         private void cargarConConsumible(consumible c)
        {
            textBox1.Text = Convert.ToString(c.precio);
            richTextBox1.Text = c.descripcion;
        }

         private void label1_Click(object sender, EventArgs e)
         {

         }
        
    }
}
