using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class EditClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                column: "ClientId");

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

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Pharmacies_PharmacyId",
                schema: "Pharmacy",
                table: "Clients",
                column: "PharmacyId",
                principalSchema: "Pharmacy",
                principalTable: "Pharmacies",
                principalColumn: "Id");
        }
    }
}
