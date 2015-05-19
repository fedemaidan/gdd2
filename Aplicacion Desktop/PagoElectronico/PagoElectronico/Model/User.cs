using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PagoElectronico.Home;

namespace PagoElectronico.Model
{
    public class User
    {
        public String password = "";
        public List<Object> roles = new List<Object>();
        public String rol = "";
        public String mail = "";
        public String name = "";
        public String lastName = "";
        public long document = 0;
        public DateTime date = new DateTime();
        public List<Object> hotel = new List<Object>();
        public long telephone = 0;
        public String username = "";
        public List<int> funcionalidades = new List<int>();
        public User() { }

        public User(String name, String pass)
        {
            this.username = name;
            this.password = pass;
        }

        public User(Dictionary<String, Object> values)
        {
            this.fillProperties(values);
        }


        private bool EqualsTo(String username)
        {
            bool result = false;
            if (this.username.Equals(username))
                result = true;
            return result;
        }



        public void fillProperties(Dictionary<String, Object> values)
        {
            Boolean exists_rol = true;
            long i = 0;
            
            this.password = (string)values["pass_usuario"];
            while (exists_rol)
            {

                String rol = "";
                if (values.ContainsKey("rol"))
                {
                    this.rol = (string)values["rol"];
                    this.roles.Add(values["rol"]);
                }

                if (values.ContainsKey("rol" + "_" + i.ToString()))
                {
                    rol = (string)values["rol" + "_" + i.ToString()];
                    this.roles.Add(rol);
                }

                if (rol == "")
                    exists_rol = false;


                i++;

            }
            //this.mail = (string)values["mail"];
            //this.name = (string)values["nombre"];
            //this.lastName = (string)values["apellido"];
            //this.username = (string)values["username"];
            //this.document = Convert.ToInt64(values["dni"].ToString());
            //this.telephone = Convert.ToInt64(values["telefono"].ToString());
            //this.date = (DateTime)values["fecha_nacimiento"];

            //cargo las funcionalidades
            DataTable dt = new Database().select_query("select rf.Funcion_ID from QWERTY.funcionalidades_por_rol rf join QWERTY.Roles r on r.Rol_ID = rf.Rol_ID where r.descripcion = '" + this.rol + "';");
            foreach (DataRow row in dt.Rows)
            {
                this.funcionalidades.Add(Convert.ToInt32(row["funcion_id"]));
               
            }

        }


        public void setYouDown()
        {
            homeDB home = new homeDB();
            home.downUser(this.username);
        }

        public void setYouUP()
        {
            homeDB home = new homeDB();
            home.upUser(this);
        }

        /* GETTERS && SETTERS */
        public String getName() { return this.name; }
        public String getPassword() { return this.password; }
        public String getLastName() { return this.lastName; }
        public String getMail() { return this.mail; }
        public long getDocument() { return this.document; }
        public List<Object> getHotel() { return this.hotel; }
        public DateTime getDate() { return this.date; }
        public List<Object> getRoles() { return this.roles; }
        public String getRol() { return this.rol; }
        public String getUserName() { return this.username; }
        public long getTelephone() { return this.telephone; }
        

        public void setUsername(String username) { this.username = username; }
        public void setPassword(String password) { this.password = password; }
        
        public void setRol(String rol) { this.rol = rol; }
        public void setName(String name) { this.name = name; }
        public void setDate(DateTime date) { this.date = date; }
        public void setLastName(String lastname) { this.lastName = lastname; }
        public void setDocument(long doc) { this.document = doc; }
        public void setMail(String mail) { this.mail = mail; }
        public void setTelephone(long tel) { this.telephone = tel; }
    }

}
