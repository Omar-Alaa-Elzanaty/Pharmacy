using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pharamcy.Application.extention
{
    public static class ServiceCollectionExtentention
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMapping().AddMediator();

            return services;
        }
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);

            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
        private static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }

    }
}
