namespace Meow.Web
{
    using System;

    public class ImageExtensions
    {
        //public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

        //    return ms.ToArray();
        //}

        public string ByteArrayToImage(byte[] imageArray)
        {
            return $"data:image/gif;base64,{Convert.ToBase64String(imageArray)}";
        }
    }
}