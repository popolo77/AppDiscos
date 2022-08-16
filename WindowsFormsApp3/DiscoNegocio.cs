using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//LIBRERIA PARA PODER DECLARAR OBJETOS NECESARIOS PARA TRABAJAR CON SQL

namespace WindowsFormsApp3
{
    internal class DiscoNegocio
    {
        //PARA CONECTARME A MI BASE DE DATOS TENGO QUE HACER ESTA CLASE QUE TENGA UN METODO ESPECIAL QUE HAGA LA LECTURA Y ME TRAIGA LA CONEXION CON SQL PARA
        // TRAER LOS DATOS DE MIS DISCOS( EN ESTE CASO)


        // 1 - VOY A HACER UNA FUNCION (METODO) PUBLIC (PARA QUE TENGA ACCESO) QUE LEA REGISTROS DE LA BASE DE DATOS ( Listar() ) y RETORNE EN FORMA DE LISTA ( List <Disco> )
        //MIS OBJETOS DISCO.

        public List<Disco> Listar(){ // 1-

            List<Disco> list = new List<Disco>();// INSTANCIO (CREO) MI LISTA 
            SqlConnection conection = new SqlConnection();//OBJETO PARA CONECTARME CON SQL
            SqlCommand cmd = new SqlCommand();//OBJETO PARA REALIZAR ACCIONES
            SqlDataReader lector;//DEL RESULTADO DE LA LECTURA DE LA BASE DE DATOS, ESA LECTURA LA VOY A GUARDAR EN LA VARIABLE Lector DE TIPO SqlDataReader



            try //DENTRO DE MI FUNCION Y A TRAVES DEL MANEJO DE EXCEPCIONES VOY A PONER TODA LA FUNCIONALIDAD (CONECTARSE, COMANDO, DIRECCIONES, ETC )
                //LA FUNCION BASICA DEL TRY ES QUE ME VA A RETORNAR UNA LISTA ( <Disco> ) SI TODO ESTA BIEN ( CONECCIONES, COMANDOS, DIRECCIONES ,ETC )
                //Y UN CATCH SI HAY ALGUN ERROR
            {
                conection.ConnectionString = "server= .\\SQLEXPRESS; database=DISCOS_DB; integrated security=true ";//OBJETO PARA CONECTARME CON SQL (DIRECCION EN ESTE CASO MI PC, NOMBRE DE LA BASE DE DATOS ( DISCOS_DB ), Y LA SEGURIDAD ( INTEGRADA )
                cmd.CommandType = System.Data.CommandType.Text;//COMANDO DE ACCION TIPO TEXTO , LE INYECTA LA SENTENCIA SQL DESDE EL BACK 
                cmd.CommandText = "Select Titulo, CantidadCanciones, UrlImagenTapa ,FechaLanzamiento,  E.Descripcion, T.Descripcion from DISCOS D, ESTILOS E , TIPOSEDICION T Where E.Id = D.IdEstilo and T.Id = D.IdTipoEdicion";//CONSULTA QUE LE MANDO A MI BASE DE DATOS
                cmd.Connection = conection;//LINEA QUE HACE: MI COMANDO (cmd) SE VA A EJECUTAR EN LA CONEXION QUE YO TENGO (connection.ConnectionString)
                
                conection.Open();//ABRO LA CONEXION
                lector = cmd.ExecuteReader();//LEO LA CONEXION. ASIGNO LA VARIABLE Lector (QUE ES UNA VARIABLE DE TIPO SQLDataReader)QUE DENTRO TIENE BASE DE DATOS, AL COMANDO (ACCION) cmd.ExecuteReader() QUE VA A LEER LA DATA


                //PARA LEER EL OBJETO (lector) hago un While que va a leer la primera fila del objeto
                while (lector.Read())
                {
                    Disco aux = new Disco();//CREO UNA OBJETO AUXILIAR(aux) para poder ir completando
                    aux.Titulo = (string)lector[0];
                    aux.CantidadCanciones = lector.GetInt32(1);
                    aux.UrlImagenTapa = (string)lector[2];
                    aux.FechaLanzamiento = (DateTime)lector[3];
                    aux.Tipo = new Estilos();
                    aux.Tipo.Descripcion = (string)lector[4];
                    aux.Edicion = new TipoEdicion();
                    aux.Edicion.Descripcion = (string)lector[5];

                    list.Add(aux);//voy agregando a mi coleccion los objetos 


                }
                    
                conection.Close();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            


    }
    }
}
