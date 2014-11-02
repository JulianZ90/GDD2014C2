namespace FrbaHotel
{
    partial class FrmGuest
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
            this.btnGenerarReserva = new System.Windows.Forms.Button();
            this.btnModificarReserva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerarReserva
            // 
            this.btnGenerarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReserva.Location = new System.Drawing.Point(55, 54);
            this.btnGenerarReserva.Name = "btnGenerarReserva";
            this.btnGenerarReserva.Size = new System.Drawing.Size(238, 43);
            this.btnGenerarReserva.TabIndex = 0;
            this.btnGenerarReserva.Text = "Generar Nueva Reserva";
            this.btnGenerarReserva.UseVisualStyleBackColor = true;
            this.btnGenerarReserva.Click += new System.EventHandler(this.btnGenerarReserva_Click);
            // 
            // btnModificarReserva
            // 
            this.btnModificarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarReserva.Location = new System.Drawing.Point(55, 125);
            this.btnModificarReserva.Name = "btnModificarReserva";
            this.btnModificarReserva.Size = new System.Drawing.Size(238, 65);
            this.btnModificarReserva.TabIndex = 1;
            this.btnModificarReserva.Text = "Modificar o Cancelar Reserva";
            this.btnModificarReserva.UseVisualStyleBackColor = true;
            this.btnModificarReserva.Click += new System.EventHandler(this.btnModificarReserva_Click);
            // 
            // FrmGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 248);
            this.Controls.Add(this.btnModificarReserva);
            this.Controls.Add(this.btnGenerarReserva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGuest";
            this.Text = "Invitado";
            this.Load += new System.EventHandler(this.FrmGuest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarReserva;
        private System.Windows.Forms.Button btnModificarReserva;
    }
}