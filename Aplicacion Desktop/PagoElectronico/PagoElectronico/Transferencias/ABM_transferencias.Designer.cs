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
            this.SuspendLayout();
            // 
            // comboBox_ctaorigen
            // 
            this.comboBox_ctaorigen.FormattingEnabled = true;
            this.comboBox_ctaorigen.Location = new System.Drawing.Point(87, 70);
            this.comboBox_ctaorigen.Name = "comboBox_ctaorigen";
            this.comboBox_ctaorigen.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ctaorigen.TabIndex = 0;
            // 
            // comboBox_ctadestino
            // 
            this.comboBox_ctadestino.FormattingEnabled = true;
            this.comboBox_ctadestino.Location = new System.Drawing.Point(321, 70);
            this.comboBox_ctadestino.Name = "comboBox_ctadestino";
            this.comboBox_ctadestino.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ctadestino.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cuenta origen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 42);
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
            this.label4.Location = new System.Drawing.Point(84, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Importe:";
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(87, 148);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(121, 20);
            this.textBox_importe.TabIndex = 8;
            // 
            // ABM_transferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 262);
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
    }
}