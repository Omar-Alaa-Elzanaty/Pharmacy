using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class SaleInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AdditionalValue",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryName",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceWriter",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Paied",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TermAmount",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalDiscount",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalOfSalePrice",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalOfSalePriceAfterDiscount",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                schema: "Pharmacy",
                table: "SalesInvoiceItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                schema: "Pharmacy",
                table: "SalesInvoiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "SalesInvoiceItems",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<double>(
                name: "PriceAfterDiscount",
                schema: "Pharmacy",
                table: "SalesInvoiceItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SalePrice",
                schema: "Pharmacy",
                table: "SalesInvoiceItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Tablets",
                schema: "Pharmacy",
                table: "SalesInvoiceItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taps",
                schema: "Pharmacy",
                table: "SalesInvoiceItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taxis",
                schema: "Pharmacy",
                table: "SalesInvoiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ImportInvoiceNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_ImportInvoiceNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                column: "ImportInvoiceNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoices_ImportInvoiceNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "AdditionalValue",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "DeliveryName",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "InvoiceWriter",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "Paied",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "TermAmount",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "TotalDiscount",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "TotalOfSalePrice",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "TotalOfSalePriceAfterDiscount",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "Pharmacy",
                table: "SalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "Pharmacy",
                table: "SalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "SalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "PriceAfterDiscount",
                schema: "Pharmacy",
                table: "SalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                schema: "Pharmacy",
                table: "SalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "Tablets",
                schema: "Pharmacy",
                table: "SalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "Taps",
                schema: "Pharmacy",
                table: "SalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "Taxis",
                schema: "Pharmacy",
                table: "SalesInvoiceItems");

            migrationBuilder.AlterColumn<string>(
                name: "ImportInvoiceNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
