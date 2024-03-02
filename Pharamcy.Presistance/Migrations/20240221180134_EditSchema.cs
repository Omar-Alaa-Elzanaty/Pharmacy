using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class EditSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "Stores",
                schema: "Phamracy",
                newName: "Stores",
                newSchema: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "SalesInvoices",
                schema: "Phamracy",
                newName: "SalesInvoices",
                newSchema: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "PurchaseInvoices",
                schema: "Phamracy",
                newName: "PurchaseInvoices",
                newSchema: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "Pharmacies",
                schema: "Phamracy",
                newName: "Pharmacies",
                newSchema: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "MedicinesReference",
                schema: "Phamracy",
                newName: "MedicinesReference",
                newSchema: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "Medicines",
                schema: "Phamracy",
                newName: "Medicines",
                newSchema: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "Losts",
                schema: "Phamracy",
                newName: "Losts",
                newSchema: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "Clients",
                schema: "Phamracy",
                newName: "Clients",
                newSchema: "Pharmacy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Phamracy");

            migrationBuilder.RenameTable(
                name: "Stores",
                schema: "Pharmacy",
                newName: "Stores",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "SalesInvoices",
                schema: "Pharmacy",
                newName: "SalesInvoices",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "PurchaseInvoices",
                schema: "Pharmacy",
                newName: "PurchaseInvoices",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "Pharmacies",
                schema: "Pharmacy",
                newName: "Pharmacies",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "MedicinesReference",
                schema: "Pharmacy",
                newName: "MedicinesReference",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "Medicines",
                schema: "Pharmacy",
                newName: "Medicines",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "Losts",
                schema: "Pharmacy",
                newName: "Losts",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "Clients",
                schema: "Pharmacy",
                newName: "Clients",
                newSchema: "Phamracy");
        }
    }
}
