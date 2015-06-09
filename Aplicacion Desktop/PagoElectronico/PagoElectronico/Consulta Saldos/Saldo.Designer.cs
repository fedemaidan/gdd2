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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTransferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDepositos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRetiros)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCuentas
            // 
            this.cbCuentas.FormattingEnabled = true;
            this.cbCuentas.Location = new System.Drawing.Point(33, 37);
            this.cbCuentas.Name = "cbCuentas";
            this.cbCuentas.Size = new System.Drawing.Size(121, 21);
            this.cbCuentas.TabIndex = 0;
            this.cbCuentas.SelectedIndexChanged += new System.EventHandler(this.cbCuentas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuentas";
            // 
            // saldo1
            // 
            this.saldo1.Enabled = false;
            this.saldo1.Location = new System.Drawing.Point(217, 38);
            this.saldo1.Name = "saldo1";
            this.saldo1.Size = new System.Drawing.Size(100, 20);
            this.saldo1.TabIndex = 2;
            // 
            // dataGridTransferencias
            // 
            this.dataGridTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTransferencias.Location = new System.Drawing.Point(42, 101);
            this.dataGridTransferencias.Name = "dataGridTransferencias";
            this.dataGridTransferencias.Size = new System.Drawing.Size(275, 339);
            this.dataGridTransferencias.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Transferencias";
            // 
            // dataGridDepositos
            // 
            this.dataGridDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDepositos.Location = new System.Drawing.Point(362, 101);
            this.dataGridDepositos.Name = "dataGridDepositos";
            this.dataGridDepositos.Size = new System.Drawing.Size(240, 154);
            this.dataGridDepositos.TabIndex = 11;
            // 
            // dataGridRetiros
            // 
            this.dataGridRetiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRetiros.Location = new System.Drawing.Point(362, 290);
            this.dataGridRetiros.Name = "dataGridRetiros";
            this.dataGridRetiros.Size = new System.Drawing.Size(240, 150);
            this.dataGridRetiros.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Depositos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Retiros";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Saldo";
            // 
            // Saldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 452);
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
    }
}