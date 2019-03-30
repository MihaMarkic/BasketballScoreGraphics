using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace BasketballScoreGraphics.Extensions
{
    public static class WpfExtensions
    {
        public static Task BeginAsync(this Storyboard sb)
        {
            var tcs = new TaskCompletionSource<object>();
            EventHandler completed = null;
            completed = (_, __) =>
            {
                sb.Completed -= completed;
                tcs.SetResult(null);
            };
            sb.Completed += completed;
            sb.Begin();
            return tcs.Task;
        }
    }
}
