using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Search.Model
{
    public class ContextFactory : IDesignTimeDbContextFactory<SearchContext>
    {
        public SearchContext CreateDbContext(string[] args)
        {
            const string connectionString = "Server=.;Database=FullTextSearch;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<SearchContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new SearchContext(optionsBuilder.Options);
        }
    }
}