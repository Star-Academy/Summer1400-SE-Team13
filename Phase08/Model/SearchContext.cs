using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class SearchContext : DbContext
    {
        public DbSet<Doc> Docs { set; get;}
        public DbSet<Word> Words { set; get;}
        public DbSet<DocToWord> RelationTable { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=.;Database=FullTextSearch;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DocToWord>().HasKey(i => new { i.DocId, i.WordId });
            // modelBuilder.Entity<Word>()
            // .HasMany(w => w.Docs)
            // .WithMany(d => d.Words);
        }
    }
}