using Righthand.Immutable;

namespace BasketballScoreGraphics.Engine.Config
{
    public class Configuration
    {
        public Team[] Teams { get; }

        public Configuration(Team[] teams)
        {
            Teams = teams;
        }

        public Configuration Clone(Param<Team[]>? teams = null)
        {
            return new Configuration(teams.HasValue ? teams.Value.Value : Teams);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var o = (Configuration)obj;
            return Equals(Teams, o.Teams);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 23;
                hash = hash * 37 + (Teams != null ? Teams.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
