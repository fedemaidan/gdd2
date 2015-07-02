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
        private Dictionary<string, Int64> dicBancos = new Dictionary<string, Int64>();

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
            string qeri_cuenta = "select distinct c.numero_cuenta from qwerty.cuentas c where c.cliente_id=" + this.id_cliente + "and c.estado_id=3"; //estado_id=3 es la cuenta habilitada
            dt = db.select_query(qeri_cuenta);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_nrocuenta.Items.Add(row["numero_cuenta"].ToString());
                
            }

            string query_bancos = "select banco_id,nombre from qwerty.bancos where banco_id <> 10004";
            dt = db.select_query(query_bancos);
            foreach (DataRow row in dt.Rows)
            {
                cb_d_bancos.Items.Add(row["nombre"].ToString());
                dicBancos[row["nombre"].ToString()] = Int64.Parse(row["banco_id"].ToString());
            }

            //agrego monedas al combobox
            string qeri_monedas = "select m.descripcion from qwerty.monedas m";
            dt = db.select_query(qeri_monedas);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_tipomoneda.Items.Add(row["descripcion"].ToString());
            }
            //  termino de agregar monedas  al combobox

            
                        
            // agrego fecha al textbox
            Dia dia = new Dia();
            textBox_fecha.Text = dia.Hoy().ToString("yyyy-MM-dd");
            
            //agrego tarjetas al combobox
            string qeri_tarjeta = "select tc.numero_tarjeta from qwerty.tarjetas_de_credito tc, qwerty.clientes c where tc.titular=c.cliente_id and c.cliente_id="+this.id_cliente+" and tc.fecha_vencimiento > '" +dia.Hoy().ToString("yyyy-MM-dd")+"'";
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
            Database db = new Database();
            DataTable dt2 = new DataTable();
            string busco_ExisteAsociacion = "select * from qwerty.tarjetas_de_credito tc where tc.numero_tarjeta="+Convert.ToInt64(comboBox_tc.SelectedItem.ToString())+" and tc.numero_cuenta="+Convert.ToInt64(comboBox_nrocuenta.SelectedItem.ToString());
            dt2 = db.select_query(busco_ExisteAsociacion);

            if (dt2.Rows.Count==0) { MessageBox.Show("Tarjeta no asociada a la cuenta"); return; }
            
            string qeri_insert = "insert into qwerty.depositos (numero_cuenta,banco_id,importe,moneda_id,numero_trajeta,fecha_deposito) values (" + comboBox_nrocuenta.SelectedItem.ToString() + "," + dicBancos[cb_d_bancos.SelectedItem.ToString()] + ","+ textBox_importe.Text + "," + (Convert.ToInt32(comboBox_tipomoneda.SelectedIndex.ToString()) + 1) + "," + comboBox_tc.SelectedItem.ToString() + ",'" + textBox_fecha.Text + "')";
            db.insert_query(qeri_insert);

            string query_codOperacion = "select max(deposito_id) as codigo_operacion from qwerty.depositos;";
            DataTable dt_codOp = new DataTable();
            dt_codOp = db.select_query(query_codOperacion);
            string codOp = dt_codOp.Rows[0].ItemArray[0].ToString();
            Int64 codigo_operacion = Int64.Parse(codOp);
           

            string update_query = "update qwerty.depositos set codigo_operacion = 'D-" + codigo_operacion.ToString() + "' where deposito_id = " +codigo_operacion; 
            db.update_query(update_query);
            //actualizar cuenta

            string saldo_cuenta = "select c.saldo from qwerty.cuentas c where c.numero_cuenta=" + comboBox_nrocuenta.SelectedItem.ToString();
            
            dt2 = db.select_query(saldo_cuenta);
            double saldo_anterior = 0;
            foreach (DataRow row in dt2.Rows)
            {
                saldo_anterior = Convert.ToDouble(row["saldo"].ToString());
            }
            double saldo_final = saldo_anterior + Convert.ToDouble(textBox_importe.Text);
            string query_actualizocuenta = "update qwerty.cuentas set saldo=" + saldo_final + " where numero_cuenta=" + comboBox_nrocuenta.SelectedItem.ToString();
            query_actualizocuenta = query_actualizocuenta.Replace(',', '.');
            db.update_query(query_actualizocuenta);

            //termino de actualizar cuenta

            
            this.Close();
            
        }
    }
}
