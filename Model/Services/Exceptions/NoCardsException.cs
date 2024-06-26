﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions
{
    [Serializable]

    public class NoCardsException : Exception
    {
        // Excepcion con mensaje por defecto
        public NoCardsException() : base("El usuario no tiene tarjetas.")
        {
        }
        // Excepcion con mensaje personalizado

        public NoCardsException(string message) : base(message)
        {
        }
        // Excepcion con mensaje personalizado y excepcion interna

        public NoCardsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
