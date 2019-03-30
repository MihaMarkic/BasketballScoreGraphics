using Righthand.Immutable;
using System.Diagnostics;

namespace BasketballScoreGraphics.Engine.Config
{
    [DebuggerDisplay("{Name,nq}")]
    public class Team
    {
        public string Name { get; }
        public string Logo { get; }
        public uint Color { get; }
        public Player[] Players { get; }

        public Team(string name, string logo, uint color, Player[] players)
        {
            Name = name;
            Logo = logo;
            Color = color;
            Players = players;
        }

        public Team Clone(Param<string>? name = null, Param<string>? logo = null, Param<uint>? color = null, Param<Player[]>? players = null)
        {
            return new Team(name.HasValue ? name.Value.Value : Name,
                logo.HasValue ? logo.Value.Value : Logo,
                color.HasValue ? color.Value.Value : Color,
                players.HasValue ? players.Value.Value : Players);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var o = (Team)obj;
            return Equals(Name, o.Name) && Equals(Logo, o.Logo) && Equals(Color, o.Color) && Equals(Players, o.Players);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 23;
                hash = hash * 37 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 37 + (Logo != null ? Logo.GetHashCode() : 0);
                hash = hash * 37 + Color.GetHashCode();
                hash = hash * 37 + (Players != null ? Players.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
