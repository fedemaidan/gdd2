namespace PagoElectronico.Tarjeta
{
    partial class editTarjeta
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
            this.cancelar = new System.Windows.Forms.Button();
            this.editar = new System.Windows.Forms.Button();
            this.txtCodSeguridad = new System.Windows.Forms.TextBox();
            this.BtnFechaVencimiento = new System.Windows.Forms.Button();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.txtFechaVen = new System.Windows.Forms.TextBox();
            this.BtnFechaEmision = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtFechaEmision = new System.Windows.Forms.TextBox();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.cbEmisor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(165, 209);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 133;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // editar
            // 
            this.editar.Location = new System.Drawing.Point(68, 210);
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(75, 23);
            this.editar.TabIndex = 132;
            this.editar.Text = "Editar";
            this.editar.UseVisualStyleBackColor = true;
            this.editar.Click += new System.EventHandler(this.editar_Click);
            // 
            // txtCodSeguridad
            // 
            this.txtCodSeguridad.Location = new System.Drawing.Point(133, 156);
            this.txtCodSeguridad.Name = "txtCodSeguridad";
            this.txtCodSeguridad.Size = new System.Drawing.Size(121, 20);
            this.txtCodSeguridad.TabIndex = 131;
            this.txtCodSeguridad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTarjeta_KeyPress);
            // 
            // BtnFechaVencimiento
            // 
            this.BtnFechaVencimiento.Location = new System.Drawing.Point(272, 132);
            this.BtnFechaVencimiento.Name = "BtnFechaVencimiento";
            this.BtnFechaVencimiento.Size = new System.Drawing.Size(84, 23);
            this.BtnFechaVencimiento.TabIndex = 130;
            this.BtnFechaVencimiento.Text = "Seleccionar";
            this.BtnFechaVencimiento.UseVisualStyleBackColor = true;
            this.BtnFechaVencimiento.Click += new System.EventHandler(this.BtnFechaVencimiento_Click);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(368, 56);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 129;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            // 
            // txtFechaVen
            // 
            this.txtFechaVen.Location = new System.Drawing.Point(133, 132);
            this.txtFechaVen.Name = "txtFechaVen";
            this.txtFechaVen.ReadOnly = true;
            this.txtFechaVen.Size = new System.Drawing.Size(121, 20);
            this.txtFechaVen.TabIndex = 128;
            this.txtFechaVen.TextChanged += new System.EventHandler(this.txtFechaVen_TextChanged);
            // 
            // BtnFechaEmision
            // 
            this.BtnFechaEmision.Location = new System.Drawing.Point(272, 106);
            this.BtnFechaEmision.Name = "BtnFechaEmision";
            this.BtnFechaEmision.Size = new System.Drawing.Size(84, 23);
            this.BtnFechaEmision.TabIndex = 127;
            this.BtnFechaEmision.Text = "Seleccionar";
            this.BtnFechaEmision.UseVisualStyleBackColor = true;
            this.BtnFechaEmision.Click += new System.EventHandler(this.BtnFechaEmision_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(368, 30);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 126;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // txtFechaEmision
            // 
            this.txtFechaEmision.Location = new System.Drawing.Point(133, 106);
            this.txtFechaEmision.Name = "txtFechaEmision";
            this.txtFechaEmision.ReadOnly = true;
            this.txtFechaEmision.Size = new System.Drawing.Size(121, 20);
            this.txtFechaEmision.TabIndex = 125;
            this.txtFechaEmision.TextChanged += new System.EventHandler(this.txtFechaEmisor_TextChanged);
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(133, 56);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(121, 20);
            this.txtNumeroTarjeta.TabIndex = 124;
            this.txtNumeroTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTarjeta_KeyPress);
            // 
            // cbEmisor
            // 
            this.cbEmisor.FormattingEnabled = true;
            this.cbEmisor.Location = new System.Drawing.Point(133, 79);
            this.cbEmisor.Name = "cbEmisor";
            this.cbEmisor.Size = new System.Drawing.Size(121, 21);
            this.cbEmisor.TabIndex = 123;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 122;
            this.label5.Text = "Codigo de seguridad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "Fecha de vencimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 120;
            this.label3.Text = "Fecha de emision";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 119;
            this.label2.Text = "Emisor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "Numero de tarjeta";
            // 
            // editTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 336);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.editar);
            this.Controls.Add(this.txtCodSeguridad);
            this.Controls.Add(this.BtnFechaVencimiento);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.txtFechaVen);
            this.Controls.Add(this.BtnFechaEmision);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.txtFechaEmision);
            this.Controls.Add(this.txtNumeroTarjeta);
            this.Controls.Add(this.cbEmisor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "editTarjeta";
            this.Text = "editTarjeta";
            this.Load += new System.EventHandler(this.editTarjeta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button editar;
        private System.Windows.Forms.TextBox txtCodSeguridad;
        private System.Windows.Forms.Button BtnFechaVencimiento;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.TextBox txtFechaVen;
        private System.Windows.Forms.Button BtnFechaEmision;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox txtFechaEmision;
        private System.Windows.Forms.TextBox txtNumeroTarjeta;
        private System.Windows.Forms.ComboBox cbEmisor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}