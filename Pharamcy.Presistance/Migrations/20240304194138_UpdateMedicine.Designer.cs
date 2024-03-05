﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pharamcy.Presistance.Context;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    [DbContext(typeof(PharmacyDBContext))]
    [Migration("20240304194138_UpdateMedicine")]
    partial class UpdateMedicine
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Pharmacy")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicalEffectiveMaterialMedicineDefinition", b =>
                {
                    b.Property<int>("EffectiveMaterialsId")
                        .HasColumnType("int");

                    b.Property<int>("MedicinesId")
                        .HasColumnType("int");

                    b.HasKey("EffectiveMaterialsId", "MedicinesId");

                    b.HasIndex("MedicinesId");

                    b.ToTable("MedicalEffectiveMaterialMedicineDefinition", "Pharmacy");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", "Account");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Account");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Account");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Account");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Account");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Account");
                });

            modelBuilder.Entity("Pharamcy.Domain.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "Account");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PharmacyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyId");

                    b.ToTable("Clients", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Lost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PharmacyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyId");

                    b.ToTable("Losts", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.MedicalCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MedicalCompanies", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.MedicalEffectiveMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MedicalEffectiveMaterials", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.MedicalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MedicalTypes", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AllowToPrint")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowToSale")
                        .HasColumnType("bit");

                    b.Property<double>("BuyDiscount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DefaultSale")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int>("InformationId")
                        .HasColumnType("int");

                    b.Property<int>("MaximumAmount")
                        .HasColumnType("int");

                    b.Property<int>("MedicinDefinitionId")
                        .HasColumnType("int");

                    b.Property<string>("MessageDuringSale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinimumAmount")
                        .HasColumnType("int");

                    b.Property<double>("Offer")
                        .HasColumnType("float");

                    b.Property<int>("OfferCount")
                        .HasColumnType("int");

                    b.Property<int>("PharmacyId")
                        .HasColumnType("int");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("money");

                    b.Property<int>("Reflux")
                        .HasColumnType("int");

                    b.Property<int?>("ShortCode")
                        .HasColumnType("int");

                    b.Property<double>("StorageTemperature")
                        .HasColumnType("float");

                    b.Property<string>("StroageRack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InformationId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("Medicines", "Pharmacy");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Medicine");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.MedicineDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalCode")
                        .HasColumnType("int");

                    b.Property<string>("Pharmacology")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicalCompaniesDefinition", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.MedicineTracking", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("MedicineId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("BarCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("SalePrice")
                        .HasColumnType("float");

                    b.HasKey("Id", "MedicineId");

                    b.HasIndex("MedicineId");

                    b.ToTable("MedicineTrackings", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.PartitionMedicineTracking", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("PartitionMedicineId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("BarCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("SalePrice")
                        .HasColumnType("float");

                    b.Property<double>("TabletSalePrice")
                        .HasColumnType("float");

                    b.Property<double?>("TapeSalePrice")
                        .HasColumnType("float");

                    b.HasKey("Id", "PartitionMedicineId");

                    b.HasIndex("PartitionMedicineId");

                    b.ToTable("PartitionMedicineTrackings", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Pharmacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArabicFooter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArabicHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnglishFooter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PharmacyLogo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Pharmacies", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.PurchaseInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PharmacyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyId");

                    b.ToTable("PurchaseInvoices", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.SalesInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PharmacyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyId");

                    b.ToTable("SalesInvoices", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.ToTable("Stores", "Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.PartitionMedicine", b =>
                {
                    b.HasBaseType("Pharamcy.Domain.Models.Medicine");

                    b.HasDiscriminator().HasValue("PartitionMedicine");
                });

            modelBuilder.Entity("MedicalEffectiveMaterialMedicineDefinition", b =>
                {
                    b.HasOne("Pharamcy.Domain.Models.MedicalEffectiveMaterial", null)
                        .WithMany()
                        .HasForeignKey("EffectiveMaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pharamcy.Domain.Models.MedicineDefinition", null)
                        .WithMany()
                        .HasForeignKey("MedicinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Pharamcy.Domain.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Pharamcy.Domain.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pharamcy.Domain.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Pharamcy.Domain.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Client", b =>
                {
                    b.HasOne("Pharamcy.Domain.Models.Pharmacy", null)
                        .WithMany("Clients")
                        .HasForeignKey("PharmacyId");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Lost", b =>
                {
                    b.HasOne("Pharamcy.Domain.Models.Pharmacy", null)
                        .WithMany("LostProfits")
                        .HasForeignKey("PharmacyId");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Medicine", b =>
                {
                    b.HasOne("Pharamcy.Domain.Models.MedicineDefinition", "Information")
                        .WithMany()
                        .HasForeignKey("InformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pharamcy.Domain.Models.Pharmacy", "Pharmacy")
                        .WithMany()
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Information");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.MedicineTracking", b =>
                {
                    b.HasOne("Pharamcy.Domain.Models.Medicine", null)
                        .WithMany("Tracking")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.PartitionMedicineTracking", b =>
                {
                    b.HasOne("Pharamcy.Domain.Models.PartitionMedicine", null)
                        .WithMany("PartitionMedicineTrackings")
                        .HasForeignKey("PartitionMedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Pharmacy", b =>
                {
                    b.HasOne("Pharamcy.Domain.Identity.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.PurchaseInvoice", b =>
                {
                    b.HasOne("Pharamcy.Domain.Models.Pharmacy", null)
                        .WithMany("PurchaseInvoices")
                        .HasForeignKey("PharmacyId");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.SalesInvoice", b =>
                {
                    b.HasOne("Pharamcy.Domain.Models.Pharmacy", null)
                        .WithMany("SalesInvoices")
                        .HasForeignKey("PharmacyId");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Store", b =>
                {
                    b.HasOne("Pharamcy.Domain.Models.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicine");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Medicine", b =>
                {
                    b.Navigation("Tracking");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.Pharmacy", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("LostProfits");

                    b.Navigation("PurchaseInvoices");

                    b.Navigation("SalesInvoices");
                });

            modelBuilder.Entity("Pharamcy.Domain.Models.PartitionMedicine", b =>
                {
                    b.Navigation("PartitionMedicineTrackings");
                });
#pragma warning restore 612, 618
        }
    }
}
