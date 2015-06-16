<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;
using PagoElectronico.ABM_de_Usuario;


namespace PagoElectronico.ABM_Cuenta
{
    public partial class ABM_Cuenta : Form
    {
        public ABM_Cuenta(User user)
        {
            InitializeComponent();

            Database db = new Database();
            DataTable dt = new DataTable();

            if (user.rol != "Administrador")
            {
                this.cb_clientes.Visible = false;
                this.label5.Visible = false;
            }
            else
            {
                string query_user = "select u.nombre_usuario from qwerty.clientes c  join qwerty.usuarios u  on u.nombre_usuario = c.nombre_usuario;";
                db = new Database();
                dt = new DataTable();
                dt = db.select_query(query_user);
                foreach (DataRow row in dt.Rows)
                {
                    cb_clientes.Items.Add(row["nombre_usuario"].ToString());

                }
            }


            Dia dia = new Dia();
            textBox_fecha.Text = dia.Hoy().ToString("yyyy-MM-dd");
            this.user=user;
            
            //agrego paises  al combobox
            string qeri_paises = "select p.desc_pais from qwerty.paises p";
            db = new Database();
            dt = new DataTable();
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

        }
        private User user;
        
        private int id_cliente;

        private void ABM_Cuenta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qeri_buscoIDcliente;
            if (user.rol != "Administrador")
            {
                qeri_buscoIDcliente = "select c.cliente_id from qwerty.clientes c where c.nombre_usuario='" + user.getUserName() + "'";
            }
            else
            {
                qeri_buscoIDcliente = "select c.cliente_id from qwerty.clientes c where c.nombre_usuario='" + cb_clientes.SelectedItem.ToString()  + "'";
            }

            
            Database db = new Database();
            

            // tengo q buscar cliente_id en la tabla clientes con el nombre_usuario
            
            DataTable dt = db.select_query(qeri_buscoIDcliente);
            foreach (DataRow row in dt.Rows)
            {
                this.id_cliente = Convert.ToInt32(row["cliente_id"]);
            }
            //termino de buscar el cliente_id
            
            // IMPORTANTE
            // el numero_cuenta lo meto hardcodeado porque eso hay qe resolverlo en la tabla
            // agregando al campo numero_cuenta la propiedad para que sea autoincrementable
            //Random r = new Random();
            //int aleatorio = r.Next(1,10000000);

            // busco codigo del pais
            string qeri_cod_pais = "select p.cod_pais from qwerty.paises p where p.desc_pais='"+comboBox_pais.SelectedItem.ToString()+"'";
            dt = db.select_query(qeri_cod_pais);
            int cod_pais = 0;
            foreach (DataRow row in dt.Rows) {
                cod_pais = Convert.ToInt32(row["cod_pais"]);
            }
            //termino de buscar codigo del pais
            string qeri_duracion = "select cc.duracion from qwerty.categorias_de_cuentas cc where cc.descripcion='"+comboBox_tipocuenta.SelectedItem.ToString()+"'";
            dt=db.select_query(qeri_duracion);
            int duracion = 0;
            foreach(DataRow row in dt.Rows){
                duracion = Convert.ToInt32(row["duracion"]);
            }
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;
using PagoElectronico.ABM_de_Usuario;


namespace PagoElectronico.ABM_Cuenta
{
    public partial class ABM_Cuenta : Form
    {
        public ABM_Cuenta(User user)
        {
            InitializeComponent();
>>>>>>> Stashed changes
            Dia dia = new Dia();
            textBox_fecha.Text = dia.Hoy().ToString("yyyy-MM-dd");
            this.user=user;
            
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

        }
        private User user;
        
        private int id_cliente;

        private void ABM_Cuenta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            

            // tengo q buscar cliente_id en la tabla clientes con el nombre_usuario
            
            string qeri_buscoIDcliente = "select c.cliente_id from qwerty.clientes c where c.nombre_usuario='" + user.getUserName() + "'";

            DataTable dt = db.select_query(qeri_buscoIDcliente);
            foreach (DataRow row in dt.Rows)
            {
                this.id_cliente = Convert.ToInt32(row["cliente_id"]);
            }
            //termino de buscar el cliente_id
            
            
            // busco codigo del pais
            string qeri_cod_pais = "select p.cod_pais from qwerty.paises p where p.desc_pais='"+comboBox_pais.SelectedItem.ToString()+"'";
            dt = db.select_query(qeri_cod_pais);
            int cod_pais = 0;
            foreach (DataRow row in dt.Rows) {
                cod_pais = Convert.ToInt32(row["cod_pais"]);
            }
            //termino de buscar codigo del pais
            string qeri_duracion = "select cc.duracion from qwerty.categorias_de_cuentas cc where cc.descripcion='"+comboBox_tipocuenta.SelectedItem.ToString()+"'";
            dt=db.select_query(qeri_duracion);
            int duracion = 0;
            foreach(DataRow row in dt.Rows){
                duracion = Convert.ToInt32(row["duracion"]);
            }
            Dia dia = new Dia();

            string queri = "insert into qwerty.cuentas (cod_pais, moneda_id,fecha_apertura,categoria_id,cliente_id,estado_id,fecha_cierre,pendiente_facturacion) values (" + cod_pais + "," + (comboBox_moneda.SelectedIndex + 1) + ",convert(datetime,'" + textBox_fecha.Text + "',121)," + (comboBox_tipocuenta.SelectedIndex + 1) + "," + this.id_cliente + ", 1," + "( dateadd(day," + duracion + ",convert(datetime,'" + dia.Hoy().ToString("yyyy-MM-dd") + "',121))),'S')";
            db.insert_query(queri);

            //obtengo el numero de cuenta q se ingreso
            string qeri_obtengo_nrocta = "select top 1 c.numero_cuenta from qwerty.cuentas c order by c.numero_cuenta desc";
            dt=db.select_query(qeri_obtengo_nrocta);
            Int64 nrocta = 0;
            foreach (DataRow row in dt.Rows) {
                nrocta = Convert.ToInt64(row["numero_cuenta"]);
            }
            //obtengo el numero de cuenta q se ingreso FINN
            string qeri_transac = "insert into qwerty.transacciones (numero_cuenta,tipo_cuenta,cliente_id,tipo_transaccion,fecha_transaccion,importe,costo_id) values ("+nrocta+",'"+comboBox_tipocuenta.SelectedItem.ToString()+"',"+this.id_cliente+",'Apertura Cuenta','"+dia.Hoy()+"',3.99,2)";
            db.insert_query(qeri_transac);

            this.Close();

        }

        private void comboBox_tipocuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
