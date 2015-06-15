namespace PagoElectronico.Facturacion
{
    partial class suscripciones
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
            this.comboBox_ctas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_cant = new System.Windows.Forms.NumericUpDown();
            this.button_listo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cant)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_ctas
            // 
            this.comboBox_ctas.FormattingEnabled = true;
            this.comboBox_ctas.Location = new System.Drawing.Point(63, 71);
            this.comboBox_ctas.Name = "comboBox_ctas";
            this.comboBox_ctas.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ctas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Elija la cuenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad de suscripciones";
            // 
            // numericUpDown_cant
            // 
            this.numericUpDown_cant.Location = new System.Drawing.Point(283, 72);
            this.numericUpDown_cant.Name = "numericUpDown_cant";
            this.numericUpDown_cant.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_cant.TabIndex = 3;
            // 
            // button_listo
            // 
            this.button_listo.Location = new System.Drawing.Point(187, 132);
            this.button_listo.Name = "button_listo";
            this.button_listo.Size = new System.Drawing.Size(100, 50);
            this.button_listo.TabIndex = 4;
            this.button_listo.Text = "Agregar";
            this.button_listo.UseVisualStyleBackColor = true;
            this.button_listo.Click += new System.EventHandler(this.button_listo_Click);
            // 
            // suscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 262);
            this.Controls.Add(this.button_listo);
            this.Controls.Add(this.numericUpDown_cant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_ctas);
            this.Name = "suscripciones";
            this.Text = "suscripciones";
            this.Load += new System.EventHandler(this.suscripciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_ctas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_cant;
        private System.Windows.Forms.Button button_listo;
    }
}