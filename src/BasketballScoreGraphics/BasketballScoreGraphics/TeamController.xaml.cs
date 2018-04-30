using BasketballScoreGraphics.Engine.ViewModels;
using System.Windows.Controls;

namespace BasketballScoreGraphics
{
    /// <summary>
    /// Interaction logic for TeamController.xaml
    /// </summary>
    public partial class TeamController : UserControl
    {
        public TeamController()
        {
            InitializeComponent();
        }
        TeamControlsViewModel ViewModel => (TeamControlsViewModel)DataContext;
    }
}
