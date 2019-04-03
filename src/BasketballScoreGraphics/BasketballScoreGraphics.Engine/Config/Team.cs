using Righthand.Immutable;
using System.Diagnostics;

namespace BasketballScoreGraphics.Engine.Config
{
    [DebuggerDisplay("{Name,nq}")]
    public class Team
    {
        public string Name { get; }
        public string ShortName { get; }
        public string Logo { get; }
        public string Coach { get; }
        public uint Color { get; }
        public Player[] Players { get; }

        public Team(string name, string shortName, string logo, string coach, uint color, Player[] players)
        {
            Name = name;
            ShortName = shortName;
            Logo = logo;
            Coach = coach;
            Color = color;
            Players = players;
        }

        public Team Clone(Param<string>? name = null, Param<string>? shortName = null, Param<string>? logo = null, Param<string>? coach = null, Param<uint>? color = null, Param<Player[]>? players = null)
        {
            return new Team(name.HasValue ? name.Value.Value : Name,
				shortName.HasValue ? shortName.Value.Value : ShortName,
				logo.HasValue ? logo.Value.Value : Logo,
				coach.HasValue ? coach.Value.Value : Coach,
				color.HasValue ? color.Value.Value : Color,
				players.HasValue ? players.Value.Value : Players);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var o = (Team)obj;
            return Equals(Name, o.Name) && Equals(ShortName, o.ShortName) && Equals(Logo, o.Logo) && Equals(Coach, o.Coach) && Equals(Color, o.Color) && Equals(Players, o.Players);
}

        public override int GetHashCode()
        {
            unchecked
			{
				int hash = 23;
				hash = hash * 37 + (Name != null ? Name.GetHashCode() : 0);
				hash = hash * 37 + (ShortName != null ? ShortName.GetHashCode() : 0);
				hash = hash * 37 + (Logo != null ? Logo.GetHashCode() : 0);
				hash = hash * 37 + (Coach != null ? Coach.GetHashCode() : 0);
				hash = hash * 37 + Color.GetHashCode();
				hash = hash * 37 + (Players != null ? Players.GetHashCode() : 0);
				return hash;
			}
        }
    }
}
