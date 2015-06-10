using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Home;
namespace PagoElectronico.Consulta_Saldos
{
    public partial class Saldo : Form
    {
        string idCliente;
        public Saldo(string idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            this.cargarCuentas();
        }

        public void cargarCuentas()
        {
            

            DataTable cuentas  = new Home2().getCuentas(this.idCliente);

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

            DataTable transferencias = home2.getTransferencias10(numeroCuenta);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = transferencias;
            dataGridTransferencias.DataSource = bsource;

            DataTable retiros = home2.getRetiros5(numeroCuenta);
            BindingSource bsource2 = new BindingSource();
            bsource2.DataSource = retiros;
            dataGridRetiros.DataSource = bsource2;

            DataTable depositos = home2.getDepositos5(numeroCuenta);
            BindingSource bsource3 = new BindingSource();
            bsource3.DataSource = depositos;
            dataGridDepositos.DataSource = bsource3;

            saldo1.Text = home2.getSaldo(numeroCuenta);
        }
    }
}
