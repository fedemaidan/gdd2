namespace PagoElectronico.Consulta_Saldos
{
    partial class Saldo
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
            this.cbCuentas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saldo1 = new System.Windows.Forms.TextBox();
            this.dataGridTransferencias = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridDepositos = new System.Windows.Forms.DataGridView();
            this.dataGridRetiros = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_clientes = new System.Windows.Forms.ComboBox();
            this.cb_cs_bancos = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTransferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDepositos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRetiros)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCuentas
            // 
            this.cbCuentas.FormattingEnabled = true;
            this.cbCuentas.Location = new System.Drawing.Point(196, 39);
            this.cbCuentas.Name = "cbCuentas";
            this.cbCuentas.Size = new System.Drawing.Size(121, 21);
            this.cbCuentas.TabIndex = 0;
            this.cbCuentas.SelectedIndexChanged += new System.EventHandler(this.cbCuentas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuentas";
            // 
            // saldo1
            // 
            this.saldo1.Enabled = false;
            this.saldo1.Location = new System.Drawing.Point(24, 100);
            this.saldo1.Name = "saldo1";
            this.saldo1.Size = new System.Drawing.Size(121, 20);
            this.saldo1.TabIndex = 2;
            // 
            // dataGridTransferencias
            // 
            this.dataGridTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTransferencias.Location = new System.Drawing.Point(344, 27);
            this.dataGridTransferencias.Name = "dataGridTransferencias";
            this.dataGridTransferencias.Size = new System.Drawing.Size(570, 244);
            this.dataGridTransferencias.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Transferencias";
            // 
            // dataGridDepositos
            // 
            this.dataGridDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDepositos.Location = new System.Drawing.Point(344, 472);
            this.dataGridDepositos.Name = "dataGridDepositos";
            this.dataGridDepositos.Size = new System.Drawing.Size(563, 154);
            this.dataGridDepositos.TabIndex = 11;
            // 
            // dataGridRetiros
            // 
            this.dataGridRetiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRetiros.Location = new System.Drawing.Point(344, 297);
            this.dataGridRetiros.Name = "dataGridRetiros";
            this.dataGridRetiros.Size = new System.Drawing.Size(563, 143);
            this.dataGridRetiros.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 456);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Depositos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Retiros";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Saldo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Clientes";
            // 
            // cb_clientes
            // 
            this.cb_clientes.FormattingEnabled = true;
            this.cb_clientes.Location = new System.Drawing.Point(24, 39);
            this.cb_clientes.Name = "cb_clientes";
            this.cb_clientes.Size = new System.Drawing.Size(121, 21);
            this.cb_clientes.TabIndex = 16;
            this.cb_clientes.SelectedIndexChanged += new System.EventHandler(this.cb_clientes_SelectedIndexChanged);
            // 
            // cb_cs_bancos
            // 
            this.cb_cs_bancos.FormattingEnabled = true;
            this.cb_cs_bancos.Location = new System.Drawing.Point(196, 99);
            this.cb_cs_bancos.Name = "cb_cs_bancos";
            this.cb_cs_bancos.Size = new System.Drawing.Size(121, 21);
            this.cb_cs_bancos.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(196, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Bancos";
            // 
            // Saldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 733);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_cs_bancos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_clientes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridRetiros);
            this.Controls.Add(this.dataGridDepositos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridTransferencias);
            this.Controls.Add(this.saldo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCuentas);
            this.Name = "Saldo";
            this.Text = "Saldo";
            this.Load += new System.EventHandler(this.Saldo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTransferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDepositos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRetiros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCuentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox saldo1;
        private System.Windows.Forms.DataGridView dataGridTransferencias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridDepositos;
        private System.Windows.Forms.DataGridView dataGridRetiros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_clientes;
        private System.Windows.Forms.ComboBox cb_cs_bancos;
        private System.Windows.Forms.Label label7;
    }
}