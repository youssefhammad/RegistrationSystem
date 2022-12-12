using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Registration.Server.Migrations
{
    /// <inheritdoc />
    public partial class userIdFKrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9924052c-beff-4d3b-b577-7257fe8c9add");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1e50c8a-5fd4-4d50-afe9-8a879843a40b");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_UserId_ASPUSER",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fb23cda-9b73-4b9b-93b1-7d460a666207", "f7ea2147-fc04-4dbd-ae7a-ebae1ff447a4", "Admin", "ADMIN" },
                    { "f20ed070-9039-46f3-9ee7-dc1a328f5932", "a958858b-fd13-4867-8df8-1c743d62c6b6", "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fb23cda-9b73-4b9b-93b1-7d460a666207");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f20ed070-9039-46f3-9ee7-dc1a328f5932");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9924052c-beff-4d3b-b577-7257fe8c9add", "2b9dc602-61f9-4c38-be24-383b1ec10f5a", "Admin", "ADMIN" },
                    { "f1e50c8a-5fd4-4d50-afe9-8a879843a40b", "2c4f5e59-300d-46f9-932f-54844ee09475", "Student", "STUDENT" }
                });
        }
    }
}
