using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;

namespace PagoElectronico.Retiros
{
    public partial class ABM_Retiro_de_dinero : Form
    {
        public ABM_Retiro_de_dinero(User user) 
        {
            InitializeComponent();
            this.user = user;


            // tengo q buscar cliente_id en la tabla clientes con el nombre_usuario
            Database db = new Database();
            string qeri_buscoIDcliente = "select c.cliente_id from qwerty.clientes c where c.nombre_usuario='" + user.getUserName() + "'";

            DataTable dt = db.select_query(qeri_buscoIDcliente);
            foreach (DataRow row in dt.Rows)
            {
                this.id_cliente = Convert.ToInt32(row["cliente_id"]);
            }
            //termino de buscar el cliente_id

            //agrego cuentas del cliente al combobox
            string qeri_cuenta = "select c.numero_cuenta from qwerty.cuentas c where c.cliente_id=" + this.id_cliente + "and c.estado_id=3 and c.saldo > 0"; //estado_id=3 es la cuenta habilitada
            dt = db.select_query(qeri_cuenta);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_nrocuenta.Items.Add(row["numero_cuenta"].ToString());

            }
            //  termino de agregar cuentas del cliente  al combobox

            //agrego monedas al combobox
            string qeri_monedas = "select m.descripcion from qwerty.monedas m";
            dt = db.select_query(qeri_monedas);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_tipomoneda.Items.Add(row["descripcion"].ToString());

            }
            //  termino de agregar monedas  al combobox

            
        }
        private User user;
        private int id_cliente;
        public bool tieneDNI;
        public void dni(bool dni) { this.tieneDNI=dni;}

        private void ABM_Retiro_de_dinero_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chequeoDNI check = new chequeoDNI(this, id_cliente);
            check.ShowDialog();
            
            if (tieneDNI) {
                string tieneSaldo = "select c.saldo from qwerty.cuentas c where c.cliente_id="+id_cliente;
                Database db = new Database();
                DataTable dt = new DataTable();
                int saldo=0;
                dt = db.select_query(tieneSaldo);
                foreach (DataRow row in dt.Rows)
                {
                    saldo = Convert.ToInt32(row["saldo"].ToString());
                }
                if (saldo > Convert.ToInt32(textBox_importe.Text)) {
                    string retiro_dinero = "update qwerty.cuentas set saldo=" + (saldo - Convert.ToInt32(textBox_importe.Text)) + " where cliente_id="+id_cliente;
                    db.update_query(retiro_dinero);
                    MessageBox.Show("Retiro realizado!");
                    this.Close();
                }
            } 
            else { MessageBox.Show("no tiene dni"); }
        }
    }
}
