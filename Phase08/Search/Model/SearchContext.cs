using Microsoft.EntityFrameworkCore;

namespace Search.Model
{
    public class SearchContext : DbContext
    {
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Word> Words { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Server=.;Database=FullTextSearch;Trusted_Connection=True;";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Word>()
            .HasMany(w => w.Docs)
            .WithMany(d => d.Words).UsingEntity(x => x.ToTable("RelationTable"));
        }
    }
}