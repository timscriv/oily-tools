using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Products.Infrastructure.EntityFramework.Contexts;

namespace Products.Infrastructure.EntityFramework.Sqlite
{
    public class ProductsContextFactory : IDesignTimeDbContextFactory<ProductsContext>
    {
        public ProductsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductsContext>();
            optionsBuilder.UseSqlite("Data Source=../../../oilytools.db");

            return new ProductsContext(optionsBuilder.Options, null);
        }
    }
}
