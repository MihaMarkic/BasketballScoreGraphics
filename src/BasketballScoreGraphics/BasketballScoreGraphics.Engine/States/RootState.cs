using BasketballScoreGraphics.Engine.Core;
using Righthand.Immutable;

namespace BasketballScoreGraphics.Engine
{
    public readonly struct RootState
    {
        public string Home { get; }
        public string Away { get; }
        public int HomeScore { get; }
        public int AwayScore { get; }
        public int HomeFouls { get; }
        public int AwayFouls { get; }
        public int Period { get; }
        public PeriodType PeriodType { get; }
        public bool IsTeamEdit { get; }

        public RootState(string home, string away, int homeScore, int awayScore, int homeFouls, int awayFouls, int period, PeriodType periodType, bool isTeamEdit)
        {
            Home = home;
            Away = away;
            HomeScore = homeScore;
            AwayScore = awayScore;
            HomeFouls = homeFouls;
            AwayFouls = awayFouls;
            Period = period;
            PeriodType = periodType;
            IsTeamEdit = isTeamEdit;
        }

        public RootState Clone(Param<string>? home = null, Param<string>? away = null, Param<int>? homeScore = null, Param<int>? awayScore = null, Param<int>? homeFouls = null, Param<int>? awayFouls = null, Param<int>? period = null, Param<PeriodType>? periodType = null, Param<bool>? isTeamEdit = null)
        {
            return new RootState(home.HasValue ? home.Value.Value : Home,
away.HasValue ? away.Value.Value : Away,
homeScore.HasValue ? homeScore.Value.Value : HomeScore,
awayScore.HasValue ? awayScore.Value.Value : AwayScore,
homeFouls.HasValue ? homeFouls.Value.Value : HomeFouls,
awayFouls.HasValue ? awayFouls.Value.Value : AwayFouls,
period.HasValue ? period.Value.Value : Period,
periodType.HasValue ? periodType.Value.Value : PeriodType,
isTeamEdit.HasValue ? isTeamEdit.Value.Value : IsTeamEdit);
        }
    }
}
