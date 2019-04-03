using BasketballScoreGraphics.Extensions;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BasketballScoreGraphics
{
    /// <summary>
    /// Interaction logic for Rooster.xaml
    /// </summary>
    public partial class Rooster : Window
    {
        readonly CancellationTokenSource cts;
        bool isShowingHome = true;
        public Rooster()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
            Loaded += Rooster_Loaded;
        }

        void Rooster_Loaded(object sender, RoutedEventArgs e)
        {
            var ignore = AnimationAsync(cts.Token);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            cts.Cancel();
            base.OnClosing(e);
        }

        async Task AnimationAsync(CancellationToken ct)
        {
            while(!ct.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(5), ct);
                    TeamRooster current = isShowingHome ? Home: Away;
                    TeamRooster next = !isShowingHome ? Home : Away;
                    await FadeOrShowAsync(1, 0, 300, current);
                    await FadeOrShowAsync(0, 1, 300, next);
                    isShowingHome = !isShowingHome;
                }
                catch (OperationCanceledException)
                {
                    return;
                }
                catch (Exception)
                {

                }
            }
        }

        async Task FadeOrShowAsync(double start, double end, int milliseconds, TeamRooster target)
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
    }
}
