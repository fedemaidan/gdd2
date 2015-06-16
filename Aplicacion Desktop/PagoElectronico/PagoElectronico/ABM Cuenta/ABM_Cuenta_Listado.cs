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
    public partial class ABM_Cuenta_Listado : Form
    {
        public ABM_Cuenta_Listado(User user)
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
            //  termino de agregar paises al combobox

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
            if (user.getRol() == "Administrador") { qeri = "select c.numero_cuenta as Cuenta,cli.nombre_usuario as Usuario,c.saldo as Saldo,c.fecha_apertura,c.fecha_cierre,m.descripcion as Moneda,p.desc_pais as País,cc.descripcion as Categoría, c.estado_id as Estado from qwerty.cuentas c, qwerty.paises p, qwerty.monedas m, qwerty.categorias_de_cuentas cc,qwerty.clientes cli  where  m.moneda_id=c.moneda_id and cc.categoria_id=c.categoria_id and c.cod_pais=p.cod_pais  and c.cliente_id=cli.cliente_id"; }
            else { qeri = "select c.numero_cuenta as Cuenta,c.saldo as Saldo,c.estado_id as Estado,c.fecha_apertura,c.fecha_cierre,m.descripcion as Moneda,p.desc_pais as País,cc.descripcion as categoría from qwerty.cuentas c, qwerty.paises p, qwerty.monedas m, qwerty.categorias_de_cuentas cc  where c.cliente_id=" + this.id_cliente + " and m.moneda_id=c.moneda_id and  p.cod_pais=c.cod_pais and cc.categoria_id=c.categoria_id"; }
            
            
            DataTable dt2 = new DataTable();
            BindingSource bsource = new BindingSource();
            //string qeri = "select * from qwerty.cuentas where cliente_id="+id_cliente;
            dt2 = db.select_query(qeri);
            bsource.DataSource = dt2;
            dataGridView1.DataSource = bsource;
            
            if (Convert.ToInt32(dataGridView1.RowCount.ToString()) == 1) { button4.Enabled = false; }
        }
        private int id_cliente;
        private User user;
        

        private void ABM_Cuenta_Listado_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox_pais.SelectedIndex = 0;
            textBox_cuenta.Clear();
            button3.Enabled = false;
            dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            BindingSource bsource = new BindingSource();
            string qeri = "";
            if (user.getRol() == "Administrador") { qeri = "select c.numero_cuenta as Cuenta,cli.nombre_usuario as Usuario,c.saldo as Saldo,c.fecha_apertura,c.fecha_cierre,m.descripcion as Moneda,p.desc_pais as País,cc.descripcion as Categoría, c.estado_id as Estado from qwerty.cuentas c, qwerty.paises p, qwerty.monedas m, qwerty.categorias_de_cuentas cc,qwerty.clientes cli  where  c.numero_cuenta like '%" + textBox_cuenta.Text + "%' and p.desc_pais like '%" + comboBox_pais.SelectedItem.ToString() + "%' and p.cod_pais=c.cod_pais and m.moneda_id=c.moneda_id and cc.categoria_id=c.categoria_id  and c.cliente_id=cli.cliente_id"; }
            else { qeri = "select c.numero_cuenta as Cuenta,c.saldo as Saldo,c.estado_id as Estado,c.fecha_apertura,c.fecha_cierre,m.descripcion as Moneda,p.desc_pais as País,cc.descripcion as categoría from qwerty.cuentas c, qwerty.paises p, qwerty.monedas m, qwerty.categorias_de_cuentas cc  where c.numero_cuenta like '%" + textBox_cuenta.Text + "%' and p.desc_pais like '%" + comboBox_pais.SelectedItem.ToString() + "%' and c.cliente_id=" + this.id_cliente + " and m.moneda_id=c.moneda_id and cc.categoria_id=c.categoria_id and p.cod_pais=c.cod_pais "; }
            
            dt = db.select_query(qeri);
            bsource.DataSource = dt;
            dataGridView1.DataSource = bsource;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
            Int64 nro_cta = Convert.ToInt64(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Modificacion_Cuenta rml = new Modificacion_Cuenta(nro_cta, this.dataGridView1.CurrentRow.Cells[5].Value.ToString(), this.dataGridView1.CurrentRow.Cells[7].Value.ToString(),this.dataGridView1.CurrentRow.Cells[6].Value.ToString());
                    
            rml.textBox_fecha.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
            rml.Show();
        }
    }
}
