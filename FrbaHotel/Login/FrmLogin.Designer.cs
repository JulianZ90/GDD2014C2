namespace FrbaHotel.Login
{
    partial class FrmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIncorrecta = new System.Windows.Forms.Label();
            this.lblInhabilitado = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnGuest = new System.Windows.Forms.Button();
            this.txtBoxUser = new System.Windows.Forms.TextBox();
            this.txtBoxPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUserIncorrecto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido al Sistema Hotelero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "FRBA - Hotel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contraseña:";
            // 
            // lblIncorrecta
            // 
            this.lblIncorrecta.AutoSize = true;
            this.lblIncorrecta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncorrecta.ForeColor = System.Drawing.Color.Red;
            this.lblIncorrecta.Location = new System.Drawing.Point(350, 242);
            this.lblIncorrecta.Name = "lblIncorrecta";
            this.lblIncorrecta.Size = new System.Drawing.Size(139, 16);
            this.lblIncorrecta.TabIndex = 4;
            this.lblIncorrecta.Text = "Contraseña incorrecta";
            // 
            // lblInhabilitado
            // 
            this.lblInhabilitado.AutoSize = true;
            this.lblInhabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInhabilitado.ForeColor = System.Drawing.Color.Red;
            this.lblInhabilitado.Location = new System.Drawing.Point(105, 354);
            this.lblInhabilitado.Name = "lblInhabilitado";
            this.lblInhabilitado.Size = new System.Drawing.Size(194, 24);
            this.lblInhabilitado.TabIndex = 5;
            this.lblInhabilitado.Text = "Usuario Inhabilitado";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(71, 297);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(106, 35);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnGuest
            // 
            this.btnGuest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuest.Location = new System.Drawing.Point(254, 298);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(202, 35);
            this.btnGuest.TabIndex = 7;
            this.btnGuest.Text = "Ingresar como invitado";
            this.btnGuest.UseVisualStyleBackColor = true;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click);
            // 
            // txtBoxUser
            // 
            this.txtBoxUser.Location = new System.Drawing.Point(217, 186);
            this.txtBoxUser.Name = "txtBoxUser";
            this.txtBoxUser.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUser.TabIndex = 8;
            this.txtBoxUser.Text = "admin";
            // 
            // txtBoxPass
            // 
            this.txtBoxPass.Location = new System.Drawing.Point(217, 241);
            this.txtBoxPass.Name = "txtBoxPass";
            this.txtBoxPass.PasswordChar = '*';
            this.txtBoxPass.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPass.TabIndex = 9;
            this.txtBoxPass.Text = "w23e";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(322, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Por favor ingrese sus datos para acceder al sistema:";
            // 
            // lblUserIncorrecto
            // 
            this.lblUserIncorrecto.AutoSize = true;
            this.lblUserIncorrecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIncorrecto.ForeColor = System.Drawing.Color.Red;
            this.lblUserIncorrecto.Location = new System.Drawing.Point(350, 190);
            this.lblUserIncorrecto.Name = "lblUserIncorrecto";
            this.lblUserIncorrecto.Size = new System.Drawing.Size(129, 16);
            this.lblUserIncorrecto.TabIndex = 11;
            this.lblUserIncorrecto.Text = "No Existe el Usuario";
            this.lblUserIncorrecto.Click += new System.EventHandler(this.label5_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 399);
            this.Controls.Add(this.lblUserIncorrecto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBoxPass);
            this.Controls.Add(this.txtBoxUser);
            this.Controls.Add(this.btnGuest);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblInhabilitado);
            this.Controls.Add(this.lblIncorrecta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIncorrecta;
        private System.Windows.Forms.Label lblInhabilitado;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.TextBox txtBoxUser;
        private System.Windows.Forms.TextBox txtBoxPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUserIncorrecto;
    }
}