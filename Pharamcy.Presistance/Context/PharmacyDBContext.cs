using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pharamcy.Domain.Models;

namespace Pharamcy.Presistance.Context
{
    public class PharmacyDBContext:DbContext
    {
        public PharmacyDBContext(DbContextOptions options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Pharmacy>  Pharmacies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lost> Losts { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<Store> Stores { get; set; }

    }
}
