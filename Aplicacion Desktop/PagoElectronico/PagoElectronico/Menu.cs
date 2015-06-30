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
using PagoElectronico.Transferencias;
using PagoElectronico.Retiros;
using PagoElectronico.ABM_Cliente;
using PagoElectronico.Consulta_Saldos;
using PagoElectronico.Tarjeta;
using PagoElectronico.Facturacion;


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
            this.ABM_de_Rol.Visible = false;
            this.ABM_de_Usuario.Visible = false;
            this.ABM_de_cuenta.Visible = false;
            this.Deposito.Visible = false;
            this.retirar_dinero.Visible = false;
            this.Transferencias.Visible = false;
            this.button_facturacion.Visible = false;
            this.button_consulta_saldo.Visible = false;
            this.button_listado.Visible = false;
            this.button_tarjeta.Visible = false;
            this.button_cliente.Visible = false;

            if (this.logged_user.funcionalidades.Contains(1))  //funcionalidad 1 
            { this.ABM_de_Rol.Visible = true; }
            //if (this.logged_user.funcionalidades.Contains(2))  //funcionalidad 2
            //{ this.ABM_de_Usuario.Visible = true; }
            if (this.logged_user.funcionalidades.Contains(3))  //funcionalidad 3
            { this.button_cliente.Visible = true; }
            if (this.logged_user.funcionalidades.Contains(4))  //funcionalidad 4 
            { this.ABM_de_cuenta.Visible = true; }
            if (this.logged_user.funcionalidades.Contains(5))  //funcionalidad 5 abm cliente
            { this.button_cliente.Visible = true; }
            if (this.logged_user.funcionalidades.Contains(6))  //funcionalidad 6 ASOCIAR y desasociar TARJETA DE CREDITO 
            { this.button_tarjeta.Visible = true; }
            if (this.logged_user.funcionalidades.Contains(7))  //funcionalidad 7
            {this.Deposito.Visible = true;}
            if (this.logged_user.funcionalidades.Contains(8))  //funcionalidad 8
            { this.retirar_dinero.Visible = true; }
            if (this.logged_user.funcionalidades.Contains(9))  //funcionalidad 9
            { this.Transferencias.Visible = true; }
            if (this.logged_user.funcionalidades.Contains(10))  //funcionalidad 10
            { this.button_facturacion.Visible = true; }
            if (this.logged_user.funcionalidades.Contains(11))  //funcionalidad 11
            { this.button_consulta_saldo.Visible = true; }
            if (this.logged_user.funcionalidades.Contains(12))  //funcionalidad 12
            { this.button_listado.Visible = true; }

        }


        public User getUserLogged()
        {
            return this.logged_user;
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

        private void button5_Click(object sender, EventArgs e)
        {
            ABM_Cliente.AddCliente abm = new AddCliente();
            
                abm.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ABM_depositos abm = new ABM_depositos(this.logged_user);
            abm.Show();
                      
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ABM_transferencias abm = new ABM_transferencias(this.logged_user);
            abm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ABM_Retiro_de_dinero abm = new ABM_Retiro_de_dinero(this.logged_user);
            abm.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            guestABM abm = new guestABM();
            abm.Show();
        }

        private void button_consulta_saldo_Click(object sender, EventArgs e)
        {
            new Saldo(this.logged_user.getUserName()).Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Tarjetas tarjeta = new Tarjetas(this.logged_user.getUserName());
            tarjeta.Show();
        }

        private void button_listado_Click(object sender, EventArgs e)
        {
            new Listados.ListadosEstadisticos().Show();
        }

        private void button_facturacion_Click(object sender, EventArgs e)
        {
            Facturacion.Facturacion abm = new Facturacion.Facturacion(this.logged_user);
            abm.Show();
        }

        private void label_logged_Click(object sender, EventArgs e)
        {

        }
    }
}
