using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;
using PagoElectronico.Home;

namespace PagoElectronico.Tarjeta
{
    public partial class agregarTarjeta : Form
    {
        string username;
        public agregarTarjeta(string username)
        {
            this.username = username;
            InitializeComponent();
            monthCalendar2.Visible = false;
            monthCalendar1.Visible = false;
            this.cargarComboBancos();

        }


        private void cargarComboBancos()
        {
            Home2 home2 = new Home2();
            DataTable bancos = home2.getBancosList();

            int rows = bancos.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
               cbBanco.Items.Add(bancos.Rows[i]["nombre"]);
            }

            DataTable emisores = home2.getEmisoresList();

            rows = emisores.Rows.Count;

            for (int i = 0; i < rows; i++)
            {
                cbEmisor.Items.Add(emisores.Rows[i]["nombre"]);
            }

            DataTable cuentas = home2.getCuentas(this.username);

            rows = cuentas.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                cbCuentas.Items.Add(cuentas.Rows[i]["numero_cuenta"]);
            }

        }


        private void BtnFechaEmision_Click(object sender, EventArgs e)
        {
            Dia d = new Dia();
            monthCalendar1.SetDate(d.Hoy());
            monthCalendar1.Show();
        }

        private void BtnFechaVencimiento_Click(object sender, EventArgs e)
        {
            Dia d = new Dia();
            monthCalendar2.SetDate(d.Hoy());
            monthCalendar2.Show();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaEmision.Text = monthCalendar1.SelectionStart.ToLongDateString();
            monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaVen.Text = monthCalendar2.SelectionStart.ToLongDateString();
            monthCalendar2.Visible = false;
        }

        private void txtFechaVen_TextChanged(object sender, EventArgs e)
        {
            txtFechaVen.Text = monthCalendar2.SelectionStart.ToString("yyyy-MM-dd");
        }

        private void txtFechaEmision_TextChanged(object sender, EventArgs e)
        {
            txtFechaEmision.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
        }

        private void agregarTarjeta_Load(object sender, EventArgs e)
        {

        }

        private void asociar_Click(object sender, EventArgs e)
        {
            //DateTime fechaEmision = Convert.ToDateTime(txtFechaEmision.Text);
            //DateTime fechaVen = Convert.ToDateTime(txtFechaVen.Text);
            
            DateTime fechaEmision = Convert.ToDateTime( txtFechaEmision.Text);
            DateTime fechaVen = Convert.ToDateTime( txtFechaVen.Text);
            int resultado = new Home2().asociarTarjetaACliente(this.username, txtNumeroTarjeta.Text, cbBanco.Text,fechaEmision, fechaVen, txtCodSeguridad.Text, cbEmisor.Text, cbCuentas.Text);
            if (resultado == 1)
            {
                this.Close();
            }
            else
                MessageBox.Show("No se pudo agregar cliente");
        }

        private void cbEmisor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumeroTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                MessageBox.Show("Caracter digito");
            }
        }

        private void txtCodSeguridad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                MessageBox.Show("Caracter debe ser digito ");
            }
        }


       
       
    }
}

