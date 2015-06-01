using System;
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
    public partial class ABM_Cuenta_Menu : Form
    {
        public ABM_Cuenta_Menu(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private User user;

        private void ABM_Cuenta_Menu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ABM_Cuenta_Listado abm = new ABM_Cuenta_Listado(user);
            abm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ABM_Cuenta abm = new ABM_Cuenta(user);
            abm.Show();
        }
    }
}
