using System;
using System.IO;
using System.Windows.Media;

namespace WanCeDesktopApp
{
    public class MaterialDesignFonts
    {
        public static FontFamily MiSans { get; }

        static MaterialDesignFonts()
        {
            var fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Fonts\MiSans\");
            MiSans = new FontFamily(new Uri($"file:///{fontPath}"), "./#MiSans");
        }
    }
}