﻿using System.Globalization;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Auth;
using Pharamcy.Application.Interfaces.Email;
using Pharamcy.Application.Interfaces.Media;
using Pharamcy.Infrastructure.Email;
using Pharamcy.Infrastructure.Media;
using Pharamcy.Infrastructure.Services.Auth;
using Pharamcy.Infrastructure.Services.Localization;

namespace Pharamcy.Infrastructure.Extention
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddLocalization()
                    .AddCollections();

            return services;
        }

        private static IServiceCollection AddLocalization(this IServiceCollection services)
        {
            LocalizationServiceCollectionExtensions.AddLocalization(services);


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
                 };
                op.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0]);

                op.SupportedCultures = supportedCultures;
            });

            return services;
        }

        private static IServiceCollection AddCollections(this IServiceCollection services)
        {
            services.AddTransient<IAuthServices, AuthServices>();
            services.AddTransient<IMediaService, MediaServices>();
            services.AddTransient<IEmailSerivce, EmailService>();
            return services;
        }
    }
}
