using System.Collections.Generic;

namespace OilyTools.Core.Exceptions
{
    public class ValidationException: DomainException
    {
        public ValidationException(IDictionary<string, IEnumerable<string>> failures)
            : base("One or more validation failures have occurred.")
        {
            Failures = failures;
        }

        private ValidationException(string businessMessage) : base(businessMessage)
        {
        }

        public IDictionary<string, IEnumerable<string>> Failures { get; }
    }
}
