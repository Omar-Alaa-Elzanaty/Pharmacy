using Microsoft.EntityFrameworkCore;
using Pharamcy.Domain.Models;

namespace Pharamcy.Presistance.Context
{
    public class PharmacyDBContext:DbContext
    {
        public PharmacyDBContext(DbContextOptions options):base(options) { }
        public DbSet<Pharmacy>  Pharmacies { get; set; }

    }
}
