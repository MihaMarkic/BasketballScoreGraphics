using Righthand.Immutable;
using System.Diagnostics;

namespace BasketballScoreGraphics.Engine.Config
{
    [DebuggerDisplay("{Surname,nq}, {Name,nq}")]
    public class Player
    {
        public int? Number { get; }
        public string Name { get; }
        public string Surname { get; }
        public int? BirthYear { get; }
        public int? Height { get; }

        public Player(int? number, string name, string surname, int? birthYear, int? height)
        {
            Number = number;
            Name = name;
            Surname = surname;
            BirthYear = birthYear;
            Height = height;
        }

        public Player Clone(Param<int?>? number = null, Param<string>? name = null, Param<string>? surname = null, Param<int?>? birthYear = null, Param<int?>? height = null)
        {
            return new Player(number.HasValue ? number.Value.Value : Number,
                name.HasValue ? name.Value.Value : Name,
                surname.HasValue ? surname.Value.Value : Surname,
                birthYear.HasValue ? birthYear.Value.Value : BirthYear,
                height.HasValue ? height.Value.Value : Height);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var o = (Player)obj;
            return Equals(Number, o.Number) && Equals(Name, o.Name) && Equals(Surname, o.Surname) && Equals(BirthYear, o.BirthYear) && Equals(Height, o.Height);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 23;
                hash = hash * 37 + (Number != null ? Number.GetHashCode() : 0);
                hash = hash * 37 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 37 + (Surname != null ? Surname.GetHashCode() : 0);
                hash = hash * 37 + (BirthYear != null ? BirthYear.GetHashCode() : 0);
                hash = hash * 37 + (Height != null ? Height.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
