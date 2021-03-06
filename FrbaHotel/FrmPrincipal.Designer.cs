﻿namespace FrbaHotel
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarOEliminarRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.altaClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarHabitacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regimenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarOCancelarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadíaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.altaHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumiblesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoConsumibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarConsumibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarConsumibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitacionesOcupadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitacionesDeUnaEstadiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codigoDeReservaDeUnaHabitacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.asignarRolAUsuarioExistenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewMenu,
            this.consultasToolStripMenuItem,
            this.windowsMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(582, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarContraseñaToolStripMenuItem,
            this.rolesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem5,
            this.habitaciónToolStripMenuItem,
            this.regimenToolStripMenuItem,
            this.reservasToolStripMenuItem,
            this.estadíaToolStripMenuItem,
            this.listadosToolStripMenuItem,
            this.toolStripMenuItem4,
            this.consumiblesToolStripMenuItem,
            this.toolStripMenuItem6,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(95, 20);
            this.fileMenu.Text = "&Funcionalidades";
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
            this.cambiarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoRolToolStripMenuItem,
            this.modificarOEliminarRolToolStripMenuItem});
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.rolesToolStripMenuItem.Text = "Roles";
            // 
            // nuevoRolToolStripMenuItem
            // 
            this.nuevoRolToolStripMenuItem.Name = "nuevoRolToolStripMenuItem";
            this.nuevoRolToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.nuevoRolToolStripMenuItem.Text = "Nuevo Rol";
            this.nuevoRolToolStripMenuItem.Click += new System.EventHandler(this.nuevoRolToolStripMenuItem_Click);
            // 
            // modificarOEliminarRolToolStripMenuItem
            // 
            this.modificarOEliminarRolToolStripMenuItem.Name = "modificarOEliminarRolToolStripMenuItem";
            this.modificarOEliminarRolToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.modificarOEliminarRolToolStripMenuItem.Text = "Modificar o Eliminar Rol";
            this.modificarOEliminarRolToolStripMenuItem.Click += new System.EventHandler(this.modificarOEliminarRolToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.asignarRolAUsuarioExistenteToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem1.Text = "Usuarios";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(231, 22);
            this.toolStripMenuItem2.Text = "Usuarios de este hotel";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(231, 22);
            this.toolStripMenuItem3.Text = "Nuevo Usuario";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaClienteToolStripMenuItem,
            this.listadoToolStripMenuItem});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem5.Text = "Clientes";
            // 
            // altaClienteToolStripMenuItem
            // 
            this.altaClienteToolStripMenuItem.Name = "altaClienteToolStripMenuItem";
            this.altaClienteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.altaClienteToolStripMenuItem.Text = "Alta Cliente";
            this.altaClienteToolStripMenuItem.Click += new System.EventHandler(this.altaClienteToolStripMenuItem_Click);
            // 
            // listadoToolStripMenuItem
            // 
            this.listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            this.listadoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.listadoToolStripMenuItem.Text = "Listado Clientes";
            this.listadoToolStripMenuItem.Click += new System.EventHandler(this.listadoToolStripMenuItem_Click);
            // 
            // habitaciónToolStripMenuItem
            // 
            this.habitaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaToolStripMenuItem,
            this.listarHabitacionesToolStripMenuItem});
            this.habitaciónToolStripMenuItem.Name = "habitaciónToolStripMenuItem";
            this.habitaciónToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.habitaciónToolStripMenuItem.Text = "Habitación";
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.nuevaToolStripMenuItem.Text = "Nueva Habitación";
            this.nuevaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // listarHabitacionesToolStripMenuItem
            // 
            this.listarHabitacionesToolStripMenuItem.Name = "listarHabitacionesToolStripMenuItem";
            this.listarHabitacionesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.listarHabitacionesToolStripMenuItem.Text = "Listar Habitaciones";
            this.listarHabitacionesToolStripMenuItem.Click += new System.EventHandler(this.listarHabitacionesToolStripMenuItem_Click);
            // 
            // regimenToolStripMenuItem
            // 
            this.regimenToolStripMenuItem.Name = "regimenToolStripMenuItem";
            this.regimenToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.regimenToolStripMenuItem.Text = "Regimen";
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaReservaToolStripMenuItem,
            this.modificarOCancelarReservaToolStripMenuItem});
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.reservasToolStripMenuItem.Text = "Reservas";
            // 
            // nuevaReservaToolStripMenuItem
            // 
            this.nuevaReservaToolStripMenuItem.Name = "nuevaReservaToolStripMenuItem";
            this.nuevaReservaToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.nuevaReservaToolStripMenuItem.Text = "Nueva Reserva";
            this.nuevaReservaToolStripMenuItem.Click += new System.EventHandler(this.nuevaReservaToolStripMenuItem_Click);
            // 
            // modificarOCancelarReservaToolStripMenuItem
            // 
            this.modificarOCancelarReservaToolStripMenuItem.Name = "modificarOCancelarReservaToolStripMenuItem";
            this.modificarOCancelarReservaToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.modificarOCancelarReservaToolStripMenuItem.Text = "Modificar o Cancelar Reserva";
            this.modificarOCancelarReservaToolStripMenuItem.Click += new System.EventHandler(this.modificarOCancelarReservaToolStripMenuItem_Click);
            // 
            // estadíaToolStripMenuItem
            // 
            this.estadíaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkInToolStripMenuItem,
            this.checkOutToolStripMenuItem});
            this.estadíaToolStripMenuItem.Name = "estadíaToolStripMenuItem";
            this.estadíaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.estadíaToolStripMenuItem.Text = "Registrar Estadia";
            // 
            // checkInToolStripMenuItem
            // 
            this.checkInToolStripMenuItem.Name = "checkInToolStripMenuItem";
            this.checkInToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.checkInToolStripMenuItem.Text = "Checkin";
            this.checkInToolStripMenuItem.Click += new System.EventHandler(this.checkInToolStripMenuItem_Click);
            // 
            // checkOutToolStripMenuItem
            // 
            this.checkOutToolStripMenuItem.Name = "checkOutToolStripMenuItem";
            this.checkOutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.checkOutToolStripMenuItem.Text = "Checkout";
            this.checkOutToolStripMenuItem.Click += new System.EventHandler(this.checkOutToolStripMenuItem_Click);
            // 
            // listadosToolStripMenuItem
            // 
            this.listadosToolStripMenuItem.Name = "listadosToolStripMenuItem";
            this.listadosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.listadosToolStripMenuItem.Text = "Listados";
            this.listadosToolStripMenuItem.Click += new System.EventHandler(this.listadosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaHotelToolStripMenuItem,
            this.listadoHotelToolStripMenuItem});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem4.Text = "Hoteles";
            // 
            // altaHotelToolStripMenuItem
            // 
            this.altaHotelToolStripMenuItem.Name = "altaHotelToolStripMenuItem";
            this.altaHotelToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.altaHotelToolStripMenuItem.Text = "Alta Hotel";
            this.altaHotelToolStripMenuItem.Click += new System.EventHandler(this.altaHotelToolStripMenuItem_Click);
            // 
            // listadoHotelToolStripMenuItem
            // 
            this.listadoHotelToolStripMenuItem.Name = "listadoHotelToolStripMenuItem";
            this.listadoHotelToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.listadoHotelToolStripMenuItem.Text = "Listar Hoteles";
            this.listadoHotelToolStripMenuItem.Click += new System.EventHandler(this.listadoHotelToolStripMenuItem_Click);
            // 
            // consumiblesToolStripMenuItem
            // 
            this.consumiblesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoConsumibleToolStripMenuItem,
            this.modificarConsumibleToolStripMenuItem,
            this.registrarConsumibleToolStripMenuItem});
            this.consumiblesToolStripMenuItem.Name = "consumiblesToolStripMenuItem";
            this.consumiblesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.consumiblesToolStripMenuItem.Text = "Consumibles";
            // 
            // nuevoConsumibleToolStripMenuItem
            // 
            this.nuevoConsumibleToolStripMenuItem.Name = "nuevoConsumibleToolStripMenuItem";
            this.nuevoConsumibleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.nuevoConsumibleToolStripMenuItem.Text = "alta consumible";
            this.nuevoConsumibleToolStripMenuItem.Click += new System.EventHandler(this.nuevoConsumibleToolStripMenuItem_Click);
            // 
            // modificarConsumibleToolStripMenuItem
            // 
            this.modificarConsumibleToolStripMenuItem.Name = "modificarConsumibleToolStripMenuItem";
            this.modificarConsumibleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.modificarConsumibleToolStripMenuItem.Text = "listado consumibles";
            this.modificarConsumibleToolStripMenuItem.Click += new System.EventHandler(this.modificarConsumibleToolStripMenuItem_Click);
            // 
            // registrarConsumibleToolStripMenuItem
            // 
            this.registrarConsumibleToolStripMenuItem.Name = "registrarConsumibleToolStripMenuItem";
            this.registrarConsumibleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.registrarConsumibleToolStripMenuItem.Text = "Registrar Consumible";
            this.registrarConsumibleToolStripMenuItem.Click += new System.EventHandler(this.registrarConsumibleToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exitToolStripMenuItem.Text = "Cerrar Sesion";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(35, 20);
            this.viewMenu.Text = "&Ver";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.toolBarToolStripMenuItem.Text = "&Barra de herramientas";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.statusBarToolStripMenuItem.Text = "&Barra de estado";
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.habitacionesOcupadasToolStripMenuItem,
            this.habitacionesDeUnaEstadiaToolStripMenuItem,
            this.codigoDeReservaDeUnaHabitacionToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // habitacionesOcupadasToolStripMenuItem
            // 
            this.habitacionesOcupadasToolStripMenuItem.Name = "habitacionesOcupadasToolStripMenuItem";
            this.habitacionesOcupadasToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.habitacionesOcupadasToolStripMenuItem.Text = "Habitaciones ocupadas";
            this.habitacionesOcupadasToolStripMenuItem.Click += new System.EventHandler(this.habitacionesOcupadasToolStripMenuItem_Click);
            // 
            // habitacionesDeUnaEstadiaToolStripMenuItem
            // 
            this.habitacionesDeUnaEstadiaToolStripMenuItem.Name = "habitacionesDeUnaEstadiaToolStripMenuItem";
            this.habitacionesDeUnaEstadiaToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.habitacionesDeUnaEstadiaToolStripMenuItem.Text = "Habitaciones de una estadia";
            this.habitacionesDeUnaEstadiaToolStripMenuItem.Click += new System.EventHandler(this.habitacionesDeUnaEstadiaToolStripMenuItem_Click);
            // 
            // codigoDeReservaDeUnaHabitacionToolStripMenuItem
            // 
            this.codigoDeReservaDeUnaHabitacionToolStripMenuItem.Name = "codigoDeReservaDeUnaHabitacionToolStripMenuItem";
            this.codigoDeReservaDeUnaHabitacionToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.codigoDeReservaDeUnaHabitacionToolStripMenuItem.Text = "Codigo de reserva de una habitacion";
            this.codigoDeReservaDeUnaHabitacionToolStripMenuItem.Click += new System.EventHandler(this.codigoDeReservaDeUnaHabitacionToolStripMenuItem_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAllToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(64, 20);
            this.windowsMenu.Text = "&Ventanas";
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.closeAllToolStripMenuItem.Text = "C&errar todo";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 403);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(582, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // asignarRolAUsuarioExistenteToolStripMenuItem
            // 
            this.asignarRolAUsuarioExistenteToolStripMenuItem.Name = "asignarRolAUsuarioExistenteToolStripMenuItem";
            this.asignarRolAUsuarioExistenteToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.asignarRolAUsuarioExistenteToolStripMenuItem.Text = "Asignar rol a usuario existente";
            this.asignarRolAUsuarioExistenteToolStripMenuItem.Click += new System.EventHandler(this.asignarRolAUsuarioExistenteToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(582, 425);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmPrincipal";
            this.Text = "GAME OF QUERYS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarOEliminarRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarHabitacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem altaHotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoHotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consumiblesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoConsumibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarConsumibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem altaClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarOCancelarReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadíaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regimenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem checkInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarConsumibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesOcupadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesDeUnaEstadiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codigoDeReservaDeUnaHabitacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarRolAUsuarioExistenteToolStripMenuItem;
    }
}



