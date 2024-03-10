using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicalCompaniesDefinition_InformationId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropTable(
                name: "MedicalCompanies",
                schema: "Pharmacy");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_InformationId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "TapeSalePrice",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings");

            migrationBuilder.DropColumn(
                name: "InformationId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "MedicinDefinitionId",
                schema: "Pharmacy",
                table: "Medicines",
                newName: "NationalCode");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatorName",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DiscountCostPrecent",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImportInvoiceNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Paied",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TermAmount",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "serialNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TabletsCount",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TapesCount",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ArabicName",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pharmacology",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                schema: "Pharmacy",
                table: "MedicalEffectiveMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                schema: "Pharmacy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreditLimit",
                schema: "Pharmacy",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Indebtedness",
                schema: "Pharmacy",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompany",
                schema: "Pharmacy",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LocalDiscount",
                schema: "Pharmacy",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Pharmacy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "OnlyCash",
                schema: "Pharmacy",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "Pharmacy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Relay",
                schema: "Pharmacy",
                table: "Clients",
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
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false),
                    shelf = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    InvoiceImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StripsCount = table.Column<int>(type: "int", nullable: false),
                    TaxiPrecent = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: false),
                    AdditionalDiscount = table.Column<int>(type: "int", nullable: false),
                    pharmaceuticalDiscount = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    ExpireDate = table.Column<DateOnly>(type: "date", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PharamcyId = table.Column<int>(type: "int", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "Pharmacy",
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "systemMedicalCompanies",
                schema: "Pharmacy",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemMedicalCompanies", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyFinanicalDues",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    FinancialDue = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "IX_MedicalEffectiveMaterials_MedicineId",
                schema: "Pharmacy",
                table: "MedicalEffectiveMaterials",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyFinanicalDues_SupplierId",
                schema: "Pharmacy",
                table: "PharmacyFinanicalDues",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PruchaseInvoiceItem_PurchaseInvoiceId",
                schema: "Pharmacy",
                table: "PruchaseInvoiceItem",
                column: "PurchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PharmacyId",
                schema: "Pharmacy",
                table: "Suppliers",
                column: "PharmacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalEffectiveMaterials_Medicines_MedicineId",
                schema: "Pharmacy",
                table: "MedicalEffectiveMaterials",
                column: "MedicineId",
                principalSchema: "Pharmacy",
                principalTable: "Medicines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalEffectiveMaterials_Medicines_MedicineId",
                schema: "Pharmacy",
                table: "MedicalEffectiveMaterials");

            migrationBuilder.DropTable(
                name: "PharmacyFinanicalDues",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PruchaseInvoiceItem",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "systemMedicalCompanies",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Pharmacy");

            migrationBuilder.DropIndex(
                name: "IX_MedicalEffectiveMaterials_MedicineId",
                schema: "Pharmacy",
                table: "MedicalEffectiveMaterials");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "CreatorName",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "DiscountCostPrecent",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "ImportInvoiceNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "Paied",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "TermAmount",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "serialNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "TabletsCount",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings");

            migrationBuilder.DropColumn(
                name: "TapesCount",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "MedicineTrackings");

            migrationBuilder.DropColumn(
                name: "ArabicName",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Pharmacology",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                schema: "Pharmacy",
                table: "MedicalEffectiveMaterials");

            migrationBuilder.DropColumn(
                name: "Adress",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreditLimit",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Indebtedness",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsCompany",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LocalDiscount",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "OnlyCash",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Relay",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "NationalCode",
                schema: "Pharmacy",
                table: "Medicines",
                newName: "MedicinDefinitionId");

            migrationBuilder.AddColumn<double>(
                name: "TapeSalePrice",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InformationId",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "Medicines",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "MedicalCompanies",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCompanies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_InformationId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "InformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCompanies_Name",
                schema: "Pharmacy",
                table: "MedicalCompanies",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicalCompaniesDefinition_InformationId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "InformationId",
                principalSchema: "Pharmacy",
                principalTable: "MedicalCompaniesDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
