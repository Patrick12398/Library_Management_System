using Library_Management_System.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.DB
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<DBBook> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DBBook>(entity =>
            {
                entity.ToTable("Books");

                entity.HasKey(b => b.Id);

                entity.Property(b => b.Title)
                                      .IsRequired()
                                      .HasMaxLength(200);

                entity.Property(b => b.Author)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(b => b.ISBN)
                      .HasMaxLength(50);

                entity.Property(b => b.PublishedYear)
                      .IsRequired();

                entity.Property(b => b.IsAvailable)
                      .HasDefaultValue(true);
            });
        }
    }
}
