using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceImage",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                newName: "InvoiceImageUrl");

            migrationBuilder.AlterColumn<double>(
                name: "TermAmount",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Paied",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "SalePrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "TabletSalePrice",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "SalePrice",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "SalePrice",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
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
                name: "FK_PurchaseInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceImageUrl",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                newName: "InvoiceImage");

            migrationBuilder.AlterColumn<decimal>(
                name: "TermAmount",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Paied",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalePrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "TabletSalePrice",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalePrice",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalePrice",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                column: "PharmacyId",
                principalSchema: "Pharmacy",
                principalTable: "Pharmacies",
                principalColumn: "Id");
        }
    }
}
