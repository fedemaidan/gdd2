using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;
using PagoElectronico.ABM_Rol;
using PagoElectronico.ABM_de_Usuario;
using PagoElectronico.ABM_Cuenta;
using PagoElectronico.Login;
using PagoElectronico.Depositos;

namespace PagoElectronico
{
    public partial class Menu : Form
    {
        public static Menu Instance;
        public User logged_user = null;
       
        public Menu()
        {
            Instance = this;
            InitializeComponent();
            //Database data = new Database();
            //data.select_query("select * from dgfgfdf");

        }
        public static Menu sharedInstance()
        {
            return Instance;
        }

        public void setUserLogged(User user)
        {
            this.label_logged.Text = user.getUserName();
            this.logged_user = user;


            if (this.logged_user.funcionalidades.Contains(1))  ; //funcionalidad 1 this.button_ABMCheckIn.Visible = true;
            if (this.logged_user.funcionalidades.Contains(2)) ; //funcionalidad 1this.button2.Visible = true;
            if (this.logged_user.funcionalidades.Contains(3)) ; //funcionalidad 1this.button_ABMReserva.Visible = true;
            if (this.logged_user.funcionalidades.Contains(4)) ; //funcionalidad 1.button_CancelarReserva.Visible = true;
            if (this.logged_user.funcionalidades.Contains(5)) ; //funcionalidad 1 this.btn_user_abm.Visible = true;
            if (this.logged_user.funcionalidades.Contains(6)) ; //funcionalidad 1this.button_ABMCliente.Visible = true;
            if (this.logged_user.funcionalidades.Contains(7)) ; //funcionalidad 1this.button_ABMHotel.Visible = true;
            if (this.logged_user.funcionalidades.Contains(8)) ; //funcionalidad 1this.button_ABMHabitacion.Visible = true;
            if (this.logged_user.funcionalidades.Contains(9)) ; //funcionalidad 1this.button_listados.Visible = true;
            if (this.logged_user.funcionalidades.Contains(10)) ; //funcionalidad 1 this.button3.Visible = true;

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ABM_Rol.ABM_Rol abm = new ABM_Rol.ABM_Rol();
            abm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userABM abm = new userABM();
            abm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login_window log = new login_window();
            log.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //int id_cliente = 1; //falta 
            ABM_Cuenta.ABM_Cuenta_Menu abm2 = new ABM_Cuenta.ABM_Cuenta_Menu(this.logged_user);
            abm2.Show();
        }

        private void label_logged_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ABM_de_Usuario.altaUsuario abm = new ABM_de_Usuario.altaUsuario(this.logged_user);
                abm.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ABM_depositos abm = new ABM_depositos(this.logged_user);
            abm.Show();
                      
        }
    }
}
