using System;
using System.Collections.Generic;

namespace Products.Core.Common.Entities
{
    public class Product: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }

        public List<HistoricalPrice> HistoricalPrices { get; set; } = new List<HistoricalPrice>();
    }
}
