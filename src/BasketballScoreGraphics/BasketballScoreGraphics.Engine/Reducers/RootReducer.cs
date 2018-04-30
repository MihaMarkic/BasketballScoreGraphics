using BasketballScoreGraphics.Engine.Actions;
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
                                    periodType = PeriodType.EndRegularGame;
                                }
                                else if (state.Period == 2)
                                {
                                    periodType = PeriodType.HalfTime;
                                }
                                else
                                {
                                    periodType = PeriodType.QuarterBreak;
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
                                periodType = PeriodType.OvertimeBreak;
                                break;
                            case PeriodType.OvertimeBreak:
                                period++;
                                periodType = PeriodType.Overtime;
                                break;
                        }
                    }
                    else if(changePeriodAction.Difference == -1)
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
                                    periodType = PeriodType.QuarterBreak;
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
                                    periodType = PeriodType.EndRegularGame;
                                }
                                else
                                {
                                    period--;
                                    periodType = PeriodType.OvertimeBreak;
                                }
                                break;
                            case PeriodType.OvertimeBreak:
                                periodType = PeriodType.Overtime;
                                break;
                        }
                    }
                    newState = state.Clone(period: period, periodType: periodType);
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
                case StartTeamEditAction _:
                    newState = state.Clone(isTeamEdit: true);
                    break;
                case EndTeamEditAction _:
                    newState = state.Clone(isTeamEdit: false);
                    break;
                case ResetAction _:
                    newState = new RootState("Domači", "Gostujoči", 0, 0, 0, 0, 0, PeriodType.BeforeGame, isTeamEdit: true);
                    break;
                case SetTeamNameAction setTeamNameAction:
                    if (setTeamNameAction.TeamType == TeamType.Home)
                    {
                        newState = state.Clone(home: setTeamNameAction.Name);
                    }
                    else
                    {
                        newState = state.Clone(away: setTeamNameAction.Name);
                    }
                    break;
                case LoadStateAction loadStateAction:
                    newState = loadStateAction.State;
                    break;
                default:
                    newState = state;
                    break;
            }
            return Task.FromResult(newState);
        }
    }
}