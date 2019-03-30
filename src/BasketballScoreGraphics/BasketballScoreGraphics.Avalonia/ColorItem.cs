using Avalonia.Media;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace BasketballScoreGraphics.Avalonia
{
    public class ColorItem
    {
        public static ColorItem[] Items { get; }
        static readonly ImmutableDictionary<uint, ColorItem> colors;
        public string Name { get; }
        public  Color Color { get; }
        public SolidColorBrush Brush => new SolidColorBrush(Color);
        static ColorItem()
        {
            Items = (from cp in typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                     where cp.Name != "Aqua" && cp.Name != "Magenta" && cp.Name != "Transparent" // have duplicate items
                     let pc = (Color)cp.GetValue(null)
                     // eliminates transparency
                     let c = Color.FromRgb(pc.R, pc.G, pc.B)
                        select new ColorItem(
                            name: cp.Name,
                            color: c
                        )).ToArray();
            var duplicates = Items.GroupBy(i => i.Color.ToUint32(), i => i).Where(g => g.Count() > 1).ToArray();
            // cut first byte of opacity
            colors = Items.ToImmutableDictionary(i => i.Color.ToUint32(), i => i);
        }
        public ColorItem(string name, Color color)
        {
            Name = name;
            Color = color;
        }
        public static ColorItem ItemByColor(uint color) => colors[color | 0xFF000000];
    }
}