namespace FrbaHotel.ABM_de_Habitacion
{
    partial class FrmListadoHabitacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBxVista = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxNroHab = new System.Windows.Forms.TextBox();
            this.cmbBxTipoHab = new System.Windows.Forms.ComboBox();
            this.cmbBxPiso = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.radBtnDisp = new System.Windows.Forms.RadioButton();
            this.radBtnNoDisp = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Location = new System.Drawing.Point(12, 214);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 254);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(627, 254);
            this.dataGridView.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radBtnNoDisp);
            this.groupBox1.Controls.Add(this.radBtnDisp);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtBxVista);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBxNroHab);
            this.groupBox1.Controls.Add(this.cmbBxTipoHab);
            this.groupBox1.Controls.Add(this.cmbBxPiso);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 196);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Habitación";
            // 
            // txtBxVista
            // 
            this.txtBxVista.Location = new System.Drawing.Point(159, 142);
            this.txtBxVista.Name = "txtBxVista";
            this.txtBxVista.Size = new System.Drawing.Size(121, 21);
            this.txtBxVista.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 39);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ubicación en \r\nel hotel (N / S):\r\nN: exterior - S: interior";
            // 
            // txtBxNroHab
            // 
            this.txtBxNroHab.Location = new System.Drawing.Point(159, 28);
            this.txtBxNroHab.Name = "txtBxNroHab";
            this.txtBxNroHab.Size = new System.Drawing.Size(121, 21);
            this.txtBxNroHab.TabIndex = 5;
            // 
            // cmbBxTipoHab
            // 
            this.cmbBxTipoHab.FormattingEnabled = true;
            this.cmbBxTipoHab.Location = new System.Drawing.Point(461, 28);
            this.cmbBxTipoHab.Name = "cmbBxTipoHab";
            this.cmbBxTipoHab.Size = new System.Drawing.Size(121, 21);
            this.cmbBxTipoHab.TabIndex = 4;
            // 
            // cmbBxPiso
            // 
            this.cmbBxPiso.FormattingEnabled = true;
            this.cmbBxPiso.Location = new System.Drawing.Point(159, 84);
            this.cmbBxPiso.Name = "cmbBxPiso";
            this.cmbBxPiso.Size = new System.Drawing.Size(121, 21);
            this.cmbBxPiso.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de habitación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Piso:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de habitación:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(410, 149);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(507, 149);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // radBtnDisp
            // 
            this.radBtnDisp.AutoSize = true;
            this.radBtnDisp.Location = new System.Drawing.Point(437, 78);
            this.radBtnDisp.Name = "radBtnDisp";
            this.radBtnDisp.Size = new System.Drawing.Size(145, 17);
            this.radBtnDisp.TabIndex = 10;
            this.radBtnDisp.TabStop = true;
            this.radBtnDisp.Text = "Habitación disponible";
            this.radBtnDisp.UseVisualStyleBackColor = true;
            // 
            // radBtnNoDisp
            // 
            this.radBtnNoDisp.AutoSize = true;
            this.radBtnNoDisp.Location = new System.Drawing.Point(437, 110);
            this.radBtnNoDisp.Name = "radBtnNoDisp";
            this.radBtnNoDisp.Size = new System.Drawing.Size(163, 17);
            this.radBtnNoDisp.TabIndex = 11;
            this.radBtnNoDisp.TabStop = true;
            this.radBtnNoDisp.Text = "Habitación no disponible";
            this.radBtnNoDisp.UseVisualStyleBackColor = true;
            // 
            // FrmListadoHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 480);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadoHabitacion";
            this.Text = "Buscar Habitación";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxNroHab;
        private System.Windows.Forms.ComboBox cmbBxTipoHab;
        private System.Windows.Forms.ComboBox cmbBxPiso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBxVista;
        private System.Windows.Forms.RadioButton radBtnNoDisp;
        private System.Windows.Forms.RadioButton radBtnDisp;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
    }
}