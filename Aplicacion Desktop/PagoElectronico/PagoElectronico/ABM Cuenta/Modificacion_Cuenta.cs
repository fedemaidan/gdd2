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
        public Modificacion_Cuenta(Int64 numero_cta, string moneda, string categoria, string pais,Int32 banco_id)
        {
            InitializeComponent();
            
            this.nro_cta = numero_cta;
            this.moneda = moneda;
            this.categoria = categoria;
            this.desc_pais = pais;
            this.banco_id = banco_id;

            //agrego paises  al combobox
            string qeri_paises = "select p.desc_pais from qwerty.paises p";
            Database db = new Database();
            DataTable dt = new DataTable();
            dt = db.select_query(qeri_paises);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_pais.Items.Add(row["desc_pais"].ToString());

            }
            //  termino de agregar paises al combobox

            //agrego tipos de cuentas  al combobox
            string qeri_tiposcuentas = "select c.descripcion from qwerty.categorias_de_cuentas c";

            dt = db.select_query(qeri_tiposcuentas);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_tipocuenta.Items.Add(row["descripcion"].ToString());

            }
            //  termino de agregar tipos de cuentas al combobox

            //agrego monedas  al combobox
            string qeri_monedas = "select m.descripcion from qwerty.monedas m";

            dt = db.select_query(qeri_monedas);
            foreach (DataRow row in dt.Rows)
            {
                comboBox_moneda.Items.Add(row["descripcion"].ToString());

            }
            //  termino de agregar monedas al combobox

            
            comboBox_pais.SelectedIndex = comboBox_pais.FindStringExact(desc_pais);
            comboBox_moneda.SelectedIndex = comboBox_moneda.FindStringExact(moneda);
            comboBox_tipocuenta.SelectedIndex = comboBox_tipocuenta.FindStringExact(categoria);
        }
        private Int64 nro_cta;
        private string moneda;
        private string categoria;
        private string desc_pais;
        private int id_cliente;
        private Int32 banco_id;

        private void Modificacion_Cuenta_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // busco codigo del pais
            Database db = new Database();
            DataTable dt = new DataTable();
            string qeri_cod_pais = "select p.cod_pais from qwerty.paises p where p.desc_pais='" + comboBox_pais.SelectedItem.ToString() + "'";
            dt = db.select_query(qeri_cod_pais);
            int cod_pais = 0;
            foreach (DataRow row in dt.Rows)
            {
                cod_pais = Convert.ToInt32(row["cod_pais"]);
            }
            //termino de buscar codigo del pais

            //me fijo si cambio el tipo de cuenta
            string qeri = "";
            bool cambio = false;
            if (categoria != comboBox_tipocuenta.SelectedItem.ToString()) { qeri = "update qwerty.cuentas set moneda_id=" + (comboBox_moneda.SelectedIndex + 1) + ", categoria_id=" + (comboBox_tipocuenta.SelectedIndex + 1) + ",cod_pais=" + cod_pais + " where numero_cuenta=" + this.nro_cta;
            cambio = true;
            }
            else { qeri="update qwerty.cuentas set moneda_id=" + (comboBox_moneda.SelectedIndex + 1) + ", cod_pais=" + cod_pais + " where numero_cuenta=" + this.nro_cta; }
            //me fijo si cambio el tipo de cuenta FIN

            db.update_query(qeri);
            // tengo q buscar cliente_id en la tabla clientes con el nombre_usuario

            string qeri_buscoIDcliente = "select c.cliente_id from qwerty.cuentas c where c.numero_cuenta=" + this.nro_cta;

            dt = db.select_query(qeri_buscoIDcliente);
            foreach (DataRow row in dt.Rows)
            {
                this.id_cliente = Convert.ToInt32(row["cliente_id"]);
            }
            //termino de buscar el cliente_id
            if (cambio == true) {
                //chequeo que la cuenta este habilitada para poder hacer el cambio 
                string estado_cuenta = "select estado_id from qwerty.cuentas where numero_cuenta ="+this.nro_cta;
                dt = db.select_query(estado_cuenta);
                int estado = 0;
                foreach (DataRow row in dt.Rows) {
                    estado = Convert.ToInt32(row["estado_id"].ToString());
                }
                if (estado == 4) { MessageBox.Show("Cuenta inhabilitada, primero debe pagar para poder cambiar el tipo"); return; }
                //termino de chequear
             
                Dia dia= new Dia();
                //busco costo de transaccion
                string qeri_cost_transac = "select ct.costo from qwerty.costos_de_transacciones ct where ct.costo_id=3";
                dt = db.select_query(qeri_cost_transac);
                decimal costo_transac = 0;
                foreach (DataRow row in dt.Rows) { costo_transac = Convert.ToDecimal(row["costo"]); }
                //busco costo de transaccion FIN
                
                
                System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                customCulture.NumberFormat.NumberDecimalSeparator = ".";
                System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
                
                //inserto transaccion
                string insert_transac = "insert into qwerty.transacciones (numero_cuenta,tipo_cuenta,cliente_id,tipo_transaccion,fecha_transaccion,importe,costo_id) values(" + this.nro_cta + ",'" + comboBox_tipocuenta.SelectedItem.ToString() + "'," + this.id_cliente + ",'Modificacion Cuenta','" + dia.Hoy().ToString("yyyy-MM-dd") + "'," + costo_transac + ",3)";
                db.insert_query(insert_transac);
                //inserto transaccion FINN
                
                //busco id de categoria seleccionada
                string busco_Cat="select cc.categoria_id from qwerty.categorias_de_cuentas cc where cc.descripcion='"+comboBox_tipocuenta.SelectedItem.ToString()+"'";
                dt=db.select_query(busco_Cat);
                int categoria_nueva=0;
                foreach(DataRow row in dt.Rows){
                    categoria_nueva=Convert.ToInt32(row["categoria_id"]);
                }
                //busco id de categoria seleccionada FINN
                
                // inserto en cambio de cuenta
                //string insert_cambiocta = "insert into qwerty.cambios_de_cuentas (numero_cuenta,categoria,costo_id,fecha_cambio) values ("+this.nro_cta+","+categoria_nueva+",2,'"+new Dia().Hoy()+"')";
                string insert_cambiocta = "insert into qwerty.cambios_de_cuentas (numero_cuenta,categoria,costo_id,fecha_cambio) values (" + this.nro_cta + "," + categoria_nueva + ",2,'" + new Dia().tiempoHoy().ToString("yyyy-MM-dd HH:mm:ss") + "')";
                db.insert_query(insert_cambiocta);
                // inserto en cambio de cuenta FIN

                //chequeo si tiene mas de 5 transacciones sin facturar en esta cuenta entonces si es asi lo inhabilito
                string cant_transac = "select * from qwerty.transacciones t where t.factura_id is null and t.cliente_id=" + id_cliente + " and t.numero_cuenta=" + nro_cta + " and t.banco_id=" + banco_id;
                dt = db.select_query(cant_transac);
                int cantidad = 0;
                foreach (DataRow row in dt.Rows)
                {
                    cantidad++;

                }
                if (cantidad > 5)
                {//inhabilito cuenta
                    
                    string insert_cuenta_inhabilitada = "insert into qwerty.inhabilitaciones_por_cuenta (inhabilitacion_id,numero_cuenta,banco_id,fecha) values (1," + this.nro_cta + "," + this.banco_id + ",'" + dia.Hoy().ToString("yyyy-MM-dd") + "')";
                    db.insert_query(insert_cuenta_inhabilitada);
                    string updateo_cuenta_Estado = "update qwerty.cuentas set estado_id=4 where numero_cuenta=" + this.nro_cta;
                    db.update_query(updateo_cuenta_Estado);
                    MessageBox.Show("Cuenta inhabilitada:" + " " + this.nro_cta);
                };

                //termino de cheqear
            }
            
            this.Close();
        
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
