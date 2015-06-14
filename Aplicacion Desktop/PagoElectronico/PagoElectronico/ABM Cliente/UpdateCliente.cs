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

namespace PagoElectronico.ABM_Cliente
{
    public partial class UpdateCliente : Form
    {
        string username;
        string habilitado;
        public UpdateCliente(string username)
        {
            InitializeComponent();
            this.username = username;
            
            this.cargarDatosDelCliente();
            this.cargarComboTipoDoc();
        }

        private void cargarDatosDelCliente()
        {
            Home2 home2 = new Home2();
            DataRow datosCliente = home2.getClient(this.username);

            txt_nombre.Text = datosCliente["nombre"].ToString();
            txt_apellido.Text = datosCliente["apellido"].ToString();
            txt_pais.Text = datosCliente["pais"].ToString();
            txt_mail.Text = datosCliente["mail"].ToString();
            txt_dni.Text = datosCliente["nro_documento"].ToString();
            cb_docs.Text = datosCliente["tipo_doc"].ToString();
            txt_calle.Text = datosCliente["calle"].ToString();
            txt_altura.Text = datosCliente["altura"].ToString();
            txt_piso.Text = datosCliente["piso"].ToString();
            txt_depto.Text = datosCliente["depto"].ToString();
            txt_localidad.Text = datosCliente["localidad"].ToString();
            txt_nacionalidad.Text = datosCliente["nacionalidad"].ToString();
            textBox_fecha.Text = datosCliente["fecha_nacimiento"].ToString();

            this.habilitado = datosCliente["habilitado"].ToString();

            if (this.habilitado != "S")
                this.btnDarDeAlta.Visible = true;
            else
                this.btnDarDeAlta.Visible = false;
        }

        private void cargarComboTipoDoc()
        {
            Home2 home2 = new Home2();
            DataTable tipoDoc = home2.getTipoDocList();

            int rows = tipoDoc.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                cb_docs.Items.Add(tipoDoc.Rows[i]["tipo_doc"]);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox_fecha.Text = monthCalendar1.SelectionStart.ToLongDateString();
            monthCalendar1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dia d = new Dia();
            monthCalendar1.SetDate(d.Hoy());
            monthCalendar1.Show();
        }

        private void textBox_fecha_TextChanged(object sender, EventArgs e)
        {
            textBox_fecha.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
        }

        private bool validar(Form form)
        {
            bool vacio = false;
            foreach (Control cont in form.Controls)
            {
                if (cont is TextBox && (cont.Text == String.Empty)) { vacio = true; }
            }

            if (vacio == true) { MessageBox.Show("Por favor llene todos los campos"); }

            return !vacio;
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\'') || (e.KeyChar == '"') || (e.KeyChar == ' '))
            {
                MessageBox.Show("Caracter debe ser distinto de \" , ' y espacio");
                e.Handled = true;
                return;
            }
        }

        private void txt_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\'') || (e.KeyChar == '"') || (e.KeyChar == ' '))
            {
                MessageBox.Show("Caracter debe ser distinto de \" , ' y espacio");
                e.Handled = true;
                return;
            }
        }

        private void txt_dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser digito");
                e.Handled = true;
                return;
            }

        }

        private void txt_nacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser letra");
                e.Handled = true;
                return;
            }

        }

        private void txt_mail_TextChanged(object sender, EventArgs e)
        {


        }

        private void txt_mail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != '@') && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser letra, digito , @ o .");
                e.Handled = true;
                return;
            }
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser digito");
                e.Handled = true;
                return;
            }
        }

        private void txt_pais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser letra");
                e.Handled = true;
                return;
            }
        }

        private void txt_calle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser letra, digito");
                e.Handled = true;
                return;
            }
        }

        private void txt_altura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser digito");
                e.Handled = true;
                return;
            }
        }

        private void txt_piso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser digito");
                e.Handled = true;
                return;
            }
        }

        private void txt_depto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser letra o digito");
                e.Handled = true;
                return;
            }
        }

        private void txt_localidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser letra o digito");
                e.Handled = true;
                return;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            Home2 home2 = new Home2();

 
            int resultado = home2.updateCliente(txt_nombre.Text, txt_apellido.Text, txt_mail.Text, txt_dni.Text, cb_docs.Text, txt_pais.Text, txt_calle.Text, txt_altura.Text, txt_piso.Text, txt_depto.Text, txt_localidad.Text, txt_nacionalidad.Text,textBox_fecha.Text , this.username);

            if (resultado == 1)
                this.Close();
            else
                MessageBox.Show("No se pudo editar cliente");

        }

        private void textBox_fecha_TextChanged_1(object sender, EventArgs e)
        {
            textBox_fecha.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
        }

        private void btnDarDeAlta_Click(object sender, EventArgs e)
        {
                Home2 home2 = new Home2();
                home2.altaCliente(this.username);
                this.Close();
        }


    }
}
