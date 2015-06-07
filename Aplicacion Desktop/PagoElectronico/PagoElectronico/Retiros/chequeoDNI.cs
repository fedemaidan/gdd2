using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;

namespace PagoElectronico.Retiros
{
    public partial class chequeoDNI : Form
    {
        public chequeoDNI(ABM_Retiro_de_dinero abm, int id_cliente)
        {
            InitializeComponent();
            this.abm = abm;
            this.id_cliente = id_cliente;

        }
        private ABM_Retiro_de_dinero abm;
        private int id_cliente;
        private int dni;

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            string buscoDNIdelUsuario = "select c.nro_documento from qwerty.clientes c where c.cliente_id="+id_cliente;
            dt= db.select_query(buscoDNIdelUsuario);
            foreach (DataRow row in dt.Rows)
            {
                dni = Convert.ToInt32(row["nro_documento"].ToString());
            }
            if (Convert.ToInt32(textBox_dni.Text) == dni) {
                abm.dni(true);
                this.Close();
                
                } else 
            { MessageBox.Show("El número de dni no se corresponde con el usuario logueado");
            abm.dni(false);
            this.Close();
            }

        }
    }
}
