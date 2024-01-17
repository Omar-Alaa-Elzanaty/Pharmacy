using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Pharamcy.Infrastructure.Extention
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Localization();
              

            return services;    
        }
       
        private static IServiceCollection Localization(this IServiceCollection services)
        {
            services.AddLocalization();

            services.AddDistributedMemoryCache();

            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

            services.AddMvc().AddDataAnnotationsLocalization(op =>
            {
                op.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(JsonStringLocalizerFactory));
            }
             );

            services.Configure<RequestLocalizationOptions>(op =>
            {
                var supportedCultures = new[] {
                  new CultureInfo("en-US"),
                  new CultureInfo("ar-EG"),
                  new CultureInfo("de-DE")
                 };
                op.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0]);

                op.SupportedCultures = supportedCultures;
            });

            return services;
        }
    }
}
