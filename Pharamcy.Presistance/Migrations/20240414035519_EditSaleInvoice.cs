using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class EditSaleInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                schema: "Pharmacy",
                table: "SalesInvoices",
                newName: "ClientName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientName",
                schema: "Pharmacy",
                table: "SalesInvoices",
                newName: "CustomerName");
        }
    }
}
