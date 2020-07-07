using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    [Serializable]
    public class Docente : Persona
    {

        private string eMail;
        private string sexo;

        public Docente()
        {

        }

        public string Email
        {
            get { return this.eMail; }
            set { this.eMail = value; }
        }

        public string Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
            }
        }

        public Docente(string nombre, string apellido, int edad, string sexo, int dni, int iD, string direccion, string eMail)
            : base(nombre, apellido, edad, dni, iD, direccion)
        {
            this.eMail = eMail;
            this.sexo = sexo;
        }

        /// <summary>
        /// override ToString para cada entidad mostrar su datos
        /// </summary>de la base trae atributos de personal
        /// <returns></returns> los datos de Docente
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Nombre.ToString());
            sb.AppendLine(", ");
            sb.AppendLine(base.Apellido.ToString());

            return sb.ToString();
        }

        public string Mostrar()
        {
            return this.ToString();
        }
    }

}
