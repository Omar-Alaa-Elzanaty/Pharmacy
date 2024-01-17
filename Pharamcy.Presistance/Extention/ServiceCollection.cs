using Microsoft.Extensions.DependencyInjection;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Presistance.Repositories;

namespace Pharamcy.Presistance.Extention
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddPresistance(this IServiceCollection services)
        {
            //services.AddDbContext<PharmacyDBContext>(
            //    op => op.UseSqlServer(configuration.GetConnectionString("constr")));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}
