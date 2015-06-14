namespace PagoElectronico.ABM_Cuenta
{
    partial class Modificacion_Cuenta
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
            this.comboBox_moneda = new System.Windows.Forms.ComboBox();
            this.comboBox_tipocuenta = new System.Windows.Forms.ComboBox();
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_pais = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox_moneda
            // 
            this.comboBox_moneda.FormattingEnabled = true;
            this.comboBox_moneda.Location = new System.Drawing.Point(334, 75);
            this.comboBox_moneda.Name = "comboBox_moneda";
            this.comboBox_moneda.Size = new System.Drawing.Size(100, 21);
            this.comboBox_moneda.TabIndex = 18;
            // 
            // comboBox_tipocuenta
            // 
            this.comboBox_tipocuenta.FormattingEnabled = true;
            this.comboBox_tipocuenta.Location = new System.Drawing.Point(334, 142);
            this.comboBox_tipocuenta.Name = "comboBox_tipocuenta";
            this.comboBox_tipocuenta.Size = new System.Drawing.Size(100, 21);
            this.comboBox_tipocuenta.TabIndex = 17;
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.Location = new System.Drawing.Point(120, 143);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.ReadOnly = true;
            this.textBox_fecha.Size = new System.Drawing.Size(100, 20);
            this.textBox_fecha.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tipo de cuenta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha de apertura:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Moneda:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "País:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Confirmar modificación";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_pais
            // 
            this.comboBox_pais.FormattingEnabled = true;
            this.comboBox_pais.Location = new System.Drawing.Point(119, 75);
            this.comboBox_pais.Name = "comboBox_pais";
            this.comboBox_pais.Size = new System.Drawing.Size(101, 21);
            this.comboBox_pais.TabIndex = 19;
            // 
            // Modificacion_Cuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 301);
            this.Controls.Add(this.comboBox_pais);
            this.Controls.Add(this.comboBox_moneda);
            this.Controls.Add(this.comboBox_tipocuenta);
            this.Controls.Add(this.textBox_fecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Modificacion_Cuenta";
            this.Text = "Modificacion_Cuenta";
            this.Load += new System.EventHandler(this.Modificacion_Cuenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox comboBox_moneda;
        public System.Windows.Forms.ComboBox comboBox_tipocuenta;
        public System.Windows.Forms.TextBox textBox_fecha;
        public System.Windows.Forms.ComboBox comboBox_pais;
    }
}