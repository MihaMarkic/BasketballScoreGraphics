using Sharp.Redux;
using Righthand.Immutable;

namespace BasketballScoreGraphics.Engine.Actions
{
    public class LoadStateAction: ReduxAction
    {
        public RootState State { get; }

        public LoadStateAction(RootState state) : base()
        {
            State = state;
        }
        public LoadStateAction Clone(Param<RootState>? state = null)
        {
            return new LoadStateAction(state.HasValue ? state.Value.Value : State);
        }
    }
}
