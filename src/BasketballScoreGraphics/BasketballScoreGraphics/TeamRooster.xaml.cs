using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BasketballScoreGraphics
{
    /// <summary>
    /// Interaction logic for TeamRooster.xaml
    /// </summary>
    public partial class TeamRooster : UserControl
    {
        public TeamRooster()
        {
            InitializeComponent();
        }

        void Players_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                Players.UnselectAll()));
        }
    }
}
