using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class AddingPartitionMedicine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartitionMedicineTrackings_Medicines_PartitionMedicineId",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.CreateTable(
                name: "PartitionMedicine",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitionMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartitionMedicine_Medicines_Id",
                        column: x => x.Id,
                        principalSchema: "Pharmacy",
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PartitionMedicineTrackings_PartitionMedicine_PartitionMedicineId",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                column: "PartitionMedicineId",
                principalSchema: "Pharmacy",
                principalTable: "PartitionMedicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartitionMedicineTrackings_PartitionMedicine_PartitionMedicineId",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings");

            migrationBuilder.DropTable(
                name: "PartitionMedicine",
                schema: "Pharmacy");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PartitionMedicineTrackings_Medicines_PartitionMedicineId",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                column: "PartitionMedicineId",
                principalSchema: "Pharmacy",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
