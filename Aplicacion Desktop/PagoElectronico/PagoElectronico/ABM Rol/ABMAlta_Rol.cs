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


    }
}
