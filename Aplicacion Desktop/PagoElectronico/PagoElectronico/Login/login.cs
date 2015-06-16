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
            User onLogginUser =  new User();
            onLogginUser.setUsername(user);
            onLogginUser.setPassword(pass);
            

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
                
                Database db = new Database();
                DateTime ahora = DateTime.Now;
                
                string qeri_log = "insert into qwerty.log (nombre_usuario,tipo_loggin,fecha) values ('" + user.ToString() + "','Logueo correcto',convert(datetime,'" + ahora.ToString("yyyy-MM-dd") + "',121))";
                string borro_intentos_loggin = "delete from qwerty.intentos_loggin where nombre_usuario='" + user.ToString() + "'";
                db.select_query(qeri_log);
                db.delete_query(borro_intentos_loggin);



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
                DataTable dt = new Database().select_query("select rf.Funcion_ID from QWERTY.funcionalidades_por_rol rf join QWERTY.Roles r on r.Rol_ID = rf.Rol_ID where r.descripcion = '" + rol + "';");
                foreach (DataRow row in dt.Rows)
                {
                    logged_user.funcionalidades.Add(Convert.ToInt32(row["funcion_id"]));
                }




               
                logged_user.setRol(rol);
                //home_db.verifyUser(user,pass);
                verify = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                
             
                
            }
            //MessageBox.Show(user.ToString());
            //SI NO EXISTE EL USUARIO LE TENGO QUE DECIR QUE SE LOGUEE
            string qeri_buscousuario = "select u.nombre_usuario from qwerty.usuarios u where u.nombre_usuario='"+user.ToString()+"'";
            Database db2 = new Database();
            DataTable dt2 = new DataTable();
            dt2 = db2.select_query(qeri_buscousuario);
            string user_buscado = "";
            int flag = 0;
            foreach (DataRow row in dt2.Rows) { 
             
            user_buscado= row["nombre_usuario"].ToString() ;
            }
            if (user.ToString() != user_buscado)
            {
                flag = 1;
            }

                //SI INGRESA MAL LA CONTRASEÑA TENGO QUE CONTARLE 3 INTENTOS
                if (!verify && (flag==0))
                {
                    Database db = new Database();
                    DataTable dt = new DataTable();
                    //Dia dia = new Dia();
                    DateTime ahora = DateTime.Now;
                    //obtengo cantidad que lleva de intentos fallidos este usuario
                    string cant_intentos_fallidos = "select top 1 il.intentos from qwerty.intentos_loggin il where il.nombre_usuario='" + user.ToString() + "' order by fecha desc";
                    int intentos = 0;
                    dt = db.select_query(cant_intentos_fallidos);
                    foreach (DataRow row in dt.Rows)
                    {
                        intentos = Convert.ToInt32(row["intentos"].ToString());
                    }
                    fails = intentos;

                    // termino de obtener cantidad de intentos fallidos
                    fails++;
                    //ingreso el intento fallido en intentos_loggin

                    //Dia dia = new Dia();

                    string qeri_ingreso_fallido = "insert into qwerty.intentos_loggin (nombre_usuario,fecha,intentos) values ('" + user.ToString() + "',convert(datetime,'" + ahora.ToString("yyyy-MM-dd") + "',121)," + fails + ")";


                    db.insert_query(qeri_ingreso_fallido);
                    //termino de ingresar el intento en intentos_loggin

                    //ingreso registro en log
                    string qeri_log = "insert into qwerty.log (nombre_usuario,tipo_loggin,fecha) values ('" + user.ToString() + "','Contraseña incorrecta',convert(datetime,'" + ahora.ToString("yyyy-MM-dd") + "',121))";
                    db.insert_query(qeri_log);
                    //termino de ingresar registro en log

                    if (fails > 2)
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

                    if (logged_user != null)
                    {
                        PagoElectronico.Menu.sharedInstance().setUserLogged(logged_user);

                        this.Close();
                    }
                }
            //}
        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_window_Load_1(object sender, EventArgs e)
        {

        }

    }
}
