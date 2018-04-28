using Sharp.Redux;
using Righthand.Immutable;

namespace BasketballScoreGraphics.Engine.Actions
{
    public class ChangePeriodAction: ReduxAction
    {
        public int Difference { get; }

        public ChangePeriodAction(int difference) : base()
        {
            Difference = difference;
        }

        public ChangePeriodAction Clone(Param<int>? difference = null)
        {
            return new ChangePeriodAction(difference.HasValue ? difference.Value.Value : Difference);
        }
    }
}
