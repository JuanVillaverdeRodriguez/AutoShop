using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions
{
    [Serializable]

    public class NoDefaultCardException : Exception
    {
        // Excepcion con mensaje por defecto
        public NoDefaultCardException() : base("User doesn't have a default card.")
        {
        }
        // Excepcion con mensaje personalizado

        public NoDefaultCardException(string message) : base(message)
        {
        }
        // Excepcion con mensaje personalizado y excepcion interna

        public NoDefaultCardException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
