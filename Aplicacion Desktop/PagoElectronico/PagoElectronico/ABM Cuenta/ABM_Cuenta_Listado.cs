﻿using System;
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
            // tengo q buscar cliente_id en la tabla clientes con el nombre_usuario
            Database db = new Database();
            string qeri_buscoIDcliente = "select c.cliente_id from qwerty.clientes c where c.nombre_usuario='" + user.getUserName() + "'";

            DataTable dt = db.select_query(qeri_buscoIDcliente);
            foreach (DataRow row in dt.Rows)
            {
                this.id_cliente = Convert.ToInt32(row["cliente_id"]);
            }
            //termino de buscar el cliente_id
            InitializeComponent();
            
            DataTable dt2 = new DataTable();
            BindingSource bsource = new BindingSource();
            string qeri = "select * from qwerty.cuentas where cliente_id="+id_cliente;
            dt2 = db.select_query(qeri);
            bsource.DataSource = dt2;
            dataGridView1.DataSource = bsource;
        }
        private int id_cliente;

        private void ABM_Cuenta_Listado_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_pais.Clear();
            textBox_cuenta.Clear();
            button3.Enabled = false;
            dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            BindingSource bsource = new BindingSource();
            string qeri = "select * from qwerty.cuentas c where c.numero_cuenta like '%"+textBox_cuenta.Text+"%' and c.pais  like '%"+textBox_pais.Text+"%'";
            dt = db.select_query(qeri);
            bsource.DataSource = dt;
            dataGridView1.DataSource = bsource;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Int32 nro_cta = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Modificacion_Cuenta rml = new Modificacion_Cuenta(nro_cta);
            
            rml.textBox_pais.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            rml.textBox_fecha.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            rml.comboBox_moneda.SelectedIndex = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[1].Value.ToString())-1;
            rml.comboBox_tipocuenta.SelectedIndex = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[4].Value.ToString())-1;

            rml.Show();
        }
    }
}