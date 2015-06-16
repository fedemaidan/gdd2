namespace PagoElectronico.ABM_Cuenta
{
    partial class ABM_Cuenta
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
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.comboBox_tipocuenta = new System.Windows.Forms.ComboBox();
            this.comboBox_moneda = new System.Windows.Forms.ComboBox();
            this.comboBox_pais = new System.Windows.Forms.ComboBox();
            this.cb_clientes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Confirmar Alta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "País:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Moneda:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha de apertura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tipo de cuenta:";
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.Location = new System.Drawing.Point(126, 101);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.ReadOnly = true;
            this.textBox_fecha.Size = new System.Drawing.Size(100, 20);
            this.textBox_fecha.TabIndex = 6;
            // 
            // comboBox_tipocuenta
            // 
            this.comboBox_tipocuenta.FormattingEnabled = true;
            this.comboBox_tipocuenta.Location = new System.Drawing.Point(340, 100);
            this.comboBox_tipocuenta.Name = "comboBox_tipocuenta";
            this.comboBox_tipocuenta.Size = new System.Drawing.Size(100, 21);
            this.comboBox_tipocuenta.TabIndex = 8;
            this.comboBox_tipocuenta.SelectedIndexChanged += new System.EventHandler(this.comboBox_tipocuenta_SelectedIndexChanged);
            // 
            // comboBox_moneda
            // 
            this.comboBox_moneda.FormattingEnabled = true;
            this.comboBox_moneda.Location = new System.Drawing.Point(340, 52);
            this.comboBox_moneda.Name = "comboBox_moneda";
            this.comboBox_moneda.Size = new System.Drawing.Size(100, 21);
            this.comboBox_moneda.TabIndex = 9;
            // 
            // comboBox_pais
            // 
            this.comboBox_pais.FormattingEnabled = true;
            this.comboBox_pais.Location = new System.Drawing.Point(126, 57);
            this.comboBox_pais.Name = "comboBox_pais";
            this.comboBox_pais.Size = new System.Drawing.Size(100, 21);
            this.comboBox_pais.TabIndex = 10;
            // 
            // cb_clientes
            // 
            this.cb_clientes.FormattingEnabled = true;
            this.cb_clientes.Location = new System.Drawing.Point(126, 12);
            this.cb_clientes.Name = "cb_clientes";
            this.cb_clientes.Size = new System.Drawing.Size(100, 21);
            this.cb_clientes.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cliente username:";
            // 
            // ABM_Cuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 214);
            this.Controls.Add(this.cb_clientes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_pais);
            this.Controls.Add(this.comboBox_moneda);
            this.Controls.Add(this.comboBox_tipocuenta);
            this.Controls.Add(this.textBox_fecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "ABM_Cuenta";
            this.Text = "ABM de Cuenta";
            this.Load += new System.EventHandler(this.ABM_Cuenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_fecha;
        private System.Windows.Forms.ComboBox comboBox_tipocuenta;
        private System.Windows.Forms.ComboBox comboBox_moneda;
        private System.Windows.Forms.ComboBox comboBox_pais;
        private System.Windows.Forms.ComboBox cb_clientes;
        private System.Windows.Forms.Label label5;
    }
}