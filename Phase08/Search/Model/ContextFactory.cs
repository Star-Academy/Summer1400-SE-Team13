using Microsoft.EntityFrameworkCore;

namespace Search.Model
{
    public class ContextFactory
    {
        public SearchContext CreateDbContext()
        {
            const string connectionString = "Server=.;Database=FullTextSearch;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<SearchContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new SearchContext(optionsBuilder.Options);
        }
    }
}