using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;

namespace Pharamcy.Infrastructure.Services.Localization
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IWebHostEnvironment _host;
        private readonly IConfiguration _configuration;
        public JsonStringLocalizerFactory(
            IWebHostEnvironment host,
            IConfiguration configuration)
        {
            _host = host;
            _configuration = configuration;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocalizer(_host,_configuration);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer(_host, _configuration);

        }
    }
}
