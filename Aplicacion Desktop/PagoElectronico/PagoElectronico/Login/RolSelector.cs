using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Login
{
    public partial class RolSelector : Form
    {
        private List<CheckBox> cb_list = new List<CheckBox>();
        private String rol = "";

        public RolSelector()
        {
            InitializeComponent();
        }

        public RolSelector(List<Object> rols)
        {
            int pos = 0;
            foreach (String rol in rols)
            {
                CheckBox cb = new CheckBox();
                cb.Text = rol;
                cb.Location = new System.Drawing.Point(20, 20 + pos);
                cb_list.Add(cb);
                Controls.Add(cb);

                pos += 30;
            }
            InitializeComponent();
        }

        private void RolSelector_Load(object sender, EventArgs e)
        {

        }

        public String getSelectedRol()
        {
            return this.rol;
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {

            try
            {
                int checks = 0;
                foreach (CheckBox cb in cb_list)
                {
                    if (cb.Checked)
                    {
                        checks++;
                        this.rol = cb.Text;
                    }
                }


                if (checks > 1 || checks == 0)
                {
                    throw new Exception("Debe seleccionar 1 rol");
                }
                else
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }
    }
}
