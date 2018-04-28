using Autofac;
using BasketballScoreGraphics.Engine;
using BasketballScoreGraphics.Engine.ViewModels;
using System.Windows;

namespace BasketballScoreGraphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = IoCRegistrar.Container.Resolve<MainViewModel>();
            ViewModel.Start();
            DataContext = ViewModel;

            var controller = new Controller();
            controller.DataContext = ViewModel;
            controller.Show();
        }
    }
}
