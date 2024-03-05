using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMedicine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Users_AdminId",
                schema: "Pharmacy",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_PharmacyId",
                schema: "Pharmacy",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                schema: "Pharmacy",
                table: "Pharmacies",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_AdminId",
                schema: "Pharmacy",
                table: "Pharmacies",
                newName: "IX_Pharmacies_OwnerId");

            migrationBuilder.RenameColumn(
                name: "NationalCode",
                schema: "Pharmacy",
                table: "Medicines",
                newName: "Reflux");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Pharmacy",
                table: "Medicines",
                newName: "StroageRack");

            migrationBuilder.AddColumn<bool>(
                name: "AllowToPrint",
                schema: "Pharmacy",
                table: "Medicines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowToSale",
                schema: "Pharmacy",
                table: "Medicines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "BuyDiscount",
                schema: "Pharmacy",
                table: "Medicines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DefaultSale",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InformationId",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaximumAmount",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicinDefinitionId",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MessageDuringSale",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MinimumAmount",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Offer",
                schema: "Pharmacy",
                table: "Medicines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "OfferCount",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PharmacyId",
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

            migrationBuilder.AddColumn<int>(
                name: "ShortCode",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StorageTemperature",
                schema: "Pharmacy",
                table: "Medicines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "MedicalCompanies",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCompaniesDefinition",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pharmacology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCompaniesDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalEffectiveMaterials",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalEffectiveMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalTypes",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTrackings",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTrackings", x => new { x.Id, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_MedicineTrackings_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalSchema: "Pharmacy",
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartitionMedicineTrackings",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PartitionMedicineId = table.Column<int>(type: "int", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    TabletSalePrice = table.Column<double>(type: "float", nullable: false),
                    TapeSalePrice = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitionMedicineTrackings", x => new { x.Id, x.PartitionMedicineId });
                    table.ForeignKey(
                        name: "FK_PartitionMedicineTrackings_Medicines_PartitionMedicineId",
                        column: x => x.PartitionMedicineId,
                        principalSchema: "Pharmacy",
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalEffectiveMaterialMedicineDefinition",
                schema: "Pharmacy",
                columns: table => new
                {
                    EffectiveMaterialsId = table.Column<int>(type: "int", nullable: false),
                    MedicinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalEffectiveMaterialMedicineDefinition", x => new { x.EffectiveMaterialsId, x.MedicinesId });
                    table.ForeignKey(
                        name: "FK_MedicalEffectiveMaterialMedicineDefinition_MedicalCompaniesDefinition_MedicinesId",
                        column: x => x.MedicinesId,
                        principalSchema: "Pharmacy",
                        principalTable: "MedicalCompaniesDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalEffectiveMaterialMedicineDefinition_MedicalEffectiveMaterials_EffectiveMaterialsId",
                        column: x => x.EffectiveMaterialsId,
                        principalSchema: "Pharmacy",
                        principalTable: "MedicalEffectiveMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_InformationId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "InformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_PharmacyId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCompanies_Name",
                schema: "Pharmacy",
                table: "MedicalCompanies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalEffectiveMaterialMedicineDefinition_MedicinesId",
                schema: "Pharmacy",
                table: "MedicalEffectiveMaterialMedicineDefinition",
                column: "MedicinesId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTypes_Name",
                schema: "Pharmacy",
                table: "MedicalTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTrackings_MedicineId",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionMedicineTrackings_PartitionMedicineId",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                column: "PartitionMedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicalCompaniesDefinition_InformationId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "InformationId",
                principalSchema: "Pharmacy",
                principalTable: "MedicalCompaniesDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "PharmacyId",
                principalSchema: "Pharmacy",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Users_OwnerId",
                schema: "Pharmacy",
                table: "Pharmacies",
                column: "OwnerId",
                principalSchema: "Account",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicalCompaniesDefinition_InformationId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Users_OwnerId",
                schema: "Pharmacy",
                table: "Pharmacies");

            migrationBuilder.DropTable(
                name: "MedicalCompanies",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "MedicalEffectiveMaterialMedicineDefinition",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "MedicalTypes",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "MedicineTrackings",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PartitionMedicineTrackings",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "MedicalCompaniesDefinition",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "MedicalEffectiveMaterials",
                schema: "Pharmacy");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_InformationId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_PharmacyId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "AllowToPrint",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "AllowToSale",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "BuyDiscount",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "DefaultSale",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "InformationId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MaximumAmount",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MedicinDefinitionId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MessageDuringSale",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MinimumAmount",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Offer",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "OfferCount",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ShortCode",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "StorageTemperature",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                schema: "Pharmacy",
                table: "Pharmacies",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_OwnerId",
                schema: "Pharmacy",
                table: "Pharmacies",
                newName: "IX_Pharmacies_AdminId");

            migrationBuilder.RenameColumn(
                name: "StroageRack",
                schema: "Pharmacy",
                table: "Medicines",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Reflux",
                schema: "Pharmacy",
                table: "Medicines",
                newName: "NationalCode");

            migrationBuilder.AddColumn<int>(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_PharmacyId",
                schema: "Pharmacy",
                table: "Stores",
                column: "PharmacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Users_AdminId",
                schema: "Pharmacy",
                table: "Pharmacies",
                column: "AdminId",
                principalSchema: "Account",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Stores",
                column: "PharmacyId",
                principalSchema: "Pharmacy",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
