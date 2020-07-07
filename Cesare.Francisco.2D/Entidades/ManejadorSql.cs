using Excepciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Entidades
{

    public static class ManejadorSql<T> //where T : class
    {
        static SqlConnection connection;

        static ManejadorSql()
        {

        }

        public static bool EjecutarConexion(SqlConnection datosConexion)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                connection = datosConexion;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    command.Connection = connection;
                }
                return true;
            }
            catch (NullReferenceException e)
            {
                GuardarString.Guardar("LOGS Errores.txt", e.Message.ToString());
                throw e;
            }
            catch (Exception e)
            {
                GuardarString.Guardar("LOGS Errores.txt", e.Message.ToString());
                throw e;
            }
            finally
            {

            }
            // return true;   ///esto no seria false???
        }

        public static int EjecutarComando(string orden, List<SqlParameter> parametros, SqlConnection connection)
        {
            int retorno = -1;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = orden; //esto va a venir del FRM 

                if (parametros != null)
                {
                    foreach (SqlParameter item in parametros) //recorre la lista y a cada uno le agrega parametro
                    {
                        command.Parameters.Add(item);
                    }
                }
                retorno = command.ExecuteNonQuery(); //devuelve un int de cuantas rows afecto. 1 o maS pudo, -1 no
            }
            catch (Exception ex)
            {
                GuardarString.Guardar("LOGS Errores.txt", ex.Message.ToString());
                throw new ArchivosException(ex.Message); // MessageBox.Show(ex.Message);
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return retorno;
        }

        public static SqlDataReader EjecutarConsulta(string consulta, List<SqlParameter> parametros, SqlConnection connection)  ////mucho lio hacer generica????
        {
            SqlDataReader dataReader;

            try
            {

                if (connection.State != ConnectionState.Open)  ////TODO ESTO SE PODRIA SIMPLIFICAR
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand();  /////LLEGA CERRADA la consulta me parece
                command.Connection = connection;
                command.CommandText = consulta; //esta la trae de quien la invoque

                if (parametros != null)
                {
                    foreach (SqlParameter item in parametros) //recorre la lista y a cada uno le agrega parametro
                    {
                        command.Parameters.Add(item);
                    }

                }
                dataReader = command.ExecuteReader(); //carga la tabla con lo que leyo         
            }

            catch (NullReferenceException e)
            {
                GuardarString.Guardar("LOGS Errores.txt", e.Message.ToString());
                throw e;
            }
            catch (System.Exception e)
            {
                GuardarString.Guardar("LOGS Errores.txt", e.Message.ToString());
                throw e;
            }
            finally
            {
              
            }

            return dataReader;
        }



    }
}
