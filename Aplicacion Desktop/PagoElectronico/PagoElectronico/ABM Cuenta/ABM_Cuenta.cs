using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Model;
using PagoElectronico.ABM_de_Usuario;


namespace PagoElectronico.ABM_Cuenta
{
    public partial class ABM_Cuenta : Form
    {
        public ABM_Cuenta(User user)
        {
            InitializeComponent();
            Dia dia = new Dia();
            textBox_fecha.Text = dia.Hoy().ToString();
            this.user=user;
        }
        private User user;
        private int moneda;
        private int id_cliente;

        private void ABM_Cuenta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            if (comboBox_moneda.SelectedIndex == 0) { this.moneda = 1; }

            // tengo q buscar cliente_id en la tabla clientes con el nombre_usuario
            
            string qeri_buscoIDcliente = "select c.cliente_id from qwerty.clientes c where c.nombre_usuario='" + user.getUserName() + "'";

            DataTable dt = db.select_query(qeri_buscoIDcliente);
            foreach (DataRow row in dt.Rows)
            {
                this.id_cliente = Convert.ToInt32(row["cliente_id"]);
            }
            //termino de buscar el cliente_id
            
            // IMPORTANTE
            // el numero_cuenta lo meto hardcodeado porque eso hay qe resolverlo en la tabla
            // agregando al campo numero_cuenta la propiedad para que sea autoincrementable
            Random r = new Random();
            int aleatorio = r.Next(1,10000000);
            string queri = "insert into qwerty.cuentas (numero_cuenta, moneda_id,fecha_apertura,categoria_id,cliente_id,estado_id,pais) values ("+aleatorio+"," + this.moneda + ",'" + textBox_fecha.Text + "'," + (comboBox_tipocuenta.SelectedIndex + 1) + "," + this.id_cliente + ", 1, '" + textBox_pais.Text + "')";
            db.insert_query(queri);

            this.Close();

        }
        
    }
}
