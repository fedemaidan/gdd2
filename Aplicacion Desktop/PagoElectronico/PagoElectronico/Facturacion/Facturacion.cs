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
    public partial class Facturacion : Form
    {
        private Dictionary<string, Int64> dicBancos = new Dictionary<string, Int64>();

        public Facturacion(User user)
        {
            InitializeComponent();
            this.user = user;
            //agrego paises  al combobox

            string qeri_paises = "select p.desc_pais from qwerty.paises p";
            Database db = new Database();
            DataTable dt = new DataTable();
            dt = db.select_query(qeri_paises);
            comboBox_pais.Items.Add("");
            foreach (DataRow row in dt.Rows)
            {
                comboBox_pais.Items.Add(row["desc_pais"].ToString());

            }

            string query_bancos = "select banco_id,nombre from qwerty.bancos where banco_id <> 10004";
            dt = db.select_query(query_bancos);
            foreach (DataRow row in dt.Rows)
            {
                cb_f_bancos.Items.Add(row["nombre"].ToString());
                dicBancos[row["nombre"].ToString()] = Int64.Parse(row["banco_id"].ToString());
            }

            // tengo q buscar cliente_id en la tabla clientes con el nombre_usuario

            string qeri_buscoIDcliente = "select c.cliente_id from qwerty.clientes c where c.nombre_usuario='" + user.getUserName() + "'";

            dt = db.select_query(qeri_buscoIDcliente);
            foreach (DataRow row in dt.Rows)
            {
                this.id_cliente = Convert.ToInt32(row["cliente_id"]);
            }
            //termino de buscar el cliente_id

            string qeri;
            // el if es para que si entro como administrador puedo ver y modificar todas las   IMPORTANTEE
            //cuentas entonces cuando haga una modficacion tengo que avisar a qe usuario afecto IMPORTANTEEEE
            if (user.getRol() == "Administrador") { qeri = "select t.numero_cuenta as Cuenta,cli.nombre_usuario as Usuario,c.saldo as Saldo,c.fecha_apertura,c.fecha_cierre,m.descripcion as Moneda,p.desc_pais as País,cc.descripcion as Categoría, c.estado_id as Estado from qwerty.cuentas c, qwerty.transacciones t, qwerty.paises p, qwerty.monedas m, qwerty.categorias_de_cuentas cc,qwerty.clientes cli  where  m.moneda_id=c.moneda_id and cc.categoria_id=c.categoria_id and c.cliente_id=cli.cliente_id and c.cod_pais=p.cod_pais and c.numero_cuenta=t.numero_cuenta and t.factura_id is null"; }
            else { qeri = "select c.numero_cuenta as Cuenta,c.saldo as Saldo,c.estado_id as Estado,c.fecha_apertura,c.fecha_cierre,m.descripcion as Moneda,p.desc_pais as País,cc.descripcion as categoría from qwerty.cuentas c,  qwerty.transacciones t,qwerty.paises p, qwerty.monedas m, qwerty.categorias_de_cuentas cc  where c.cliente_id=" + id_cliente + " and m.moneda_id=c.moneda_id and  p.cod_pais=c.cod_pais and cc.categoria_id=c.categoria_id and c.numero_cuenta=t.numero_cuenta and t.factura_id is null"; }


            
            BindingSource bsource = new BindingSource();
            //string qeri = "select * from qwerty.cuentas where cliente_id="+id_cliente;
            dt = db.select_query(qeri);
            bsource.DataSource = dt;
            dataGridView_cuentas.DataSource = bsource;
        }
        private User user;
        private int id_cliente;

        private void Facturacion_Load(object sender, EventArgs e)
        {

        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                BindingSource bsource = new BindingSource();
                string qeri = "";
                if (user.getRol() == "Administrador") { qeri = "select c.numero_cuenta as Cuenta,cli.nombre_usuario as Usuario,c.saldo as Saldo,c.fecha_apertura,c.fecha_cierre,m.descripcion as Moneda,p.desc_pais as País,cc.descripcion as Categoría, c.estado_id as Estado from qwerty.cuentas c, qwerty.paises p, qwerty.monedas m, qwerty.categorias_de_cuentas cc,qwerty.clientes cli  where  c.numero_cuenta like '%" + textBox_cuenta.Text + "%' and p.desc_pais like '%" + comboBox_pais.SelectedItem.ToString() + "%' and p.cod_pais=c.cod_pais and m.moneda_id=c.moneda_id and cc.categoria_id=c.categoria_id  and c.cliente_id=cli.cliente_id"; }
                else { qeri = "select c.numero_cuenta as Cuenta,c.saldo as Saldo,c.estado_id as Estado,c.fecha_apertura,c.fecha_cierre,m.descripcion as Moneda,p.desc_pais as País,cc.descripcion as categoría from qwerty.cuentas c, qwerty.paises p, qwerty.monedas m, qwerty.categorias_de_cuentas cc  where c.numero_cuenta like '%" + textBox_cuenta.Text + "%' and p.desc_pais like '%" + comboBox_pais.SelectedItem.ToString() + "%' and c.cliente_id=" + id_cliente + " and m.moneda_id=c.moneda_id and cc.categoria_id=c.categoria_id and p.cod_pais=c.cod_pais "; }

                dt = db.select_query(qeri);
                bsource.DataSource = dt;
                dataGridView_cuentas.DataSource = bsource;
                button_limpiar.Enabled = true;
                button_seleccionar.Enabled = true;
            }
            catch { MessageBox.Show("Debe seleccionar un país"); }
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            comboBox_pais.SelectedIndex = 0;
            textBox_cuenta.Clear();
            button_seleccionar.Enabled = false;
            dataGridView_cuentas.DataSource = null;
        }

        private void button_seleccionar_Click(object sender, EventArgs e)
        {
            if (user.getRol() == "Cliente")
            {// chequeo qe no tenga mas de cinco transacciones por cuenta/banco sino lo tengo q inhabilitar
                string qeri = "select t.numero_cuenta,t.banco_id, COUNT(*) as cant from qwerty.transacciones t where t.factura_id is null and t.cliente_id="+id_cliente+" group by t.numero_cuenta,t.banco_id";
                Database db = new Database();
                DataTable dt = new DataTable();
                dt = db.select_query(qeri);
                foreach(DataRow row in dt.Rows) {//inhabilitar 
                    if (Convert.ToInt32(row["cant"].ToString())>5) {//inhabilito cuenta!! 
                        //necesito campos: inhabilitacion id es siempre 1,numero_cuenta, banco_id, y fecha
                        Dia dia = new Dia();
                        string insert_cuenta_inhabilitada = "insert into qwerty.inhabilitaciones_por_cuenta (inhabilitacion_id,numero_cuenta,banco_id,fecha) values (1," + Convert.ToInt64(row["numero_cuenta"].ToString()) + "," + Convert.ToInt32(row["banco_id"].ToString()) + ",'" + dia.Hoy().ToString("yyyy-MM-dd") + "')";
                        db.insert_query(insert_cuenta_inhabilitada);
                        MessageBox.Show("Cuenta inhabilitada:"+" "+row["numero_cuenta"].ToString());
                        
                    };
                    
                }
                //termino de hacer el cheqeo de la cantidad de transacciones
                
                // le facturo todas las cuentas
                string facturo_cliente = "exec qwerty.facturar_cliente " + id_cliente;
                
                db.select_query(facturo_cliente);
                MessageBox.Show("Facturacion realizada correctamente");
                this.Close();
            }
            else {
                DialogResult dr = MessageBox.Show("Desea facturar al cliente?", "Confirmación", MessageBoxButtons.YesNo,
       MessageBoxIcon.Information);
                if (dr == DialogResult.Yes) {

                    // tengo q buscar cliente_id en la tabla clientes con el nombre_usuario

                    string qeri_buscoIDcliente = "select c.cliente_id from qwerty.clientes c where c.nombre_usuario='" + this.dataGridView_cuentas.CurrentRow.Cells[1].Value.ToString() +"'";
                    //Int64 cuenta_id = Int64.Parse(textBox_cuenta.Text);
                    //Int64 banco_id = dicBancos[cb_f_bancos.SelectedItem.ToString()];
                    //string query_clie = "select cliente_id from qwerty.cuentas where numero_cuenta= "+ cuenta_id + "and banco_id= " +banco_id+";";
                    Database db = new Database();
                    DataTable dt = new DataTable();
                    dt = db.select_query(qeri_buscoIDcliente);
                    int idUser=0;
                    foreach (DataRow row in dt.Rows)
                    {
                        idUser= Convert.ToInt32(row["cliente_id"]);
                    }
                    //termino de buscar el cliente_id

                    // chequeo qe no tenga mas de cinco transacciones por cuenta/banco sino lo tengo q inhabilitar
                    string qeri = "select t.numero_cuenta,t.banco_id, COUNT(*) as cant from qwerty.transacciones t where t.factura_id is null and t.cliente_id=" + idUser + " group by t.numero_cuenta,t.banco_id";
                    dt = db.select_query(qeri);
                    foreach (DataRow row in dt.Rows)
                    {//inhabilitar 
                        if (Convert.ToInt32(row["cant"].ToString()) > 5)
                        {//inhabilito cuenta!! 
                            //necesito campos: inhabilitacion id es siempre 1,numero_cuenta, banco_id, y fecha
                            Dia dia = new Dia();
                            string insert_cuenta_inhabilitada = "insert into qwerty.inhabilitaciones_por_cuenta (inhabilitacion_id,numero_cuenta,banco_id,fecha) values (1," + Convert.ToInt64(row["numero_cuenta"].ToString()) + "," + Convert.ToInt32(row["banco_id"].ToString()) + ",'" + dia.Hoy().ToString("yyyy-MM-dd") + "')";
                            db.insert_query(insert_cuenta_inhabilitada);
                            MessageBox.Show("Cuenta inhabilitada:" + " " + row["numero_cuenta"].ToString());

                        };

                    }
                    //termino de hacer el cheqeo de la cantidad de transacciones


                    string facturo_cliente = "exec qwerty.facturar_cliente " + idUser;
                    
                    db.select_query(facturo_cliente);
                    MessageBox.Show("Cliente con username " + this.dataGridView_cuentas.CurrentRow.Cells[1].Value.ToString() + " facturado correctamente");
                    this.Close();
                    
                } 
                
                else { ; }
                
            }
        }

        private void button_suscripciones_Click(object sender, EventArgs e)
        {
            suscripciones abm = new suscripciones(id_cliente,user);
            abm.ShowDialog();
        }
    }
}
