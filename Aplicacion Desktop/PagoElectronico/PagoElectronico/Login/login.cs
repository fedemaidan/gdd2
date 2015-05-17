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
using PagoElectronico.Login;

namespace PagoElectronico.Login
{
    public partial class login_window : Form
    {
        private homeDB home_db = new homeDB();
        private int fails = 0;

        public login_window()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Boolean verify = false;
            String user = txt_user.Text;
            String pass = txt_pass.Text;
            User logged_user = null;
            /*User onLogginUser =  new User();
            onLogginUser.setUsername(user);
            onLogginUser.setPassword(pass);
            */

            try
            {
                if (user == "")
                {
                    throw new Exception("El nombre de usuario no puede estar vacio");
                }
                if (pass == "")
                {
                    throw new Exception("La constrasenia no puede estar vacia");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Campo incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //VERIFICO QUE SEA ADMIN O RECEPCIONISTA
            //VERIFICO QUE NO SEA UN USUARIO INHABILITADO
            //VERIFICO CONSTRASENIA (FALTA VERIFICAR)
            try
            {
                Dictionary<String, Object> user_values = home_db.getUserData(user, pass);

                logged_user = new UserAdmin(user_values);


                MessageBox.Show("Logueo con exito!!", "Login",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);




                //MOSTRAR CON QUE ROL QUIERE LOGUEARSE
                int rols = logged_user.getRoles().Count();
                String rol = "";
                Console.WriteLine("Cantida de roles: " + rols);
                if (rols > 1)
                {
                    RolSelector rolWindows = new RolSelector(logged_user.getRoles());
                    rolWindows.ShowDialog();
                    rol = rolWindows.getSelectedRol();
                }
                else
                {
                    rol = logged_user.getRoles()[0].ToString();
                }


                logged_user = new UserAdmin(user_values);

                //cargo las funcionalidades
                DataTable dt = new Database().select_query("select rf.Funcionalidad_ID from QWERTY.Roles_Funcionalidades rf join QWERTY.Roles r on r.Rol_ID = rf.Rol_ID where r.Rol = '" + rol + "';");
                foreach (DataRow row in dt.Rows)
                {
                    logged_user.funcionalidades.Add(row.Field<int>(0));
                }




                //MOSTRAR EN QUE HOTEL QUIERE LOGUEARSE

                /*
                int hotels = logged_user.getHotel().Count();
                String hotel = "";
                if (hotels > 1)
                {
                    HotelSelector hotelWindows = new HotelSelector(logged_user.getHotel());
                    hotelWindows.ShowDialog();
                    hotel = hotelWindows.getSelectedHotel();

                }
                else
                {
                    Hotel hotelObj = (Hotel)logged_user.getHotel()[0];
                    hotel = hotelObj.getName();
                }

                logged_user.setLoggedHotel(new Hotel(hotel));
                */

                //home_db.verifyUser(user,pass);
                verify = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //SI NO EXISTE EL USUARIO TENGO QUE CONTAR LOS INTENTOS
            if (!verify)
            {
                fails++;
                if (fails == 3)
                {
                    //INHABILITAR USUARIO, GUARDO UNA TABLA CON LOS USUARIOS INHABILITADOS
                    home_db.setUnavaibleUser(user);
                    MessageBox.Show("Usuario inhabilitado por hacer mas de 3 intentos", "Bloqueo de usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fails = 0;
                }
            }
            else
            {
                fails = 0;

                //REDIRECT A PAGINA PRINCIPAL
                PagoElectronico.Menu.sharedInstance().setUserLogged(logged_user);
                this.Close();
            }
        }

        private int getRowsCount(Object user)
        {
            return 0;
        }
        /*Constructor vacio*/
        private void login_window_Load(object sender, EventArgs e) { }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Boolean verify = false;
            String user = txt_user.Text;
            String pass = txt_pass.Text;
            User logged_user = null;
            /*User onLogginUser =  new User();
            onLogginUser.setUsername(user);
            onLogginUser.setPassword(pass);
            */

            try
            {
                if (user == "")
                {
                    throw new Exception("El nombre de usuario no puede estar vacio");
                }
                if (pass == "")
                {
                    throw new Exception("La constrasenia no puede estar vacia");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Campo incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //VERIFICO QUE SEA ADMIN O RECEPCIONISTA
            //VERIFICO QUE NO SEA UN USUARIO INHABILITADO
            //VERIFICO CONSTRASENIA (FALTA VERIFICAR)
            try
            {
                Dictionary<String, Object> user_values = home_db.getUserData(user, pass);

                logged_user = new UserAdmin(user_values);


                MessageBox.Show("Logueo con exito!!", "Login",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);




                //MOSTRAR CON QUE ROL QUIERE LOGUEARSE
                int rols = logged_user.getRoles().Count();
                String rol = "";
                Console.WriteLine("Cantida de roles: " + rols);
                if (rols > 1)
                {
                    RolSelector rolWindows = new RolSelector(logged_user.getRoles());
                    rolWindows.ShowDialog();
                    rol = rolWindows.getSelectedRol();
                }
                else
                {
                    rol = logged_user.getRoles()[0].ToString();
                }


                logged_user = new UserAdmin(user_values);

                //cargo las funcionalidades
                DataTable dt = new Database().select_query("select rf.Funcionalidad_ID from QWERTY.Roles_Funcionalidades rf join QWERTY.Roles r on r.Rol_ID = rf.Rol_ID where r.Rol = '" + rol + "';");
                foreach (DataRow row in dt.Rows)
                {
                    logged_user.funcionalidades.Add(row.Field<int>(0));
                }




                //MOSTRAR EN QUE HOTEL QUIERE LOGUEARSE
                /*
                int hotels = logged_user.getHotel().Count();
                String hotel = "";
                if (hotels > 1)
                {
                    HotelSelector hotelWindows = new HotelSelector(logged_user.getHotel());
                    hotelWindows.ShowDialog();
                    hotel = hotelWindows.getSelectedHotel();

                }
                else
                {
                    Hotel hotelObj = (Hotel)logged_user.getHotel()[0];
                    hotel = hotelObj.getName();
                }

                logged_user.setLoggedHotel(new Hotel(hotel));*/

                //home_db.verifyUser(user,pass);
                verify = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //SI NO EXISTE EL USUARIO TENGO QUE CONTAR LOS INTENTOS
            if (!verify)
            {
                fails++;
                if (fails == 3)
                {
                    //INHABILITAR USUARIO, GUARDO UNA TABLA CON LOS USUARIOS INHABILITADOS
                    home_db.setUnavaibleUser(user);
                    MessageBox.Show("Usuario inhabilitado por hacer mas de 3 intentos", "Bloqueo de usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fails = 0;
                }
            }
            else
            {
                fails = 0;

                //REDIRECT A PAGINA PRINCIPAL
                PagoElectronico.Menu.sharedInstance().setUserLogged(logged_user);
                this.Close();
            }
        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
