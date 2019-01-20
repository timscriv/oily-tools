using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Core.Common.Entities;

namespace Products.Core.EntityFramework.Contexts.Configurations
{
    public class HistoricalPriceConfiguration : IEntityTypeConfiguration<HistoricalPrice>
    {
        public void Configure(EntityTypeBuilder<HistoricalPrice> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Product)
                .WithMany(p => p.HistoricalPrices)
                .HasForeignKey(e => e.ProductId);
        }
    }
}
