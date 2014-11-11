namespace FrbaHotel
{
    partial class FrmConsultas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBxConsulta = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtBxReserva = new System.Windows.Forms.TextBox();
            this.lblReserva = new System.Windows.Forms.Label();
            this.txtBxHabitacion = new System.Windows.Forms.TextBox();
            this.lblHabitacion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpBxConsulta.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBxConsulta
            // 
            this.grpBxConsulta.Controls.Add(this.btnConsultar);
            this.grpBxConsulta.Controls.Add(this.txtBxReserva);
            this.grpBxConsulta.Controls.Add(this.lblReserva);
            this.grpBxConsulta.Controls.Add(this.txtBxHabitacion);
            this.grpBxConsulta.Controls.Add(this.lblHabitacion);
            this.grpBxConsulta.Location = new System.Drawing.Point(125, 13);
            this.grpBxConsulta.Name = "grpBxConsulta";
            this.grpBxConsulta.Size = new System.Drawing.Size(151, 175);
            this.grpBxConsulta.TabIndex = 0;
            this.grpBxConsulta.TabStop = false;
            this.grpBxConsulta.Text = "Consulta";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(31, 129);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(84, 27);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtBxReserva
            // 
            this.txtBxReserva.Location = new System.Drawing.Point(68, 83);
            this.txtBxReserva.Name = "txtBxReserva";
            this.txtBxReserva.Size = new System.Drawing.Size(74, 20);
            this.txtBxReserva.TabIndex = 3;
            this.txtBxReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxReserva_KeyPress);
            // 
            // lblReserva
            // 
            this.lblReserva.AutoSize = true;
            this.lblReserva.Location = new System.Drawing.Point(6, 79);
            this.lblReserva.Name = "lblReserva";
            this.lblReserva.Size = new System.Drawing.Size(55, 26);
            this.lblReserva.TabIndex = 2;
            this.lblReserva.Text = "Codigo de\r\nreserva";
            this.lblReserva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBxHabitacion
            // 
            this.txtBxHabitacion.Location = new System.Drawing.Point(68, 25);
            this.txtBxHabitacion.Name = "txtBxHabitacion";
            this.txtBxHabitacion.Size = new System.Drawing.Size(74, 20);
            this.txtBxHabitacion.TabIndex = 1;
            this.txtBxHabitacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxHabitacion_KeyPress);
            // 
            // lblHabitacion
            // 
            this.lblHabitacion.AutoSize = true;
            this.lblHabitacion.Location = new System.Drawing.Point(6, 25);
            this.lblHabitacion.Name = "lblHabitacion";
            this.lblHabitacion.Size = new System.Drawing.Size(56, 26);
            this.lblHabitacion.TabIndex = 0;
            this.lblHabitacion.Text = "Nro de\r\nhabitacion";
            this.lblHabitacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 176);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(107, 176);
            this.dataGridView1.TabIndex = 0;
            // 
            // FrmConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 204);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpBxConsulta);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultas";
            this.Text = "Consultas";
            this.grpBxConsulta.ResumeLayout(false);
            this.grpBxConsulta.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxConsulta;
        private System.Windows.Forms.TextBox txtBxReserva;
        private System.Windows.Forms.Label lblReserva;
        private System.Windows.Forms.TextBox txtBxHabitacion;
        private System.Windows.Forms.Label lblHabitacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnConsultar;
    }
}