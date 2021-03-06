﻿using BasketballScoreGraphics.Engine.Config;
using BasketballScoreGraphics.Engine.Core;
using Newtonsoft.Json;
using Righthand.Immutable;

namespace BasketballScoreGraphics.Engine
{
    public class RootState
    {
        public string Home { get; }
        public string Away { get; }
        public string ShortHome { get; }
        public string ShortAway { get; }
        public int HomeScore { get; }
        public int AwayScore { get; }
        public int HomeFouls { get; }
        public int AwayFouls { get; }
        public int Period { get; }
        public PeriodType PeriodType { get; }
        public bool IsTeamEdit { get; }
        public bool IsEndGame { get; }
        public uint HomeColor { get; }
        public uint AwayColor { get; }
        public string HomeLogo { get; }
        public string AwayLogo { get; }
        public Configuration Configuration { get; }

        public RootState(string home, string away, string shortHome, string shortAway,
            int homeScore, int awayScore, int homeFouls, int awayFouls, int period,
            PeriodType periodType, bool isTeamEdit, bool isEndGame,
            uint homeColor, uint awayColor, string homeLogo, string awayLogo, Configuration configuration)
        {
            Home = home;
            Away = away;
            ShortHome = shortHome;
            ShortAway = shortAway;
            HomeScore = homeScore;
            AwayScore = awayScore;
            HomeFouls = homeFouls;
            AwayFouls = awayFouls;
            Period = period;
            PeriodType = periodType;
            IsTeamEdit = isTeamEdit;
            IsEndGame = isEndGame;
            HomeColor = homeColor;
            AwayColor = awayColor;
            HomeLogo = homeLogo;
            AwayLogo = awayLogo;
            Configuration = configuration;
        }

        public RootState Clone(Param<string>? home = null, Param<string>? away = null, Param<string>? shortHome = null, Param<string>? shortAway = null, Param<int>? homeScore = null, Param<int>? awayScore = null, Param<int>? homeFouls = null, Param<int>? awayFouls = null, Param<int>? period = null, Param<PeriodType>? periodType = null, Param<bool>? isTeamEdit = null, Param<bool>? isEndGame = null, Param<uint>? homeColor = null, Param<uint>? awayColor = null, Param<string>? homeLogo = null, Param<string>? awayLogo = null, Param<Configuration>? configuration = null)
        {
            return new RootState(home.HasValue ? home.Value.Value : Home,
                away.HasValue ? away.Value.Value : Away,
                shortHome.HasValue ? shortHome.Value.Value : ShortHome,
                shortAway.HasValue ? shortAway.Value.Value : ShortAway,
                homeScore.HasValue ? homeScore.Value.Value : HomeScore,
                awayScore.HasValue ? awayScore.Value.Value : AwayScore,
                homeFouls.HasValue ? homeFouls.Value.Value : HomeFouls,
                awayFouls.HasValue ? awayFouls.Value.Value : AwayFouls,
                period.HasValue ? period.Value.Value : Period,
                periodType.HasValue ? periodType.Value.Value : PeriodType,
                isTeamEdit.HasValue ? isTeamEdit.Value.Value : IsTeamEdit,
                isEndGame.HasValue ? isEndGame.Value.Value : IsEndGame,
                homeColor.HasValue ? homeColor.Value.Value : HomeColor,
                awayColor.HasValue ? awayColor.Value.Value : AwayColor,
                homeLogo.HasValue ? homeLogo.Value.Value : HomeLogo,
                awayLogo.HasValue ? awayLogo.Value.Value : AwayLogo,
                configuration.HasValue ? configuration.Value.Value : Configuration);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var o = (RootState)obj;
            return Equals(Home, o.Home) && Equals(Away, o.Away) && Equals(ShortHome, o.ShortHome) && Equals(ShortAway, o.ShortAway) && Equals(HomeScore, o.HomeScore) && Equals(AwayScore, o.AwayScore) && Equals(HomeFouls, o.HomeFouls) && Equals(AwayFouls, o.AwayFouls) && Equals(Period, o.Period) && Equals(PeriodType, o.PeriodType) && Equals(IsTeamEdit, o.IsTeamEdit) && Equals(IsEndGame, o.IsEndGame) && Equals(HomeColor, o.HomeColor) && Equals(AwayColor, o.AwayColor) && Equals(HomeLogo, o.HomeLogo) && Equals(AwayLogo, o.AwayLogo) && Equals(Configuration, o.Configuration);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 23;
                hash = hash * 37 + (Home != null ? Home.GetHashCode() : 0);
                hash = hash * 37 + (Away != null ? Away.GetHashCode() : 0);
                hash = hash * 37 + (ShortHome != null ? ShortHome.GetHashCode() : 0);
                hash = hash * 37 + (ShortAway != null ? ShortAway.GetHashCode() : 0);
                hash = hash * 37 + HomeScore.GetHashCode();
                hash = hash * 37 + AwayScore.GetHashCode();
                hash = hash * 37 + HomeFouls.GetHashCode();
                hash = hash * 37 + AwayFouls.GetHashCode();
                hash = hash * 37 + Period.GetHashCode();
                hash = hash * 37 + PeriodType.GetHashCode();
                hash = hash * 37 + IsTeamEdit.GetHashCode();
                hash = hash * 37 + IsEndGame.GetHashCode();
                hash = hash * 37 + HomeColor.GetHashCode();
                hash = hash * 37 + AwayColor.GetHashCode();
                hash = hash * 37 + (HomeLogo != null ? HomeLogo.GetHashCode() : 0);
                hash = hash * 37 + (AwayLogo != null ? AwayLogo.GetHashCode() : 0);
                hash = hash * 37 + (Configuration != null ? Configuration.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
