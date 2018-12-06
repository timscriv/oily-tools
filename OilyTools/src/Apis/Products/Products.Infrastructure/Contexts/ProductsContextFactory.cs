using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Products.Infrastructure.Contexts
{
    public class ProductsContextFactory : IDesignTimeDbContextFactory<ProductsContext>
    {
        public ProductsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductsContext>();
            optionsBuilder.UseSqlite("Data Source=../../../../oilytools.db");

            return new ProductsContext(optionsBuilder.Options, null);
        }
    }
}
