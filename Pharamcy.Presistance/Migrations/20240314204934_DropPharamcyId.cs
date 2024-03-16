using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class DropPharamcyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PruchaseInvoiceItem",
                schema: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "PharamcyId",
                schema: "Pharmacy",
                table: "Suppliers");

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceItem",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Bonse = table.Column<int>(type: "int", nullable: false),
                    Shelf = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Taps = table.Column<int>(type: "int", nullable: false),
                    Tablets = table.Column<int>(type: "int", nullable: false),
                    Taxis = table.Column<int>(type: "int", nullable: false),
                    AdditionalDiscount = table.Column<int>(type: "int", nullable: false),
                    BaseDiscount = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    ExpireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceItem_PurchaseInvoices_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalSchema: "Pharmacy",
                        principalTable: "PurchaseInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceItem_PurchaseInvoiceId",
                schema: "Pharmacy",
                table: "PurchaseInvoiceItem",
                column: "PurchaseInvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseInvoiceItem",
                schema: "Pharmacy");

            migrationBuilder.AddColumn<int>(
                name: "PharamcyId",
                schema: "Pharmacy",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PruchaseInvoiceItem",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false),
                    AdditionalDiscount = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BaseDiscount = table.Column<int>(type: "int", nullable: false),
                    Bonse = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    Shelf = table.Column<int>(type: "int", nullable: false),
                    Tablets = table.Column<int>(type: "int", nullable: false),
                    Taps = table.Column<int>(type: "int", nullable: false),
                    Taxis = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PruchaseInvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PruchaseInvoiceItem_PurchaseInvoices_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalSchema: "Pharmacy",
                        principalTable: "PurchaseInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PruchaseInvoiceItem_PurchaseInvoiceId",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                column: "PurchaseInvoiceId");
        }
    }
}
