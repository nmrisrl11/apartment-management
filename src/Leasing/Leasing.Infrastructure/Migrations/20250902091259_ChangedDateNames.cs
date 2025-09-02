using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leasing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDateNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateRenewal",
                schema: "Leasing",
                table: "LeasingRecords",
                newName: "DateExpiry");

            migrationBuilder.RenameColumn(
                name: "DateLeased",
                schema: "Leasing",
                table: "LeasingRecords",
                newName: "DateCommenced");

            migrationBuilder.RenameColumn(
                name: "DateRenewal",
                schema: "Leasing",
                table: "LeasingAgreements",
                newName: "DateExpiry");

            migrationBuilder.RenameColumn(
                name: "DateLeased",
                schema: "Leasing",
                table: "LeasingAgreements",
                newName: "DateCommenced");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateExpiry",
                schema: "Leasing",
                table: "LeasingRecords",
                newName: "DateRenewal");

            migrationBuilder.RenameColumn(
                name: "DateCommenced",
                schema: "Leasing",
                table: "LeasingRecords",
                newName: "DateLeased");

            migrationBuilder.RenameColumn(
                name: "DateExpiry",
                schema: "Leasing",
                table: "LeasingAgreements",
                newName: "DateRenewal");

            migrationBuilder.RenameColumn(
                name: "DateCommenced",
                schema: "Leasing",
                table: "LeasingAgreements",
                newName: "DateLeased");
        }
    }
}
