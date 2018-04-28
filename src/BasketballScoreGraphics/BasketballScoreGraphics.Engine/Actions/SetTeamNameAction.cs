using BasketballScoreGraphics.Engine.Core;
using Righthand.Immutable;
using Sharp.Redux;

namespace BasketballScoreGraphics.Engine.Actions
{
    public class SetTeamNameAction: ReduxAction
    {
        public TeamType TeamType { get; }
        public string Name { get; }

        public SetTeamNameAction(TeamType teamType, string name) : base()
        {
            TeamType = teamType;
            Name = name;
        }public SetTeamNameAction Clone(Param<TeamType>? teamType = null, Param<string>? name = null)
        {
            return new SetTeamNameAction(teamType.HasValue ? teamType.Value.Value : TeamType,
name.HasValue ? name.Value.Value : Name);
        }
    }
}
