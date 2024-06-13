using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace FinalProject.Business.Helper
{
    public static class ImageHelper
    {
        // Resizing keeps aspect ration so if file is not square it will take
        // Bigger side gets scaled down and smaller side gets value that is set by user
        public static byte[] Resize(byte[] imageData, int width, int height)
        {
            using MemoryStream inStream = new(imageData);
            using Image<Rgba32> imgSharp = Image.Load<Rgba32>(inStream);
            int newWidth, newHeight;

            if (imgSharp.Width < imgSharp.Height)
            {
                newWidth = width;
                newHeight = (int)((double)imgSharp.Height / imgSharp.Width * width);
            }
            else
            {
                newWidth = (int)((double)imgSharp.Width / imgSharp.Height * height);
                newHeight = height;
            }

            imgSharp.Mutate(x => x.Resize(newWidth, newHeight));

            using MemoryStream outStream = new();
            imgSharp.SaveAsJpeg(outStream);
            return outStream.ToArray();
        }
    }
}