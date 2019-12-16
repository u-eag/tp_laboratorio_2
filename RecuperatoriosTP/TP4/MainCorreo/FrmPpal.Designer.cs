namespace MainCorreo
{
    partial class FrmPpal
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
            this.gbxEstadosPaquetes = new System.Windows.Forms.GroupBox();
            this.lblIngresado = new System.Windows.Forms.Label();
            this.lblEnViaje = new System.Windows.Forms.Label();
            this.lblEntregado = new System.Windows.Forms.Label();
            this.gbxPaquete = new System.Windows.Forms.GroupBox();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.mtxtTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.lstEstadoIngresado = new System.Windows.Forms.ListBox();
            this.lstEstadoEnViaje = new System.Windows.Forms.ListBox();
            this.lstEstadoEntregado = new System.Windows.Forms.ListBox();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.gbxEstadosPaquetes.SuspendLayout();
            this.gbxPaquete.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxEstadosPaquetes
            // 
            this.gbxEstadosPaquetes.Controls.Add(this.lstEstadoEntregado);
            this.gbxEstadosPaquetes.Controls.Add(this.lstEstadoEnViaje);
            this.gbxEstadosPaquetes.Controls.Add(this.lstEstadoIngresado);
            this.gbxEstadosPaquetes.Controls.Add(this.lblEntregado);
            this.gbxEstadosPaquetes.Controls.Add(this.lblEnViaje);
            this.gbxEstadosPaquetes.Controls.Add(this.lblIngresado);
            this.gbxEstadosPaquetes.Location = new System.Drawing.Point(15, 19);
            this.gbxEstadosPaquetes.Name = "gbxEstadosPaquetes";
            this.gbxEstadosPaquetes.Size = new System.Drawing.Size(764, 231);
            this.gbxEstadosPaquetes.TabIndex = 0;
            this.gbxEstadosPaquetes.TabStop = false;
            this.gbxEstadosPaquetes.Text = "Estados Paquetes";
            // 
            // lblIngresado
            // 
            this.lblIngresado.AutoSize = true;
            this.lblIngresado.Location = new System.Drawing.Point(36, 39);
            this.lblIngresado.Name = "lblIngresado";
            this.lblIngresado.Size = new System.Drawing.Size(54, 13);
            this.lblIngresado.TabIndex = 0;
            this.lblIngresado.Text = "Ingresado";
            // 
            // lblEnViaje
            // 
            this.lblEnViaje.AutoSize = true;
            this.lblEnViaje.Location = new System.Drawing.Point(307, 39);
            this.lblEnViaje.Name = "lblEnViaje";
            this.lblEnViaje.Size = new System.Drawing.Size(46, 13);
            this.lblEnViaje.TabIndex = 1;
            this.lblEnViaje.Text = "En Viaje";
            // 
            // lblEntregado
            // 
            this.lblEntregado.AutoSize = true;
            this.lblEntregado.Location = new System.Drawing.Point(555, 39);
            this.lblEntregado.Name = "lblEntregado";
            this.lblEntregado.Size = new System.Drawing.Size(56, 13);
            this.lblEntregado.TabIndex = 2;
            this.lblEntregado.Text = "Entregado";
            // 
            // gbxPaquete
            // 
            this.gbxPaquete.Controls.Add(this.mtxtTrackingID);
            this.gbxPaquete.Controls.Add(this.txtDireccion);
            this.gbxPaquete.Controls.Add(this.btnMostrarTodos);
            this.gbxPaquete.Controls.Add(this.btnAgregar);
            this.gbxPaquete.Controls.Add(this.lblDireccion);
            this.gbxPaquete.Controls.Add(this.lblTrackingID);
            this.gbxPaquete.Location = new System.Drawing.Point(444, 272);
            this.gbxPaquete.Name = "gbxPaquete";
            this.gbxPaquete.Size = new System.Drawing.Size(335, 159);
            this.gbxPaquete.TabIndex = 1;
            this.gbxPaquete.TabStop = false;
            this.gbxPaquete.Text = "Paquete";
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.Location = new System.Drawing.Point(35, 44);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(63, 13);
            this.lblTrackingID.TabIndex = 0;
            this.lblTrackingID.Text = "Tracking ID";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(35, 100);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 1;
            this.lblDireccion.Text = "Dirección";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(224, 50);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(89, 33);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(224, 106);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(89, 33);
            this.btnMostrarTodos.TabIndex = 3;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(39, 118);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(171, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // mtxtTrackingID
            // 
            this.mtxtTrackingID.Location = new System.Drawing.Point(38, 60);
            this.mtxtTrackingID.Name = "mtxtTrackingID";
            this.mtxtTrackingID.Size = new System.Drawing.Size(172, 20);
            this.mtxtTrackingID.TabIndex = 5;
            // 
            // lstEstadoIngresado
            // 
            this.lstEstadoIngresado.FormattingEnabled = true;
            this.lstEstadoIngresado.Location = new System.Drawing.Point(25, 58);
            this.lstEstadoIngresado.Name = "lstEstadoIngresado";
            this.lstEstadoIngresado.Size = new System.Drawing.Size(185, 160);
            this.lstEstadoIngresado.TabIndex = 3;
            // 
            // lstEstadoEnViaje
            // 
            this.lstEstadoEnViaje.FormattingEnabled = true;
            this.lstEstadoEnViaje.Location = new System.Drawing.Point(286, 58);
            this.lstEstadoEnViaje.Name = "lstEstadoEnViaje";
            this.lstEstadoEnViaje.Size = new System.Drawing.Size(185, 160);
            this.lstEstadoEnViaje.TabIndex = 4;
            // 
            // lstEstadoEntregado
            // 
            this.lstEstadoEntregado.FormattingEnabled = true;
            this.lstEstadoEntregado.Location = new System.Drawing.Point(539, 58);
            this.lstEstadoEntregado.Name = "lstEstadoEntregado";
            this.lstEstadoEntregado.Size = new System.Drawing.Size(185, 160);
            this.lstEstadoEntregado.TabIndex = 5;
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Location = new System.Drawing.Point(17, 272);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.Size = new System.Drawing.Size(413, 158);
            this.rtbMostrar.TabIndex = 2;
            this.rtbMostrar.Text = "";
            // 
            // FrmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.gbxPaquete);
            this.Controls.Add(this.gbxEstadosPaquetes);
            this.Name = "FrmPpal";
            this.Text = "Correo UTN por Antonella.Gualco.2C";
            this.gbxEstadosPaquetes.ResumeLayout(false);
            this.gbxEstadosPaquetes.PerformLayout();
            this.gbxPaquete.ResumeLayout(false);
            this.gbxPaquete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxEstadosPaquetes;
        private System.Windows.Forms.Label lblEntregado;
        private System.Windows.Forms.Label lblEnViaje;
        private System.Windows.Forms.Label lblIngresado;
        private System.Windows.Forms.ListBox lstEstadoEntregado;
        private System.Windows.Forms.ListBox lstEstadoEnViaje;
        private System.Windows.Forms.ListBox lstEstadoIngresado;
        private System.Windows.Forms.GroupBox gbxPaquete;
        private System.Windows.Forms.MaskedTextBox mtxtTrackingID;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.RichTextBox rtbMostrar;
    }
}

