﻿namespace FrbaHotel.ABM_de_Habitacion
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radBtnNoDisp = new System.Windows.Forms.RadioButton();
            this.radBtnDisp = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radBtnExterior = new System.Windows.Forms.RadioButton();
            this.radBtnInterior = new System.Windows.Forms.RadioButton();
            this.checkBxTipo = new System.Windows.Forms.CheckBox();
            this.txtBxPiso = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBxNroHab = new System.Windows.Forms.TextBox();
            this.cmbBxTipoHab = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Location = new System.Drawing.Point(12, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 274);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(627, 274);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.checkBxTipo);
            this.groupBox1.Controls.Add(this.txtBxPiso);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtBxNroHab);
            this.groupBox1.Controls.Add(this.cmbBxTipoHab);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 176);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Habitación";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radBtnNoDisp);
            this.groupBox3.Controls.Add(this.radBtnDisp);
            this.groupBox3.Location = new System.Drawing.Point(320, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 61);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Habitación";
            // 
            // radBtnNoDisp
            // 
            this.radBtnNoDisp.AutoSize = true;
            this.radBtnNoDisp.Location = new System.Drawing.Point(47, 29);
            this.radBtnNoDisp.Name = "radBtnNoDisp";
            this.radBtnNoDisp.Size = new System.Drawing.Size(101, 17);
            this.radBtnNoDisp.TabIndex = 11;
            this.radBtnNoDisp.TabStop = true;
            this.radBtnNoDisp.Text = "No disponible";
            this.radBtnNoDisp.UseVisualStyleBackColor = true;
            // 
            // radBtnDisp
            // 
            this.radBtnDisp.AutoSize = true;
            this.radBtnDisp.Location = new System.Drawing.Point(158, 29);
            this.radBtnDisp.Name = "radBtnDisp";
            this.radBtnDisp.Size = new System.Drawing.Size(84, 17);
            this.radBtnDisp.TabIndex = 10;
            this.radBtnDisp.TabStop = true;
            this.radBtnDisp.Text = "Disponible";
            this.radBtnDisp.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radBtnExterior);
            this.groupBox2.Controls.Add(this.radBtnInterior);
            this.groupBox2.Location = new System.Drawing.Point(10, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 63);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ubicación";
            // 
            // radBtnExterior
            // 
            this.radBtnExterior.AutoSize = true;
            this.radBtnExterior.Location = new System.Drawing.Point(30, 32);
            this.radBtnExterior.Name = "radBtnExterior";
            this.radBtnExterior.Size = new System.Drawing.Size(70, 17);
            this.radBtnExterior.TabIndex = 14;
            this.radBtnExterior.TabStop = true;
            this.radBtnExterior.Text = "Exterior";
            this.radBtnExterior.UseVisualStyleBackColor = true;
            // 
            // radBtnInterior
            // 
            this.radBtnInterior.AutoSize = true;
            this.radBtnInterior.Location = new System.Drawing.Point(129, 32);
            this.radBtnInterior.Name = "radBtnInterior";
            this.radBtnInterior.Size = new System.Drawing.Size(68, 17);
            this.radBtnInterior.TabIndex = 15;
            this.radBtnInterior.TabStop = true;
            this.radBtnInterior.Text = "Interior";
            this.radBtnInterior.UseVisualStyleBackColor = true;
            // 
            // checkBxTipo
            // 
            this.checkBxTipo.AutoSize = true;
            this.checkBxTipo.Location = new System.Drawing.Point(590, 31);
            this.checkBxTipo.Name = "checkBxTipo";
            this.checkBxTipo.Size = new System.Drawing.Size(15, 14);
            this.checkBxTipo.TabIndex = 13;
            this.checkBxTipo.UseVisualStyleBackColor = true;
            this.checkBxTipo.CheckedChanged += new System.EventHandler(this.checkBxTipo_CheckedChanged);
            // 
            // txtBxPiso
            // 
            this.txtBxPiso.Location = new System.Drawing.Point(159, 69);
            this.txtBxPiso.Name = "txtBxPiso";
            this.txtBxPiso.Size = new System.Drawing.Size(121, 21);
            this.txtBxPiso.TabIndex = 12;
            this.txtBxPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxPiso_KeyPress);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(516, 147);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(424, 147);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBxNroHab
            // 
            this.txtBxNroHab.Location = new System.Drawing.Point(159, 28);
            this.txtBxNroHab.Name = "txtBxNroHab";
            this.txtBxNroHab.Size = new System.Drawing.Size(121, 21);
            this.txtBxNroHab.TabIndex = 5;
            this.txtBxNroHab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBxNroHab_KeyPress);
            // 
            // cmbBxTipoHab
            // 
            this.cmbBxTipoHab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxTipoHab.FormattingEnabled = true;
            this.cmbBxTipoHab.Location = new System.Drawing.Point(443, 28);
            this.cmbBxTipoHab.Name = "cmbBxTipoHab";
            this.cmbBxTipoHab.Size = new System.Drawing.Size(121, 21);
            this.cmbBxTipoHab.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de habitación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 73);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.RadioButton radBtnNoDisp;
        private System.Windows.Forms.RadioButton radBtnDisp;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBxPiso;
        private System.Windows.Forms.CheckBox checkBxTipo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radBtnExterior;
        private System.Windows.Forms.RadioButton radBtnInterior;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}