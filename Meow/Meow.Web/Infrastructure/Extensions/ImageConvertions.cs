namespace Meow.Web
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;
    using System.Net;

    public static class ImageConvertions
    {
        public static byte[] ImageToByteArray(IFormFile image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.CopyToAsync(memoryStream);

                return memoryStream.ToArray();
            }
        }

        public static string ByteArrayToImage(byte[] imageArray)
            => $"data:image/gif;base64,{Convert.ToBase64String(imageArray)}";

        public static byte[] ImagePathToArray(string path)
            => File.ReadAllBytes(path);

        public static byte[] ImageUrlToArray(string url)
        {
            var web = new WebClient();

            return web.DownloadData(url);
        }
    }
}