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
                
                string tieneSaldo = "select c.saldo from qwerty.cuentas c where c.numero_cuenta="+comboBox_nrocuenta.SelectedItem.ToString()+" and c.cliente_id=" + id_cliente;
                Database db = new Database();
                DataTable dt = new DataTable();
                int saldo=0;
                dt = db.select_query(tieneSaldo);
                foreach (DataRow row in dt.Rows)
                {
                    saldo = Convert.ToInt32(row["saldo"].ToString());
                }
                if (saldo >= Convert.ToInt32(textBox_importe.Text))
                {
                    string retiro_dinero = "update qwerty.cuentas set saldo=" + (saldo - Convert.ToInt32(textBox_importe.Text)) + " where numero_cuenta=" + comboBox_nrocuenta.SelectedItem.ToString() + " and cliente_id=" + id_cliente;
                    db.update_query(retiro_dinero);
                    //busco banco_id
                    string busco_bancoID = "select tc.banco_id, b.nombre  from qwerty.tarjetas_de_credito tc, qwerty.bancos b  where tc.banco_id=b.banco_id and tc.numero_cuenta="+comboBox_nrocuenta.SelectedItem.ToString();
                    
                    dt = db.select_query(busco_bancoID);
                    int banco_id = 0;
                    string banco_nombre = "";
                    foreach (DataRow row in dt.Rows) {
                        banco_id = Convert.ToInt32(row["banco_id"].ToString());
                        banco_nombre = row["nombre"].ToString();
                    }
                    //termino de buscar banco_id

                    //busco nombre y ap del cliente
                    string busc_nombre_ap= "select nombre,apellido from qwerty.clientes where cliente_id="+this.id_cliente;
                    dt = db.select_query(busc_nombre_ap);
                    string nombre = "";
                    string apellido = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        nombre = row["nombre"].ToString();
                        apellido = row["apellido"].ToString();
                    }
                    //busco nombre y ap del cliente FINN
                    
                    //genero el retiro
                    Random nro = new Random();
                    int aleatorio = nro.Next(1, 10000000);
                    Dia dia = new Dia();
                    string qeri_retiro = "insert into qwerty.retiro_de_efectivo (retiro_id,numero_cuenta,importe,fecha_retiro,nombre,apellido,nombre_banco) values ("+aleatorio+","+Convert.ToInt64(comboBox_nrocuenta.SelectedItem.ToString())+","+Convert.ToInt64(textBox_importe.Text)+",'"+dia.Hoy()+"','"+nombre+"','"+apellido+"','"+banco_nombre+"')";
                    db.insert_query(qeri_retiro);
                    //string inserto_cheque = "insert into qwerty.cheques (cliente_id,banco_id,importe,fecha) values ("+this.id_cliente+","+banco_id+","+Convert.ToDouble(textBox_importe.Text)+",'"+dia.Hoy()+"')";
                    //db.insert_query(inserto_cheque);


                    MessageBox.Show("Retiro realizado!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No tiene saldo!");
                    this.Close();
                }
            } 
            else { MessageBox.Show("no tiene dni"); }
        }
    }
}
