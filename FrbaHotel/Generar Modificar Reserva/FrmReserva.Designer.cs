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
            this.btnEliminarHab = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBxCostoDiario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBxTipoHab = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBxDetalle = new System.Windows.Forms.TextBox();
            this.btnAgregarHabitacion = new System.Windows.Forms.Button();
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegimen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminarHab);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtBxDetalle);
            this.groupBox1.Controls.Add(this.btnAgregarHabitacion);
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
            // btnEliminarHab
            // 
            this.btnEliminarHab.Location = new System.Drawing.Point(469, 314);
            this.btnEliminarHab.Name = "btnEliminarHab";
            this.btnEliminarHab.Size = new System.Drawing.Size(167, 23);
            this.btnEliminarHab.TabIndex = 20;
            this.btnEliminarHab.Text = "Eliminar todas las habitaciones";
            this.btnEliminarHab.UseVisualStyleBackColor = true;
            this.btnEliminarHab.Click += new System.EventHandler(this.btnEliminarHab_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(373, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Detalle de habitaciones reservadas:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBxCostoDiario);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbBxTipoHab);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(321, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 63);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Habitación";
            // 
            // txtBxCostoDiario
            // 
            this.txtBxCostoDiario.Location = new System.Drawing.Point(360, 28);
            this.txtBxCostoDiario.Name = "txtBxCostoDiario";
            this.txtBxCostoDiario.Size = new System.Drawing.Size(100, 20);
            this.txtBxCostoDiario.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Costo Diario:";
            // 
            // cmbBxTipoHab
            // 
            this.cmbBxTipoHab.FormattingEnabled = true;
            this.cmbBxTipoHab.Location = new System.Drawing.Point(112, 28);
            this.cmbBxTipoHab.Name = "cmbBxTipoHab";
            this.cmbBxTipoHab.Size = new System.Drawing.Size(146, 21);
            this.cmbBxTipoHab.TabIndex = 1;
            this.cmbBxTipoHab.SelectedValueChanged += new System.EventHandler(this.cmbBxTipoHab_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tipo de Habitaciòn:";
            // 
            // txtBxDetalle
            // 
            this.txtBxDetalle.Location = new System.Drawing.Point(376, 210);
            this.txtBxDetalle.Multiline = true;
            this.txtBxDetalle.Name = "txtBxDetalle";
            this.txtBxDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBxDetalle.Size = new System.Drawing.Size(356, 98);
            this.txtBxDetalle.TabIndex = 17;
            // 
            // btnAgregarHabitacion
            // 
            this.btnAgregarHabitacion.Location = new System.Drawing.Point(330, 147);
            this.btnAgregarHabitacion.Name = "btnAgregarHabitacion";
            this.btnAgregarHabitacion.Size = new System.Drawing.Size(170, 23);
            this.btnAgregarHabitacion.TabIndex = 14;
            this.btnAgregarHabitacion.Text = "Agregar habitación a la reserva";
            this.btnAgregarHabitacion.UseVisualStyleBackColor = true;
            this.btnAgregarHabitacion.Click += new System.EventHandler(this.btnAgregarHabitacion_Click);
            // 
            // cmbBxHoteles
            // 
            this.cmbBxHoteles.FormattingEnabled = true;
            this.cmbBxHoteles.Location = new System.Drawing.Point(81, 18);
            this.cmbBxHoteles.Name = "cmbBxHoteles";
            this.cmbBxHoteles.Size = new System.Drawing.Size(235, 21);
            this.cmbBxHoteles.TabIndex = 10;
            this.cmbBxHoteles.SelectedValueChanged += new System.EventHandler(this.cmbBxHoteles_SelectedValueChanged);
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(13, 21);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(62, 13);
            this.lblHotel.TabIndex = 9;
            this.lblHotel.Text = "Elegir hotel:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewRegimen);
            this.panel1.Location = new System.Drawing.Point(38, 208);
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
            this.tbnMostrarRegimen.Location = new System.Drawing.Point(38, 152);
            this.tbnMostrarRegimen.Name = "tbnMostrarRegimen";
            this.tbnMostrarRegimen.Size = new System.Drawing.Size(184, 23);
            this.tbnMostrarRegimen.TabIndex = 7;
            this.tbnMostrarRegimen.Text = "Seleccione un régimen del hotel";
            this.tbnMostrarRegimen.UseVisualStyleBackColor = true;
            this.tbnMostrarRegimen.Click += new System.EventHandler(this.tbnMostrarRegimen_Click);
            // 
            // txtBxRegimen
            // 
            this.txtBxRegimen.Location = new System.Drawing.Point(95, 94);
            this.txtBxRegimen.Name = "txtBxRegimen";
            this.txtBxRegimen.Size = new System.Drawing.Size(159, 20);
            this.txtBxRegimen.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(334, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fechas de estadía:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Régimen:";
            // 
            // dateTimeFin
            // 
            this.dateTimeFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFin.Location = new System.Drawing.Point(614, 52);
            this.dateTimeFin.Name = "dateTimeFin";
            this.dateTimeFin.Size = new System.Drawing.Size(102, 20);
            this.dateTimeFin.TabIndex = 3;
            // 
            // dateTimeInicio
            // 
            this.dateTimeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeInicio.Location = new System.Drawing.Point(469, 52);
            this.dateTimeInicio.Name = "dateTimeInicio";
            this.dateTimeInicio.Size = new System.Drawing.Size(102, 20);
            this.dateTimeInicio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde:";
            // 
            // txtBxCostoTotal
            // 
            this.txtBxCostoTotal.Location = new System.Drawing.Point(290, 376);
            this.txtBxCostoTotal.Name = "txtBxCostoTotal";
            this.txtBxCostoTotal.Size = new System.Drawing.Size(100, 20);
            this.txtBxCostoTotal.TabIndex = 16;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Location = new System.Drawing.Point(215, 379);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(72, 13);
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
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(12, 373);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 408);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtBxCostoTotal);
            this.Controls.Add(this.btnDisponibilidad);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCosto);
            this.Name = "FrmReserva";
            this.Text = "Nueva Reserva";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button btnAgregarHabitacion;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.TextBox txtBxCostoTotal;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Button btnDisponibilidad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBxCostoDiario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBxTipoHab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBxDetalle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminarHab;

    }
}