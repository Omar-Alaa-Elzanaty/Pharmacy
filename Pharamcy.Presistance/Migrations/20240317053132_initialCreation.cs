using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class initialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pharmacy");

            migrationBuilder.EnsureSchema(
                name: "Account");

            migrationBuilder.CreateTable(
                name: "MedicalTypes",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineDefinitions",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pharmacology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDefinitions", x => x.Id);
                });

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
                name: "systemMedicalCompanies",
                schema: "Pharmacy",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemMedicalCompanies", x => x.Name);
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
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Pharmacies",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicFooter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishFooter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PharmacyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pharmacies_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Account",
                        principalTable: "Users",
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

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indebtedness = table.Column<int>(type: "int", nullable: false),
                    LocalDiscount = table.Column<int>(type: "int", nullable: false),
                    CreditLimit = table.Column<int>(type: "int", nullable: false),
                    IsCompany = table.Column<bool>(type: "bit", nullable: false),
                    OnlyCash = table.Column<bool>(type: "bit", nullable: false),
                    Relay = table.Column<int>(type: "int", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "Pharmacy",
                        principalTable: "Pharmacies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Losts",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Losts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Losts_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "Pharmacy",
                        principalTable: "Pharmacies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pharmacology = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<int>(type: "int", nullable: false),
                    ShortCode = table.Column<int>(type: "int", nullable: true),
                    AllowToPrint = table.Column<bool>(type: "bit", nullable: false),
                    AllowToSale = table.Column<bool>(type: "bit", nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageTemperature = table.Column<double>(type: "float", nullable: false),
                    MinimumAmount = table.Column<int>(type: "int", nullable: true),
                    MaximumAmount = table.Column<int>(type: "int", nullable: true),
                    BuyDiscount = table.Column<int>(type: "int", nullable: true),
                    Reflux = table.Column<int>(type: "int", nullable: true),
                    OfferCount = table.Column<int>(type: "int", nullable: true),
                    Offer = table.Column<int>(type: "int", nullable: true),
                    DefaultSale = table.Column<int>(type: "int", nullable: true),
                    MessageDuringSale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPartationing = table.Column<bool>(type: "bit", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "Pharmacy",
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartitionMedicine",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pharmacology = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<int>(type: "int", nullable: false),
                    ShortCode = table.Column<int>(type: "int", nullable: true),
                    AllowToPrint = table.Column<bool>(type: "bit", nullable: false),
                    AllowToSale = table.Column<bool>(type: "bit", nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageTemperature = table.Column<double>(type: "float", nullable: false),
                    MinimumAmount = table.Column<int>(type: "int", nullable: true),
                    MaximumAmount = table.Column<int>(type: "int", nullable: true),
                    BuyDiscount = table.Column<int>(type: "int", nullable: true),
                    Reflux = table.Column<int>(type: "int", nullable: true),
                    OfferCount = table.Column<int>(type: "int", nullable: true),
                    Offer = table.Column<int>(type: "int", nullable: true),
                    DefaultSale = table.Column<int>(type: "int", nullable: true),
                    MessageDuringSale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPartationing = table.Column<bool>(type: "bit", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitionMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartitionMedicine_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "Pharmacy",
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoices",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    ImportInvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountCostPrecent = table.Column<int>(type: "int", nullable: false),
                    TermAmount = table.Column<double>(type: "float", nullable: false),
                    Paied = table.Column<double>(type: "float", nullable: false),
                    CreatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PharmacyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "Pharmacy",
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoices",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "Pharmacy",
                        principalTable: "Pharmacies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinancialDue = table.Column<double>(type: "float", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalSchema: "Pharmacy",
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTrackings",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTrackings", x => new { x.Id, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_MedicineTrackings_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalSchema: "Pharmacy",
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalEffectiveMaterials",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: true),
                    PartitionMedicineId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalEffectiveMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalEffectiveMaterials_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalSchema: "Pharmacy",
                        principalTable: "Medicines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalEffectiveMaterials_PartitionMedicine_PartitionMedicineId",
                        column: x => x.PartitionMedicineId,
                        principalSchema: "Pharmacy",
                        principalTable: "PartitionMedicine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartitionMedicineTrackings",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PartitionMedicineId = table.Column<int>(type: "int", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    Taps = table.Column<int>(type: "int", nullable: false),
                    Tablets = table.Column<int>(type: "int", nullable: false),
                    TabletsAvailableAmount = table.Column<int>(type: "int", nullable: false),
                    TabletSalePrice = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitionMedicineTrackings", x => new { x.Id, x.PartitionMedicineId });
                    table.ForeignKey(
                        name: "FK_PartitionMedicineTrackings_PartitionMedicine_PartitionMedicineId",
                        column: x => x.PartitionMedicineId,
                        principalSchema: "Pharmacy",
                        principalTable: "PartitionMedicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceItem",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Bonse = table.Column<int>(type: "int", nullable: false),
                    Shelf = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Taps = table.Column<int>(type: "int", nullable: false),
                    Tablets = table.Column<int>(type: "int", nullable: false),
                    Taxis = table.Column<int>(type: "int", nullable: false),
                    AdditionalDiscount = table.Column<int>(type: "int", nullable: false),
                    BaseDiscount = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    ExpireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TabletSalePrice = table.Column<double>(type: "float", nullable: false),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceItem_PurchaseInvoices_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalSchema: "Pharmacy",
                        principalTable: "PurchaseInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceItems",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceItems_SalesInvoices_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Pharmacy",
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalEffectiveMaterialMedicineDefinition",
                schema: "Pharmacy",
                columns: table => new
                {
                    EffectiveMaterialsId = table.Column<int>(type: "int", nullable: false),
                    MedicinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalEffectiveMaterialMedicineDefinition", x => new { x.EffectiveMaterialsId, x.MedicinesId });
                    table.ForeignKey(
                        name: "FK_MedicalEffectiveMaterialMedicineDefinition_MedicalEffectiveMaterials_EffectiveMaterialsId",
                        column: x => x.EffectiveMaterialsId,
                        principalSchema: "Pharmacy",
                        principalTable: "MedicalEffectiveMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalEffectiveMaterialMedicineDefinition_MedicineDefinitions_MedicinesId",
                        column: x => x.MedicinesId,
                        principalSchema: "Pharmacy",
                        principalTable: "MedicineDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PharmacyId",
                schema: "Pharmacy",
                table: "Clients",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Losts_PharmacyId",
                schema: "Pharmacy",
                table: "Losts",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalEffectiveMaterialMedicineDefinition_MedicinesId",
                schema: "Pharmacy",
                table: "MedicalEffectiveMaterialMedicineDefinition",
                column: "MedicinesId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalEffectiveMaterials_MedicineId",
                schema: "Pharmacy",
                table: "MedicalEffectiveMaterials",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalEffectiveMaterials_PartitionMedicineId",
                schema: "Pharmacy",
                table: "MedicalEffectiveMaterials",
                column: "PartitionMedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalTypes_Name",
                schema: "Pharmacy",
                table: "MedicalTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_PharmacyId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTrackings_MedicineId",
                schema: "Pharmacy",
                table: "MedicineTrackings",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionMedicine_PharmacyId",
                schema: "Pharmacy",
                table: "PartitionMedicine",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionMedicineTrackings_PartitionMedicineId",
                schema: "Pharmacy",
                table: "PartitionMedicineTrackings",
                column: "PartitionMedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_OwnerId",
                schema: "Pharmacy",
                table: "Pharmacies",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceItem_PurchaseInvoiceId",
                schema: "Pharmacy",
                table: "PurchaseInvoiceItem",
                column: "PurchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_PharmacyId",
                schema: "Pharmacy",
                table: "PurchaseInvoices",
                column: "PharmacyId");

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
                name: "IX_SalesInvoiceItems_SalesInvoiceId",
                schema: "Pharmacy",
                table: "SalesInvoiceItems",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_PharmacyId",
                schema: "Pharmacy",
                table: "SalesInvoices",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PharmacyId",
                schema: "Pharmacy",
                table: "Suppliers",
                column: "PharmacyId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Losts",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "MedicalEffectiveMaterialMedicineDefinition",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "MedicalTypes",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "MedicineTrackings",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PartitionMedicineTrackings",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PurchaseInvoiceItem",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "SalesInvoiceItems",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "systemMedicalCompanies",
                schema: "Pharmacy");

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
                name: "MedicalEffectiveMaterials",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "MedicineDefinitions",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PurchaseInvoices",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "SalesInvoices",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Medicines",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PartitionMedicine",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Pharmacies",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Account");
        }
    }
}
