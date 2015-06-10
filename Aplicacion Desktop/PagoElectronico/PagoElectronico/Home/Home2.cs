using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using PagoElectronico.Model;
using System.Security.Cryptography;


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
        public DataTable getPaisesList()
        {    
            String query = "select desc_pais from qwerty.paises";
            DataTable dt = db.select_query(query); 
            return dt;
        }
        
        public DataTable getBancosList()
        {
            String query = "select nombre from qwerty.bancos";
            DataTable dt = db.select_query(query);
            return dt;
        }

        public DataTable getEmisoresList()
        {
            String query = "select nombre from qwerty.emisores_de_tarjetas";
            DataTable dt = db.select_query(query);
            return dt;
        }
        
        


        public int asociarTarjetaACliente(string username, string numeroTarjeta, string bancoNombre, string  fechaEmision , string fechaVencimiento ,  string codigo, string emisorNombre, string numeroCuenta )
        {
            string numeroTitular = "";
            string bancoId = "";
            String queryCliente = "select cliente_id from qwerty.clientes where nombre_usuario = '"+ username+"';";
            DataTable dt = db.select_query(queryCliente); 

            foreach (DataRow row in dt.Rows)
            {
                numeroTitular = row["cliente_id"].ToString();
            }

            String queryBanco = "select banco_id from qwerty.bancos where nombre = '" + bancoNombre + "';";
            DataTable dtbanco = db.select_query(queryBanco);

            foreach (DataRow row in dtbanco.Rows)
            {
                bancoId = row["banco_id"].ToString();
            }

            String queryEmisor = "select emisor_id from qwerty.emisores_de_tarjetas where nombre = '" + emisorNombre + "';";
            DataTable dtEmisores = db.select_query(queryEmisor);
            String emisorId = "visa";
            foreach (DataRow row in dtEmisores.Rows)
            {
                emisorId = row["emisor_id"].ToString();
            }


            string query = "INSERT INTO qwerty.tarjetas_de_credito VALUES(" + numeroTarjeta + "," + bancoId + ", " + emisorId  + ", '" + fechaEmision + "','" + fechaVencimiento + "','" + codigo + "', " + numeroCuenta + "," + numeroTitular + ",1);";

            db.insert_query(query);

            return 1;
        }

        public int updateTarjeta(string username, string numeroTarjeta, string bancoNombre, string fechaEmision, string fechaVencimiento, string codigo)
        {
            
            string bancoId = "";

            String queryBanco = "select banco_id from qwerty.bancos where nombre = '" + bancoNombre + "';";
            DataTable dtbanco = db.select_query(queryBanco);

            foreach (DataRow row in dtbanco.Rows)
            {
                bancoId = row["banco_id"].ToString();
            }

            string query = "UPDATE qwerty.tarjetas_de_credito SET numero_tarjeta = " + numeroTarjeta + ",banco_id = " + bancoId + ",fecha_emision = '" + fechaEmision + "' ,fecha_vencimiento = '" + fechaVencimiento + "' ,cod_seguridad = '" + codigo + "' WHERE numero_tarjeta = " + numeroTarjeta + ";";

            db.update_query(query);

            return 1;
        }

        

        public DataTable getTarjetasDelCliente(string username, string numeroTarjeta, string banco, string fechaEmision , string fechaVencimiento)
        {
            String query = "select t.numero_tarjeta , b.nombre , t.fecha_emision , t.fecha_vencimiento from qwerty.tarjetas_de_credito t join qwerty.bancos b on b.banco_id = t.banco_id where numero_tarjeta like '%" + numeroTarjeta + "%' and b.nombre like '%" + banco + "%' and t.fecha_emision like '%" + fechaEmision + "%' and t.fecha_vencimiento like '%" + fechaVencimiento + "%' and vinculada = 1;";

            DataTable dt = db.select_query(query);
            return dt;
        }
        
        public DataTable  getClientList(string nombre, string apellido, string mail, string doc, string tipoDoc){
            String query ;
            if (!tipoDoc.Equals(""))
                query = "select c.nombre_usuario, c.nombre, c.apellido, p.desc_pais as pais, c.mail, c.nro_documento, d.tipo_doc, c.calle, c.altura, c.piso, c.depto, c.localidad, c.nacionalidad, c.fecha_nacimiento from qwerty.clientes c join qwerty.paises p on p.cod_pais = c.pais_id left join qwerty.documentos d on d.doc_id = c.documento_id where apellido like '%" + apellido + "%' and nombre like '%" + nombre + "%' and mail like '%" + mail + "%' and nro_documento like '%" + doc + "%' and  d.tipo_doc = '" + tipoDoc + "' and habilitado = 'S';";
            else
                query = "select c.nombre_usuario, c.nombre, c.apellido, p.desc_pais as pais, c.mail, c.nro_documento, d.tipo_doc, c.calle, c.altura, c.piso, c.depto, c.localidad, c.nacionalidad, c.fecha_nacimiento from qwerty.clientes c join qwerty.paises p on p.cod_pais = c.pais_id left join qwerty.documentos d on d.doc_id = c.documento_id where apellido like '%" + apellido + "%' and nombre like '%" + nombre + "%' and mail like '%" + mail + "%' and nro_documento like '%" + doc + "%' and habilitado = 'S' ;";

            DataTable dt = db.select_query(query);  
            return dt;
        }


        public DataTable getCuentas(string username)
        {
            DataRow cliente = this.getClient(username);
            string idCliente = cliente["cliente_id"].ToString();
            String query = "select numero_cuenta from qwerty.cuentas where cliente_id = '"+idCliente+"';";
            DataTable dt = db.select_query(query);
            return dt;
        }
        


        public DataRow getClient(string username)
        {
            String query = "select c.cliente_id, c.nombre_usuario, c.nombre, c.apellido, p.desc_pais as pais, c.mail, c.nro_documento, d.tipo_doc, c.calle, c.altura, c.piso, c.depto, c.localidad, c.nacionalidad, c.fecha_nacimiento, c.habilitado from qwerty.clientes c  join qwerty.paises p on p.cod_pais = c.pais_id left join qwerty.documentos d on d.doc_id = c.documento_id where nombre_usuario= '" + username + "';";
            DataTable dt = db.select_query(query);
            
            foreach (DataRow row in dt.Rows)
            {
                return row;
            }

            return null;
        }

        public DataRow getTarjeta(string numeroTarjeta)
        {
            String query = "select t.numero_tarjeta , b.nombre , t.fecha_emision , t.fecha_vencimiento , t.cod_seguridad from qwerty.tarjetas_de_credito t join qwerty.bancos b on b.banco_id = t.banco_id where t.numero_tarjeta = " + numeroTarjeta + ";";
            
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

        public int desasociarTarjeta(string numeroTarjeta)
        {
            String query = "UPDATE qwerty.tarjetas_de_credito SET vinculada = 0 WHERE numero_tarjeta = " + numeroTarjeta + ";";
            db.update_query(query);
            return 1;
        }
        

        public int insertarCliente(string nombre, string apellido, string mail, string documento , string tipoDoc, string pais, string calle, string altura , string piso, string depto, string localidad, string nacionalidad, string fechaNacimieno, string username, string password, string preguntaSecreta, string respuestaSecreta)
        {
            DateTime fechaCreacionDateTime = (new Dia()).Hoy();
            DateTime fechaModificacionDateTime = (new Dia()).Hoy();

            string fechaCreacion = fechaCreacionDateTime.ToString("yyyy-MM-dd");
            string fechaModificacion = fechaModificacionDateTime.ToString("yyyy-MM-dd");

            string passwordHash = new homeDB().encriptacionSHA256(password);
            string respuestaSecretaHash = new homeDB().encriptacionSHA256(respuestaSecreta);

            String queryInsertarUsuario = "INSERT INTO qwerty.usuarios VALUES('" + username + "','" + passwordHash + "','" + fechaCreacion + "','" + fechaModificacion + "','" + preguntaSecreta + "','" + respuestaSecretaHash+ "','S');";
            db.insert_query(queryInsertarUsuario);

            String query = "select d.doc_id from qwerty.documentos d where d.tipo_doc = '" + tipoDoc + "' ;";
            DataTable dt = db.select_query(query);
            
            string doc_id = "1";
            foreach (DataRow row in dt.Rows)
            {
                doc_id = row["doc_id"].ToString();
            }

            String query2 = "select cod_pais from qwerty.paises where desc_pais = '" + pais + "' ;";
            DataTable dt2 = db.select_query(query2);

            string paiss = "Argentina";
            foreach (DataRow row in dt2.Rows)
            {
                paiss = row["cod_pais"].ToString();
            }

            String queryInsertaCliente = "INSERT INTO qwerty.clientes VALUES ('" + username + "' ,'" + nombre + "','" + apellido + "','" + paiss + "','" + mail + "'," + documento + "," + doc_id + ",'" + calle + "'," + altura + "," + piso + ",'" + depto + "','" + localidad + "','" + nacionalidad + "','" + fechaNacimieno + "','S');";
            db.insert_query(queryInsertaCliente);


            String queryRoles = "INSERT INTO qwerty.roles_de_usuarios VALUES ('" + username + "', 2)";
            db.insert_query(queryRoles);
            return 1;
        }

        public int updateCliente(string nombre, string apellido, string mail, string documento, string tipoDoc, string pais, string calle, string altura, string piso, string depto, string localidad, string nacionalidad, string fechaNacimieno, string username)
        {
            String query = "select d.doc_id from qwerty.documentos d where d.tipo_doc = '" + tipoDoc + "' ;";
            DataTable dt = db.select_query(query);

            string doc_id = "1";
            foreach (DataRow row in dt.Rows)
            {
                doc_id = row["doc_id"].ToString();
            }


            String query2 = "select cod_pais from qwerty.paises where desc_pais = '" + pais + "' ;";
            DataTable dt2 = db.select_query(query2);

            string paiss = "Argentina";
            foreach (DataRow row in dt2.Rows)
            {
                paiss = row["cod_pais"].ToString();
            }


            String queryUpdateCliente = "UPDATE qwerty.clientes SET  nombre = '" + nombre + "' ,apellido = '" + apellido + "' ,pais_id = '" + paiss + "' ,mail = '" + mail + "' ,nro_documento = " + documento + " ,documento_id = " + doc_id + " ,calle = '" + calle + "' ,altura = " + altura + " ,piso = " + piso + " ,depto = '" + depto + "' ,localidad = '" + localidad + "' ,nacionalidad = '" + nacionalidad + "' ,fecha_nacimiento = '" + fechaNacimieno + "' WHERE nombre_usuario = '" + username + "';";
            db.update_query(queryUpdateCliente);

            return 1;
        }


        public DataTable getTransferencias10(string numeroCuenta)
        {
            String query = "select top 10 fecha_transferencia , cuenta_origen, cuenta_destino, importe, tipo_de_cuenta from qwerty.transferencias where cuenta_origen = '" + numeroCuenta + "' order by fecha_transferencia desc;";
            DataTable dt = db.select_query(query);
            return dt;
        }

        public DataTable getDepositos5(string numeroCuenta)
        {
            String query = "select top 5 fecha_deposito, importe, numero_trajeta from qwerty.depositos where numero_cuenta = '" + numeroCuenta + "' order by fecha_deposito desc;";
            DataTable dt = db.select_query(query);
            return dt;
        }

        public DataTable getRetiros5(string numeroCuenta)
        {
            String query = "select top 5 fecha_retiro, importe, numero_cuenta, nombre, apellido  from qwerty.retiro_de_efectivo where numero_cuenta = '" + numeroCuenta + "' order by fecha_retiro desc;";
            DataTable dt = db.select_query(query);
            return dt;
        }

        public string getSaldo(string numeroCuenta)
        {
            String query = "select saldo from qwerty.cuentas  where numero_cuenta = " + numeroCuenta+ ";";

            DataTable dt = db.select_query(query);
            foreach (DataRow row in dt.Rows)
            {
                return row["saldo"].ToString();
            }

            return "";
        }
    }
}
