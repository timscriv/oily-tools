﻿using System.Collections.Generic;
using OilyTools.Core.ValueObjects;

namespace Clients.Core.ValueObjects
{
    public class ClientsRequest : BaseValueObject
    {
        public int? Year { get; set; }
        public string LastName { get; set; }
        public int Limit { get; set; } = 10;
        public string Cursor { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Year;
            yield return LastName;
            yield return Limit;
            yield return Cursor;
        }
    }
}
