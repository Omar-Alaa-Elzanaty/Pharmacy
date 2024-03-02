using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class updatetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Phamracy",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                schema: "Phamracy",
                table: "Pharmacies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArabicFooter",
                schema: "Phamracy",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArabicHeader",
                schema: "Phamracy",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnglishFooter",
                schema: "Phamracy",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnglishHeader",
                schema: "Phamracy",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Phamracy",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MedicinesReference",
                schema: "Phamracy",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinesReference", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_AdminId",
                schema: "Phamracy",
                table: "Pharmacies",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Users_AdminId",
                schema: "Phamracy",
                table: "Pharmacies",
                column: "AdminId",
                principalSchema: "Account",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Users_AdminId",
                schema: "Phamracy",
                table: "Pharmacies");

            migrationBuilder.DropTable(
                name: "MedicinesReference",
                schema: "Phamracy");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_AdminId",
                schema: "Phamracy",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Phamracy",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "AdminId",
                schema: "Phamracy",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "ArabicFooter",
                schema: "Phamracy",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "ArabicHeader",
                schema: "Phamracy",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "EnglishFooter",
                schema: "Phamracy",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "EnglishHeader",
                schema: "Phamracy",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Phamracy",
                table: "Pharmacies");
        }
    }
}
