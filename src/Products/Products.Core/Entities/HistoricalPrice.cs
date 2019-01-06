using System;

namespace Products.Core.Entities
{
    public class HistoricalPrice : BaseEntity
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
