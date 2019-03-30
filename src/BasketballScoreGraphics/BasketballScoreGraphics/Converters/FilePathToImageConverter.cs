using BasketballScoreGraphics.Engine.Services.Implementation;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasketballScoreGraphics.Converters
{
    public class FilePathToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = (string)value;
            if (path != null)
            {
                var source = new BitmapImage();
                source.BeginInit();
                source.UriSource = new Uri(ConfigLoader.GetImagePath(path), UriKind.Absolute);
                source.EndInit();
                return source;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
