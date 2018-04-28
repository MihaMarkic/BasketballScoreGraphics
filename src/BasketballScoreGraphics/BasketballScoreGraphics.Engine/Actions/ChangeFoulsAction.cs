using BasketballScoreGraphics.Engine.Core;
using Righthand.Immutable;
using Sharp.Redux;

namespace BasketballScoreGraphics.Engine.Actions
{
    public class ChangeFoulsAction: ReduxAction
    {
        public TeamType TeamType { get; }
        public int Difference { get; }

        public ChangeFoulsAction(TeamType teamType, int score) : base()
        {
            TeamType = teamType;
            Difference = score;
        }public ChangeFoulsAction Clone(Param<TeamType>? teamType = null, Param<int>? score = null)
        {
            return new ChangeFoulsAction(teamType.HasValue ? teamType.Value.Value : TeamType,
score.HasValue ? score.Value.Value : Difference);
        }
    }
}
