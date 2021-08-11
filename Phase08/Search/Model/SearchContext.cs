using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Search.Model
{
    public class SearchContext : DbContext
    {
        public DbSet<Doc> Docs { set; get;}
        public DbSet<Word> Words { set; get;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.;Database=FullTextSearch;Trusted_Connection=True;");
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