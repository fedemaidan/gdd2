using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class altaUsuario : Form
    {
        public altaUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            //busco si ya existe el usuario...
            string usuario_repetido = "select * from qwerty.usuarios u where u.nombre_usuario='"+textBox_usuario.Text+"'";
            dt = db.select_query(usuario_repetido);

            if (Convert.ToInt32(dt.Rows.Count.ToString()) > 0) { MessageBox.Show("Nombre de usuario incorrecto"); }
            else
            {



                // termino de buscar si existe
                string q = "insert into qwerty.usuarios (nombre_usuario,pass_usuario,estado) values ('" + textBox_usuario.Text + "','" + textBox_pass.Text + "',1)";
                db.insert_query(q);

                this.Close();
            }
        }
    }
}
