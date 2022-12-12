using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Registration.Server.Migrations
{
    /// <inheritdoc />
    public partial class userIdFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0223df49-ae20-403b-b108-8e3cb7a2879f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2d2e02d-791d-4e80-9e85-4080997b68bd");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "0223df49-ae20-403b-b108-8e3cb7a2879f", "331785ac-6e86-46cf-b31f-28f2fe725413", "Student", "STUDENT" },
                    { "c2d2e02d-791d-4e80-9e85-4080997b68bd", "1640e737-9b8f-43c7-aab7-5f37844f3cc6", "Admin", "ADMIN" }
                });
        }
    }
}
