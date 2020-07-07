using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;

namespace Entidades
{

    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Docente))]
    public abstract class Persona
    {
       protected int iD;
       protected string nombre;
       protected string apellido;
       protected int edad;
       protected int dni;
       protected string direccion;

        public Persona()
        {

        }

     
        protected Persona(string nombre, string apellido, int edad, int dni, int iD,string direccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.Dni = dni;
            this.iD = iD;
            this.direccion = direccion;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

      public int Id
        {
            get { return this.iD; }
            set { this.iD = value; }
        }

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }


        public int Dni
        {
            get { return this.dni; }
            set
            {
                try
                {
                    ValidarPersonaSinDNI(value);  //va a lanzar una excepcion si es menor a 1000000
                    this.dni = value;
                }
                catch (SinDniExcepcion ex) //EX la instancia de la excepcion que me fallo
                {
                    GuardarString.Guardar("LOGS Errores.txt", ex.Message.ToString());
                    throw new SinDniExcepcion("te dije que era invalido", ex);
                }
            }
        }
      
        public  string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }







        public void ValidarPersonaSinDNI(int value)   //un ejemplo para los test unit

        {
            if (value < 1000000)
            {
                throw new SinDniExcepcion("Numero de DNI invalido!");  ///QUE TENGO QUE HACER CON TRY Y CATCH, ESTA MAL ESTE TEMA
            }

        }




    }

}

