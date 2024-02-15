using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;

namespace Pharamcy.Infrastructure.Services.Localization
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
       

        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocalizer();
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer();

        }
    }
}
