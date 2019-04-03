using BasketballScoreGraphics.Engine.Actions;
using BasketballScoreGraphics.Engine.Config;
using BasketballScoreGraphics.Engine.Core;
using Sharp.Redux;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BasketballScoreGraphics.Engine.Reducers
{
    public class RootReducer : IReduxReducer<RootState>
    {
        public Task<RootState> ReduceAsync(RootState state, ReduxAction action, CancellationToken ct)
        {
            RootState newState;
            switch (action)
            {
                case ChangeFoulsAction changeFoulsAction:
                    if (changeFoulsAction.TeamType == TeamType.Home)
                    {
                        newState = state.Clone(homeFouls: Math.Max(0, state.HomeFouls + changeFoulsAction.Difference));
                    }
                    else
                    {
                        newState = state.Clone(awayFouls: Math.Max(0, state.AwayFouls + changeFoulsAction.Difference));
                    }
                    break;
                case ChangePeriodAction changePeriodAction:
                    if (changePeriodAction.Difference == -1 && state.IsEndGame)
                    {
                        newState = state.Clone(isEndGame: false);
                    }
                    else
                    {
                        int period = state.Period;
                        PeriodType periodType = state.PeriodType;

                        if (changePeriodAction.Difference == +1)
                        {
                            switch (state.PeriodType)
                            {
                                case PeriodType.BeforeGame:
                                    period = 1;
                                    periodType = PeriodType.Quarter;
                                    break;
                                case PeriodType.Quarter:
                                    if (state.Period == 4)
                                    {
                                        periodType = PeriodType.Overtime;
                                        period = 1;
                                    }
                                    else if (state.Period == 2)
                                    {
                                        periodType = PeriodType.HalfTime;
                                    }
                                    else
                                    {
                                        //periodType = PeriodType.QuarterBreak;
                                        period++;
                                    }
                                    break;
                                case PeriodType.QuarterBreak:
                                    period++;
                                    periodType = PeriodType.Quarter;
                                    break;
                                case PeriodType.HalfTime:
                                    period++;
                                    periodType = PeriodType.Quarter;
                                    break;
                                case PeriodType.EndRegularGame:
                                    period = 1;
                                    periodType = PeriodType.Overtime;
                                    break;
                                case PeriodType.Overtime:
                                    //periodType = PeriodType.OvertimeBreak;
                                    period++;
                                    break;
                                case PeriodType.OvertimeBreak:
                                    period++;
                                    periodType = PeriodType.Overtime;
                                    break;
                            }
                        }
                        else
                        {
                            switch (state.PeriodType)
                            {
                                case PeriodType.Quarter:
                                    if (state.Period == 3)
                                    {
                                        period--;
                                        periodType = PeriodType.HalfTime;
                                    }
                                    else if (state.Period == 1)
                                    {
                                        periodType = PeriodType.BeforeGame;
                                    }
                                    else
                                    {
                                        period--;
                                        //periodType = PeriodType.QuarterBreak;
                                    }
                                    break;
                                case PeriodType.QuarterBreak:
                                    periodType = PeriodType.Quarter;
                                    break;
                                case PeriodType.HalfTime:
                                    period = 2;
                                    periodType = PeriodType.Quarter;
                                    break;
                                case PeriodType.EndRegularGame:
                                    period = 4;
                                    periodType = PeriodType.Quarter;
                                    break;
                                case PeriodType.Overtime:
                                    if (period == 1)
                                    {
                                        periodType = PeriodType.Quarter;
                                        period = 4;
                                    }
                                    else
                                    {
                                        period--;
                                        //periodType = PeriodType.OvertimeBreak;
                                    }
                                    break;
                                case PeriodType.OvertimeBreak:
                                    periodType = PeriodType.Overtime;
                                    break;
                            }
                        }
                        newState = state.Clone(period: period, periodType: periodType);
                    }
                    break;
                case ChangeScoreAction changeScoreAction:
                    if (changeScoreAction.TeamType == TeamType.Home)
                    {
                        newState = state.Clone(homeScore: Math.Max(0, state.HomeScore + changeScoreAction.Difference));
                    }
                    else
                    {
                        newState = state.Clone(awayScore: Math.Max(0, state.AwayScore + changeScoreAction.Difference));
                    }
                    break;
                case SetScoreAction setScoreAction:
                    if (setScoreAction.TeamType == TeamType.Home)
                    {
                        newState = state.Clone(homeScore: Math.Max(0, setScoreAction.Score));
                    }
                    else
                    {
                        newState = state.Clone(awayScore: Math.Max(0, setScoreAction.Score));
                    }
                    break;
                case SetTeamColorAction setTeamColorAction:
                    if (setTeamColorAction.TeamType == TeamType.Home)
                    {
                        newState = state.Clone(homeColor: setTeamColorAction.Color);
                    }
                    else
                    {
                        newState = state.Clone(awayColor: setTeamColorAction.Color);
                    }
                    break;
                case SetTeamLogoAction setTeamLogoAction:
                    if (setTeamLogoAction.TeamType == TeamType.Home)
                    {
                        newState = state.Clone(homeLogo: setTeamLogoAction.Logo);
                    }
                    else
                    {
                        newState = state.Clone(awayLogo: setTeamLogoAction.Logo);
                    }
                    break;
                case StartTeamEditAction _:
                    newState = state.Clone(isTeamEdit: true);
                    break;
                case EndTeamEditAction _:
                    newState = state.Clone(isTeamEdit: false);
                    break;
                case ResetAction _:
                    newState = new RootState("Domači", "Gostujoči", "Domači", "Gostujoči", 0, 0, 0, 0, 0, PeriodType.BeforeGame, isTeamEdit: true, isEndGame: false,
                        homeColor: 0xF00F, awayColor: 0xFF00, homeLogo: null, awayLogo: null, configuration:  state.Configuration);
                    break;
                case SetTeamNameAction setTeamNameAction:
                    if (setTeamNameAction.TeamType == TeamType.Home)
                    {
                        newState = state.Clone(home: setTeamNameAction.Name, shortHome: setTeamNameAction.ShortName);
                    }
                    else
                    {
                        newState = state.Clone(away: setTeamNameAction.Name, shortAway: setTeamNameAction.ShortName);
                    }
                    break;
                case LoadStateAction loadStateAction:
                    newState = loadStateAction.State;
                    break;
                case EndGameAction _:
                    newState = state.Clone(isEndGame: true);
                    break;
                case ToggleTeamEditAction _:
                    newState = state.Clone(isTeamEdit: !state.IsTeamEdit);
                    break;
                case LoadConfigurationAction loadConfigurationAction:
                    newState = state.Clone(configuration: loadConfigurationAction.Configuration);
                    break;
                default:
                    newState = state;
                    break;
            }
            return Task.FromResult(newState);
        }
    }
}