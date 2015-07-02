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

namespace PagoElectronico.Tarjeta
{
    public partial class editTarjeta : Form
    {
        string username;
        string numeroTarjeta;

        public editTarjeta(string username, string numeroTarjeta)
        {
            
            this.numeroTarjeta = numeroTarjeta;
            this.username = username;
            InitializeComponent();
            this.completarDatos();
            monthCalendar2.Visible = false;
            monthCalendar1.Visible = false;
            this.cargarComboBancos();
            
        }

        private void completarDatos()
        {
            DataRow tarjeta = new Home2().getTarjeta(this.numeroTarjeta);
            
            monthCalendar2.SelectionStart = Convert.ToDateTime(tarjeta["fecha_vencimiento"].ToString());
            monthCalendar1.SelectionStart = Convert.ToDateTime(tarjeta["fecha_emision"].ToString());

            txtCodSeguridad.Text = tarjeta["cod_seguridad"].ToString();
            txtFechaEmision.Text = tarjeta["fecha_emision"].ToString();
            txtFechaVen.Text = tarjeta["fecha_vencimiento"].ToString();
            txtNumeroTarjeta.Text = tarjeta["numero_tarjeta"].ToString();
            cbEmisor.Text = tarjeta["nombre"].ToString();

        }

        private void cargarComboBancos()
        {
            Home2 home2 = new Home2();
            DataTable tipoDoc = home2.getEmisoresList();

            int rows = tipoDoc.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                cbEmisor.Items.Add(tipoDoc.Rows[i]["nombre"]);
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


        private void editTarjeta_Load(object sender, EventArgs e)
        {

        }

        private void editar_Click(object sender, EventArgs e)
        {

            DateTime fechaEmision = Convert.ToDateTime( txtFechaEmision.Text);
            DateTime fechaVen = Convert.ToDateTime( txtFechaVen.Text);
            int resultado = new Home2().updateTarjeta(this.username, txtNumeroTarjeta.Text, cbEmisor.Text, txtFechaEmision.Text, txtFechaVen.Text, txtCodSeguridad.Text);
            if (resultado == 1)
            {
                MessageBox.Show("Tarjeta editada correctamente");
                this.Close();
            }
            else
                MessageBox.Show("No se pudo editar tarjeta");
        }

        private void txtFechaEmisor_TextChanged(object sender, EventArgs e)
        {
            txtFechaEmision.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumeroTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser digito");
                e.Handled = true;
                return;
            }
        }

        private void cbEmisor_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("No se puede escribir en el combo");
            e.Handled = true;
            return;
        }

    }
}
