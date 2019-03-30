using BasketballScoreGraphics.Engine.Core;
using Righthand.Immutable;
using Sharp.Redux;

namespace BasketballScoreGraphics.Engine.Actions
{
    public class SetTeamLogoAction : ReduxAction
    {
        public TeamType TeamType { get; }
        public string Logo { get; }

        public SetTeamLogoAction(TeamType teamType, string logo) : base()
        {
            TeamType = teamType;
            Logo = logo;
        }

        public SetTeamLogoAction Clone(Param<TeamType>? teamType = null, Param<string>? logo = null)
        {
            return new SetTeamLogoAction(teamType.HasValue ? teamType.Value.Value : TeamType,
                logo.HasValue ? logo.Value.Value : Logo);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var o = (SetTeamLogoAction)obj;
            return Equals(TeamType, o.TeamType) && Equals(Logo, o.Logo);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = base.GetHashCode();
                hash = hash * 37 + TeamType.GetHashCode();
                hash = hash * 37 + (Logo != null ? Logo.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
