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
                name: "Lessees",
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
                    table.PrimaryKey("PK_Lessees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessors",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_Lessors_LessorId",
                        column: x => x.LessorId,
                        principalSchema: "Leasing",
                        principalTable: "Lessors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeasingAgreements",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LesseeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateCommenced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExpiry = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_LeasingAgreements_Lessees_LesseeId",
                        column: x => x.LesseeId,
                        principalSchema: "Leasing",
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeasingAgreements_Lessors_LessorId",
                        column: x => x.LessorId,
                        principalSchema: "Leasing",
                        principalTable: "Lessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeasingRecords",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LesseeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCommenced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        name: "FK_LeasingRecords_Lessees_LesseeId",
                        column: x => x.LesseeId,
                        principalSchema: "Leasing",
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeasingRecords_Lessors_LessorId",
                        column: x => x.LessorId,
                        principalSchema: "Leasing",
                        principalTable: "Lessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_LessorId",
                schema: "Leasing",
                table: "Apartments",
                column: "LessorId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingAgreements_ApartmentId",
                schema: "Leasing",
                table: "LeasingAgreements",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingAgreements_LesseeId",
                schema: "Leasing",
                table: "LeasingAgreements",
                column: "LesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingAgreements_LessorId",
                schema: "Leasing",
                table: "LeasingAgreements",
                column: "LessorId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_ApartmentId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_LesseeId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "LesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_LessorId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "LessorId");
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
                name: "Lessees",
                schema: "Leasing");

            migrationBuilder.DropTable(
                name: "Lessors",
                schema: "Leasing");
        }
    }
}
