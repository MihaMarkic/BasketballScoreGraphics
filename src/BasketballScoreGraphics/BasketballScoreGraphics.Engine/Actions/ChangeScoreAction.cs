using BasketballScoreGraphics.Engine.Core;
using Sharp.Redux;
using Righthand.Immutable;

namespace BasketballScoreGraphics.Engine.Actions
{
    public class ChangeScoreAction : ReduxAction
    {
        public TeamType TeamType { get; }
        public int Difference { get; }

        public ChangeScoreAction(TeamType teamType, int difference) : base()
        {
            TeamType = teamType;
            Difference = difference;
        }
        public ChangeScoreAction Clone(Param<TeamType>? teamType = null, Param<int>? difference = null)
        {
            return new ChangeScoreAction(teamType.HasValue ? teamType.Value.Value : TeamType,
difference.HasValue ? difference.Value.Value : Difference);
        }
    }
}