using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class EditSaleInvoice2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "ClientName",
                schema: "Pharmacy",
                table: "SalesInvoices");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                column: "PharmacyId",
                principalSchema: "Pharmacy",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
