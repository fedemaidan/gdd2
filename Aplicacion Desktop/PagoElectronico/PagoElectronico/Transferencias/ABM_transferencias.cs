using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;

namespace PagoElectronico.Transferencias
{
    public partial class ABM_transferencias : Form
    {
        public ABM_transferencias(User user)
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

            //agrego cuentas del cliente origen al combobox
            string qeri_cuenta = "select c.numero_cuenta from qwerty.cuentas c where c.cliente_id=" + this.id_cliente + "and c.estado_id=3"; //estado_id=3 es la cuenta habilitada
            dt = db.select_query(qeri_cuenta);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_ctaorigen.Items.Add(row["numero_cuenta"].ToString());
                

            }
            //  termino de agregar cuentas del cliente origen  al combobox

            //agrego cuentas del cliente destino al combobox
            string qeri_cuentadest = "select c.numero_cuenta from qwerty.cuentas c where c.estado_id=3 or c.estado_id=4"; //estado_id=3 es la cuenta habilitada y 4 es la cuenta inhabilitada a la cual le puedo mandar plata
            dt = db.select_query(qeri_cuentadest);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_ctadestino.Items.Add(row["numero_cuenta"].ToString());
                
            }
            //  termino de agregar cuentas del destino origen  al combobox


        }
        private User user;
        private int id_cliente;
        private void ABM_transferencias_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            double saldo_anterior = 0;
            double saldo_origen = 0;

            // validar saldo de cuenta origen
            string saldo_ctaorigen = "select c.saldo from qwerty.cuentas c where c.numero_cuenta=" + comboBox_ctaorigen.SelectedItem.ToString();
            dt = db.select_query(saldo_ctaorigen);
            foreach (DataRow row in dt.Rows)
            {
                saldo_origen = Convert.ToDouble(row["saldo"].ToString());
            }

            if (Convert.ToDouble(textBox_importe.Text) > saldo_origen) { MessageBox.Show("No tiene fondos suficientes para realizar la transferencia"); }
            else
            {

                // termino la validacion

                //actualizo saldo cuenta destino

                string saldo_ctadestino = "select c.saldo from qwerty.cuentas c where c.numero_cuenta=" + comboBox_ctadestino.SelectedItem.ToString();

                dt2 = db.select_query(saldo_ctadestino);
                foreach (DataRow row in dt2.Rows)
                {
                    saldo_anterior = Convert.ToDouble(row["saldo"].ToString());
                }
                double saldo_final = saldo_anterior + Convert.ToDouble(textBox_importe.Text);
                string qeri_transf = "update qwerty.cuentas set saldo=" + saldo_final + " where numero_cuenta=" + comboBox_ctadestino.SelectedItem.ToString();
                db.update_query(qeri_transf);

                // termino de actualizar saldo cuenta destino


                //actualizo saldo cuenta origen

                string saldo_cuentaorigen = "select c.saldo from qwerty.cuentas c where c.numero_cuenta=" + comboBox_ctaorigen.SelectedItem.ToString();

                dt2 = db.select_query(saldo_cuentaorigen);
                foreach (DataRow row in dt2.Rows)
                {
                    saldo_anterior = Convert.ToDouble(row["saldo"].ToString());
                }
                double saldo_final2 = saldo_anterior - Convert.ToDouble(textBox_importe.Text);
                string qeri_transf2 = "update qwerty.cuentas set saldo=" + saldo_final2 + " where numero_cuenta=" + comboBox_ctaorigen.SelectedItem.ToString();
                db.update_query(qeri_transf2);

                // termino de actualizar saldo cuenta origen
                //busco tipo de cuenta origen
                string tipo_cta_origen = "select c.categoria_id from qwerty.cuentas c where c.numero_cuenta="+Convert.ToInt64(comboBox_ctaorigen.SelectedItem.ToString());
                dt2 = db.select_query(tipo_cta_origen);
                int categoria = 0;
                foreach(DataRow row in dt2.Rows){
                    categoria = Convert.ToInt32(row["categoria_id"].ToString());
                }
                //termino de buscar tipo de cuenta origen
                //actualizo tabla de transferencias
                Dia dia = new Dia();
                string transf = "insert into qwerty.transferencias (importe,cuenta_origen,cuenta_destino,tipo_de_cuenta,costo_id,fecha_transferencia,pendiente_facturacion) values ("+Convert.ToDouble(textBox_importe.Text)+","+Convert.ToInt64(comboBox_ctaorigen.SelectedItem.ToString())+","+Convert.ToInt64(comboBox_ctadestino.SelectedItem.ToString())+","+categoria+",1,'"+dia.Hoy()+"',1)";
                db.insert_query(transf);
                //termino de actualizar tabla de transferencias

                // inserto en transacciones
                //busco el tipo de cuenta
                string busco_tipoCta = "select cc.descripcion from qwerty.cuentas c, qwerty.categorias_de_cuentas cc where c.categoria_id=cc.categoria_id and c.numero_cuenta=" + Convert.ToInt64(comboBox_ctaorigen.SelectedItem.ToString());
                string descripcion = "";
                dt2 = db.select_query(busco_tipoCta);
                foreach (DataRow row in dt2.Rows) { descripcion = row["descripcion"].ToString(); }
                //busco el tipo de cuenta FINN

                // agrego la transaccion
                
                string qeri_transac = "insert into qwerty.transacciones (numero_cuenta,tipo_cuenta,cliente_id,tipo_transaccion,fecha_transaccion,importe,costo_id) values (" + Convert.ToInt64(comboBox_ctaorigen.SelectedItem.ToString()) + ",'" + descripcion + "'," + id_cliente + ",'Transferencia','"+dia.Hoy()+"',0.2,1)";
                db.insert_query(qeri_transac);
                // agrego la transaccion FINN
                
                // inserto en transacciones FINN

                this.Close();

            }
        }
    }
}
