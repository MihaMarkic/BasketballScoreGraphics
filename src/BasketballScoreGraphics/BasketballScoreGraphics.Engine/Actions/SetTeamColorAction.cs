using BasketballScoreGraphics.Engine.Core;
using Righthand.Immutable;
using Sharp.Redux;

namespace BasketballScoreGraphics.Engine.Actions
{
    public class SetTeamColorAction: ReduxAction
    {
        public TeamType TeamType { get; }
        public uint Color { get; }

        public SetTeamColorAction(TeamType teamType, uint color) : base()
        {
            TeamType = teamType;
            Color = color;
        }

        public SetTeamColorAction Clone(Param<TeamType>? teamType = null, Param<uint>? color = null)
        {
            return new SetTeamColorAction(teamType.HasValue ? teamType.Value.Value : TeamType,
				color.HasValue ? color.Value.Value : Color);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var o = (SetTeamColorAction)obj;
            return Equals(TeamType, o.TeamType) && Equals(Color, o.Color);}

        public override int GetHashCode()
        {
            unchecked
			{
				int hash = base.GetHashCode();
				hash = hash * 37 + (TeamType != null ? TeamType.GetHashCode() : 0);
				hash = hash * 37 + Color.GetHashCode();
				return hash;
			}
        }
    }
}
