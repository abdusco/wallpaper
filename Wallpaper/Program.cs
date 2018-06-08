using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Wallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("No image path was given");
                return;
            }
            var imagePath = args[0];
            SetWallpaper(imagePath);
        }

        static void SetWallpaper(string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            if (!IsImage(imagePath))
            {
                Console.WriteLine("Not an image");
                return;
            }

            WallpaperApi.SetWallpaperUsingActiveDesktop(imagePath);
        }

        private static bool IsImage(string imagePath)
        {
            var imageExtensions = new string[] {".jpg", ".jpeg", ".png", ".bmp"};
            var ext = System.IO.Path.GetExtension(imagePath);
            return ext != null
                   && imageExtensions.Any(e => ext.ToLowerInvariant().Equals(ext));
        }
    }
}