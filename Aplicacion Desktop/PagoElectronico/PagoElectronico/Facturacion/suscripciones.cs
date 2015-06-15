using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;

namespace PagoElectronico.Facturacion
{
    public partial class suscripciones : Form
    {
        public suscripciones(int id, User user)
        {
            InitializeComponent();
            this.id_cliente = id;
            this.user = user;

            Database db = new Database();
            DataTable dt = new DataTable();
            //agrego cuentas del cliente al combobox
            string qeri_cuenta;
            if (user.getRol() == "Administrador")
            { qeri_cuenta = "select t.numero_cuenta from qwerty.transacciones t where t.factura_id is null"; }
            else
            { qeri_cuenta = "select c.numero_cuenta from qwerty.cuentas c where c.cliente_id=" + this.id_cliente; }
            dt = db.select_query(qeri_cuenta);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_ctas.Items.Add(row["numero_cuenta"].ToString());

            }
            //  termino de agregar cuentas del cliente  al combobox
        }
        private int id_cliente;
        private User user;
        private void suscripciones_Load(object sender, EventArgs e)
        {

        }

        private void button_listo_Click(object sender, EventArgs e)
        {
            
            string suscripciones = "exec qwerty.adicionar_suscripciones "+comboBox_ctas.SelectedItem.ToString()+","+numericUpDown_cant.Value;

            Database db = new Database();
            db.select_query(suscripciones);
            this.Close();
        }
    }
}
