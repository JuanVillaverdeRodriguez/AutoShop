using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions
{
    class MistakenCredentialsException : Exception
    {
        // Excepcion con mensaje por defecto
        public MistakenCredentialsException() : base("Password is not correct. Try again.")
        {
        }
        // Excepcion con mensaje personalizado

        public MistakenCredentialsException(string message) : base(message)
        {
        }
        // Excepcion con mensaje personalizado y excepcion interna

        public MistakenCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
