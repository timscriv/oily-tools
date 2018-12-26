using System;
using System.Collections.Generic;
using System.Text;

namespace Paginator.Exceptions
{
    public class InvalidCursorException: Exception
    {
        public InvalidCursorException() : base()
        {
        }

        public InvalidCursorException(string message) : base(message)
        {
        }

        public InvalidCursorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
