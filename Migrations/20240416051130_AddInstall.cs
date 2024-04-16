using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BTH_BUOI1.Migrations
{
    /// <inheritdoc />
    public partial class AddInstall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: true),
                    DateRead = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    Genre = table.Column<int>(type: "int", nullable: true),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Book_Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Authors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Book_Authors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Book_Authors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "FullName" },
                values: new object[,]
                {
                    { 1, "Paulo Coelho" },
                    { 2, "J.K. Rowling" },
                    { 3, "Jeff Kinney" },
                    { 4, "Harper Lee" },
                    { 5, "J.D. Salinger" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 101, "HarperCollins" },
                    { 102, "Bloomsbury (UK), Scholastic (US)" },
                    { 103, "Amulet Books (US), Puffin Books (UK)" },
                    { 104, "J.B. Lippincott & Co." },
                    { 105, "Little, Brown and Company" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "CoverUrl", "DateAdded", "DateRead", "Description", "Genre", "IsRead", "PublisherId", "Rate", "Title" },
                values: new object[,]
                {
                    { 201, "https://www.tailieuielts.com/wp-content/uploads/2022/01/The-Alchemist-676x1024.jpg", new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Alchemist is about a shepherd named Santiago who embarks on a journey to fulfill his dreams and find the true meaning of life.", 1, false, 101, 5, "The Alchemist" },
                    { 202, "https://www.tailieuielts.com/wp-content/uploads/2022/01/Harry-Potter.jpg", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter series follows the adventures of a young wizard at Hogwarts School of Witchcraft and Wizardry.", 2, false, 102, 4, "Harry Potter" },
                    { 203, "https://www.tailieuielts.com/wp-content/uploads/2022/01/diary-of-a-wimpy-kid.jpg", new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diary of a Wimpy Kid series humorously documents the ups and downs of middle school life through the diary entries of protagonist Greg Heffley.", 3, false, 103, 3, "Diary of a Wimpy Kid" },
                    { 204, "https://www.tailieuielts.com/wp-content/uploads/2022/01/to-kill-a-mockingbird.jpg", new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Kill a Mockingbird is a classic novel that explores themes of racial injustice and moral growth through the eyes of young Scout Finch in the American South of the 1930s.", 4, false, 104, 2, "To Kill a Mockingbird" },
                    { 205, "https://www.tailieuielts.com/wp-content/uploads/2022/01/the-catcher-in-the-rye.jpg", new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Catcher in the Rye is a classic novel that explores teenage angst and rebellion against societal phoniness.", 5, false, 105, 1, "The Catcher in the Rye" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Authors_AuthorId",
                table: "Book_Authors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Authors_BookId",
                table: "Book_Authors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_Authors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
