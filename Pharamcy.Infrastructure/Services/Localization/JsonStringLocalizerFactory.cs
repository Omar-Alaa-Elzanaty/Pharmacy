﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;

namespace Pharamcy.Infrastructure.Services.Localization
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IConfiguration _configuration;
        public JsonStringLocalizerFactory(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocalizer(_configuration);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer(_configuration);

        }
    }
}
