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
    public partial class guestABM : Form
    {
        private homeDB home_db = new homeDB();
        private Home2 home2 = new Home2();
        private List<Cliente> listBox_clients = new List<Cliente>();

        public guestABM()
        {
            
            InitializeComponent();
            this.cargarComboTipoDoc();
            this.buscarClientes();
        }
        private void cargarComboTipoDoc()
        {
            DataTable tipoDoc = home2.getTipoDocList();

                int rows = tipoDoc.Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    comboBox1.Items.Add(tipoDoc.Rows[i]["tipo_doc"]);
                }
        }

        private void buscarClientes()
        {
            DataTable clientsTable ;
            if (comboBox1.SelectedItem != null)
                clientsTable = home2.getClientList(textBox1.Text, textBox3.Text, textBox4.Text, textBox2.Text, comboBox1.SelectedItem.ToString());
            else
                clientsTable = home2.getClientList(textBox1.Text, textBox3.Text, textBox4.Text, textBox2.Text, "");

            BindingSource bsource = new BindingSource();
            bsource.DataSource = clientsTable;
            dataGridView1.DataSource = bsource;
            
            if (dataGridView1.Rows.Count != 0)
                dataGridView1.Rows[0].Selected = true;

        }

        private void guestABM_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.buscarClientes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            dataGridView1.Rows[index].Selected = true;

        }
    }
}
