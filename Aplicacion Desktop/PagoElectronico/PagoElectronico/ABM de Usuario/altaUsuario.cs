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
        public altaUsuario(User user)
        {
            InitializeComponent();
            this.user = user;
            MessageBox.Show(user.getRol());
            //me tengo q fijar si es administrador le permito crear otro admin sino solo un cliente
            if (user.getRol() =="Administrador"){ comboBox_rol.Enabled=true;} ;
        }
        private int tipodoc;
        private User user;
        private int id_rol;

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
                edit_window encriptar = new edit_window();
                string pass = encriptar.encriptacionSHA256(textBox_pass.Text);



                // termino de buscar si existe
                string q_user = "insert into qwerty.usuarios (nombre_usuario,pass_usuario,estado) values ('" + textBox_usuario.Text + "','" + pass + "',1)";
                db.insert_query(q_user);

                if (comboBox_rol.Enabled == false) { id_rol = 2; }
                
                string q_userroles = "insert into qwerty.roles_de_usuarios values ('"+textBox_usuario.Text+"',"+(comboBox_rol.SelectedIndex + 1)+")";

                db.insert_query(q_userroles);

                if (comboBox_tipodoc.SelectedIndex == 0) { tipodoc = 10002; }
                string q_cliente = "insert into qwerty.clientes (nombre_usuario,nombre,apellido,mail,nro_documento,documento_id) values ('"+textBox_usuario.Text+"','"+textBox_nombre.Text+"','"+textBox_apellido.Text+"','"+textBox_mail.Text+"',"+textBox_nrodoc.Text+","+tipodoc+")";
                db.insert_query(q_cliente);
                this.Close();
            }
        }

        private void altaUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
