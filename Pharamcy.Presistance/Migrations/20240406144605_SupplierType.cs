using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class SupplierType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicalTypes_Name",
                schema: "Pharmacy",
                table: "MedicalTypes");

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                schema: "Pharmacy",
                table: "Suppliers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Pharmacy",
                table: "MedicalTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Pharmacy",
                table: "Suppliers");

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
    }
}
