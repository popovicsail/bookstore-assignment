using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "date_of_creation",
                table: "award",
                type: "integer",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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
                table: "award",
                columns: new[] { "id", "date_of_creation", "description", "name" },
                values: new object[,]
                {
                    { 1, 1954, "Književna nagrada za najbolji roman godine.", "NIN-ova nagrada" },
                    { 2, 1975, "Književna nagrada za najbolju pripovetku.", "Andrićeva nagrada" },
                    { 3, 1988, "Književna nagrada za najbolju knjigu godine.", "Meša Selimović nagrada" },
                    { 4, 1901, "Međunarodna nagrada za književnost.", "Nobelova nagrada za književnost" }
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
                columns: new[] { "id", "author_id", "award_id", "year_of_winning" },
                values: new object[,]
                {
                    { -15, 5, 2, 1985 },
                    { -14, 4, 2, 1982 },
                    { -13, 4, 1, 1930 },
                    { -12, 3, 3, 1989 },
                    { -11, 2, 2, 1980 },
                    { -10, 1, 1, 1955 },
                    { -9, 5, 3, 1992 },
                    { -8, 5, 1, 1954 },
                    { -7, 4, 3, 1990 },
                    { -6, 3, 2, 1978 },
                    { -5, 3, 1, 1972 },
                    { -4, 2, 3, 1988 },
                    { -3, 2, 1, 1967 },
                    { -2, 1, 2, 1976 },
                    { -1, 1, 4, 1961 }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "award",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "award",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "award",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "award",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_of_creation",
                table: "award",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
