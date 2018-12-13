using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSaudeVacina.Domain.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {

        }
    }
}
