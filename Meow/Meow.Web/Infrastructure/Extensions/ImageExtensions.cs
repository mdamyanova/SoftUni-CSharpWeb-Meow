namespace Meow.Web
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;

    public static class ImageExtensions
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
        {
            return $"data:image/gif;base64,{Convert.ToBase64String(imageArray)}";
        }
    }
}