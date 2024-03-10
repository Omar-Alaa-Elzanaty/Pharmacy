using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class EditingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "serialNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "BuyPrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem");

            migrationBuilder.DropColumn(
                name: "InvoiceImage",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem");

            migrationBuilder.RenameColumn(
                name: "shelf",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "Shelf");

            migrationBuilder.RenameColumn(
                name: "pharmaceuticalDiscount",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "Taxis");

            migrationBuilder.RenameColumn(
                name: "TaxiPrecent",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "Taps");

            migrationBuilder.RenameColumn(
                name: "StripsCount",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "Tablets");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "Bonse");

            migrationBuilder.RenameColumn(
                name: "Bonus",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "BaseDiscount");

            migrationBuilder.RenameColumn(
                name: "TapesCount",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                newName: "Taps");

            migrationBuilder.RenameColumn(
                name: "TabletsCount",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                newName: "TabletsAvailableAmount");

            migrationBuilder.RenameColumn(
                name: "Amount",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                newName: "Tablets");

            migrationBuilder.RenameColumn(
                name: "StroageRack",
                schema: "Pharmacy",
                table: "Medicines",
                newName: "StorageRack");

            migrationBuilder.AlterColumn<decimal>(
                name: "TermAmount",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Paied",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceImage",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SalePrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AlterColumn<int>(
                name: "Offer",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "BuyDiscount",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceImage",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings");

            migrationBuilder.RenameColumn(
                name: "Shelf",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "shelf");

            migrationBuilder.RenameColumn(
                name: "Taxis",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "pharmaceuticalDiscount");

            migrationBuilder.RenameColumn(
                name: "Taps",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "TaxiPrecent");

            migrationBuilder.RenameColumn(
                name: "Tablets",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "StripsCount");

            migrationBuilder.RenameColumn(
                name: "Bonse",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "BaseDiscount",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                newName: "Bonus");

            migrationBuilder.RenameColumn(
                name: "Taps",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                newName: "TapesCount");

            migrationBuilder.RenameColumn(
                name: "TabletsAvailableAmount",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                newName: "TabletsCount");

            migrationBuilder.RenameColumn(
                name: "Tablets",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "StorageRack",
                schema: "Pharmacy",
                table: "Medicines",
                newName: "StroageRack");

            migrationBuilder.AlterColumn<double>(
                name: "TermAmount",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Paied",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "serialNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<double>(
                name: "BuyPrice",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceImage",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AlterColumn<double>(
                name: "Offer",
                schema: "Pharmacy",
                table: "Medicines",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "BuyDiscount",
                schema: "Pharmacy",
                table: "Medicines",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
