using Autofac;
using BasketballScoreGraphics.Engine.Config;
using BasketballScoreGraphics.Engine.Core;
using BasketballScoreGraphics.Engine.Reducers;
using BasketballScoreGraphics.Engine.ViewModels;
using Sharp.Redux;

namespace BasketballScoreGraphics.Engine
{
    public static class IoCRegistrar
    {
        public static IContainer Container { get; private set; }
        public static void Build(ContainerBuilder builder)
        {
            builder.RegisterType<RootReducer>().As<IReduxReducer<RootState>>().SingleInstance();
            // register root dispatcher and initialize state
            builder.Register<IMainReduxDispatcher>(
                ctx => new MainReduxDispatcher(
                            initialState: new RootState("Domači", "Gostujoči", 0, 0, 0, 0, 0, PeriodType.BeforeGame, isTeamEdit: true, isEndGame: false,
                            homeColor: 0xF00F, awayColor: 0xFF00, homeLogo: null, awayLogo: null, configuration: new Configuration(new Team[0])),
                            reducer: ctx.Resolve<IReduxReducer<RootState>>())
            ).SingleInstance();
            // register view models
            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<TeamControlsViewModel>();
            Container = builder.Build();
        }
    }
}
