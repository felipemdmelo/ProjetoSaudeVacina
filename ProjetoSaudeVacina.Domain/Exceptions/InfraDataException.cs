using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSaudeVacina.Domain.Exceptions
{
    public class InfraDataException : Exception
    {
        public Exception OriginException { get; private set; }

        public InfraDataException(string message, Exception e) : base(message)
        {
            OriginException = e;
        }
    }
}
