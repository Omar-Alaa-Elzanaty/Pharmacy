using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class EditSavePurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                schema: "Pharmacy",
                table: "MedicineTrackings");
        }
    }
}
