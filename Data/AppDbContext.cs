using Microsoft.EntityFrameworkCore;
using BTH_BUOI1.Models.Domain;
using BTH_BUOI1.Models;

namespace BTH_BUOI1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Books> Books { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Books>()
                .HasOne(x => x.Publisher)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.PublisherId);

            // Seed data
            new DbTemplateBook(builder).Seed();
        }
    }
}
