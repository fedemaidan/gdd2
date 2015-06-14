using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using PagoElectronico.Model;

namespace PagoElectronico.Home
{
    class homeDB
    {
        private Database db = new Database();

        public homeDB() { }

        public Dictionary<String, Object> getUserData(String user, String pass)
        {
            Dictionary<String, Object> values = new Dictionary<String, Object>();
            this.verifyUser(user, pass);
            values = this.getUserConfig(user, pass);

            return values;
        }
        public string encriptacionSHA256(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        //Verifico que el usuario que se loguea sea Adminn o Receps
        //Verifico que su password sea correcta
        //Verifico que no este inhabilitado
        //public void verifyUser(User logginUser) {
        private void verifyUser(String user, String password2)
        {
            //user = UserAdmin.logginUser.getUserName();
            /*String password = logginUser.getPassword(); */
            string password = encriptacionSHA256(password2);


            String rol = "";
            String db_password = "";
            string estado="1";
            String query = "select r.descripcion, u.pass_usuario,u.estado from qwerty.usuarios u, qwerty.roles_de_usuarios ur,qwerty.roles r where ur.rol_id = r.rol_id and u.nombre_usuario= ur.nombre_usuario and	ur.nombre_usuario = '"+user+"'";
            DataTable dt = db.select_query(query);

            if (dt.Rows.Count != 0)
            {
                estado=(string)dt.Rows[0]["estado"];
                if ( estado == "0")
                {
                    throw new Exception("Usuario inhabilitado");
                }
                else
                {
                    rol = (string)dt.Rows[0]["descripcion"];
                    db_password = (string)dt.Rows[0]["pass_usuario"];
                }
            }

            if (rol != "Administrador" && rol != "Cliente")
                throw new Exception("Usuario inexistente");

            if (db_password != password)
            {
                throw new Exception("Contraseña incorrecta");
            }

        }

        //Verifico que no este en la tabla de usuarios inhabilitados
        private void isUserAvaible(String username)
        {
            String query = "select u.estado from qwerty.usuarios u where u.nombre_usuario='"+username+"'";
            DataTable dt = db.select_query(query);
            char estado = '0';
            foreach(DataRow row in dt.Rows){
                estado = Convert.ToChar(row["estado"].ToString());             
            }
            if (estado == '0')
            {
                throw new Exception("Usuario Inhabilitado");
            }


        }

        public void upUser(User user)
        {

        }

        public void downUser(String username)
        {
            Database db = new Database();
            String query = "insert into qwerty.baja_usuarios values ('" + username + "','Eliminado por el administrador');";
            // String update = "update qwerty.usuarios set status= 'B' where username ='" + username +"';";
            String delete = "delete from qwerty.usuarios where username ='" + username + "';";
            db.insert_query(query);
            // db.update_query(update);
            db.delete_query(delete);
        }

        //Obtengo una lista de todos los usuarios 
        public DataTable getUsersList()
        {
            String query = "select u.nombre_usuario from qwerty.usuarios;";
            DataTable dt = db.select_query(query);
            return dt;
        }

        //Traigo datos del usuario y los paso de un dataTable a un diccionario
        public Dictionary<String, Object> getUserConfig(String username, String password)
        {
            
            //String query = "select * from qwerty.usuarios where username ='"+username+"' and password = '"+password+"';";
            String query = "select * from qwerty.usuarios where nombre_usuario ='" + username + "';";
            String query_rol = "select r.descripcion as rol from qwerty.roles_de_usuarios ur,qwerty.roles r where ur.rol_id = r.rol_id and ur.nombre_usuario = '" + username + "'";
            
            
            DataTable dt = db.select_query(query);
            DataTable dt_rol = db.select_query(query_rol);
            
            
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            Dictionary<String, Object> dic_rol = new Dictionary<String, Object>();
            
            

            /*CARGO DIC*/
            foreach (DataColumn dc in dt.Columns)
            {

                int rows = dt.Rows.Count;
                for (int i = 0; i < rows; i++)
                    dic[dc.ToString().ToLower()] = dt.Rows[i][dc];
            }
            /*CARGO DIC ROL*/
            foreach (DataColumn dc in dt_rol.Columns)
            {

                int rows = dt_rol.Rows.Count;
                for (int i = 0; i < rows; i++)
                    dic_rol[dc.ToString().ToLower() + "_" + i.ToString()] = dt_rol.Rows[i][dc];
            }

            
            
            Dictionary<String, Object> dic_final = dic.Union(dic_rol).ToDictionary(key => key.Key, value => value.Value);
            
            return dic_final;
        }

        //Setea a un usuario como inhabilitado
        public void setUnavaibleUser(String user)
        {
            Database db = new Database();
            string qeri = "update qwerty.usuarios set estado=0 where nombre_usuario='"+user.ToString()+"'";
            //String query = "insert into qwerty.usuarios_inhabilitados values('" + user.ToString() + "',Intento loguearse 3 veces sin exito);";
            db.insert_query(qeri);
        }

    

    }



}
