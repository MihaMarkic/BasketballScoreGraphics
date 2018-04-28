using BasketballScoreGraphics.Engine.Core;
using Sharp.Redux;
using Righthand.Immutable;

namespace BasketballScoreGraphics.Engine.Actions
{
    public class SetScoreAction : ReduxAction
    {
        public TeamType TeamType { get; }
        public int Score { get; }

        public SetScoreAction(TeamType teamType, int score) : base()
        {
            TeamType = teamType;
            Score = score;
        }public SetScoreAction Clone(Param<TeamType>? teamType = null, Param<int>? score = null)
        {
            return new SetScoreAction(teamType.HasValue ? teamType.Value.Value : TeamType,
score.HasValue ? score.Value.Value : Score);
        }
    }
}
