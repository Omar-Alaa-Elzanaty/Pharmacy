using Microsoft.EntityFrameworkCore;

namespace Pharamcy.Presistance.Context
{
    public class PharmacyDBContext:DbContext
    {
        public PharmacyDBContext(DbContextOptions options):base(options) { }    
        
    }
}
