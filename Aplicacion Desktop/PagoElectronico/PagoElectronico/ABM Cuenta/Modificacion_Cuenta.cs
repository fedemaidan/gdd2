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
        public Modificacion_Cuenta(Int64 numero_cta, string moneda, string categoria, string pais)
        {
            InitializeComponent();
            
            this.nro_cta = numero_cta;
            this.moneda = moneda;
            this.categoria = categoria;
            this.desc_pais = pais;

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
            if (cambio == true) {
                // tengo q buscar cliente_id en la tabla clientes con el nombre_usuario
            
            string qeri_buscoIDcliente = "select c.cliente_id from qwerty.cuentas c where c.numero_cuenta="+this.nro_cta;

            dt = db.select_query(qeri_buscoIDcliente);
            foreach (DataRow row in dt.Rows)
            {
                this.id_cliente = Convert.ToInt32(row["cliente_id"]);
            }
            //termino de buscar el cliente_id
                Dia dia= new Dia();
                //busco costo de transaccion
                string qeri_cost_transac = "select ct.costo from qwerty.costos_de_transacciones ct where ct.costo_id=3";
                dt = db.select_query(qeri_cost_transac);
                decimal costo_transac = 0;
                foreach (DataRow row in dt.Rows) { costo_transac = Convert.ToDecimal(row["costo"]); }
                //busco costo de transaccion FIN
                string insert_transac = "insert into qwerty.transacciones (numero_cuenta,tipo_cuenta,cliente_id,tipo_transaccion,fecha_transaccion,importe,costo_id) values("+this.nro_cta+","+(comboBox_tipocuenta.SelectedIndex+1)+","+this.id_cliente+",'Modificacion Cuenta','"+dia.Hoy()+"',"+costo_transac+",3)";
                db.insert_query(insert_transac);
            }
            
            this.Close();
        
        }
    }
}
