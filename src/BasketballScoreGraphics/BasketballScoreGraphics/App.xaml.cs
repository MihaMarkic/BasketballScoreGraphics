using Autofac;
using BasketballScoreGraphics.Engine;
using System.Windows;

namespace BasketballScoreGraphics
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IoC.Init();
            // connect visualizer
            var sourceDispatcher = IoCRegistrar.Container.Resolve<IMainReduxDispatcher>();
            Bootstrapper.Init(sourceDispatcher);
            //ReduxVisualizer.Init(
            //    sourceDispatcher,
            //    new string[] { "Todo.Engine.Actions" });
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            IoCRegistrar.Container.Dispose();
            base.OnExit(e);
        }
    }
}
