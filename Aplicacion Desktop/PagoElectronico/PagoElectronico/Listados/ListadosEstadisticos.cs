using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Listados
{
    public partial class ListadosEstadisticos : Form
    {
        public ListadosEstadisticos()
        {
            InitializeComponent();
            this.cargarCombos();
        }

        private void cargarCombos()
        {

            for (int i = 2015; 1950 < i; i--)
            {
                cbAnio.Items.Add(i.ToString());
            }

            for (int i = 1; i < 5; i++)
            {
                cbTrimestre.Items.Add(i.ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string desde = "2010-01-01";   
            string hasta = "2016-01-01";   
            Home.Home2 home2 = new Home.Home2();
            DataTable dt = new DataTable();

            if (radioButton1.Checked)
                dt = home2.getRepo1(desde,hasta);
            if (radioButton2.Checked)
                dt = home2.getRepo2(desde, hasta);
            if (radioButton3.Checked)
                dt = home2.getRepo3(desde, hasta);
            if (radioButton4.Checked)
                dt = home2.getRepo4(desde, hasta);
            if (radioButton5.Checked)
                dt = home2.getRepo5(desde, hasta);

            BindingSource bsource = new BindingSource();
            bsource.DataSource = dt;
            dataGridView1.DataSource = bsource;


        }
    }
}
