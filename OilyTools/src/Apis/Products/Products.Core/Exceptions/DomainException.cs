using System;

namespace Products.Core.Exceptions
{
    public class DomainException: Exception
    {
        public string BusinessMessage { get; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }

        private DomainException() : base()
        {
        }

        private DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
