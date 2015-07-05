namespace PagoElectronico.Transferencias
{
    partial class ABM_transferencias
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
            this.comboBox_ctaorigen = new System.Windows.Forms.ComboBox();
            this.comboBox_ctadestino = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_b_dest = new System.Windows.Forms.ComboBox();
            this.cb_b_origen = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox_ctaorigen
            // 
            this.comboBox_ctaorigen.FormattingEnabled = true;
            this.comboBox_ctaorigen.Location = new System.Drawing.Point(87, 55);
            this.comboBox_ctaorigen.Name = "comboBox_ctaorigen";
            this.comboBox_ctaorigen.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ctaorigen.TabIndex = 0;
            this.comboBox_ctaorigen.SelectedIndexChanged += new System.EventHandler(this.comboBox_ctaorigen_SelectedIndexChanged);
            // 
            // comboBox_ctadestino
            // 
            this.comboBox_ctadestino.FormattingEnabled = true;
            this.comboBox_ctadestino.Location = new System.Drawing.Point(321, 55);
            this.comboBox_ctadestino.Name = "comboBox_ctadestino";
            this.comboBox_ctadestino.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ctadestino.TabIndex = 1;
            this.comboBox_ctadestino.SelectedIndexChanged += new System.EventHandler(this.comboBox_ctadestino_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cuenta origen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cuenta destino:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Realizar transferencia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Importe:";
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(211, 158);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(121, 20);
            this.textBox_importe.TabIndex = 8;
            this.textBox_importe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_importe_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Banco origen:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Banco destino:";
            // 
            // cb_b_dest
            // 
            this.cb_b_dest.FormattingEnabled = true;
            this.cb_b_dest.Location = new System.Drawing.Point(321, 104);
            this.cb_b_dest.Name = "cb_b_dest";
            this.cb_b_dest.Size = new System.Drawing.Size(121, 21);
            this.cb_b_dest.TabIndex = 12;
            // 
            // cb_b_origen
            // 
            this.cb_b_origen.FormattingEnabled = true;
            this.cb_b_origen.Location = new System.Drawing.Point(87, 104);
            this.cb_b_origen.Name = "cb_b_origen";
            this.cb_b_origen.Size = new System.Drawing.Size(121, 21);
            this.cb_b_origen.TabIndex = 11;
            // 
            // ABM_transferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 262);
            this.Controls.Add(this.cb_b_dest);
            this.Controls.Add(this.cb_b_origen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_ctadestino);
            this.Controls.Add(this.comboBox_ctaorigen);
            this.Name = "ABM_transferencias";
            this.Text = "ABM_transferencias";
            this.Load += new System.EventHandler(this.ABM_transferencias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_ctaorigen;
        private System.Windows.Forms.ComboBox comboBox_ctadestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_b_dest;
        private System.Windows.Forms.ComboBox cb_b_origen;
    }
}