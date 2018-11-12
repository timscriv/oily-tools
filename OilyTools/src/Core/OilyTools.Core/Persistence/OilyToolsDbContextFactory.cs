using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OilyTools.Core.Persistence
{
    public class OilyToolsDbContextFactory : IDesignTimeDbContextFactory<OilyToolsDbContext>
    {
        public OilyToolsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OilyToolsDbContext>();
            optionsBuilder.UseSqlite("Data Source=../../oilytools.db");

            return new OilyToolsDbContext(optionsBuilder.Options, null);
        }
    }
}
