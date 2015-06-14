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
        
        


        public int asociarTarjetaACliente(string username, string numeroTarjeta, string bancoNombre, DateTime fechaEmision , DateTime fechaVencimiento ,  string codigo, string emisorNombre, string numeroCuenta )
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


            string query = "INSERT INTO qwerty.tarjetas_de_credito VALUES(" + numeroTarjeta + "," + bancoId + ", " + emisorId + ", convert(datetime,'" + fechaEmision + "',121),convert(datetime,'" + fechaVencimiento + "',121),'" + codigo + "', " + numeroCuenta + "," + numeroTitular + ",1);";

            db.insert_query(query);

            return 1;
        }

        public int updateTarjeta(string username, string numeroTarjeta, string bancoNombre, DateTime fechaEmision, DateTime fechaVencimiento, string codigo)
        {
            
            string bancoId = "";

            String queryBanco = "select banco_id from qwerty.bancos where nombre = '" + bancoNombre + "';";
            DataTable dtbanco = db.select_query(queryBanco);

            foreach (DataRow row in dtbanco.Rows)
            {
                bancoId = row["banco_id"].ToString();
            }

            string query = "UPDATE qwerty.tarjetas_de_credito SET numero_tarjeta = " + numeroTarjeta + ",banco_id = " + bancoId + ",fecha_emision = convert(date,'" + fechaEmision + "',121) ,fecha_vencimiento = convert(datetime,'" + fechaVencimiento + "',121),cod_seguridad = '" + codigo + "' WHERE numero_tarjeta = " + numeroTarjeta + ";";

            db.update_query(query);

            return 1;
        }

        

        public DataTable getTarjetasDelCliente(string username, string numeroTarjeta, string banco, DateTime fechaEmision , DateTime fechaVencimiento)
        {
            String query = "select t.numero_tarjeta , b.nombre , t.fecha_emision , t.fecha_vencimiento from qwerty.tarjetas_de_credito t join qwerty.bancos b on b.banco_id = t.banco_id where numero_tarjeta like '%" + numeroTarjeta + "%' and b.nombre like '%" + banco + "%' and t.fecha_emision = convert(date,'" + fechaEmision + "',121) and t.fecha_vencimiento = convert(date,'" + fechaVencimiento + "',121) and vinculada = 1;";

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
        

        public int insertarCliente(string nombre, string apellido, string mail, string documento , string tipoDoc, string pais, string calle, string altura , string piso, string depto, string localidad, string nacionalidad, DateTime fechaNacimieno, string username, string password, string preguntaSecreta, string respuestaSecreta)
        {
            DateTime fechaCreacion = (new Dia()).Hoy();
            DateTime fechaModificacion = (new Dia()).Hoy();

            

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

        public int updateCliente(string nombre, string apellido, string mail, string documento, string tipoDoc, string pais, string calle, string altura, string piso, string depto, string localidad, string nacionalidad, DateTime fechaNacimieno, string username)
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
            String query = 
                @"select top 5 fecha_deposito, importe, 
                numero_trajeta from qwerty.depositos where numero_cuenta = '" + numeroCuenta + "' order by fecha_deposito desc;";
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

        public DataTable getReporte(string query)
        {
            DataTable dt = db.select_query(query);
            return dt;
        }

        public DataTable getRepo1(DateTime desde, DateTime hasta)
        {
            string query =
@"select top 5
	tabla.cliente_id,
	COUNT(*) as cantidad
from
	(select distinct 
	a.numero_cuenta,
	b.cliente_id
from
	qwerty.inhabilitaciones_por_cuenta a
inner join
	qwerty.cuentas b
on
	a.numero_cuenta = b.numero_cuenta
where
	inhabilitacion_id = 1
    and a.fecha between convert(datetime,'" + desde + "',121) and convert(datetime,'" + hasta + "',121)) tabla group by tabla.cliente_id order by cantidad desc;";

            return this.getReporte(query);
        }
        

        public DataTable getRepo2(DateTime desde, DateTime hasta)
        {
            string query =
@"
select top 5
	cliente_id,
	COUNT(*) as comisiones_cobradas
from
	qwerty.transacciones
where
	factura_id is not null 
and fecha_transaccion between convert(datetime,'" + desde + "',121) and convert(datetime,'" + hasta + "',121) group by cliente_id order by comisiones_cobradas desc ;";

            return this.getReporte(query);
        }

        public DataTable getRepo3(DateTime desde, DateTime hasta)
        {
            string query =
@"
select top 5
	a.cliente_id,
	COUNT(*) as transferencias
from
	(select distinct
	cliente_id,
	numero_cuenta
from 
	qwerty.cuentas) a
inner join
	(select
	cliente_id,
	b.cuenta_origen,
	b.cuenta_destino
from
	qwerty.cuentas a
inner join
	qwerty.transferencias b
on
	a.numero_cuenta = b.cuenta_origen
    and b.fecha_transferencia between convert(datetime,'" + desde + "',121) and convert(datetime,'" + hasta + "',121)) b on a.cliente_id = b.cliente_id where a.numero_cuenta = b.cuenta_destino		 group by a.cliente_id  order by 2 desc ;";

            return this.getReporte(query);
        }

        public DataTable getRepo4(DateTime desde, DateTime hasta)
        {
           
            string query =
@"
    select top 5 p.desc_pais as pais,(isnull(retiro.cantidad,0) + isnull(depositos.cantidad,0) + isnull(transferencias.cantidad,0) ) as cantidadMovimientos 
	from qwerty.paises p
	
	left join 
	(select  
		cod_pais,
		COUNT(*) as cantidad
	from 
		qwerty.cuentas a
	inner join
		qwerty.retiro_de_efectivo b
	on
		a.numero_cuenta = b.numero_cuenta
        and b.fecha_retiro between convert(datetime,'" + desde + "',121) and convert(datetime,'" + hasta + "',121) "
+
	@"group by cod_pais) retiro
	on retiro.cod_pais = p.cod_pais
	
	left join 
	(select  
		cod_pais,
		COUNT(*) as cantidad
	from 
		qwerty.cuentas a
	inner join
		qwerty.depositos b
	on
		a.numero_cuenta = b.numero_cuenta
and b.fecha_deposito between convert(datetime,'" + desde + "',121) and convert(datetime,'" + hasta + "',121)"
+            
	@"group by cod_pais) depositos
	on p.cod_pais = depositos.cod_pais
	
	left join 
	(select  
		cod_pais,
		COUNT(*) as cantidad
	from 
		qwerty.cuentas a
	inner join
		qwerty.transferencias b
	on
		(a.numero_cuenta = b.cuenta_origen or  -- egreso
		 a.numero_cuenta = b.cuenta_destino)  -- ingreso
    and b.fecha_transferencia between convert(datetime,'" + desde + "',121) and convert(datetime,'" + hasta + "',121)"
+                                 
	@"group by cod_pais) transferencias
	on 
	p.cod_pais = transferencias.cod_pais
	
	order by cantidadMovimientos desc;";

            return this.getReporte(query);
        }

        public DataTable getRepo5(DateTime desde, DateTime hasta)
        {
            string query =
@"
select c.numero_cuenta, (isnull(comAperturas.comision,0) + isnull(comTransferencias.comision,0) + isnull(comCambioTipo.comision,0)) as comisionTotal from

qwerty.cuentas c 

left join 

(select
	a.numero_cuenta as cuenta,
	sum(a.importe * b.costo) as comision 
from 
	qwerty.transacciones a
inner join
	qwerty.costos_de_transacciones b
on
	a.costo_id = b.costo_id
    where
	b.tipo_costo = 'Transferencias'
    and a.fecha_transaccion between convert(datetime,'" + desde + "',121) and convert(datetime,'" + hasta + "',121)"
+
@"group by a.numero_cuenta) comTransferencias

on c.numero_cuenta = comTransferencias.cuenta

left join
--- CALCULO COMISON POR APERTURA
(select
	a.numero_cuenta as cuenta,
	sum(b.costo) as comision -- sumo porque el costo de la apertura es fijo para todas las cuentas 
from 
	qwerty.transacciones a
inner join
	qwerty.costos_de_transacciones b
on
	a.costo_id = b.costo_id
where
	b.tipo_costo = 'Apertura Cuenta'
  and a.fecha_transaccion between convert(datetime,'" + desde + "',121) and convert(datetime,'" + hasta + "',121)"
+
@"group by a.numero_cuenta ) comAperturas
 on c.numero_cuenta = comAperturas.cuenta

left join
--- CALCULAMOS COMISION POR CAMBIO DE TIPO DE CUENTA
(select
	a.numero_cuenta as cuenta,
	sum( (a.importe * b.costo + c.costo)) as comision -- se agrega el costo de lo que vale el tipo de categoria cuando cambio
from 
	qwerty.transacciones a
inner join
	qwerty.costos_de_transacciones b
on
	a.costo_id = b.costo_id
inner join
	qwerty.categorias_de_cuentas c
on
	a.tipo_cuenta = c.descripcion
where
	b.tipo_costo = 'Modificacion Cuenta'
  and a.fecha_transaccion between convert(datetime,'" + desde + "',121) and convert(datetime,'" + hasta + "',121)"
+
@"group by a.numero_cuenta ) comCambioTipo

on c.numero_cuenta = comCambioTipo.cuenta

order by comisionTotal desc;
";

            return this.getReporte(query);
        }

    }
}
