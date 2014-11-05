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
        public altaConsumible(int consumible_id)
        {
            InitializeComponent();
            button1.Text = "Modificar";
            consumible = new consumible(consumible_id);
            cargarConConsumible(consumible);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") consumible.precio = Convert.ToDecimal(textBox1.Text);
            if (textBox2.Text != "") consumible.descripcion = textBox2.Text;

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
            textBox2.Text = c.descripcion;
        }

         private void label1_Click(object sender, EventArgs e)
         {

         }

         private void button2_Click(object sender, EventArgs e)
         {
                 this.textBox1.Text = string.Empty;
                 this.textBox2.Text = string.Empty;
         }

         private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
         {
          if (Char.IsDigit(e.KeyChar) | (e.KeyChar == ',') | (e.KeyChar == '.' ) ) //Al pulsar un numero o coma o punto 
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta 
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta
            }
         }
        
    }
}
