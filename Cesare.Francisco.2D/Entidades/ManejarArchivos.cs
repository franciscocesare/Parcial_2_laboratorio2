using Excepciones;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entidades
{
    /*
     * a. Al momento de serializar o de escribir el archivo (es decir, cuando creemos files), deberán verificar si la ruta existe. 
     * De no existir,crearla la ruta, grabar el file y al finalizar, lanzar una excepción personalizada que grabe en el .txt de logs, 
     * la creación de la ruta por no existir.
      Nota: La aplicación deberá poder levantar siempre los archivos del siguiente 
      path: “MisDocumentos/SegundoParcialUtn/JardinUtn/Docentes/”.

     */
    [Serializable]
    public class ManejarArchivosClass<T> : IArchivo<T>
    {

        public bool Guardar(string archivo, T datos)
        {
            if (!string.IsNullOrEmpty(archivo) && datos != null)
            {
                try
                {

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string pathCompleto = path + @"\Segundo Parcial Utn\Jardin Utn" + archivo;

                 //   if (File.Exists(pathCompleto))
                 //   {
                  //        GuardarString.Guardar("LOGSErrores.txt", archivo);
                //    }
                  //  else
                  //  {
                        using (XmlTextWriter xmlWriter = new XmlTextWriter(pathCompleto, Encoding.ASCII))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(T));
                            serializer.Serialize(xmlWriter, datos);
                        }

                  //  }

                    return true;
                }
                catch (Exception e)
                {
                  
                    GuardarString.Guardar("LOGS Errores.txt", e.Message.ToString());
                    throw new ArchivosException(e);
                }
            }
            return false;
        }


        public bool Leer(string archivo, out T datos)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pathCompleto = path + @"\Segundo Parcial Utn\Jardin Utn";

            datos = default(T);

            if (!string.IsNullOrEmpty(archivo))   ////no llego null, llego count 0, podria volver a evaluar si !=Null
            {                                  //ojo con lo de ver si el archivo existe
                try
                {
                    using (XmlTextReader xmlReader = new XmlTextReader(pathCompleto + archivo)) //
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        datos = (T)serializer.Deserialize(xmlReader);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    GuardarString.Guardar("LOGS Errores.txt", e.Message.ToString());
                    throw new ArchivosException(e);
                }
            }
            return false;
        }


        public bool SerializarBinario(string archivo, T dato)
        {
            if (!string.IsNullOrEmpty(archivo))
            {

                try
                {
                    BinaryFormatter serialBinary = new BinaryFormatter(); //Se crea el objeto serializador.
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + archivo; ///acrodarse que archivo tiene que traer el nombre .dat

                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {

                        serialBinary.Serialize(fs, dato);   //Serializa el objeto p en el archivo contenido en fs.
                    }
                    return true;
                }
                catch (SerializationException e)
                {
                    GuardarString.Guardar("LOGS Errores.txt", e.Message.ToString());
                    throw new Exception(e.Message);

                }
            }
            return false;

        }

        public bool LeerBinario(string archivo, out T dato)
        {
            dato = default(T);
            if (!string.IsNullOrEmpty(archivo))
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + archivo; ///acrodarse que archivo tiene que traer el nombre .dat
                try
                {
                    using (FileStream fst = new FileStream(path, FileMode.Open))
                    {
                        BinaryFormatter serialBinary = new BinaryFormatter(); //Se crea el objeto serializador
                        dato = (T)serialBinary.Deserialize(fst);
                    }
                    return true;
                }

                catch (SerializationException e)
                {
                    GuardarString.Guardar("LOGS Errores.txt", e.Message.ToString());
                    throw new Exception(e.Message);
                }
            }
            return false;

        }





    }
}


