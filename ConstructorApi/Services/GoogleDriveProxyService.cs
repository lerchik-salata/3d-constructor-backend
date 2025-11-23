using System.Collections.Concurrent;
using System.Diagnostics;

namespace ConstructorApi.Services
{
    public class GoogleDriveProxyService : IGoogleDriveService
    {
        private readonly IGoogleDriveService _realService;
        private readonly ConcurrentDictionary<string, byte[]> _cache = new();

        public GoogleDriveProxyService(IGoogleDriveService realService)
        {
            _realService = realService;
        }

        public async Task<Stream> DownloadFileStreamAsync(string fileId)
        {
            Console.WriteLine($"[LOG] Download request: {fileId}");

            if (_cache.TryGetValue(fileId, out var cachedData))
            {
                Console.WriteLine($"[LOG] Cache hit for fileId: {fileId}");
                return new MemoryStream(cachedData);
            }

            Console.WriteLine($"[LOG] Cache miss for fileId: {fileId}, fetching from Drive");
            var stream = await _realService.DownloadFileStreamAsync(fileId);

            if (stream != null)
            {
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                var data = ms.ToArray();
                _cache[fileId] = data;
                return new MemoryStream(data);
            }

            return null;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            Console.WriteLine($"[LOG] Upload request: {file.FileName}");
            var url = await _realService.UploadFileAsync(file);
            return url;
        }
    }
}
