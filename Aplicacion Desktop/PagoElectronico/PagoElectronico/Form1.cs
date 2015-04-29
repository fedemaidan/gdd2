using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;

namespace PagoElectronico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Database data = new Database();
            data.select_query("select * from dgfgfdf");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
