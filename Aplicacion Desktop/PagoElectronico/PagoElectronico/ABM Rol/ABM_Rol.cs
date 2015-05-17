using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;

namespace PagoElectronico.ABM_Rol
{
    public partial class ABM_Rol : Form
    {
        public ABM_Rol()
        {
            InitializeComponent();
        }

        private void ABM_Rol_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            BindingSource bsource = new BindingSource();
            string qeri = "select r.rol_id,r.descripcion,r.estado from QWERTY.Roles r where r.descripcion like '%" + textBox1.Text + "%'";
            dt = db.select_query(qeri);
            bsource.DataSource = dt;
            dataGridView1.DataSource = bsource;
            
            //this.dataGridView1.Columns[0].Visible = false;
            //this.dataGridView1.Columns[2].Visible = false;
            //this.dataGridView1.AllowUserToAddRows = false;//si no pongo esto me agrega una ultima fila editable
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Int32 id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            ABMRol_Modificacion_Listado rml = new ABMRol_Modificacion_Listado(id);
            //MessageBox.Show(this.dataGridView1.CurrentRow.Cells[2].Value.ToString());
            rml.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (this.dataGridView1.CurrentRow.Cells[2].Value.ToString() == "False") { rml.radioButton_baja.Checked = true; }
            else { rml.radioButton_alta.Checked = true; }
            //MessageBox.Show(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
            

            rml.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            button3.Enabled = false;
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ABMAlta_Rol abm = new ABMAlta_Rol();
            abm.Show();

        }
    }
}
