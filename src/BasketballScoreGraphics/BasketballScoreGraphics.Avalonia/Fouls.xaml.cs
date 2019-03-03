using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System.Linq;

namespace BasketballScoreGraphics.Avalonia
{
    /// <summary>
    /// Interaction logic for Fouls.xaml
    /// </summary>
    public partial class Fouls : UserControl
    {
        public static readonly StyledProperty<int> NumberProperty = AvaloniaProperty.Register<Fouls, int>(nameof(Number),
            validate: ValidateNumber);
        Grid grid;
        public Fouls()
        {
            InitializeComponent();
            grid = this.FindControl<Grid>("grid");
        }

        void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public int Number
        {
            get => GetValue(NumberProperty);
            set => SetValue(NumberProperty, value);
        }
        static int ValidateNumber(Fouls source, int value)
        {
            source.UpdateNumber(value);
            return value;
        }
        void UpdateNumber(int number)
        {
            var background = new SolidColorBrush( number < 5 ? Colors.Orange : Colors.DarkRed);
            var borders = grid.Children.OfType<Border>().ToArray();
            for (int i=0; i<borders.Length; i++)
            {
                var border = borders[i];
                if (i < number)
                {
                    border.Background = background;
                }
                else
                {
                    border.Background = null;
                }
            }
        }
    }
}
