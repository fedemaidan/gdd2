namespace PagoElectronico.Depositos
{
    partial class ABM_depositos
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_nrocuenta = new System.Windows.Forms.ComboBox();
            this.comboBox_tipomoneda = new System.Windows.Forms.ComboBox();
            this.comboBox_tc = new System.Windows.Forms.ComboBox();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Realizar depósito";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número de cuenta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Importe:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo de moneda:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tarjeta de crédito:";
            // 
            // comboBox_nrocuenta
            // 
            this.comboBox_nrocuenta.FormattingEnabled = true;
            this.comboBox_nrocuenta.Location = new System.Drawing.Point(167, 39);
            this.comboBox_nrocuenta.Name = "comboBox_nrocuenta";
            this.comboBox_nrocuenta.Size = new System.Drawing.Size(121, 21);
            this.comboBox_nrocuenta.TabIndex = 5;
            // 
            // comboBox_tipomoneda
            // 
            this.comboBox_tipomoneda.FormattingEnabled = true;
            this.comboBox_tipomoneda.Location = new System.Drawing.Point(501, 39);
            this.comboBox_tipomoneda.Name = "comboBox_tipomoneda";
            this.comboBox_tipomoneda.Size = new System.Drawing.Size(121, 21);
            this.comboBox_tipomoneda.TabIndex = 6;
            // 
            // comboBox_tc
            // 
            this.comboBox_tc.FormattingEnabled = true;
            this.comboBox_tc.Location = new System.Drawing.Point(501, 108);
            this.comboBox_tc.Name = "comboBox_tc";
            this.comboBox_tc.Size = new System.Drawing.Size(121, 21);
            this.comboBox_tc.TabIndex = 7;
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(167, 104);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(121, 20);
            this.textBox_importe.TabIndex = 8;
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.Location = new System.Drawing.Point(167, 151);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.ReadOnly = true;
            this.textBox_fecha.Size = new System.Drawing.Size(121, 20);
            this.textBox_fecha.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha:";
            // 
            // ABM_depositos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 288);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_fecha);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.comboBox_tc);
            this.Controls.Add(this.comboBox_tipomoneda);
            this.Controls.Add(this.comboBox_nrocuenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "ABM_depositos";
            this.Text = "ABM_depositos";
            this.Load += new System.EventHandler(this.ABM_depositos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_nrocuenta;
        private System.Windows.Forms.ComboBox comboBox_tipomoneda;
        private System.Windows.Forms.ComboBox comboBox_tc;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.TextBox textBox_fecha;
        private System.Windows.Forms.Label label5;
    }
}