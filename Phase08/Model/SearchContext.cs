using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class SearchContext : DbContext
    {
        public DbSet<Doc> Docs {set; get;}
        public DbSet<Word> Words {set; get;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=.;Database=FullTextSearch;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
            .HasMany(w => w.Docs)
            .WithMany(d => d.Words);
        }
    }
}