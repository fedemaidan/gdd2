namespace PagoElectronico.ABM_Rol
{
    partial class ABMRol_Modificacion_Listado
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton_alta = new System.Windows.Forms.RadioButton();
            this.radioButton_baja = new System.Windows.Forms.RadioButton();
            this.Actualizar = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Funcionalidades:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Estado:";
            // 
            // radioButton_alta
            // 
            this.radioButton_alta.AutoSize = true;
            this.radioButton_alta.Location = new System.Drawing.Point(121, 180);
            this.radioButton_alta.Name = "radioButton_alta";
            this.radioButton_alta.Size = new System.Drawing.Size(43, 17);
            this.radioButton_alta.TabIndex = 10;
            this.radioButton_alta.TabStop = true;
            this.radioButton_alta.Text = "Alta";
            this.radioButton_alta.UseVisualStyleBackColor = true;
            // 
            // radioButton_baja
            // 
            this.radioButton_baja.AutoSize = true;
            this.radioButton_baja.Location = new System.Drawing.Point(170, 180);
            this.radioButton_baja.Name = "radioButton_baja";
            this.radioButton_baja.Size = new System.Drawing.Size(46, 17);
            this.radioButton_baja.TabIndex = 9;
            this.radioButton_baja.TabStop = true;
            this.radioButton_baja.Text = "Baja";
            this.radioButton_baja.UseVisualStyleBackColor = true;
            // 
            // Actualizar
            // 
            this.Actualizar.Location = new System.Drawing.Point(121, 227);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(75, 23);
            this.Actualizar.TabIndex = 12;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseVisualStyleBackColor = true;
            this.Actualizar.Click += new System.EventHandler(this.Actualizar_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "ABM de Rol",
            "ABM de Usuarios",
            "ABM de Clientes",
            "ABM de Cuentas",
            "Asociar tarjeta de crédito",
            "Desasociar tarjeta de crédito",
            "Depósito",
            "Retiro de efectivo",
            "Transferencia entre cuentas",
            "Facturación de costos",
            "Consulta de saldo",
            "Listado estadístico"});
            this.checkedListBox1.Location = new System.Drawing.Point(121, 76);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ABMRol_Modificacion_Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton_alta);
            this.Controls.Add(this.radioButton_baja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "ABMRol_Modificacion_Listado";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ABMRol_Modificacion_Listado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.RadioButton radioButton_alta;
        public System.Windows.Forms.RadioButton radioButton_baja;
        private System.Windows.Forms.Button Actualizar;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        public System.Windows.Forms.TextBox textBox1;
    }
}