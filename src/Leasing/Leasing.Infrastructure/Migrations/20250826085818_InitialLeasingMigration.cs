using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leasing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialLeasingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Leasing");

            migrationBuilder.CreateTable(
                name: "Owners",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Leasing",
                        principalTable: "Owners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeasingAgreements",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateLeased = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRenewal = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeasingAgreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeasingAgreements_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalSchema: "Leasing",
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeasingAgreements_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Leasing",
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeasingAgreements_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "Leasing",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeasingRecords",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateLeased = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRenewal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeasingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeasingRecords_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalSchema: "Leasing",
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeasingRecords_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Leasing",
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeasingRecords_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "Leasing",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_OwnerId",
                schema: "Leasing",
                table: "Apartments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingAgreements_ApartmentId",
                schema: "Leasing",
                table: "LeasingAgreements",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingAgreements_OwnerId",
                schema: "Leasing",
                table: "LeasingAgreements",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingAgreements_TenantId",
                schema: "Leasing",
                table: "LeasingAgreements",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_ApartmentId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_TenantId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeasingAgreements",
                schema: "Leasing");

            migrationBuilder.DropTable(
                name: "LeasingRecords",
                schema: "Leasing");

            migrationBuilder.DropTable(
                name: "Apartments",
                schema: "Leasing");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "Leasing");

            migrationBuilder.DropTable(
                name: "Owners",
                schema: "Leasing");
        }
    }
}
