using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class editingIsPArtition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPartition",
                schema: "Pharmacy",
                table: "PurchaseInvoiceItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPartition",
                schema: "Pharmacy",
                table: "PurchaseInvoiceItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
