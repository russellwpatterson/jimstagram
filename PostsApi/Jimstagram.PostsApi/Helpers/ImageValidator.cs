using System.Linq;
using System.Text;

namespace Jimstagram.PostsApi.Helpers
{
    public enum ImageFormat
    {
        BMP,
        JPEG,
        GIF,
        TIFF,
        PNG,
        Unknown
    }

    public static class ImageValidator
    {
        public static ImageFormat GetImageFormat(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");
            var gif = Encoding.ASCII.GetBytes("GIF");
            var png = new byte[] { 137, 80, 78, 71 };
            var tiff = new byte[] { 73, 73, 42 };
            var tiff2 = new byte[] { 77, 77, 42 };
            var jpeg = new byte[] { 255, 216, 255, 224 };
            var jpeg2 = new byte[] { 255, 216, 255, 225 };

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.BMP;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.GIF;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.PNG;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)) || tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.TIFF;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)) || jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.JPEG;

            return ImageFormat.Unknown;
        }
    }
}