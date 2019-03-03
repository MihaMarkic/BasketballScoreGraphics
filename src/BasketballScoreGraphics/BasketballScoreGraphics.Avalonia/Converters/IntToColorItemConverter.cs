using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace BasketballScoreGraphics.Avalonia.Converters
{
    public class IntToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            uint color = (uint)value;
            return ColorItem.ItemByColor(color).Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var colorItem = (ColorItem)value;
            return colorItem?.Color.ToUint32() ?? 0;
        }
    }
}
