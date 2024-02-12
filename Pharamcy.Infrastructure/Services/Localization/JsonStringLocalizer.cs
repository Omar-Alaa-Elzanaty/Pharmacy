using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Pharamcy.Infrastructure.Services.Localization
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private readonly JsonSerializer? _serializer = new();
        private readonly IDistributedCache cache;

        public JsonStringLocalizer(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {

            get
            {
                var actualvalue = this[name];
                return !actualvalue.ResourceNotFound
                    ? new LocalizedString(name, string.Format(actualvalue.Value, arguments)
                    ) : actualvalue;
            }

        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader streamReader = new(stream);

            using JsonTextReader reader = new(streamReader);
            while (reader.Read())
            {
                if (reader.TokenType != JsonToken.PropertyName) continue;

                var key = reader.Value as string ?? "";

                reader.Read();

                var value = _serializer?.Deserialize<string>(reader);
                yield return new LocalizedString(key, value);

            }

        }
        private string GetString(string key)
        {
            //Resources/ar-EG.json
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";

            var fullFilePath = Path.GetFullPath(filePath);

            if (File.Exists(fullFilePath))
            {
                var cacheKey = $"local_{Thread.CurrentThread.CurrentCulture.Name}_{key}";
                var cacheValue = cache.GetString(cacheKey);
                if (!string.IsNullOrEmpty(cacheValue))
                {
                    return cacheValue;
                }
                var result = GetValueFromJson(key, fullFilePath);

                if (!string.IsNullOrEmpty(result))
                {
                    cache.SetString(cacheKey, result);
                }


                return result;

            }
            return string.Empty;
        }

        private string GetValueFromJson(string propertyName, string filePath)
        {
            if (string.IsNullOrEmpty(propertyName) ||
             string.IsNullOrEmpty(filePath))
                return string.Empty;

            using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader streamReader = new(stream);

            using JsonTextReader reader = new(streamReader);

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName && reader.Value as string == propertyName)
                {
                    reader.Read();

                    return _serializer?.Deserialize<string>(reader) ?? "";

                }

            }
            return string.Empty;
        }



    }
}
