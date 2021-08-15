using Microsoft.EntityFrameworkCore;

namespace Search.Model
{
    public class SearchContext : DbContext
    {
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Word> Words { get; set;}
        public SearchContext(DbContextOptions<SearchContext> dbContextOptions) : base(dbContextOptions) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Word>()
            .HasMany(w => w.Docs)
            .WithMany(d => d.Words).UsingEntity(x => x.ToTable("RelationTable"));
        }
    }
}