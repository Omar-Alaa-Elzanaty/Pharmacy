using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class UniqueInvoiceNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImportInvoiceNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Pharmacy",
                table: "MedicalTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTypes_Name",
                schema: "Pharmacy",
                table: "MedicalTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicalTypes_Name",
                schema: "Pharmacy",
                table: "MedicalTypes");

            migrationBuilder.DropColumn(
                name: "ImportInvoiceNumber",
                schema: "Pharmacy",
                table: "PurchaseInvoices");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Pharmacy",
                table: "MedicalTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
