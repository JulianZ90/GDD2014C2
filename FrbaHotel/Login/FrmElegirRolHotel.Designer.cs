namespace FrbaHotel.Login
{
    partial class FrmElegirRolHotel
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
            this.cmbBoxRol = new System.Windows.Forms.ComboBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBoxHotel = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbBoxRol
            // 
            this.cmbBoxRol.FormattingEnabled = true;
            this.cmbBoxRol.Location = new System.Drawing.Point(152, 80);
            this.cmbBoxRol.Name = "cmbBoxRol";
            this.cmbBoxRol.Size = new System.Drawing.Size(222, 21);
            this.cmbBoxRol.TabIndex = 0;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(134, 125);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(85, 31);
            this.btnIngresar.TabIndex = 1;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Elija el rol:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Elija hotel:";
            // 
            // cmbBoxHotel
            // 
            this.cmbBoxHotel.FormattingEnabled = true;
            this.cmbBoxHotel.Location = new System.Drawing.Point(152, 29);
            this.cmbBoxHotel.Name = "cmbBoxHotel";
            this.cmbBoxHotel.Size = new System.Drawing.Size(222, 21);
            this.cmbBoxHotel.TabIndex = 4;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(48, 175);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(299, 16);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "No tiene asignado ese rol para ese hotel";
            // 
            // FrmElegirRolHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 212);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.cmbBoxHotel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.cmbBoxRol);
            this.Name = "FrmElegirRolHotel";
            this.Text = "Elegir rol y hotel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBoxRol;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBoxHotel;
        private System.Windows.Forms.Label lblError;
    }
}