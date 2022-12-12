using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Registration.Server.Migrations
{
    /// <inheritdoc />
    public partial class dropUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f21af0b-a20d-48e0-8a98-2ddb4dadcef4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "452b18a3-cc7b-4cbd-b28a-51b370b85397");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c77b093-0452-4050-9731-8bee94cca7f6", "09681b2e-3a6c-40f3-92b3-779d61553179", "Admin", "ADMIN" },
                    { "a5981bdf-99b4-4e46-bf15-705ec7f1e93b", "cf3ee7d1-bc25-4635-a219-7b2fc9e65272", "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c77b093-0452-4050-9731-8bee94cca7f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5981bdf-99b4-4e46-bf15-705ec7f1e93b");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f21af0b-a20d-48e0-8a98-2ddb4dadcef4", "5cea3a5a-4a08-4f84-857b-eb2adbca30da", "Admin", "ADMIN" },
                    { "452b18a3-cc7b-4cbd-b28a-51b370b85397", "3a7f2d57-67a5-4394-9d1b-ba6385155041", "Student", "STUDENT" }
                });
        }
    }
}
