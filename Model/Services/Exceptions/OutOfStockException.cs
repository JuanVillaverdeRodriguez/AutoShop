using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions
{
    [Serializable]

    public class OutOfStockException : Exception
    {
        // Excepcion con mensaje por defecto
        public OutOfStockException() : base("No hay suficientes existencias de este producto.")
        {
        }
        // Excepcion con mensaje personalizado

        public OutOfStockException(string message) : base(message)
        {
        }
        // Excepcion con mensaje personalizado y excepcion interna

        public OutOfStockException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
