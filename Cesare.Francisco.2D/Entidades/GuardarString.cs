using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    /*
      Nota: La aplicación deberá poder levantar siempre los archivos del siguiente 
      path: “MisDocumentos/SegundoParcialUtn/JardinUtn/Docentes/”.

     */
    public static class GuardarString  ///EXTENSION DE STRING, POR ESO EL THIS EN LOS PARAMETROS
    {

        public static bool GuardarTexto(this string texto, string archivo)
        {
            bool aux = false;
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(texto))
            {
                try
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);  /////ver lo de my documents
                    using (StreamWriter sw = new StreamWriter(Path.Combine(path, archivo),true))
                    {
                        sw.WriteLine(texto);
                        aux = true;
                    }
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return aux;
        }


    }
}
