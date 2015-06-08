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

            //InitializeComponent();
            //this.agregoFuncionalidades();
            this.id_rol = id_rol;
            this.buscoFuncionalidadesDeEsteRol();

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
                //checkedListBox1.SetItemChecked(1,true);

            }

        }

        public void buscoFuncionalidadesDeEsteRol()
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            string qeri = "select rf.funcion_id from QWERTY.funcionalidades_por_rol rf where rf.Rol_ID=" + id_rol;
            dt = db.select_query(qeri);
            foreach (DataRow row in dt.Rows)
            {
                int index = Convert.ToInt32(row["funcion_id"]);
                checkedListBox1.SetItemChecked(index - 1, true);
                
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            string qeri_delete = "delete from qwerty.funcionalidades_por_rol where qwerty.funcionalidades_por_rol.rol_id ="+id_rol;
            db.delete_query(qeri_delete);
            char activo;
            if (radioButton_alta.Checked == true) { 
                activo = '1';}
                else 
            {  activo='0'; }

            foreach (int i in checkedListBox1.CheckedIndices)
                    {

                        string qeri_update = "insert into qwerty.funcionalidades_por_rol (qwerty.funcionalidades_por_rol.rol_id,qwerty.funcionalidades_por_rol.funcion_id) values (" + id_rol + "," + (i + 1)+ ")";
                //tengo que hacer el update
                db.insert_query(qeri_update);

                    }
            //actualizar tabla roles
            string qeri_roles = "update qwerty.roles set estado='"+activo+"' where rol_id="+id_rol;
            db.update_query(qeri_roles);

            MessageBox.Show("Datos actualizados");
            this.Close();

            

        }
    }
}
