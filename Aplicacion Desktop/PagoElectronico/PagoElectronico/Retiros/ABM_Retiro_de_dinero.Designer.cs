namespace PagoElectronico.Retiros
{
    partial class ABM_Retiro_de_dinero
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
            this.comboBox_nrocuenta = new System.Windows.Forms.ComboBox();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.comboBox_tipomoneda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_bancos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_nrocuenta
            // 
            this.comboBox_nrocuenta.FormattingEnabled = true;
            this.comboBox_nrocuenta.Location = new System.Drawing.Point(116, 66);
            this.comboBox_nrocuenta.Name = "comboBox_nrocuenta";
            this.comboBox_nrocuenta.Size = new System.Drawing.Size(121, 21);
            this.comboBox_nrocuenta.TabIndex = 0;
            this.comboBox_nrocuenta.SelectedIndexChanged += new System.EventHandler(this.comboBox_nrocuenta_SelectedIndexChanged);
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(116, 113);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(121, 20);
            this.textBox_importe.TabIndex = 1;
            // 
            // comboBox_tipomoneda
            // 
            this.comboBox_tipomoneda.FormattingEnabled = true;
            this.comboBox_tipomoneda.Location = new System.Drawing.Point(387, 112);
            this.comboBox_tipomoneda.Name = "comboBox_tipomoneda";
            this.comboBox_tipomoneda.Size = new System.Drawing.Size(121, 21);
            this.comboBox_tipomoneda.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número de cuenta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo de moneda:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Importe:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Retirar dinero";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_bancos
            // 
            this.cb_bancos.FormattingEnabled = true;
            this.cb_bancos.Location = new System.Drawing.Point(387, 66);
            this.cb_bancos.Name = "cb_bancos";
            this.cb_bancos.Size = new System.Drawing.Size(121, 21);
            this.cb_bancos.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bancos:";
            // 
            // ABM_Retiro_de_dinero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_bancos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_tipomoneda);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.comboBox_nrocuenta);
            this.Name = "ABM_Retiro_de_dinero";
            this.Text = "ABM_Retiro_de_dinero";
            this.Load += new System.EventHandler(this.ABM_Retiro_de_dinero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_nrocuenta;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.ComboBox comboBox_tipomoneda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_bancos;
        private System.Windows.Forms.Label label4;
    }
}