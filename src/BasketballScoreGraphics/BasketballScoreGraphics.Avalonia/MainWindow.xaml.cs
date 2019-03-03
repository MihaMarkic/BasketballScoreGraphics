using Autofac;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BasketballScoreGraphics.Engine;
using BasketballScoreGraphics.Engine.ViewModels;

namespace BasketballScoreGraphics.Avalonia
{
    public class MainWindow : Window
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
            controller.Closed += Controller_Closed;
        }

        void Controller_Closed(object sender, System.EventArgs e)
        {
            Close();
        }

        void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}