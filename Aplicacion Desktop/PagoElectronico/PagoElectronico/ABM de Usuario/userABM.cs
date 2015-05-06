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
using PagoElectronico.ABM_de_Usuario;

namespace PagoElectronico.ABM_de_Usuario
{
        public partial class userABM : Form
        {
            private homeDB home_db = new homeDB();
            
            private User lb_selected_user = new User();
            private String _selected_name = "";
            private User _selected_user = null;
            private List<User> listBox_users = new List<User>();

            public userABM()
            {
                InitializeComponent();
                this.fillWindowOnCreate();

            }

            public userABM(User admin)
            {
                InitializeComponent();
                this.fillWindowOnCreate();

            }

            private void refreshWindow()
            {
                this.fillWindowOnCreate();
            }

            private void button3_Click(object sender, EventArgs e)
            {
                //ABRIR LA VENTANA DE EDICION
                edit_window edition = new edit_window(_selected_user);
                edition.Show();
            }

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }

            //MUESTRO LOS DATOS DEL USUARIO A LA TABLA (SI LO SELECCIONO)
            private void lb_users_SelectedIndexChanged(object sender, EventArgs e)
            {
                lb_selected_user.setUsername(lb_users.GetItemText(lb_users.SelectedItem));
                _selected_name = lb_selected_user.getUserName();

                if (_selected_name != null && !_selected_name.Equals(""))
                {

                    Console.WriteLine("tocas en " + _selected_name);
                    User new_user = listBox_users.Find(user => user.getUserName().Equals(_selected_name));
                    this.addUsersToGrid(new_user);
                    _selected_user = new_user;
                    btn_delete.Enabled = true;
                    btn_edit.Enabled = true;

                }
                else
                {

                    btn_delete.Enabled = false;
                    btn_edit.Enabled = false;

                }
            }


            //Obtengo todos los usuarios y los agrego al listBox
            // el admin que este usando esta abm
            private void fillWindowOnCreate()
            {

                DataTable users_table = home_db.getUsersList();
                lb_users.Items.Clear();

                foreach (DataColumn dc in users_table.Columns)
                {
                    Dictionary<String, Object> dic = new Dictionary<String, Object>();
                    int rows = users_table.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        dic[dc.ToString().ToLower()] = users_table.Rows[i][dc];

                        lb_users.Items.Add(dic["username"]);
                        Dictionary<String, Object> values = home_db.getUserConfig((string)dic["username"], "");

                        //creo el usuario con el diccionario que me traje
                        User user = new User(values);

                        // lo agrego a un array local asi userABM tiene una array de usuarios
                        listBox_users.Add(user);
                    }
                }
            }
            private void btn_add_Click(object sender, EventArgs e)
            {
                ABM_de_Usuario.edit_window add_form = new ABM_de_Usuario.edit_window();
                add_form.Show();
            }


            public void addUsersToGrid(User user)
            {
                dgv_users.Rows.Clear();
                dgv_users.Rows.Add(user.getUserName(), user.getName(), user.getLastName(), user.getMail()) ;
            }

            public void addUser_to_listBox(User user)
            {
                //  lb_users.Items.Add(user.getUserName());
                //INSERTAR EN LA BASE Y HACER UN REFRESH
                user.setYouUP();
                this.refreshWindow();

            }



            private void btn_delete_Click(object sender, EventArgs e)
            {
                //ELIMINAR LA ROW DE LA GRIDVIEW 
                String selected_user = lb_users.GetItemText(lb_users.SelectedItem);
                lb_users.Items.Remove(lb_users.SelectedItem);

                //INSERTAR EN UNA TABLA LOS USUARIOS QUE SE DIERON DE BAJA(BAJA LOGICA)
                //Elimina de la tabla usuarios y deberia eliminar en las asociadas 
                User user = new User();
                user.setUsername(selected_user);
                user.setYouDown();

                //ELIMINAR DE LA TABLA DE USUARIOS
                //tener una tabla de historia de usuari    os para cuando los demos de baja
                home_db.downUser(user.getUserName());

            }

            private void btn_close_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void userABM_Load(object sender, EventArgs e)
            {

            }

            private void dgv_users_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

        }

    
}
