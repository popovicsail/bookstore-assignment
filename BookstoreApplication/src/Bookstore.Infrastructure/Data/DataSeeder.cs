using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class DataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {

        // --- 5 AUTORA ---
        var authors = new List<Author>
        {
            new Author { Id = 1, FullName = "Ivo Andrić", Biography = "Biografija Ive Andrića...", DateOfBirth = new DateTime(1892, 10, 9, 0, 0, 0, DateTimeKind.Utc) },
            new Author { Id = 2, FullName = "Meša Selimović", Biography = "Biografija Meše Selimovića...", DateOfBirth = new DateTime(1910, 4, 26, 0, 0, 0, DateTimeKind.Utc) },
            new Author { Id = 3, FullName = "Danilo Kiš", Biography = "Biografija Danila Kiša...", DateOfBirth = new DateTime(1935, 2, 22, 0, 0, 0, DateTimeKind.Utc) },
            new Author { Id = 4, FullName = "Miloš Crnjanski", Biography = "Biografija Miloša Crnjanskog...", DateOfBirth = new DateTime(1893, 10, 26, 0, 0, 0, DateTimeKind.Utc) },
            new Author { Id = 5, FullName = "Dobrica Ćosić", Biography = "Biografija Dobrice Ćosića...", DateOfBirth = new DateTime(1921, 12, 29, 0, 0, 0, DateTimeKind.Utc) }
        };

        // --- 3 IZDAVAČA ---
        var publishers = new List<Publisher>
        {
            new Publisher { Id = 1, Name = "Laguna", Address = "Resavska 33, Beograd", Website = "www.laguna.rs" },
            new Publisher { Id = 2, Name = "Vulkan Izdavaštvo", Address = "Gospodara Vučića 245, Beograd", Website = "www.vulkani.rs" },
            new Publisher { Id = 3, Name = "BIGZ školstvo", Address = "Bulevar vojvode Mišića 17, Beograd", Website = "www.bigzskolstvo.rs" }
        };

        // --- 4 NAGRADE ---
        var awards = new List<Award>
        {
            new Award { Id = 1, Name = "NIN-ova nagrada", Description = "Književna nagrada za najbolji roman godine.", DateOfCreation = new DateTime(1954, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Award { Id = 2, Name = "Andrićeva nagrada", Description = "Književna nagrada za najbolju pripovetku.", DateOfCreation = new DateTime(1975, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Award { Id = 3, Name = "Meša Selimović nagrada", Description = "Književna nagrada za najbolju knjigu godine.", DateOfCreation = new DateTime(1988, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Award { Id = 4, Name = "Nobelova nagrada za književnost", Description = "Međunarodna nagrada za književnost.", DateOfCreation = new DateTime(1901, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        };

        // --- 12 KNJIGA ---
        var books = new List<Book>
        {
            new Book { Id = 1, Title = "Na Drini ćuprija", PageCount = 379, PublishedDate = new DateTime(1945, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-521-1755-7", AuthorId = 1, PublisherId = 1 },
            new Book { Id = 2, Title = "Prokleta avlija", PageCount = 136, PublishedDate = new DateTime(1954, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-521-0318-5", AuthorId = 1, PublisherId = 2 },
            new Book { Id = 3, Title = "Derviš i smrt", PageCount = 472, PublishedDate = new DateTime(1966, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-10-01614-2", AuthorId = 2, PublisherId = 1 },
            new Book { Id = 4, Title = "Tvrđava", PageCount = 384, PublishedDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-10-01584-8", AuthorId = 2, PublisherId = 2 },
            new Book { Id = 5, Title = "Grobnica za Borisa Davidoviča", PageCount = 180, PublishedDate = new DateTime(1976, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-09-00813-2", AuthorId = 3, PublisherId = 3 },
            new Book { Id = 6, Title = "Enciklopedija mrtvih", PageCount = 160, PublishedDate = new DateTime(1983, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-09-00858-3", AuthorId = 3, PublisherId = 1 },
            new Book { Id = 7, Title = "Seobe", PageCount = 240, PublishedDate = new DateTime(1929, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-7562-022-2", AuthorId = 4, PublisherId = 2 },
            new Book { Id = 8, Title = "Dnevnik o Čarnojeviću", PageCount = 120, PublishedDate = new DateTime(1921, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-7562-045-1", AuthorId = 4, PublisherId = 3 },
            new Book { Id = 9, Title = "Koreni", PageCount = 360, PublishedDate = new DateTime(1954, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-521-0421-2", AuthorId = 5, PublisherId = 1 },
            new Book { Id = 10, Title = "Deobe", PageCount = 576, PublishedDate = new DateTime(1961, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-09-00770-8", AuthorId = 5, PublisherId = 2 },
            new Book { Id = 11, Title = "Vreme smrti", PageCount = 1500, PublishedDate = new DateTime(1972, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-09-00902-3", AuthorId = 5, PublisherId = 3 },
            new Book { Id = 12, Title = "Travnička hronika", PageCount = 496, PublishedDate = new DateTime(1945, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-521-1472-3", AuthorId = 1, PublisherId = 1 }
        };

        // --- 15 PODATAKA U TABELI POVEZNICI (AuthorAward) ---
        var authorAwards = new List<AuthorAward>
        {
            new AuthorAward { Id = -1, AuthorId = 1, AwardId = 4, DateOfWinning = new DateTime(1961, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -2, AuthorId = 1, AwardId = 2, DateOfWinning = new DateTime(1976, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -3, AuthorId = 2, AwardId = 1, DateOfWinning = new DateTime(1967, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -4, AuthorId = 2, AwardId = 3, DateOfWinning = new DateTime(1988, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -5, AuthorId = 3, AwardId = 1, DateOfWinning = new DateTime(1972, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -6, AuthorId = 3, AwardId = 2, DateOfWinning = new DateTime(1978, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -7, AuthorId = 4, AwardId = 3, DateOfWinning = new DateTime(1990, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -8, AuthorId = 5, AwardId = 1, DateOfWinning = new DateTime(1954, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -9, AuthorId = 5, AwardId = 3, DateOfWinning = new DateTime(1992, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -10, AuthorId = 1, AwardId = 1, DateOfWinning = new DateTime(1955, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -11, AuthorId = 2, AwardId = 2, DateOfWinning = new DateTime(1980, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -12, AuthorId = 3, AwardId = 3, DateOfWinning = new DateTime(1989, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -13, AuthorId = 4, AwardId = 1, DateOfWinning = new DateTime(1930, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -14, AuthorId = 4, AwardId = 2, DateOfWinning = new DateTime(1982, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AuthorAward { Id = -15, AuthorId = 5, AwardId = 2, DateOfWinning = new DateTime(1985, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        };

        // Popunjavamo tabele
        modelBuilder.Entity<Author>().HasData(authors);
        modelBuilder.Entity<Publisher>().HasData(publishers);
        modelBuilder.Entity<Award>().HasData(awards);
        modelBuilder.Entity<Book>().HasData(books);
        modelBuilder.Entity<AuthorAward>().HasData(authorAwards);
    }
}