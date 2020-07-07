using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Excepciones
{
    public class LogsException : Exception

    {
        public LogsException()
        {
        }

        public LogsException(string message) : base(message)
        {

        }
    }
}
