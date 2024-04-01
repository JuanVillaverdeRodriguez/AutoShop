using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions
{
    [Serializable]

    public class EmptyCartException : Exception
    {
        // Excepcion con mensaje por defecto
        public EmptyCartException() : base("Cart doesn't have any product.")
        {
        }
        // Excepcion con mensaje personalizado

        public EmptyCartException(string message) : base(message)
        {
        }
        // Excepcion con mensaje personalizado y excepcion interna

        public EmptyCartException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
