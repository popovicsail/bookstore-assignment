using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookstore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    biography = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "awards",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    date_of_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_awards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    website = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publishers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorAwardBridge",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    author_id = table.Column<int>(type: "integer", nullable: false),
                    award_id = table.Column<int>(type: "integer", nullable: false),
                    date_of_winning = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_author_award_bridge", x => x.id);
                    table.ForeignKey(
                        name: "fk_author_award_bridge_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_author_award_bridge_awards_award_id",
                        column: x => x.award_id,
                        principalTable: "awards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    page_count = table.Column<int>(type: "integer", nullable: false),
                    published_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isbn = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<int>(type: "integer", nullable: false),
                    publisher_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books", x => x.id);
                    table.ForeignKey(
                        name: "fk_books_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_books_publishers_publisher_id",
                        column: x => x.publisher_id,
                        principalTable: "publishers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "id", "biography", "Birthday", "full_name" },
                values: new object[,]
                {
                    { 1, "Biografija Ive Andrića...", new DateTime(1892, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Ivo Andrić" },
                    { 2, "Biografija Meše Selimovića...", new DateTime(1910, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Meša Selimović" },
                    { 3, "Biografija Danila Kiša...", new DateTime(1935, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Danilo Kiš" },
                    { 4, "Biografija Miloša Crnjanskog...", new DateTime(1893, 10, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Miloš Crnjanski" },
                    { 5, "Biografija Dobrice Ćosića...", new DateTime(1921, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Dobrica Ćosić" }
                });

            migrationBuilder.InsertData(
                table: "awards",
                columns: new[] { "id", "date_of_creation", "description", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Književna nagrada za najbolji roman godine.", "NIN-ova nagrada" },
                    { 2, new DateTime(1975, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Književna nagrada za najbolju pripovetku.", "Andrićeva nagrada" },
                    { 3, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Književna nagrada za najbolju knjigu godine.", "Meša Selimović nagrada" },
                    { 4, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Međunarodna nagrada za književnost.", "Nobelova nagrada za književnost" }
                });

            migrationBuilder.InsertData(
                table: "publishers",
                columns: new[] { "id", "address", "name", "website" },
                values: new object[,]
                {
                    { 1, "Resavska 33, Beograd", "Laguna", "www.laguna.rs" },
                    { 2, "Gospodara Vučića 245, Beograd", "Vulkan Izdavaštvo", "www.vulkani.rs" },
                    { 3, "Bulevar vojvode Mišića 17, Beograd", "BIGZ školstvo", "www.bigzskolstvo.rs" }
                });

            migrationBuilder.InsertData(
                table: "AuthorAwardBridge",
                columns: new[] { "id", "author_id", "award_id", "date_of_winning" },
                values: new object[,]
                {
                    { -15, 5, 2, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -14, 4, 2, new DateTime(1982, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -13, 4, 1, new DateTime(1930, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -12, 3, 3, new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -11, 2, 2, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -10, 1, 1, new DateTime(1955, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -9, 5, 3, new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -8, 5, 1, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -7, 4, 3, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -6, 3, 2, new DateTime(1978, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -5, 3, 1, new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -4, 2, 3, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -3, 2, 1, new DateTime(1967, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -2, 1, 2, new DateTime(1976, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -1, 1, 4, new DateTime(1961, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "id", "author_id", "isbn", "page_count", "published_date", "publisher_id", "title" },
                values: new object[,]
                {
                    { 1, 1, "978-86-521-1755-7", 379, new DateTime(1945, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Na Drini ćuprija" },
                    { 2, 1, "978-86-521-0318-5", 136, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Prokleta avlija" },
                    { 3, 2, "978-86-10-01614-2", 472, new DateTime(1966, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Derviš i smrt" },
                    { 4, 2, "978-86-10-01584-8", 384, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Tvrđava" },
                    { 5, 3, "978-86-09-00813-2", 180, new DateTime(1976, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Grobnica za Borisa Davidoviča" },
                    { 6, 3, "978-86-09-00858-3", 160, new DateTime(1983, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Enciklopedija mrtvih" },
                    { 7, 4, "978-86-7562-022-2", 240, new DateTime(1929, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Seobe" },
                    { 8, 4, "978-86-7562-045-1", 120, new DateTime(1921, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Dnevnik o Čarnojeviću" },
                    { 9, 5, "978-86-521-0421-2", 360, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Koreni" },
                    { 10, 5, "978-86-09-00770-8", 576, new DateTime(1961, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Deobe" },
                    { 11, 5, "978-86-09-00902-3", 1500, new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Vreme smrti" },
                    { 12, 1, "978-86-521-1472-3", 496, new DateTime(1945, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Travnička hronika" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_author_award_bridge_author_id",
                table: "AuthorAwardBridge",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_author_award_bridge_award_id",
                table: "AuthorAwardBridge",
                column: "award_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_author_id",
                table: "books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_publisher_id",
                table: "books",
                column: "publisher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorAwardBridge");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "awards");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
