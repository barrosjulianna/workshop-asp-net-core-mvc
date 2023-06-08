using System;

namespace SalesWebMvc.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        //excessão apra eeros de integridade referencial
        public IntegrityException(string message): base(message)
        {

        }
    }
}
