using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Registration.Server.Migrations
{
    /// <inheritdoc />
    public partial class addUserIdInAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fb23cda-9b73-4b9b-93b1-7d460a666207");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f20ed070-9039-46f3-9ee7-dc1a328f5932");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Admins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99397d2d-e1bc-4453-9ce2-98b4c0c52c39", "179c8a5d-5473-46c7-bec8-15c1852e5b0f", "Student", "STUDENT" },
                    { "cdc27915-2943-4c2c-9a43-21c4b4e856e1", "faa8be07-ce5d-43ba-bc71-f1ad749efdcd", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99397d2d-e1bc-4453-9ce2-98b4c0c52c39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdc27915-2943-4c2c-9a43-21c4b4e856e1");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Admins");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fb23cda-9b73-4b9b-93b1-7d460a666207", "f7ea2147-fc04-4dbd-ae7a-ebae1ff447a4", "Admin", "ADMIN" },
                    { "f20ed070-9039-46f3-9ee7-dc1a328f5932", "a958858b-fd13-4867-8df8-1c743d62c6b6", "Student", "STUDENT" }
                });
        }
    }
}
