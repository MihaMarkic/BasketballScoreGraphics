using BasketballScoreGraphics.Engine.Config;
using Sharp.Redux;
using Righthand.Immutable;

namespace BasketballScoreGraphics.Engine.Actions
{
    public class LoadConfigurationAction : ReduxAction
    {
        public Configuration Configuration { get; }

        public LoadConfigurationAction(Configuration configuration) : base()
        {
            Configuration = configuration;
        }

        public LoadConfigurationAction Clone(Param<Configuration>? configuration = null)
        {
            return new LoadConfigurationAction(configuration.HasValue ? configuration.Value.Value : Configuration);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var o = (LoadConfigurationAction)obj;
            return Equals(Configuration, o.Configuration);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = base.GetHashCode();
                hash = hash * 37 + (Configuration != null ? Configuration.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
