using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Presistance.Context;
using Pharamcy.Presistance.Repositories;

namespace Pharamcy.Presistance.Extention
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddPresistance(this IServiceCollection services,ConfigurationManager configuration)
        {
            services.AddDbContext<PharmacyDBContext>(
                op => op.UseSqlServer(configuration.GetConnectionString("constr")));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}
