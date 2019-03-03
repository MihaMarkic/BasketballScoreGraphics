using System;
using Autofac;
using Avalonia;
using Avalonia.Markup.Xaml;
using BasketballScoreGraphics.Engine;

namespace BasketballScoreGraphics.Avalonia
{
    public class App : Application
    {
        public override void Initialize()
        {
            IoC.Init();
            // connect visualizer
            var sourceDispatcher = IoCRegistrar.Container.Resolve<IMainReduxDispatcher>();
            Bootstrapper.Init(sourceDispatcher);
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnExiting(object sender, EventArgs e)
        {
            IoCRegistrar.Container.Dispose();
            base.OnExiting(sender, e);
        }
 }
}