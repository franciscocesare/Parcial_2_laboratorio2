using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace TestsDePrueba
{
    [TestClass]
    public class TestsUnitarios
    {/*
      * La aplicación deberá de tener implementado Unit Testing para poder probar 
      * como mínimo la siguiente funcionalidad de serialización y deserialización de alumnos en XML y Binario.
      */
        [TestMethod]
        public void TestSerializacionXml()
        {
            Alumno alumno = new Alumno("Francisco", "Cesare", 34, 33222111, 8, "falsa 123", 8);

            DateTime fecha = DateTime.Now;
            ManejarArchivosClass<Alumno> xml = new ManejarArchivosClass<Alumno>();

            Assert.IsTrue(xml.Guardar($"{alumno.Apellido}_{alumno.Nombre}_{fecha.ToString("dd_MM_yyyy")}.xml", alumno));

        }

        [TestMethod]
        public void TestDeserealizarSerializacionXml()
        {
            Alumno alumno = new Alumno("Francisco", "Cesare", 34, 33222111, 8, "falsa 123", 8);
            Alumno alumAux = new Alumno();

            DateTime fecha = DateTime.Now;
            ManejarArchivosClass<Alumno> xml = new ManejarArchivosClass<Alumno>();

            xml.Guardar($"{alumno.Apellido}_{alumno.Nombre}_{fecha.ToString("dd_MM_yyyy")}.xml", alumno); //serializo para deserealizar

            Assert.IsTrue(xml.Leer($"{alumno.Apellido}_{alumno.Nombre}_{fecha.ToString("dd_MM_yyyy")}.xml", out alumAux)); //(xml.Guardar($"{alumno.Apellido}_{alumno.Nombre}_{fecha.ToString("dd_MM_yyyy")}.xml", alumno));

        }

        [TestMethod]
        public void TestSerializacionBinaria()
        {
            Alumno alumno = new Alumno("Pancho", "Cesare", 34, 33222111, 8, "falsa 123", 8);
            Alumno alumAux = new Alumno();
            DateTime fecha = DateTime.Now;

            ManejarArchivosClass<Alumno> bin = new ManejarArchivosClass<Alumno>();

            Assert.IsTrue(bin.SerializarBinario($"{alumno.Apellido}_{alumno.Nombre}_{fecha.ToString("dd_MM_yyyy")}.dat", alumno));

        }

        [TestMethod]
        public void TestDeserializacionBinaria()
        {
            Alumno alumno = new Alumno("Francisco", "Cesare", 34, 33222111, 8, "falsa 123", 8);
            Alumno alumAux = new Alumno();
            DateTime fecha = DateTime.Now;

            ManejarArchivosClass<Alumno> bin = new ManejarArchivosClass<Alumno>();

            bin.SerializarBinario($"{alumno.Apellido}_{alumno.Nombre}_{fecha.ToString("dd_MM_yyyy")}.dat", alumno);
            Assert.IsTrue(bin.LeerBinario($"{alumno.Apellido}_{alumno.Nombre}_{fecha.ToString("dd_MM_yyyy")}.dat", out alumAux));

        }


    }////
}
