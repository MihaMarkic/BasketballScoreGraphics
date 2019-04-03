using BasketballScoreGraphics.Engine.Core;
using Righthand.Immutable;
using Sharp.Redux;

namespace BasketballScoreGraphics.Engine.Actions
{
    public class SetTeamNameAction : ReduxAction
    {
        public TeamType TeamType { get; }
        public string Name { get; }
        public string ShortName { get; }

        public SetTeamNameAction(TeamType teamType, string name, string shortName) : base()
        {
            TeamType = teamType;
            Name = name;
            ShortName = shortName;
        }

        public SetTeamNameAction Clone(Param<TeamType>? teamType = null, Param<string>? name = null, Param<string>? shortName = null)
        {
            return new SetTeamNameAction(teamType.HasValue ? teamType.Value.Value : TeamType,
                name.HasValue ? name.Value.Value : Name,
                shortName.HasValue ? shortName.Value.Value : ShortName);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var o = (SetTeamNameAction)obj;
            return Equals(TeamType, o.TeamType) && Equals(Name, o.Name) && Equals(ShortName, o.ShortName);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = base.GetHashCode();
                hash = hash * 37 + TeamType.GetHashCode();
                hash = hash * 37 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 37 + (ShortName != null ? ShortName.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
