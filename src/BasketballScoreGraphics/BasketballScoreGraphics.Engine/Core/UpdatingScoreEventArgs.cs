using System;

namespace BasketballScoreGraphics.Engine.Core
{
    public class UpdatingScoreEventArgs: EventArgs
    {
        public TeamType TeamType { get; }
        public int Difference { get; }
        public UpdatingScoreEventArgs(TeamType teamType, int difference)
        {
            TeamType = teamType;
            Difference = difference;
        }
    }
}
