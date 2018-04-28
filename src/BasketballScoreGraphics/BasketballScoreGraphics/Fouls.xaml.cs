using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BasketballScoreGraphics
{
    /// <summary>
    /// Interaction logic for Fouls.xaml
    /// </summary>
    public partial class Fouls : UserControl
    {
        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register(nameof(Number), typeof(int), typeof(Fouls), new PropertyMetadata(0, NumberChanged));
        public Fouls()
        {
            InitializeComponent();
        }

        public int Number
        {
            get => (int)GetValue(NumberProperty);
            set => SetValue(NumberProperty, value);
        }
        static void NumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Fouls fouls = (Fouls)d;
            fouls.UpdateNumber((int)e.NewValue);
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
