using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace BasketballScoreGraphics.Converters
{
    public class IntToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bytes = BitConverter.GetBytes((uint)value);
            return Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            return BitConverter.ToUInt32(new byte[] { color.B, color.G, color.R, color.A }, 0);
        }
    }
}
