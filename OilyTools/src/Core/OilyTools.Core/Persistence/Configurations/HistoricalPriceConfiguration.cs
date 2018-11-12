using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OilyTools.Core.Entities;

namespace OilyTools.Core.Persistence.Configurations
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
