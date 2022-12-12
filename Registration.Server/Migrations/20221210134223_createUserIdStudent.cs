using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Registration.Server.Migrations
{
    /// <inheritdoc />
    public partial class createUserIdStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9924052c-beff-4d3b-b577-7257fe8c9add", "2b9dc602-61f9-4c38-be24-383b1ec10f5a", "Admin", "ADMIN" },
                    { "f1e50c8a-5fd4-4d50-afe9-8a879843a40b", "2c4f5e59-300d-46f9-932f-54844ee09475", "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9924052c-beff-4d3b-b577-7257fe8c9add");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1e50c8a-5fd4-4d50-afe9-8a879843a40b");

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
    }
}
