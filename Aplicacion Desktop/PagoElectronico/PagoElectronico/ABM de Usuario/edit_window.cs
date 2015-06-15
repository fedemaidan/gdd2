using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using PagoElectronico.Home;
using PagoElectronico.Model;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class edit_window : Form
    {
        private User _user = null;
        public edit_window()
        {
            InitializeComponent();



        }

        public edit_window(User user)
        {
            InitializeComponent();
            this.llenarCheckedListBoxNombres();
            this.llenarCheckedListBoxRoles();
            this._user = user;
            this.fillFildsOnCreate(user);
            txt_pass.Enabled = false;


        }
        private void llenarCheckedListBoxRoles()
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            string query_roles = "select * from QWERTY.roles";
            dt = db.select_query(query_roles);

            foreach (DataRow row in dt.Rows)
            {
                checkedListBox_rol.Items.Add(row.Field<string>(1));

            }

        }

       // private bool vacio;
        private void validar(Form form)
        {

        }
        public class Item
        {//creo una clase Item donde voy a agregar los nombres de los hoteles junto con sus ids
            public string Name { get; set; }
            public int Value { get; set; }

            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }




        private void llenarCheckedListBoxNombres()
        {
            DataTable dt = new DataTable();
            

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

        private void fillFildsOnCreate(User user)
        {

            monthCalendar1.SelectionStart = user.getDate();
            
            txt_doc.Text = user.getDocument().ToString();
            txt_lastname.Text = user.getLastName().ToString();
            txt_name.Text = user.getName().ToString();
            txt_nickname.Text = user.getUserName().ToString();

            txt_telephone.Text = user.getTelephone().ToString();
            txt_mail.Text = user.getMail().ToString();
            
            
            
            cb_docs.Text = "DNI";

            Database db = new Database();
            DataTable dt = new DataTable();

            //levanto de la tabla usuarios_roles los roles q este usuario tiene y mostrar en checkedlistbox
            string qeri2 = "select r.rol_ID from QWERTY.usuarios_roles r where r.Username='" + user.getUserName() + "'";
            dt = db.select_query(qeri2);
            foreach (DataRow row in dt.Rows)
            {
                checkedListBox_rol.SetItemChecked(row.Field<int>(0) - 1, true);
            }



        }
        private void fillUserWithFilds()
        {
            //_user.getLoggedHotel().setName(cb_hotel.Text);
            //_user.setRol(cb_rol.Text);
            _user.setUsername(txt_nickname.Text);
            _user.setName(txt_name.Text);
            _user.setLastName(txt_lastname.Text);
            _user.setPassword(txt_pass.Text);


            _user.setDate(monthCalendar1.SelectionStart);
            _user.setDocument(int.Parse(txt_doc.Text));
            _user.setMail(txt_mail.Text);
            _user.setTelephone(int.Parse(txt_telephone.Text));

            Database db = new Database();
            
            foreach (object id_rol in checkedListBox_rol.CheckedItems)
            {

                int id = checkedListBox_rol.Items.IndexOf(id_rol.ToString()) + 1;
                String user_query = "insert into qwerty.usuarios_roles values('" + txt_nickname.Text + "','" + id + "')";
                db.insert_query(user_query);
            }

        }
        private void edit_window_Load(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {

        }

        private void btn_accept_Click(object sender, EventArgs e)
        {

        }

        public void update_user()
        {
            this.fillUserWithFilds();
            homeDB home = new homeDB();
            home.update_user(_user);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_lastname_TextChanged(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_telephone_TextChanged(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_dir_TextChanged(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_mail_TextChanged(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_department_TextChanged(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_dir_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_department_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_doc_TextChanged(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_pass_TextChanged(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_floor_TextChanged(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_direction_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
