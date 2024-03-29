using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions
{
    class MistakenPasswordException : Exception
    {
        // Excepcion con mensaje por defecto
        public MistakenPasswordException() : base("Password is not correct. Try again.")
        {
        }
        // Excepcion con mensaje personalizado

        public MistakenPasswordException(string message) : base(message)
        {
        }
        // Excepcion con mensaje personalizado y excepcion interna

        public MistakenPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
