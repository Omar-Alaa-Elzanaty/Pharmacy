using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "Adress",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Relay",
                schema: "Pharmacy",
                table: "Clients",
                newName: "TotalPoints");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AdditionalValue",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Indebtedness",
                schema: "Pharmacy",
                table: "Clients",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Pharmacy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Pharmacy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastProcess",
                schema: "Pharmacy",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PointsForCurrency",
                schema: "Pharmacy",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Delivery",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "Pharmacy",
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Discount_percentage = table.Column<double>(type: "float", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalSchema: "Pharmacy",
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_PharmacyId",
                schema: "Pharmacy",
                table: "Delivery",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_MedicineId",
                schema: "Pharmacy",
                table: "Offers",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Clients",
                column: "PharmacyId",
                principalSchema: "Pharmacy",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Clients_ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                column: "ClientId",
                principalSchema: "Pharmacy",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                column: "PharmacyId",
                principalSchema: "Pharmacy",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Clients_ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "Delivery",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Offers",
                schema: "Pharmacy");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "AdditionalValue",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "ClientId",
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

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "MedicineTrackings");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastProcess",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PointsForCurrency",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "TotalPoints",
                schema: "Pharmacy",
                table: "Clients",
                newName: "Relay");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Indebtedness",
                schema: "Pharmacy",
                table: "Clients",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                schema: "Pharmacy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Clients",
                column: "PharmacyId",
                principalSchema: "Pharmacy",
                principalTable: "Pharmacies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                column: "PharmacyId",
                principalSchema: "Pharmacy",
                principalTable: "Pharmacies",
                principalColumn: "Id");
        }
    }
}
