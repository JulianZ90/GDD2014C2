namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class FrmReserva
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBxCostoTotal = new System.Windows.Forms.TextBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.btnAgregarHabitacion = new System.Windows.Forms.Button();
            this.tableHabitaciones = new System.Windows.Forms.TableLayoutPanel();
            this.cmbBxTipoHab = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBxCostoDia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBxHoteles = new System.Windows.Forms.ComboBox();
            this.lblHotel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewRegimen = new System.Windows.Forms.DataGridView();
            this.tbnMostrarRegimen = new System.Windows.Forms.Button();
            this.txtBxRegimen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimeFin = new System.Windows.Forms.DateTimePicker();
            this.dateTimeInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnDisponibilidad = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableHabitaciones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegimen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBxCostoTotal);
            this.groupBox1.Controls.Add(this.lblCosto);
            this.groupBox1.Controls.Add(this.btnAgregarHabitacion);
            this.groupBox1.Controls.Add(this.tableHabitaciones);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbBxHoteles);
            this.groupBox1.Controls.Add(this.lblHotel);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.tbnMostrarRegimen);
            this.groupBox1.Controls.Add(this.txtBxRegimen);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimeFin);
            this.groupBox1.Controls.Add(this.dateTimeInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserva";
            // 
            // txtBxCostoTotal
            // 
            this.txtBxCostoTotal.Location = new System.Drawing.Point(415, 318);
            this.txtBxCostoTotal.Name = "txtBxCostoTotal";
            this.txtBxCostoTotal.Size = new System.Drawing.Size(100, 21);
            this.txtBxCostoTotal.TabIndex = 16;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(313, 321);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(74, 13);
            this.lblCosto.TabIndex = 15;
            this.lblCosto.Text = "Costo total:";
            // 
            // btnAgregarHabitacion
            // 
            this.btnAgregarHabitacion.Location = new System.Drawing.Point(476, 57);
            this.btnAgregarHabitacion.Name = "btnAgregarHabitacion";
            this.btnAgregarHabitacion.Size = new System.Drawing.Size(131, 23);
            this.btnAgregarHabitacion.TabIndex = 14;
            this.btnAgregarHabitacion.Text = "Agregar habitación";
            this.btnAgregarHabitacion.UseVisualStyleBackColor = true;
            // 
            // tableHabitaciones
            // 
            this.tableHabitaciones.ColumnCount = 4;
            this.tableHabitaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.36917F));
            this.tableHabitaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.63083F));
            this.tableHabitaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableHabitaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableHabitaciones.Controls.Add(this.cmbBxTipoHab, 1, 0);
            this.tableHabitaciones.Controls.Add(this.label6, 0, 0);
            this.tableHabitaciones.Controls.Add(this.label8, 2, 0);
            this.tableHabitaciones.Controls.Add(this.txtBxCostoDia, 3, 0);
            this.tableHabitaciones.Location = new System.Drawing.Point(316, 93);
            this.tableHabitaciones.Name = "tableHabitaciones";
            this.tableHabitaciones.RowCount = 1;
            this.tableHabitaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableHabitaciones.Size = new System.Drawing.Size(474, 214);
            this.tableHabitaciones.TabIndex = 13;
            // 
            // cmbBxTipoHab
            // 
            this.cmbBxTipoHab.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbBxTipoHab.FormattingEnabled = true;
            this.cmbBxTipoHab.Location = new System.Drawing.Point(123, 3);
            this.cmbBxTipoHab.Name = "cmbBxTipoHab";
            this.cmbBxTipoHab.Size = new System.Drawing.Size(150, 21);
            this.cmbBxTipoHab.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tipo de habitación";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(279, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Costo por día";
            // 
            // txtBxCostoDia
            // 
            this.txtBxCostoDia.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBxCostoDia.Location = new System.Drawing.Point(375, 3);
            this.txtBxCostoDia.Name = "txtBxCostoDia";
            this.txtBxCostoDia.Size = new System.Drawing.Size(96, 21);
            this.txtBxCostoDia.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(310, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Habitaciones";
            // 
            // cmbBxHoteles
            // 
            this.cmbBxHoteles.FormattingEnabled = true;
            this.cmbBxHoteles.Location = new System.Drawing.Point(392, 13);
            this.cmbBxHoteles.Name = "cmbBxHoteles";
            this.cmbBxHoteles.Size = new System.Drawing.Size(235, 21);
            this.cmbBxHoteles.TabIndex = 10;
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(310, 16);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(76, 13);
            this.lblHotel.TabIndex = 9;
            this.lblHotel.Text = "Elegir hotel:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewRegimen);
            this.panel1.Location = new System.Drawing.Point(28, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 126);
            this.panel1.TabIndex = 8;
            // 
            // dataGridViewRegimen
            // 
            this.dataGridViewRegimen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegimen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRegimen.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRegimen.Name = "dataGridViewRegimen";
            this.dataGridViewRegimen.Size = new System.Drawing.Size(184, 126);
            this.dataGridViewRegimen.TabIndex = 0;
            // 
            // tbnMostrarRegimen
            // 
            this.tbnMostrarRegimen.Location = new System.Drawing.Point(28, 154);
            this.tbnMostrarRegimen.Name = "tbnMostrarRegimen";
            this.tbnMostrarRegimen.Size = new System.Drawing.Size(184, 23);
            this.tbnMostrarRegimen.TabIndex = 7;
            this.tbnMostrarRegimen.Text = "Buscar régimenes del hotel";
            this.tbnMostrarRegimen.UseVisualStyleBackColor = true;
            // 
            // txtBxRegimen
            // 
            this.txtBxRegimen.Location = new System.Drawing.Point(112, 112);
            this.txtBxRegimen.Name = "txtBxRegimen";
            this.txtBxRegimen.Size = new System.Drawing.Size(100, 21);
            this.txtBxRegimen.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fechas de estadía:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Régimen:";
            // 
            // dateTimeFin
            // 
            this.dateTimeFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFin.Location = new System.Drawing.Point(171, 67);
            this.dateTimeFin.Name = "dateTimeFin";
            this.dateTimeFin.Size = new System.Drawing.Size(102, 21);
            this.dateTimeFin.TabIndex = 3;
            // 
            // dateTimeInicio
            // 
            this.dateTimeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeInicio.Location = new System.Drawing.Point(37, 67);
            this.dateTimeInicio.Name = "dateTimeInicio";
            this.dateTimeInicio.Size = new System.Drawing.Size(102, 21);
            this.dateTimeInicio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde:";
            // 
            // btnReservar
            // 
            this.btnReservar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservar.Location = new System.Drawing.Point(660, 373);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(139, 23);
            this.btnReservar.TabIndex = 1;
            this.btnReservar.Text = "Generar Reserva";
            this.btnReservar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(12, 373);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnDisponibilidad
            // 
            this.btnDisponibilidad.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisponibilidad.Location = new System.Drawing.Point(449, 373);
            this.btnDisponibilidad.Name = "btnDisponibilidad";
            this.btnDisponibilidad.Size = new System.Drawing.Size(182, 23);
            this.btnDisponibilidad.TabIndex = 3;
            this.btnDisponibilidad.Text = "Consultar Disponibilidad";
            this.btnDisponibilidad.UseVisualStyleBackColor = true;
            // 
            // FrmReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 408);
            this.Controls.Add(this.btnDisponibilidad);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReserva";
            this.Text = "Nueva Reserva";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableHabitaciones.ResumeLayout(false);
            this.tableHabitaciones.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegimen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimeInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimeFin;
        private System.Windows.Forms.ComboBox cmbBxHoteles;
        private System.Windows.Forms.Label lblHotel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewRegimen;
        private System.Windows.Forms.Button tbnMostrarRegimen;
        private System.Windows.Forms.TextBox txtBxRegimen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableHabitaciones;
        private System.Windows.Forms.Button btnAgregarHabitacion;
        private System.Windows.Forms.ComboBox cmbBxTipoHab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBxCostoDia;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtBxCostoTotal;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Button btnDisponibilidad;

    }
}