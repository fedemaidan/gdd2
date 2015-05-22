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
            String query ;
            if (!tipoDoc.Equals(""))
                query = "select c.nombre_usuario, c.nombre, c.apellido, c.pais, c.mail, c.nro_documento, d.tipo_doc, c.calle, c.altura, c.piso, c.depto, c.localidad, c.nacionalidad, c.fecha_nacimiento from qwerty.clientes c left join qwerty.documentos d on d.doc_id = c.documento_id where apellido like '%" + apellido + "%' and nombre like '%" + nombre + "%' and mail like '%" + mail + "%' and nro_documento like '%" + doc + "%' and  d.tipo_doc = '" + tipoDoc + "' and habilitado = 1;";
            else
                query = "select c.nombre_usuario, c.nombre, c.apellido, c.pais, c.mail, c.nro_documento, d.tipo_doc, c.calle, c.altura, c.piso, c.depto, c.localidad, c.nacionalidad, c.fecha_nacimiento from qwerty.clientes c left join qwerty.documentos d on d.doc_id = c.documento_id where apellido like '%" + apellido + "%' and nombre like '%" + nombre + "%' and mail like '%" + mail + "%' and nro_documento like '%" + doc + "%' and habilitado = 1 ;";

            DataTable dt = db.select_query(query);  
            return dt;
        }


        public DataRow getClient(string username)
        {
            String query = "select c.nombre_usuario, c.nombre, c.apellido, c.pais, c.mail, c.nro_documento, d.tipo_doc, c.calle, c.altura, c.piso, c.depto, c.localidad, c.nacionalidad, c.fecha_nacimiento, c.habilitado from qwerty.clientes c left join qwerty.documentos d on d.doc_id = c.documento_id where nombre_usuario= '"+ username +"';";
            DataTable dt = db.select_query(query);
            
            foreach (DataRow row in dt.Rows)
            {
                return row;
            }

            return null;
        }

        public DataRow bajaCliente(string username)
        {
            String queryClientes = "update qwerty.clientes set habilitado = 0 where nombre_usuario= '"+ username +"';";
            db.update_query(queryClientes);

            String queryUsuarios = "update qwerty.usuarios set estado = 0 where nombre_usuario= '" + username + "';";
            db.update_query(queryUsuarios);

            return null;
        }
        

        public int insertarCliente(string nombre, string apellido, string mail, string documento , string tipoDoc, string pais, string calle, string altura , string piso, string depto, string localidad, string nacionalidad, DateTime fechaNacimieno, string username, string password, string preguntaSecreta, string respuestaSecreta)
        {
            DateTime fechaCreacion = (new Dia()).Hoy();
            DateTime fechaModificacion = (new Dia()).Hoy();
            String queryInsertarUsuario = "INSERT INTO qwerty.usuarios VALUES('" + username + "','" + password + "','" + fechaCreacion + "','" + fechaModificacion + "','" + preguntaSecreta + "','" + respuestaSecreta+ "',1);";
            db.insert_query(queryInsertarUsuario);

            String query = "select d.doc_id from qwerty.documentos d where d.tipo_doc = '" + tipoDoc + "' ;";
            DataTable dt = db.select_query(query);
            
            string doc_id = "1";
            foreach (DataRow row in dt.Rows)
            {
                doc_id = row["doc_id"].ToString();
            }

            
            String queryInsertaCliente = "INSERT INTO qwerty.clientes VALUES ('" + username + "' ,'" + nombre + "','" + apellido + "','" + pais + "','" + mail + "'," + documento + "," + doc_id + ",'" + calle + "'," + altura + "," + piso + ",'" + depto + "','" + localidad + "','" + nacionalidad + "','" + fechaNacimieno + "',1);";
            db.insert_query(queryInsertaCliente);

            return 1;
        }

        public int updateCliente(string nombre, string apellido, string mail, string documento, string tipoDoc, string pais, string calle, string altura, string piso, string depto, string localidad, string nacionalidad, DateTime fechaNacimieno, string username)
        {
            String query = "select d.doc_id from qwerty.documentos d where d.tipo_doc = '" + tipoDoc + "' ;";
            DataTable dt = db.select_query(query);

            string doc_id = "1";
            foreach (DataRow row in dt.Rows)
            {
                doc_id = row["doc_id"].ToString();
            }

            String queryUpdateCliente = "UPDATE qwerty.clientes SET  nombre = '" + nombre + "' ,apellido = '" + apellido + "' ,pais = '" + pais + "' ,mail = '" + mail + "' ,nro_documento = " + documento + " ,documento_id = " + doc_id + " ,calle = '" + calle + "' ,altura = " + altura + " ,piso = " + piso + " ,depto = '" + depto + "' ,localidad = '" + localidad + "' ,nacionalidad = '" + nacionalidad + "' ,fecha_nacimiento = '" + fechaNacimieno + "' WHERE nombre_usuario = '" + username + "';";
            db.update_query(queryUpdateCliente);

            return 1;
        }
        
    }
}
