namespace PagoElectronico.Facturacion
{
    partial class Facturacion
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
            this.comboBox_pais = new System.Windows.Forms.ComboBox();
            this.textBox_cuenta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_cuentas = new System.Windows.Forms.DataGridView();
            this.button_seleccionar = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_suscripciones = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_pais
            // 
            this.comboBox_pais.FormattingEnabled = true;
            this.comboBox_pais.Location = new System.Drawing.Point(231, 29);
            this.comboBox_pais.Name = "comboBox_pais";
            this.comboBox_pais.Size = new System.Drawing.Size(100, 21);
            this.comboBox_pais.TabIndex = 25;
            // 
            // textBox_cuenta
            // 
            this.textBox_cuenta.Location = new System.Drawing.Point(231, 86);
            this.textBox_cuenta.Name = "textBox_cuenta";
            this.textBox_cuenta.Size = new System.Drawing.Size(100, 20);
            this.textBox_cuenta.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nro. de cuenta:";
            // 
            // dataGridView_cuentas
            // 
            this.dataGridView_cuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_cuentas.Location = new System.Drawing.Point(83, 154);
            this.dataGridView_cuentas.Name = "dataGridView_cuentas";
            this.dataGridView_cuentas.ReadOnly = true;
            this.dataGridView_cuentas.Size = new System.Drawing.Size(497, 131);
            this.dataGridView_cuentas.TabIndex = 22;
            // 
            // button_seleccionar
            // 
            this.button_seleccionar.Location = new System.Drawing.Point(487, 37);
            this.button_seleccionar.Name = "button_seleccionar";
            this.button_seleccionar.Size = new System.Drawing.Size(93, 23);
            this.button_seleccionar.TabIndex = 21;
            this.button_seleccionar.Text = "Facturar";
            this.button_seleccionar.UseVisualStyleBackColor = true;
            this.button_seleccionar.Click += new System.EventHandler(this.button_seleccionar_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(487, 68);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(93, 23);
            this.button_limpiar.TabIndex = 20;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(83, 27);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 19;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "País:";
            // 
            // button_suscripciones
            // 
            this.button_suscripciones.Location = new System.Drawing.Point(370, 37);
            this.button_suscripciones.Name = "button_suscripciones";
            this.button_suscripciones.Size = new System.Drawing.Size(93, 54);
            this.button_suscripciones.TabIndex = 26;
            this.button_suscripciones.Text = "Agregar suscripciones";
            this.button_suscripciones.UseVisualStyleBackColor = true;
            this.button_suscripciones.Click += new System.EventHandler(this.button_suscripciones_Click);
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 309);
            this.Controls.Add(this.button_suscripciones);
            this.Controls.Add(this.comboBox_pais);
            this.Controls.Add(this.textBox_cuenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_cuentas);
            this.Controls.Add(this.button_seleccionar);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.label2);
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            this.Load += new System.EventHandler(this.Facturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cuentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_pais;
        private System.Windows.Forms.TextBox textBox_cuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_cuentas;
        private System.Windows.Forms.Button button_seleccionar;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_suscripciones;
    }
}