using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class EditSaleInvoice3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Clients_ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Clients_ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                column: "ClientId",
                principalSchema: "Pharmacy",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Clients_ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
    }
}
