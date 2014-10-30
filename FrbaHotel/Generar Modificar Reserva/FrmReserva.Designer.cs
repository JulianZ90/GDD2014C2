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
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregarHabitacion = new System.Windows.Forms.Button();
            this.tableHabitaciones = new System.Windows.Forms.TableLayoutPanel();
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
            this.txtBxCostoTotal = new System.Windows.Forms.TextBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnDisponibilidad = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegimen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAgregarHabitacion);
            this.groupBox1.Controls.Add(this.tableHabitaciones);
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 355);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserva";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(325, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Habitaciones";
            // 
            // btnAgregarHabitacion
            // 
            this.btnAgregarHabitacion.Location = new System.Drawing.Point(417, 48);
            this.btnAgregarHabitacion.Name = "btnAgregarHabitacion";
            this.btnAgregarHabitacion.Size = new System.Drawing.Size(131, 23);
            this.btnAgregarHabitacion.TabIndex = 14;
            this.btnAgregarHabitacion.Text = "Agregar habitación";
            this.btnAgregarHabitacion.UseVisualStyleBackColor = true;
            this.btnAgregarHabitacion.Click += new System.EventHandler(this.btnAgregarHabitacion_Click);
            // 
            // tableHabitaciones
            // 
            this.tableHabitaciones.AutoSize = true;
            this.tableHabitaciones.ColumnCount = 4;
            this.tableHabitaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.36917F));
            this.tableHabitaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.63083F));
            this.tableHabitaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableHabitaciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableHabitaciones.Location = new System.Drawing.Point(328, 84);
            this.tableHabitaciones.Name = "tableHabitaciones";
            this.tableHabitaciones.RowCount = 1;
            this.tableHabitaciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableHabitaciones.Size = new System.Drawing.Size(474, 249);
            this.tableHabitaciones.TabIndex = 13;
            // 
            // cmbBxHoteles
            // 
            this.cmbBxHoteles.FormattingEnabled = true;
            this.cmbBxHoteles.Location = new System.Drawing.Point(417, 13);
            this.cmbBxHoteles.Name = "cmbBxHoteles";
            this.cmbBxHoteles.Size = new System.Drawing.Size(235, 21);
            this.cmbBxHoteles.TabIndex = 10;
            this.cmbBxHoteles.SelectedValueChanged += new System.EventHandler(this.cmbBxHoteles_SelectedValueChanged);
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(325, 16);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(62, 13);
            this.lblHotel.TabIndex = 9;
            this.lblHotel.Text = "Elegir hotel:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewRegimen);
            this.panel1.Location = new System.Drawing.Point(38, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 117);
            this.panel1.TabIndex = 8;
            // 
            // dataGridViewRegimen
            // 
            this.dataGridViewRegimen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegimen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRegimen.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRegimen.Name = "dataGridViewRegimen";
            this.dataGridViewRegimen.Size = new System.Drawing.Size(184, 117);
            this.dataGridViewRegimen.TabIndex = 0;
            this.dataGridViewRegimen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRegimen_CellClick);
            // 
            // tbnMostrarRegimen
            // 
            this.tbnMostrarRegimen.Location = new System.Drawing.Point(38, 169);
            this.tbnMostrarRegimen.Name = "tbnMostrarRegimen";
            this.tbnMostrarRegimen.Size = new System.Drawing.Size(184, 23);
            this.tbnMostrarRegimen.TabIndex = 7;
            this.tbnMostrarRegimen.Text = "Buscar régimenes del hotel";
            this.tbnMostrarRegimen.UseVisualStyleBackColor = true;
            this.tbnMostrarRegimen.Click += new System.EventHandler(this.tbnMostrarRegimen_Click);
            // 
            // txtBxRegimen
            // 
            this.txtBxRegimen.Location = new System.Drawing.Point(117, 128);
            this.txtBxRegimen.Name = "txtBxRegimen";
            this.txtBxRegimen.Size = new System.Drawing.Size(159, 20);
            this.txtBxRegimen.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fechas de estadía:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Régimen:";
            // 
            // dateTimeFin
            // 
            this.dateTimeFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFin.Location = new System.Drawing.Point(174, 79);
            this.dateTimeFin.Name = "dateTimeFin";
            this.dateTimeFin.Size = new System.Drawing.Size(102, 20);
            this.dateTimeFin.TabIndex = 3;
            // 
            // dateTimeInicio
            // 
            this.dateTimeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeInicio.Location = new System.Drawing.Point(38, 79);
            this.dateTimeInicio.Name = "dateTimeInicio";
            this.dateTimeInicio.Size = new System.Drawing.Size(102, 20);
            this.dateTimeInicio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde:";
            // 
            // txtBxCostoTotal
            // 
            this.txtBxCostoTotal.Location = new System.Drawing.Point(111, 380);
            this.txtBxCostoTotal.Name = "txtBxCostoTotal";
            this.txtBxCostoTotal.Size = new System.Drawing.Size(100, 20);
            this.txtBxCostoTotal.TabIndex = 16;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(9, 383);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(60, 13);
            this.lblCosto.TabIndex = 15;
            this.lblCosto.Text = "Costo total:";
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
            // btnDisponibilidad
            // 
            this.btnDisponibilidad.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisponibilidad.Location = new System.Drawing.Point(452, 373);
            this.btnDisponibilidad.Name = "btnDisponibilidad";
            this.btnDisponibilidad.Size = new System.Drawing.Size(182, 23);
            this.btnDisponibilidad.TabIndex = 3;
            this.btnDisponibilidad.Text = "Consultar Disponibilidad";
            this.btnDisponibilidad.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Calcular costo diario por habitación";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 408);
            this.Controls.Add(this.txtBxCostoTotal);
            this.Controls.Add(this.btnDisponibilidad);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReserva";
            this.Text = "Nueva Reserva";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegimen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TableLayoutPanel tableHabitaciones;
        private System.Windows.Forms.Button btnAgregarHabitacion;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.TextBox txtBxCostoTotal;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Button btnDisponibilidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;

    }
}