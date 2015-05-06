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
    public partial class ABMRol_Modificacion_Listado : Form
    {

        private int id_rol;
        public ABMRol_Modificacion_Listado(int id_rol)
        {
            InitializeComponent();

            InitializeComponent();
            this.agregoFuncionalidades();
            this.id_rol = id_rol;
            this.buscoFuncionalidadesDeEsteRol();

        }

        public void agregoFuncionalidades()
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            string qeriFuncionalidades = "select f.Nombre from qwerty.funcionalidades f";
            dt = db.select_query(qeriFuncionalidades);
            foreach (DataRow row in dt.Rows)
            {
                checkedListBox1.Items.Add(row.Field<string>(0));
                //checkedListBox1.SetItemChecked(1,true);

            }

        }

        public void buscoFuncionalidadesDeEsteRol()
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            string qeri = "select rf.Funcionalidad_ID from QWERTY.Roles_Funcionalidades rf where rf.Rol_ID=" + id_rol;
            dt = db.select_query(qeri);
            foreach (DataRow row in dt.Rows)
            {
                checkedListBox1.SetItemChecked(row.Field<int>(0) - 1, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DataTable dt = new DataTable();

            /*eliminar en tabla roles_funcionalidades todas las funcionalidades del rol*/
            string qeri = "delete from QWERTY.Roles_Funcionalidades where Rol_ID=" + id_rol;
            db.delete_query(qeri);
            /*fin de eliminar en tabla roles_funcionalidades todas las funcionalidades del rol*/


            foreach (object item in checkedListBox1.CheckedItems)
            {
                //busco el id de funcionalidad 
                string buscoIdFuncionalidad = "select f.Funcionalidad_ID from QWERTY.Funcionalidades f where f.Nombre='" + item.ToString() + "'";
                dt = db.select_query(buscoIdFuncionalidad);
                int id_funcionalidad = dt.Rows[0].Field<int>(0);
                string insertoRolesFuncionalidades = "insert into QWERTY.Roles_Funcionalidades (Rol_ID,Funcionalidad_ID) values(" + id_rol + "," + id_funcionalidad + ")";
                db.insert_query(insertoRolesFuncionalidades);
            }

            /*edito el nombre y estado*/
            int estado;
            if (radioButton_alta.Checked == true) { estado = 1; } else { estado = 0; }
            string nombreEdito = "update QWERTY.Roles set Rol='" + textBox1.Text + "', Estado=" + estado + " where Rol_ID=" + id_rol;
            db.update_query(nombreEdito);
            /*fin de edito el nombre y estado*/

            MessageBox.Show("Rol actualizado");
            this.Close();

        }

        private void ABMRol_Modificacion_Listado_Load(object sender, EventArgs e)
        {

        }
    }
}
