using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using PagoElectronico.Model;

namespace PagoElectronico.Home
{
     

    class Home2
    {
        private Database db = new Database();

        public DataTable  getTipoDocList(){    
            String query = "select tipo_doc from qwerty.documentos";
            DataTable dt = db.select_query(query); 
            return dt;
        }
        
        public DataTable  getClientList(string nombre, string apellido, string mail, string doc, string tipoDoc){
            String query = "select c.nombre_usuario, c.nombre, c.apellido, c.pais, c.mail, c.nro_documento, d.tipo_doc, c.calle, c.altura, c.piso, c.depto, c.localidad, c.nacionalidad, c.fecha_nacimiento, c.habilitado from qwerty.clientes c left join qwerty.documentos d on d.doc_id = c.documento_id where apellido like '%" + apellido + "%' and nombre like '%" + nombre + "%' and mail like '%" + mail + "%' and nro_documento like '%" + doc + "%' and  d.tipo_doc = '" + tipoDoc + "' ;";
            DataTable dt = db.select_query(query);  
            return dt;
        }
    }
}
