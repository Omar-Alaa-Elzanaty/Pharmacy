using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Identity;
using Pharamcy.Presistance.Context;
using Pharamcy.Presistance.Repositories;
using Pharamcy.Application.Interfaces;
using Pharamcy.Presistance.Seeding;

namespace Pharamcy.Presistance.Extention
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddPresistance(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddContext(configuration)
                    .AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                    .AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("constr");

            services.AddDbContext<PharmacyDBContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(PharmacyDBContext).Assembly.FullName)));
            // Identity configuration
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<PharmacyDBContext>()
                    .AddUserManager<UserManager<ApplicationUser>>()
                    .AddSignInManager<SignInManager<ApplicationUser>>()
                    .AddDefaultTokenProviders();
            

            return services;
        }
    }
}
