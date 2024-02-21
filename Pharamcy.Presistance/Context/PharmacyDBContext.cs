using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharamcy.Domain.Identity;
using Pharamcy.Domain.Models;

namespace Pharamcy.Presistance.Context
{
    public class PharmacyDBContext : IdentityDbContext<ApplicationUser>
    {
        public PharmacyDBContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "Account");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "Account");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Account");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Account");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Account");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Account");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Account");

            modelBuilder.HasDefaultSchema("Pharmacy");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lost> Losts { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<MedicineReference> MedicinesReference { get; set; }

    }
}
