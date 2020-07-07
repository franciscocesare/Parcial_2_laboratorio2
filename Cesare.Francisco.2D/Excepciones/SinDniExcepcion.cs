using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excepciones
{
    public class SinDniExcepcion : Exception
    {
        public SinDniExcepcion(string message, System.Exception innerException) : base(message, innerException)
        {

        }

        public SinDniExcepcion(string message)
            : base(message)
        {

        }
    }
}
