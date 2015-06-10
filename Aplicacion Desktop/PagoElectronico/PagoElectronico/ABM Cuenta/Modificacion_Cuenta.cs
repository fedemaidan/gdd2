using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class Modificacion_Cuenta : Form
    {
        public Modificacion_Cuenta(int numero_cta)
        {
            InitializeComponent();
            this.nro_cta = numero_cta;
        }
        private int nro_cta;
        private int moneda;

        private void Modificacion_Cuenta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox_moneda.SelectedIndex == 0) { this.moneda = 1; }
            Database db = new Database();
            string qeri = "update qwerty.cuentas set moneda_id=" + this.moneda + ", fecha_apertura='" + textBox_fecha.Text + "', categoria_id=" + (comboBox_tipocuenta.SelectedIndex + 1) + ",pais='"+textBox_pais.Text+"' where numero_cuenta="+this.nro_cta;
            db.update_query(qeri);
            this.Close();
        }
    }
}
