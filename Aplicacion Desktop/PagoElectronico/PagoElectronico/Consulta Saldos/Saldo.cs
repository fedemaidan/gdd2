using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Home;
using PagoElectronico.Model;

namespace PagoElectronico.Consulta_Saldos
{
    public partial class Saldo : Form
    {
        string username ;
        string banco;
        public Saldo(string username)
        {
            InitializeComponent();
            this.username = username;

            if (PagoElectronico.Menu.sharedInstance().getUserLogged().rol != "Administrador")
            {
                this.cb_clientes.Visible = false;
                this.label6.Visible = false;
                
                this.cargarBancos();
            }
            else
            {
                this.cargarClientes();                
            }

            
        }

        public void cargarClientes()
        {
            string query_user = "select u.nombre_usuario from qwerty.clientes c  join qwerty.usuarios u  on u.nombre_usuario = c.nombre_usuario where baja = 'N';";
            Database db = new Database();
            DataTable dt = db.select_query(query_user);
            foreach (DataRow row in dt.Rows)
            {
                cb_clientes.Items.Add(row["nombre_usuario"].ToString());
            }
        }

        public void cargarBancos() 
        {
            DataTable bancos = new Home2().getBancosList();

            int rows = bancos.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                cb_cs_bancos.Items.Add(bancos.Rows[i]["nombre"]);
            }        
        }

        public void cargarCuentas()
        {
            
            DataTable cuentas = new Home2().getCuentasByBanco(this.username, this.banco);

            int rows = cuentas.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                cbCuentas.Items.Add(cuentas.Rows[i]["numero_cuenta"]);
            }
        }

        private void cbCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numeroCuenta = cbCuentas.Text;
            Home2 home2 = new Home2();

            DataTable transferencias = home2.getTransferencias10(numeroCuenta,this.banco);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = transferencias;
            dataGridTransferencias.DataSource = bsource;

            DataTable retiros = home2.getRetiros5(numeroCuenta,this.banco);
            BindingSource bsource2 = new BindingSource();
            bsource2.DataSource = retiros;
            dataGridRetiros.DataSource = bsource2;

            DataTable depositos = home2.getDepositos5(numeroCuenta,this.banco);
            BindingSource bsource3 = new BindingSource();
            bsource3.DataSource = depositos;
            dataGridDepositos.DataSource = bsource3;

            saldo1.Text = home2.getSaldo(numeroCuenta,this.banco);

           

        }

        private void cb_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.username = this.cb_clientes.SelectedItem.ToString();
            this.cargarBancos();
            
        }

        private void Saldo_Load(object sender, EventArgs e)
        {

        }

        private void cb_cs_bancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.banco = cb_cs_bancos.SelectedItem.ToString();
            this.cargarCuentas();
        }
    }
}
