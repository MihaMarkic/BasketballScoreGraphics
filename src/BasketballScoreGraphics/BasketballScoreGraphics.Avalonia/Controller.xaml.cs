using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using BasketballScoreGraphics.Engine.ViewModels;

namespace BasketballScoreGraphics.Avalonia
{
    public class Controller : Window
    {
        public Controller()
        {
            InitializeComponent();
        }

        void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            switch (e.Key)
            {
                case Key.NumPad1:
                case Key.D1:
                    viewModel.AwayTeamControls.ChangeScoreCommand.Execute("1");
                    break;
                case Key.NumPad2:
                case Key.D2:
                    viewModel.AwayTeamControls.ChangeScoreCommand.Execute("2");
                    break;
                case Key.NumPad3:
                case Key.D3:
                    viewModel.AwayTeamControls.ChangeScoreCommand.Execute("3");
                    break;
                case Key.NumPad7:
                case Key.D7:
                    viewModel.HomeTeamControls.ChangeScoreCommand.Execute("1");
                    break;
                case Key.NumPad8:
                case Key.D8:
                    viewModel.HomeTeamControls.ChangeScoreCommand.Execute("2");
                    break;
                case Key.NumPad9:
                case Key.D9:
                    viewModel.HomeTeamControls.ChangeScoreCommand.Execute("3");
                    break;
                case Key.OemPlus:
                    viewModel.HomeTeamControls.ChangeFoulsCommand.Execute("1");
                    break;
                case Key.OemMinus:
                    viewModel.AwayTeamControls.ChangeFoulsCommand.Execute("1");
                    break;
            }
            base.OnKeyDown(e);
        }
    }
}