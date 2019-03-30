using Autofac;

namespace BasketballScoreGraphics.Avalonia
{
    public static class IoC
    {
        public static void Init()
        {
            ContainerBuilder builder = new ContainerBuilder();
            Engine.IoCRegistrar.Build(builder);
        }
    }
}
