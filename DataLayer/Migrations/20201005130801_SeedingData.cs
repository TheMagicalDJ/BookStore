using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Name" },
                values: new object[,]
                {
                    { 1, "Martin Fowler" },
                    { 2, "Eric Evans" },
                    { 3, "Future Person" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Description", "ImageUrl", "Price", "PublishedOn", "Publisher", "SoftDeleted", "Title" },
                values: new object[,]
                {
                    { 1, "Improving the design of existing code", null, 40m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Refactoring" },
                    { 2, "Written in direct response to the stiff challenges", null, 53m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Patterns of Enterprise Application Architecture" },
                    { 3, "Linking business needs to software design", null, 56m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Domain - Driven Design" },
                    { 4, "Entangled quantum networking provides faster-than - light data communications", null, 220m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Quantum Networking" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "BookId", "AuthorId", "Order" },
                values: new object[,]
                {
                    { 1, 1, (byte)0 },
                    { 1, 2, (byte)0 },
                    { 2, 1, (byte)0 },
                    { 3, 2, (byte)0 },
                    { 4, 3, (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "BookId", "Comment", "NumStars", "VoterName" },
                values: new object[,]
                {
                    { 1, 1, "Great book", 3, null },
                    { 2, 1, "Boringbook", 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);
        }
    }
}
