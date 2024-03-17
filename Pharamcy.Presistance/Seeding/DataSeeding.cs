using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharamcy.Domain.Identity;
using Pharamcy.Presistance.Context;
using Pharamcy.Shared;

namespace Pharamcy.Presistance.Seeding
{
    public class DataSeeding
    {
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<PharmacyDBContext>();
            if (dbContext.Database.GetPendingMigrationsAsync().Result.Any())
            {
                dbContext.Database.MigrateAsync().Wait();

                var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

                var systemAdmin = new ApplicationUser()
                {
                    UserName = "System_admin",
                    PhoneNumber = "01123652462",
                    FirstName="MG",
                    LastName="Pharamcy",
                    NationalId="11111111",
                    Email = "test@test.com"
                };

                await userManager.CreateAsync(systemAdmin, "123@Abc");
                await userManager.AddToRoleAsync(systemAdmin, SystemRoles.SystemAdmin);
            }
        }
    }
}
