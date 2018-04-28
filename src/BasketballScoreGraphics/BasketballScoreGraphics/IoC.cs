using Autofac;

namespace BasketballScoreGraphics
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
