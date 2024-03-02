using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class IdentityandMedicine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropTable(
                name: "MedicinesReference",
                schema: "Pharmacy");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_PharmacyId",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "Medicines",
                newName: "NationalCode");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "Account",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PharmacyLogo",
                schema: "Pharmacy",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_PharmacyId",
                schema: "Pharmacy",
                table: "Stores",
                column: "PharmacyId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_PharmacyId",
                schema: "Pharmacy",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "Account",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PharmacyLogo",
                schema: "Pharmacy",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "NationalCode",
                schema: "Pharmacy",
                table: "Medicines",
                newName: "PharmacyId");

            migrationBuilder.CreateTable(
                name: "MedicinesReference",
                schema: "Pharmacy",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinesReference", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_PharmacyId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "PharmacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "PharmacyId",
                principalSchema: "Pharmacy",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
