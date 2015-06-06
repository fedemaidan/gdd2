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
    public partial class Tarjetas : Form
    {
        string username;

        public Tarjetas(string username)
        {
            this.username = username;
            InitializeComponent();
            this.buscarTarjetas();
            monthCalendar1Ven.Visible = false;
            monthCalendar2Em.Visible = false;
        }



        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.buscarTarjetas();
        }

        private void buscarTarjetas()
        {

            DataTable dt = new Home2().getTarjetasDelCliente(this.username, textDigitBuscar.Text, cbEmisores.Text, txtFechaEmision.Text, txtFechaVen.Text);

            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            dataGridView1.DataSource = bsource;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            new agregarTarjeta(this.username).Show();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            string numeroTarjeta = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            new editTarjeta(this.username, numeroTarjeta).Show();
        }

        private void btn_desasociar_Click(object sender, EventArgs e)
        {
            string numeroTarjeta = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int result = new Home2().desasociarTarjeta(numeroTarjeta);
            if (result == 1)
                MessageBox.Show("Tarjeta desasociada");
            else
                MessageBox.Show("No se pudo realizar la accion");
        }

        private void monthCalendar2Em_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtFechaEmision.Text = monthCalendar2Em.SelectionStart.ToLongDateString();
            monthCalendar2Em.Visible = false;
        }

        private void monthCalendar1Ven_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtFechaVen.Text = monthCalendar1Ven.SelectionStart.ToLongDateString();
            monthCalendar1Ven.Visible = false;
        }

        private void txtFechaEmision_TextChanged(object sender, EventArgs e)
        {
            txtFechaEmision.Text = monthCalendar2Em.SelectionStart.ToString("yyyy-MM-dd");
        }

        private void txtFechaVen_TextChanged(object sender, EventArgs e)
        {
            txtFechaVen.Text = monthCalendar1Ven.SelectionStart.ToString("yyyy-MM-dd");
        }

        private void BtnFechaEmision_Click(object sender, EventArgs e)
        {
            monthCalendar2Em.Visible = true;
        }

        private void BtnFechaVencimiento_Click(object sender, EventArgs e)
        {
            monthCalendar1Ven.Visible = true;
        }

    }
}
