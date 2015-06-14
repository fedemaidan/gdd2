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
    public partial class AddCliente : Form
    {
        public AddCliente()
        {
            InitializeComponent();
            this.cargarComboTipoDoc();
            this.cargarComboPaises();
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

        private void cargarComboPaises()
        {
            Home2 home2 = new Home2();
            DataTable paises = home2.getPaisesList();

            int rows = paises.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                cb_pais.Items.Add(paises.Rows[i]["desc_pais"]);
            }
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            if (this.validar(this))
            {
                Home2 home2 = new Home2();
                string nacimiento = textBox_fecha.Text;

                string username = home2.insertarCliente(txt_nombre.Text, txt_apellido.Text, txt_mail.Text, txt_dni.Text, cb_docs.Text, cb_pais.Text, txt_calle.Text, txt_altura.Text, txt_piso.Text, txt_depto.Text, txt_localidad.Text, txt_nacionalidad.Text, nacimiento, txt_username.Text, txt_password.Text, txt_pregunta.Text, txt_respuesta.Text);
                if (username != "")
                {
                    this.Close();
    
                }
                else
                    MessageBox.Show("No se pudo agregar cliente");
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
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

        private void txt_username_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser letra, digito o .");
                e.Handled = true;
                return;
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Caracter debe ser letra, digito");
                e.Handled = true;
                return;
            }
        }

        private void txt_pregunta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\'') || (e.KeyChar == '"') || (e.KeyChar == ' '))
            {
                MessageBox.Show("Caracter debe ser distinto de \" , ' y espacio");
                e.Handled = true;
                return;
            }
        }

        private void txt_respuesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\'') || (e.KeyChar == '"') || (e.KeyChar == ' '))
            {
                MessageBox.Show("Caracter debe ser distinto de \" , ' y espacio");
                e.Handled = true;
                return;
            }
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
                MessageBox.Show("Caracter debe ser letra, digito , @ o .") ;
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

        private void AddCliente_Load(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_docs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox_fecha.Text = monthCalendar1.SelectionStart.ToLongDateString();
            monthCalendar1.Visible = false;
        }

    }
}
