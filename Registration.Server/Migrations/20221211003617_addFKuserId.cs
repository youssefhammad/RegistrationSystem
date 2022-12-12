using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Registration.Server.Migrations
{
    /// <inheritdoc />
    public partial class addFKuserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99397d2d-e1bc-4453-9ce2-98b4c0c52c39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdc27915-2943-4c2c-9a43-21c4b4e856e1");

            migrationBuilder.AddForeignKey(
               name: "FK_Admin_UserId_ASPUSER",
               table: "Admins",
               column: "UserId",
               principalTable: "AspNetUsers",
               principalColumn: "Id",
               onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41bf8a5a-02b9-4432-ac06-452c735aff5f", "5b602c64-80db-43d0-8ecd-9150662cfb89", "Admin", "ADMIN" },
                    { "80c5443e-741b-4842-88ed-eeed2f846d46", "50bfddf4-ec6a-45aa-9b78-67fab7868f89", "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41bf8a5a-02b9-4432-ac06-452c735aff5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80c5443e-741b-4842-88ed-eeed2f846d46");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99397d2d-e1bc-4453-9ce2-98b4c0c52c39", "179c8a5d-5473-46c7-bec8-15c1852e5b0f", "Student", "STUDENT" },
                    { "cdc27915-2943-4c2c-9a43-21c4b4e856e1", "faa8be07-ce5d-43ba-bc71-f1ad749efdcd", "Admin", "ADMIN" }
                });
        }
    }
}
