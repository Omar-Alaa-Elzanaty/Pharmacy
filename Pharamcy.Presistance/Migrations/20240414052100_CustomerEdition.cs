using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class CustomerEdition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Relay",
                schema: "Pharmacy",
                table: "Clients",
                newName: "TotalPoints");

            migrationBuilder.RenameColumn(
                name: "Indebtedness",
                schema: "Pharmacy",
                table: "Clients",
                newName: "PointsForCurrency");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastProcess",
                schema: "Pharmacy",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastProcess",
                schema: "Pharmacy",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "TotalPoints",
                schema: "Pharmacy",
                table: "Clients",
                newName: "Relay");

            migrationBuilder.RenameColumn(
                name: "PointsForCurrency",
                schema: "Pharmacy",
                table: "Clients",
                newName: "Indebtedness");
        }
    }
}
