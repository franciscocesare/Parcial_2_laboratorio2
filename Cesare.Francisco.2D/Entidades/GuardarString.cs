using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardarString 
    {
        /// <summary>
        /// Lee datos del path pasdao
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Donde se guarda la informacion del archivo</param>
        /// <returns>Devuelve la info del archivo o vacio si no pudo</returns>
        public static bool Guardar(string archivo, string datos)
        {
            bool aux = false;
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(datos))
            {
                try
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    using (StreamWriter sw = new StreamWriter(Path.Combine(path, archivo)))
                    {
                        sw.WriteLine(datos);
                        aux = true;
                    }

                }
                catch (Exception e)
                {
                    throw new ArchivosException(e.Message);
                }
            }

            return aux;
        }

        /// <summary>
        /// Lee datos del path pasdao
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Donde se guarda la informacion del archivo</param>
        /// <returns>Devuelve la info del archivo o vacio si no pudo</returns>
        public static bool Leer(string archivo, out string datos)
        {
            bool aux = false;
            datos = "";
            if (!string.IsNullOrEmpty(archivo))
            {
                try
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    using (StreamReader sw = new StreamReader(Path.Combine(path, archivo)))
                    {
                        datos = sw.ReadToEnd();
                        aux = true;
                    }
                    //sw.Close();
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e.Message);
                }
            }
            return aux;
        }

    }

   
}
