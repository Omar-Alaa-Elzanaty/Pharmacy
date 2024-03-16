using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class DeletingFinincialDues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyFinanicalDues",
                schema: "Pharmacy");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                newName: "SupplierName");

            migrationBuilder.AddColumn<double>(
                name: "FinancialDue",
                schema: "Pharmacy",
                table: "Suppliers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPartition",
                schema: "Pharmacy",
                table: "PurchaseInvoiceItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TabletSalePrice",
                schema: "Pharmacy",
                table: "PurchaseInvoiceItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialDue",
                schema: "Pharmacy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "IsPartition",
                schema: "Pharmacy",
                table: "PurchaseInvoiceItem");

            migrationBuilder.DropColumn(
                name: "TabletSalePrice",
                schema: "Pharmacy",
                table: "PurchaseInvoiceItem");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                newName: "CompanyName");

            migrationBuilder.CreateTable(
                name: "PharmacyFinanicalDues",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancialDue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyFinanicalDues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyFinanicalDues_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Pharmacy",
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyFinanicalDues_SupplierId",
                schema: "Pharmacy",
                table: "PharmacyFinanicalDues",
                column: "SupplierId");
        }
    }
}
