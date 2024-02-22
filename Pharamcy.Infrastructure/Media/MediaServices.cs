using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Pharamcy.Application.Interfaces.Media;

namespace Pharamcy.Infrastructure.Media
{
    public class MediaServices : IMediaService
    {
        private readonly IWebHostEnvironment _host;

        //private readonly IHttpContextAccessor _contextAccessor;
        //private readonly StringBuilder _defaultPath;

        public MediaServices(
            IWebHostEnvironment host,
            IConfiguration configuration)
        {
            _host = host;
            //_contextAccessor = contextAccessor;
            //_defaultPath = new StringBuilder(@$"{contextAccessor.HttpContext?.Request.Scheme}://{contextAccessor?.HttpContext?.Request.Host}/FOLDER/");
        }

        public async Task DeleteAsync(string url)
        {
            string rootPath = $"{_host.WebRootPath}\\Images";

            var mediaNameToDelete = Path.GetFileNameWithoutExtension(url);
            var ext = Path.GetExtension(url);
            string oldPath = $@"{rootPath}\{mediaNameToDelete + ext}";

            if (File.Exists(oldPath))
            {
                File.Delete(oldPath);
            }

            await Task.CompletedTask;
        }

        public async Task<string> SaveAsync(IFormFile media)
        {
            string rootPath = $"{_host.WebRootPath}\\Images";

            string file = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(media.FileName);
            string mediaFolderPath = Path.Combine(rootPath, file + extension);

            using (Stream fileStreams = new FileStream(mediaFolderPath, FileMode.Create))
            {
                media.CopyTo(fileStreams);
                fileStreams.Flush();
                fileStreams.Dispose();
            }
            await Task.CompletedTask;
            return mediaFolderPath;
        }

        public async Task<string> UpdateAsync(string oldUrl, IFormFile newMedia)
        {
            await DeleteAsync(oldUrl);
            return await SaveAsync(newMedia);
        }

    }
}
