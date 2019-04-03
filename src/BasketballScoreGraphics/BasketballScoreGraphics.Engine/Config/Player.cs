using Righthand.Immutable;
using System.Diagnostics;

namespace BasketballScoreGraphics.Engine.Config
{
    [DebuggerDisplay("{Number}. {Name,nq}")]
    public class Player
    {
        public int? Number { get; }
        public string Name { get; }
        public int? BirthYear { get; }
        public int? Height { get; }
        public string Role { get; }

        public Player(int? number, string name, int? birthYear, int? height, string role)
        {
            Number = number;
            Name = name;
            BirthYear = birthYear;
            Height = height;
            Role = role;
        }

        public Player Clone(Param<int?>? number = null, Param<string>? name = null, Param<int?>? birthYear = null, Param<int?>? height = null, Param<string>? role = null)
        {
            return new Player(number.HasValue ? number.Value.Value : Number,
                name.HasValue ? name.Value.Value : Name,
                birthYear.HasValue ? birthYear.Value.Value : BirthYear,
                height.HasValue ? height.Value.Value : Height,
                role.HasValue ? role.Value.Value : Role);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var o = (Player)obj;
            return Equals(Number, o.Number) && Equals(Name, o.Name) && Equals(BirthYear, o.BirthYear) && Equals(Height, o.Height) && Equals(Role, o.Role);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 23;
                hash = hash * 37 + (Number != null ? Number.GetHashCode() : 0);
                hash = hash * 37 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 37 + (BirthYear != null ? BirthYear.GetHashCode() : 0);
                hash = hash * 37 + (Height != null ? Height.GetHashCode() : 0);
                hash = hash * 37 + (Role != null ? Role.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
