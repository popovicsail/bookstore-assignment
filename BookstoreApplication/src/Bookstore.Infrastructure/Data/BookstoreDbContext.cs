using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Data;
public class BookstoreDbContext : DbContext
{
    public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options) { }
    public DataSeeder DataSeeder { get; set; }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Award> Awards { get; set; }
    public DbSet<AuthorAward> AuthorAwards { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuthorAward>(entity =>
        {
            entity.ToTable("AuthorAwardBridge");
        });

        modelBuilder.Entity<Author>().Property(Author => Author.DateOfBirth).HasColumnName("Birthday");

        modelBuilder.Entity<AuthorAward>()
            .HasOne(AuthorAward => AuthorAward.Author)
            .WithMany(Author => Author.AuthorAwards)
            .HasForeignKey(AuthorAwards => AuthorAwards.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AuthorAward>()
            .HasOne(AuthorAward => AuthorAward.Award)
            .WithMany(Award => Award.AuthorAwards)
            .HasForeignKey(AuthorAward => AuthorAward.AwardId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Book>()
            .HasOne(Book => Book.Publisher)
            .WithMany(Publisher => Publisher.Books)
            .HasForeignKey(Book => Book.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

        DataSeeder.Seed(modelBuilder);
    }
}
