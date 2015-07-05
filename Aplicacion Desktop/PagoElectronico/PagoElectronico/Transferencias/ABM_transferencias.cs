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
        private Dictionary<string, Int64> dicBancos = new Dictionary<string, Int64>();

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
            string qeri_cuenta = "select distinct c.numero_cuenta from qwerty.cuentas c where c.cliente_id=" + this.id_cliente + " and c.estado_id=3"; //estado_id=3 es la cuenta habilitada
            dt = db.select_query(qeri_cuenta);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_ctaorigen.Items.Add(row["numero_cuenta"].ToString());          
            }

            //agrego bancos a combo_box bancos
            string query_bancos = "select banco_id,nombre from qwerty.bancos where banco_id <> 10004";
            dt = db.select_query(query_bancos);
            foreach (DataRow row in dt.Rows)
            {
                cb_b_origen.Items.Add(row["nombre"].ToString());
                cb_b_dest.Items.Add(row["nombre"].ToString());
                dicBancos[row["nombre"].ToString()] = Int64.Parse(row["banco_id"].ToString());
            }

            //agrego cuentas del cliente destino al combobox
            string qeri_cuentadest = "select distinct c.numero_cuenta from qwerty.cuentas c where c.estado_id=3 or c.estado_id=4"; //estado_id=3 es la cuenta habilitada y 4 es la cuenta inhabilitada a la cual le puedo mandar plata
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
            string bancoId = "";
            // validar saldo de cuenta origen
            string saldo_ctaorigen = "select c.saldo, c.banco_id from qwerty.cuentas c where c.numero_cuenta=" + comboBox_ctaorigen.SelectedItem.ToString();
            dt = db.select_query(saldo_ctaorigen);
            foreach (DataRow row in dt.Rows)
            {
                saldo_origen = Convert.ToDouble(row["saldo"].ToString());
                bancoId = row["banco_id"].ToString();
            }

            if (Convert.ToDouble(textBox_importe.Text) > saldo_origen) { MessageBox.Show("No tiene fondos suficientes para realizar la transferencia"); }
            else
            {
                double importe= Convert.ToDouble(textBox_importe.Text);
                // termino la validacion

                //actualizo saldo cuenta destino

                string saldo_ctadestino = "select c.saldo from qwerty.cuentas c where c.numero_cuenta=" + comboBox_ctadestino.SelectedItem.ToString();

                dt2 = db.select_query(saldo_ctadestino);
                foreach (DataRow row in dt2.Rows)
                {
                    saldo_anterior = Convert.ToDouble(row["saldo"].ToString());
                }
                double saldo_final = saldo_anterior + Convert.ToDouble(textBox_importe.Text);
                string query_transf = "update qwerty.cuentas set saldo=" + saldo_final + " where numero_cuenta=" + comboBox_ctadestino.SelectedItem.ToString();
                query_transf = query_transf.Replace(',', '.');
                db.update_query(query_transf);

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
                qeri_transf2 = qeri_transf2.Replace(',', '.');
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
                Int64 banco_origen = dicBancos[cb_b_origen.SelectedItem.ToString()];
                Int64 banco_destino = dicBancos[cb_b_dest.SelectedItem.ToString()];
                Int64 cuenta_origen = Convert.ToInt64(comboBox_ctaorigen.SelectedItem.ToString());
                Int64 cuenta_destino = Convert.ToInt64(comboBox_ctadestino.SelectedItem.ToString());

                //obtengo el costo de transaccion
                string query_cliente_origen = "select cliente_id from qwerty.cuentas where numero_cuenta=" + cuenta_origen + " and banco_id=" + banco_origen + ";";
                string query_cliente_destino = "select cliente_id from qwerty.cuentas where numero_cuenta=" + cuenta_destino + " and banco_id=" + banco_destino + ";";
                dt = db.select_query(query_cliente_origen);
                dt2 = db.select_query(query_cliente_destino);
                int cliente_orig =0;
                int cliente_dest = 0;
                foreach(DataRow row in dt.Rows)
                {
                    cliente_orig = int.Parse(row["cliente_id"].ToString());
                }

                foreach (DataRow row in dt2.Rows)
                {
                    cliente_dest = int.Parse(row["cliente_id"].ToString());
                }
                int costo_id = 1;
                if (cliente_orig == cliente_dest && banco_origen == banco_destino) 
                {
                    string query_costo = "select costo_id from qwerty.costos_de_transacciones where tipo_costo='Nulo'";
                    dt2 = db.select_query(query_costo);
                    foreach(DataRow row in dt2.Rows)
                        costo_id = int.Parse(row["costo_id"].ToString()); //costo nulo
                }
                string transf = "insert into qwerty.transferencias (importe,cuenta_origen,banco_origen,cuenta_destino,banco_destino,tipo_de_cuenta,costo_id,fecha_transferencia,pendiente_facturacion) values (" + Convert.ToDouble(textBox_importe.Text)  + "," + cuenta_origen + "," + banco_origen +"," + cuenta_destino + "," + banco_destino + "," + categoria + ","+ costo_id +",'" + dia.Hoy().ToString("yyyy-MM-dd") + "',1)";
                db.insert_query(transf);
                //termino de actualizar tabla de transferencias

                string query_codOperacion = "select max(transferencia_id) as codigo_operacion from qwerty.transferencias;";
                DataTable dt_codOp = new DataTable();
                dt_codOp = db.select_query(query_codOperacion);
                string codOp = dt_codOp.Rows[0].ItemArray[0].ToString();
                Int64 codigo_operacion = Int64.Parse(codOp);


                string update_query = "update qwerty.transferencias set codigo_operacion = 'T-" + codigo_operacion.ToString() + "' where transferencia_id = " + codigo_operacion;
                db.update_query(update_query);


                // inserto en transacciones
                //busco el tipo de cuenta
                string busco_tipoCta = "select cc.descripcion from qwerty.cuentas c, qwerty.categorias_de_cuentas cc where c.categoria_id=cc.categoria_id and c.numero_cuenta=" + Convert.ToInt64(comboBox_ctaorigen.SelectedItem.ToString());
                string descripcion = "";
                dt2 = db.select_query(busco_tipoCta);
                foreach (DataRow row in dt2.Rows) { descripcion = row["descripcion"].ToString(); }
                //busco el tipo de cuenta FINN

                // agrego la transaccion

                string qeri_transac = "insert into qwerty.transacciones values (" + Convert.ToInt64(comboBox_ctaorigen.SelectedItem.ToString()) + "," + bancoId + ",'" + descripcion + "'," + id_cliente + ",'Transferencia','" + dia.Hoy().ToString("yyyy-MM-dd") + "',"+importe+","+costo_id+",null,"+ codigo_operacion +")";
                db.insert_query(qeri_transac);
                // agrego la transaccion FINN
                
                // inserto en transacciones FINN

                this.Close();

            }
        }

        private void comboBox_ctaorigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_ctaorigen.SelectedIndex == -1)
            {
                ;
            }
            else
            {
                cb_b_origen.SelectedIndex = -1;
                cb_b_origen.Items.Clear();
                string qeri = "select b.nombre from qwerty.cuentas c,qwerty.bancos b where c.banco_id=b.banco_id and c.numero_cuenta=" + comboBox_ctaorigen.SelectedItem.ToString();
                Database db = new Database();
                DataTable dt = new DataTable();
                dt = db.select_query(qeri);
                //string nombre_banco="";
                foreach (DataRow row in dt.Rows)
                {

                    cb_b_origen.Items.Add(row["nombre"].ToString());
                };
                //textBox_banco.Text = nombre_banco;
            }
        }

        private void comboBox_ctadestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_ctadestino.SelectedIndex == -1)
            {
                ;
            }
            else
            {
                cb_b_dest.SelectedIndex = -1;
                cb_b_dest.Items.Clear();
                string qeri = "select b.nombre from qwerty.cuentas c,qwerty.bancos b where c.banco_id=b.banco_id and c.numero_cuenta=" + comboBox_ctadestino.SelectedItem.ToString();
                Database db = new Database();
                DataTable dt = new DataTable();
                dt = db.select_query(qeri);
                //string nombre_banco="";
                foreach (DataRow row in dt.Rows)
                {

                    cb_b_dest.Items.Add(row["nombre"].ToString());
                };
                //textBox_banco.Text = nombre_banco;
            }
        }
    }
}
