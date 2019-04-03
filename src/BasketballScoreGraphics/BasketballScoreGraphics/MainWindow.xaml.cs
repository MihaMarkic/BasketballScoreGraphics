using Autofac;
using BasketballScoreGraphics.Engine;
using BasketballScoreGraphics.Engine.Core;
using BasketballScoreGraphics.Engine.ViewModels;
using BasketballScoreGraphics.Extensions;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BasketballScoreGraphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; private set; }
        Rooster rooster;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = IoCRegistrar.Container.Resolve<MainViewModel>();
            ViewModel.Start();
            DataContext = ViewModel;
            ViewModel.UpdatingScore += ViewModel_UpdatingScore;

            var controller = new Controller();
            controller.DataContext = ViewModel;
            controller.Show();
            controller.Closed += Controller_Closed;

            rooster = new Rooster
            {
                DataContext = ViewModel.RoosterViewModel,
            };
            rooster.Show();
        }

        /// <summary>
        /// Fires animated score transition for positive difference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Not re-entrancy safe</remarks>
        void ViewModel_UpdatingScore(object sender, UpdatingScoreEventArgs e)
        {
            if (e.Difference > 0)
            {
                switch (e.TeamType)
                {
                    case TeamType.Home:
                        {
                            var ignore = UpdateScore(HomeScore, HomeScoreAnimator, e.Difference);
                        }
                        break;
                    case TeamType.Away:
                        {
                            var ignore = UpdateScore(AwayScore, AwayScoreAnimator, e.Difference);
                        }
                        break;
                }
            }
        }

        async Task UpdateScore(TextBlock text, TextBlock animator, int diff)
        {
            text.Visibility = Visibility.Hidden;
            animator.Visibility = Visibility.Visible;
            animator.Text = text.Text;
            animator.Opacity = 1;

            await FadeOrShowAsync(1, 0, 300, animator);
            animator.Text = $"+{diff}";
            animator.Background = new SolidColorBrush(Colors.Yellow);
            await FadeOrShowAsync(0, 1, 200, animator);
            await Task.Delay(TimeSpan.FromSeconds(1));
            await FadeOrShowAsync(1, 0, 200, animator);
            animator.Background = null;
            animator.Visibility = Visibility.Collapsed;
            text.Opacity = 0;
            text.Visibility = Visibility.Visible;
            await FadeOrShowAsync(0, 1, 300, text);
        }

        async Task FadeOrShowAsync(double start, double end, int milliseconds, TextBlock target)
        {
            var fadeScore = new DoubleAnimation
            {
                From = start,
                To = end,
                Duration = TimeSpan.FromMilliseconds(milliseconds),
                EasingFunction = new QuadraticEase(),
            };
            Storyboard.SetTarget(fadeScore, target);
            Storyboard.SetTargetProperty(fadeScore, new PropertyPath(TextBlock.OpacityProperty));
            var sb = new Storyboard();
            sb.Children.Add(fadeScore);
            await sb.BeginAsync();
        }

        void Controller_Closed(object sender, EventArgs e)
        {
            rooster.Close();
            Close();
        }
    }
}
