using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class addIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Pharmacies_pharmacyId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Pharmacies_PId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_PId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PId",
                table: "Medicines");

            migrationBuilder.EnsureSchema(
                name: "Phamracy");

            migrationBuilder.EnsureSchema(
                name: "Account");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Stores",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "SalesInvoices",
                newName: "SalesInvoices",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "PurchaseInvoices",
                newName: "PurchaseInvoices",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "Pharmacies",
                newName: "Pharmacies",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "Medicines",
                newName: "Medicines",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "Losts",
                newName: "Losts",
                newSchema: "Phamracy");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Clients",
                newSchema: "Phamracy");

            migrationBuilder.RenameColumn(
                name: "pharmacyId",
                schema: "Phamracy",
                table: "Medicines",
                newName: "PharmacyId");

            migrationBuilder.RenameIndex(
                name: "IX_Medicines_pharmacyId",
                schema: "Phamracy",
                table: "Medicines",
                newName: "IX_Medicines_PharmacyId");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Account",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Account",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Account",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Account",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Account",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Account",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Account",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Account",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Account",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Account",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Account",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Account",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Pharmacies_PharmacyId",
                schema: "Phamracy",
                table: "Medicines",
                column: "PharmacyId",
                principalSchema: "Phamracy",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Pharmacies_PharmacyId",
                schema: "Phamracy",
                table: "Medicines");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Account");

            migrationBuilder.RenameTable(
                name: "Stores",
                schema: "Phamracy",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "SalesInvoices",
                schema: "Phamracy",
                newName: "SalesInvoices");

            migrationBuilder.RenameTable(
                name: "PurchaseInvoices",
                schema: "Phamracy",
                newName: "PurchaseInvoices");

            migrationBuilder.RenameTable(
                name: "Pharmacies",
                schema: "Phamracy",
                newName: "Pharmacies");

            migrationBuilder.RenameTable(
                name: "Medicines",
                schema: "Phamracy",
                newName: "Medicines");

            migrationBuilder.RenameTable(
                name: "Losts",
                schema: "Phamracy",
                newName: "Losts");

            migrationBuilder.RenameTable(
                name: "Clients",
                schema: "Phamracy",
                newName: "Clients");

            migrationBuilder.RenameColumn(
                name: "PharmacyId",
                table: "Medicines",
                newName: "pharmacyId");

            migrationBuilder.RenameIndex(
                name: "IX_Medicines_PharmacyId",
                table: "Medicines",
                newName: "IX_Medicines_pharmacyId");

            migrationBuilder.AddColumn<int>(
                name: "PId",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PId",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_PId",
                table: "Stores",
                column: "PId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Pharmacies_pharmacyId",
                table: "Medicines",
                column: "pharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Pharmacies_PId",
                table: "Stores",
                column: "PId",
                principalTable: "Pharmacies",
                principalColumn: "Id");
        }
    }
}
