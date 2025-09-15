using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_author_award_authors_author_id",
                table: "author_award");

            migrationBuilder.DropForeignKey(
                name: "fk_author_award_award_award_id",
                table: "author_award");

            migrationBuilder.DropForeignKey(
                name: "fk_books_publishers_publisher_id",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "pk_author_award",
                table: "author_award");

            migrationBuilder.RenameTable(
                name: "author_award",
                newName: "AuthorAwardBridge");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                table: "authors",
                newName: "Birthday");

            migrationBuilder.RenameIndex(
                name: "ix_author_award_award_id",
                table: "AuthorAwardBridge",
                newName: "ix_author_award_bridge_award_id");

            migrationBuilder.RenameIndex(
                name: "ix_author_award_author_id",
                table: "AuthorAwardBridge",
                newName: "ix_author_award_bridge_author_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_author_award_bridge",
                table: "AuthorAwardBridge",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_author_award_bridge_authors_author_id",
                table: "AuthorAwardBridge",
                column: "author_id",
                principalTable: "authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_author_award_bridge_award_award_id",
                table: "AuthorAwardBridge",
                column: "award_id",
                principalTable: "award",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_books_publishers_publisher_id",
                table: "books",
                column: "publisher_id",
                principalTable: "publishers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_author_award_bridge_authors_author_id",
                table: "AuthorAwardBridge");

            migrationBuilder.DropForeignKey(
                name: "fk_author_award_bridge_award_award_id",
                table: "AuthorAwardBridge");

            migrationBuilder.DropForeignKey(
                name: "fk_books_publishers_publisher_id",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "pk_author_award_bridge",
                table: "AuthorAwardBridge");

            migrationBuilder.RenameTable(
                name: "AuthorAwardBridge",
                newName: "author_award");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "authors",
                newName: "date_of_birth");

            migrationBuilder.RenameIndex(
                name: "ix_author_award_bridge_award_id",
                table: "author_award",
                newName: "ix_author_award_award_id");

            migrationBuilder.RenameIndex(
                name: "ix_author_award_bridge_author_id",
                table: "author_award",
                newName: "ix_author_award_author_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_author_award",
                table: "author_award",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_author_award_authors_author_id",
                table: "author_award",
                column: "author_id",
                principalTable: "authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_author_award_award_award_id",
                table: "author_award",
                column: "award_id",
                principalTable: "award",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_books_publishers_publisher_id",
                table: "books",
                column: "publisher_id",
                principalTable: "publishers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
