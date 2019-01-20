using System.Collections.Generic;
using OilyTools.Core.ValueObjects;

namespace Clients.Core.Common.ValueObjects
{
    public class ClientsRequest : BaseValueObject
    {
        public int? Year { get; set; }
        public string LastName { get; set; }
        public int Limit { get; set; } = 10;
        public int Offset { get; set; } = 0;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Year;
            yield return LastName;
            yield return Limit;
            yield return Offset;
        }
    }
}
