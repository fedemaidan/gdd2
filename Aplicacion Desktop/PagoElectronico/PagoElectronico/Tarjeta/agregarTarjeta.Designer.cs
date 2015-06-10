namespace PagoElectronico.Tarjeta
{
    partial class agregarTarjeta
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
            this.label5 = new System.Windows.Forms.Label();
            this.cbEmisor = new System.Windows.Forms.ComboBox();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.BtnFechaEmision = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtFechaEmision = new System.Windows.Forms.TextBox();
            this.BtnFechaVencimiento = new System.Windows.Forms.Button();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.txtFechaVen = new System.Windows.Forms.TextBox();
            this.txtCodSeguridad = new System.Windows.Forms.TextBox();
            this.asociar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBanco = new System.Windows.Forms.ComboBox();
            this.cbCuentas = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de tarjeta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emisor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de emision";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de vencimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Codigo de seguridad";
            // 
            // cbEmisor
            // 
            this.cbEmisor.FormattingEnabled = true;
            this.cbEmisor.Location = new System.Drawing.Point(192, 93);
            this.cbEmisor.Name = "cbEmisor";
            this.cbEmisor.Size = new System.Drawing.Size(121, 21);
            this.cbEmisor.TabIndex = 5;
            this.cbEmisor.SelectedIndexChanged += new System.EventHandler(this.cbEmisor_SelectedIndexChanged);
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(192, 44);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(121, 20);
            this.txtNumeroTarjeta.TabIndex = 6;
            this.txtNumeroTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTarjeta_KeyPress);
            // 
            // BtnFechaEmision
            // 
            this.BtnFechaEmision.Location = new System.Drawing.Point(331, 120);
            this.BtnFechaEmision.Name = "BtnFechaEmision";
            this.BtnFechaEmision.Size = new System.Drawing.Size(84, 23);
            this.BtnFechaEmision.TabIndex = 111;
            this.BtnFechaEmision.Text = "Seleccionar";
            this.BtnFechaEmision.UseVisualStyleBackColor = true;
            this.BtnFechaEmision.Click += new System.EventHandler(this.BtnFechaEmision_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(427, 44);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 110;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // txtFechaEmision
            // 
            this.txtFechaEmision.Location = new System.Drawing.Point(192, 120);
            this.txtFechaEmision.Name = "txtFechaEmision";
            this.txtFechaEmision.ReadOnly = true;
            this.txtFechaEmision.Size = new System.Drawing.Size(121, 20);
            this.txtFechaEmision.TabIndex = 109;
            this.txtFechaEmision.TextChanged += new System.EventHandler(this.txtFechaEmision_TextChanged);
            // 
            // BtnFechaVencimiento
            // 
            this.BtnFechaVencimiento.Location = new System.Drawing.Point(331, 146);
            this.BtnFechaVencimiento.Name = "BtnFechaVencimiento";
            this.BtnFechaVencimiento.Size = new System.Drawing.Size(84, 23);
            this.BtnFechaVencimiento.TabIndex = 114;
            this.BtnFechaVencimiento.Text = "Seleccionar";
            this.BtnFechaVencimiento.UseVisualStyleBackColor = true;
            this.BtnFechaVencimiento.Click += new System.EventHandler(this.BtnFechaVencimiento_Click);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(427, 70);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 113;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            // 
            // txtFechaVen
            // 
            this.txtFechaVen.Location = new System.Drawing.Point(192, 146);
            this.txtFechaVen.Name = "txtFechaVen";
            this.txtFechaVen.ReadOnly = true;
            this.txtFechaVen.Size = new System.Drawing.Size(121, 20);
            this.txtFechaVen.TabIndex = 112;
            this.txtFechaVen.TextChanged += new System.EventHandler(this.txtFechaVen_TextChanged);
            // 
            // txtCodSeguridad
            // 
            this.txtCodSeguridad.Location = new System.Drawing.Point(191, 197);
            this.txtCodSeguridad.Name = "txtCodSeguridad";
            this.txtCodSeguridad.Size = new System.Drawing.Size(121, 20);
            this.txtCodSeguridad.TabIndex = 115;
            this.txtCodSeguridad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodSeguridad_KeyPress);
            // 
            // asociar
            // 
            this.asociar.Location = new System.Drawing.Point(127, 224);
            this.asociar.Name = "asociar";
            this.asociar.Size = new System.Drawing.Size(75, 23);
            this.asociar.TabIndex = 116;
            this.asociar.Text = "Asociar";
            this.asociar.UseVisualStyleBackColor = true;
            this.asociar.Click += new System.EventHandler(this.asociar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(224, 223);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 117;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 118;
            this.label6.Text = "Banco";
            // 
            // cbBanco
            // 
            this.cbBanco.FormattingEnabled = true;
            this.cbBanco.Location = new System.Drawing.Point(192, 66);
            this.cbBanco.Name = "cbBanco";
            this.cbBanco.Size = new System.Drawing.Size(121, 21);
            this.cbBanco.TabIndex = 119;
            // 
            // cbCuentas
            // 
            this.cbCuentas.FormattingEnabled = true;
            this.cbCuentas.Location = new System.Drawing.Point(191, 172);
            this.cbCuentas.Name = "cbCuentas";
            this.cbCuentas.Size = new System.Drawing.Size(121, 21);
            this.cbCuentas.TabIndex = 121;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 120;
            this.label7.Text = "Cuenta";
            // 
            // agregarTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 295);
            this.Controls.Add(this.cbCuentas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbBanco);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.asociar);
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
            this.Name = "agregarTarjeta";
            this.Text = "agregarTarjeta";
            this.Load += new System.EventHandler(this.agregarTarjeta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbEmisor;
        private System.Windows.Forms.TextBox txtNumeroTarjeta;
        private System.Windows.Forms.Button BtnFechaEmision;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox txtFechaEmision;
        private System.Windows.Forms.Button BtnFechaVencimiento;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.TextBox txtFechaVen;
        private System.Windows.Forms.TextBox txtCodSeguridad;
        private System.Windows.Forms.Button asociar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbBanco;
        private System.Windows.Forms.ComboBox cbCuentas;
        private System.Windows.Forms.Label label7;
    }
}