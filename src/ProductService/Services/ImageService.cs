
using System.Text.Json;

namespace ProductService.Services
{
    public class ImageService : IImageService
    {
        private readonly string apikey = "a7f1653f6cdfcc6101c011044eaf8a9b";

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var base64 = Convert.ToBase64String(ms.ToArray());

            using var client = new HttpClient();
            var form = new MultipartFormDataContent
            {
                { new StringContent(base64), "image" }
            };

            // TO‘G‘RI URL
            var url = $"https://api.imgbb.com/1/upload?key={apikey}";

            var response = await client.PostAsync(url, form);
            var json = await response.Content.ReadAsStringAsync();

            // JSON-ni to‘g‘ri o‘qish
            using var doc = JsonDocument.Parse(json);

            var root = doc.RootElement;
            var data = root.GetProperty("data");
            var imageUrl = data.GetProperty("url").GetString();

            return imageUrl!;

        }
    }
}
