using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class DropimportInvoiceNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportInvoiceNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImportInvoiceNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
