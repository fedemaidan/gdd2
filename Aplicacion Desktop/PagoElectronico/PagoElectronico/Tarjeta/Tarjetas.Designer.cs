namespace PagoElectronico.Tarjeta
{
    partial class Tarjetas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textDigitBuscar = new System.Windows.Forms.TextBox();
            this.btn_seleccionar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_desasociar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEmisores = new System.Windows.Forms.ComboBox();
            this.BtnFechaVencimiento = new System.Windows.Forms.Button();
            this.monthCalendar2Em = new System.Windows.Forms.MonthCalendar();
            this.txtFechaVen = new System.Windows.Forms.TextBox();
            this.BtnFechaEmision = new System.Windows.Forms.Button();
            this.monthCalendar1Ven = new System.Windows.Forms.MonthCalendar();
            this.txtFechaEmision = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(530, 115);
            this.dataGridView1.TabIndex = 14;
            // 
            // textDigitBuscar
            // 
            this.textDigitBuscar.Location = new System.Drawing.Point(101, 13);
            this.textDigitBuscar.Name = "textDigitBuscar";
            this.textDigitBuscar.Size = new System.Drawing.Size(138, 20);
            this.textDigitBuscar.TabIndex = 13;
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.Location = new System.Drawing.Point(118, 240);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(75, 23);
            this.btn_seleccionar.TabIndex = 12;
            this.btn_seleccionar.Text = "Editar";
            this.btn_seleccionar.UseVisualStyleBackColor = true;
            this.btn_seleccionar.Click += new System.EventHandler(this.btn_seleccionar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(164, 86);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpiar.TabIndex = 11;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(15, 240);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_agregar.TabIndex = 10;
            this.btn_agregar.Text = "Agregar nuevo rol";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(43, 86);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 9;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Numero Tarjeta";
            // 
            // btn_desasociar
            // 
            this.btn_desasociar.Location = new System.Drawing.Point(215, 240);
            this.btn_desasociar.Name = "btn_desasociar";
            this.btn_desasociar.Size = new System.Drawing.Size(75, 23);
            this.btn_desasociar.TabIndex = 15;
            this.btn_desasociar.Text = "Desasociar";
            this.btn_desasociar.UseVisualStyleBackColor = true;
            this.btn_desasociar.Click += new System.EventHandler(this.btn_desasociar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Banco";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Vencimiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Emision";
            // 
            // cbEmisores
            // 
            this.cbEmisores.FormattingEnabled = true;
            this.cbEmisores.Location = new System.Drawing.Point(101, 41);
            this.cbEmisores.Name = "cbEmisores";
            this.cbEmisores.Size = new System.Drawing.Size(138, 21);
            this.cbEmisores.TabIndex = 19;
            // 
            // BtnFechaVencimiento
            // 
            this.BtnFechaVencimiento.Location = new System.Drawing.Point(484, 41);
            this.BtnFechaVencimiento.Name = "BtnFechaVencimiento";
            this.BtnFechaVencimiento.Size = new System.Drawing.Size(84, 23);
            this.BtnFechaVencimiento.TabIndex = 136;
            this.BtnFechaVencimiento.Text = "Seleccionar";
            this.BtnFechaVencimiento.UseVisualStyleBackColor = true;
            this.BtnFechaVencimiento.Click += new System.EventHandler(this.BtnFechaVencimiento_Click);
            // 
            // monthCalendar2Em
            // 
            this.monthCalendar2Em.Location = new System.Drawing.Point(345, 76);
            this.monthCalendar2Em.Name = "monthCalendar2Em";
            this.monthCalendar2Em.TabIndex = 135;
            this.monthCalendar2Em.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2Em_DateChanged);
            // 
            // txtFechaVen
            // 
            this.txtFechaVen.Location = new System.Drawing.Point(345, 41);
            this.txtFechaVen.Name = "txtFechaVen";
            this.txtFechaVen.ReadOnly = true;
            this.txtFechaVen.Size = new System.Drawing.Size(121, 20);
            this.txtFechaVen.TabIndex = 134;
            this.txtFechaVen.TextChanged += new System.EventHandler(this.txtFechaVen_TextChanged);
            // 
            // BtnFechaEmision
            // 
            this.BtnFechaEmision.Location = new System.Drawing.Point(484, 15);
            this.BtnFechaEmision.Name = "BtnFechaEmision";
            this.BtnFechaEmision.Size = new System.Drawing.Size(84, 23);
            this.BtnFechaEmision.TabIndex = 133;
            this.BtnFechaEmision.Text = "Seleccionar";
            this.BtnFechaEmision.UseVisualStyleBackColor = true;
            this.BtnFechaEmision.Click += new System.EventHandler(this.BtnFechaEmision_Click);
            // 
            // monthCalendar1Ven
            // 
            this.monthCalendar1Ven.Location = new System.Drawing.Point(318, 76);
            this.monthCalendar1Ven.Name = "monthCalendar1Ven";
            this.monthCalendar1Ven.TabIndex = 132;
            this.monthCalendar1Ven.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1Ven_DateChanged);
            // 
            // txtFechaEmision
            // 
            this.txtFechaEmision.Location = new System.Drawing.Point(345, 15);
            this.txtFechaEmision.Name = "txtFechaEmision";
            this.txtFechaEmision.ReadOnly = true;
            this.txtFechaEmision.Size = new System.Drawing.Size(121, 20);
            this.txtFechaEmision.TabIndex = 131;
            this.txtFechaEmision.TextChanged += new System.EventHandler(this.txtFechaEmision_TextChanged);
            // 
            // Tarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 320);
            this.Controls.Add(this.BtnFechaVencimiento);
            this.Controls.Add(this.monthCalendar2Em);
            this.Controls.Add(this.txtFechaVen);
            this.Controls.Add(this.BtnFechaEmision);
            this.Controls.Add(this.monthCalendar1Ven);
            this.Controls.Add(this.txtFechaEmision);
            this.Controls.Add(this.cbEmisores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_desasociar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textDigitBuscar);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label2);
            this.Name = "Tarjetas";
            this.Text = "Tarjetas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textDigitBuscar;
        private System.Windows.Forms.Button btn_seleccionar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_desasociar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEmisores;
        private System.Windows.Forms.Button BtnFechaVencimiento;
        private System.Windows.Forms.MonthCalendar monthCalendar2Em;
        private System.Windows.Forms.TextBox txtFechaVen;
        private System.Windows.Forms.Button BtnFechaEmision;
        private System.Windows.Forms.MonthCalendar monthCalendar1Ven;
        private System.Windows.Forms.TextBox txtFechaEmision;
    }
}