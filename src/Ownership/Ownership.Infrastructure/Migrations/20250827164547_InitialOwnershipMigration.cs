using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ownership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialOwnershipMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ownership");

            migrationBuilder.CreateTable(
                name: "Owners",
                schema: "Ownership",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owners",
                schema: "Ownership");
        }
    }
}
