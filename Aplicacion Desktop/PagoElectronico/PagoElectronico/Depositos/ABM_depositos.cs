using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;

namespace PagoElectronico.Depositos
{
    public partial class ABM_depositos : Form
    {
        public ABM_depositos(User user)
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
            string qeri_cuenta = "select c.numero_cuenta from qwerty.cuentas c where c.cliente_id=" + this.id_cliente + "and c.estado_id=3"; //estado_id=3 es la cuenta habilitada
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

            

            //agrego tarjetas al combobox
            Dia dia = new Dia();
            // agrego fecha al textbox
            textBox_fecha.Text = dia.Hoy().ToString();

            string qeri_tarjeta = "select tc.numero_tarjeta from qwerty.tarjetas_de_credito tc, qwerty.clientes c where tc.titular=c.cliente_id and tc.fecha_vencimiento > '" +dia.Hoy().ToString()+"'";
            dt = db.select_query(qeri_tarjeta);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_tc.Items.Add(row["numero_tarjeta"].ToString());
                

            }
            //  termino de agregar tarjetas  al combobox
        }

        private User user;
        private int id_cliente;
        private void ABM_depositos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random(); //IMPORTANTE QITAR ESTO DESPUES PORQE LO USO PARA GENERAR EL ID DEL DEPOSITO
            int aleatorio = random.Next(1, 10000000);
            MessageBox.Show(aleatorio.ToString());
            MessageBox.Show(comboBox_nrocuenta.SelectedItem.ToString());
            MessageBox.Show((Convert.ToInt32(comboBox_tipomoneda.SelectedIndex.ToString()) + 1).ToString());

            string qeri_insert = "insert into qwerty.depositos values (" + aleatorio + "," + comboBox_nrocuenta.SelectedItem.ToString() + "," + textBox_importe.Text + "," + (Convert.ToInt32(comboBox_tipomoneda.SelectedIndex.ToString()) + 1) + "," + comboBox_tc.SelectedItem.ToString() + ",'" + textBox_fecha.Text + "')";
            Database db = new Database();
            db.insert_query(qeri_insert);
            this.Close();
            
        }
    }
}
