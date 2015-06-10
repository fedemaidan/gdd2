using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;

namespace PagoElectronico.ABM_Rol
{
    public partial class ABMAlta_Rol : Form
    {
        public ABMAlta_Rol()
        {
            InitializeComponent();
            this.agregoFuncionalidades();
        }

        private int rol_id;
        private void ABMAlta_Rol_Load(object sender, EventArgs e)
        {

        }

        public void agregoFuncionalidades()
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            string qeriFuncionalidades = "select f.descripcion from qwerty.funcionalidades f";
            dt = db.select_query(qeriFuncionalidades);
            foreach (DataRow row in dt.Rows)
            {
                checkedListBox1.Items.Add(row.Field<string>(0));

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DataTable dt = new DataTable();

            /*busco rol id*/
            string insertoRol = "insert into QWERTY.Roles (Rol,Estado) values ('" + textBox1.Text + "',1)";
            db.insert_query(insertoRol);


            string buscoIdRol = "select r.Rol_ID from QWERTY.Roles r where r.Rol='" + textBox1.Text + "'";
            dt = db.select_query(buscoIdRol);
            int id_rol = dt.Rows[0].Field<int>(0);

            /*fin de buscar rol id*/

            foreach (object item in checkedListBox1.CheckedItems)
            {
                //busco el id de funcionalidad 
                string buscoIdFuncionalidad = "select f.Funcionalidad_ID from QWERTY.Funcionalidades f where f.Nombre='" + item.ToString() + "'";
                dt = db.select_query(buscoIdFuncionalidad);
                int id_funcionalidad = dt.Rows[0].Field<int>(0);
                string insertoRolesFuncionalidades = "insert into QWERTY.Roles_Funcionalidades (Rol_ID,Funcionalidad_ID) values(" + id_rol + "," + id_funcionalidad + ")";
                db.insert_query(insertoRolesFuncionalidades);
            }
            MessageBox.Show("Rol cargado");
            this.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        

            {
                Database db = new Database();
                string qeri_rol = "insert into qwerty.roles (descripcion,estado) values('" + textBox1.Text + "',1)";
                db.insert_query(qeri_rol);
                string obtengoID_Rol = "select r.rol_id from qwerty.roles r where r.descripcion ='" + textBox1.Text + "'";
                DataTable dt = db.select_query(obtengoID_Rol);

                
                foreach (DataRow row in dt.Rows)
                {
                    this.rol_id = Convert.ToInt32(row["rol_id"]);
                }

                foreach (int i in checkedListBox1.CheckedIndices)
                {
    
                    string qeri_update = "insert into qwerty.funcionalidades_por_rol (qwerty.funcionalidades_por_rol.rol_id,qwerty.funcionalidades_por_rol.funcion_id) values (" + this.rol_id + "," + (i + 1) + ")";
                    //tengo que hacer el update
                    db.insert_query(qeri_update);

                }
                

                MessageBox.Show("Datos actualizados");
                this.Close();



            }



    }
}
