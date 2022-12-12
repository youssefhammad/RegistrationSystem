using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Server.Migrations
{
    /// <inheritdoc />
    public partial class dateOfReg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationTime",
                table: "Registrations",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationTime",
                table: "Registrations");
        }
    }
}
