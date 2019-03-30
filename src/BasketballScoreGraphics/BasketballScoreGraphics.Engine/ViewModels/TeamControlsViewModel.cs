using BasketballScoreGraphics.Engine.Actions;
using BasketballScoreGraphics.Engine.Config;
using BasketballScoreGraphics.Engine.Core;
using Sharp.Redux;
using System;
using System.Linq;

namespace BasketballScoreGraphics.Engine.ViewModels
{
    public class TeamControlsViewModel: NotifiableObject
    {
        readonly IMainReduxDispatcher dispatcher;
        public TeamType TeamType { get; }
        public string TeamName { get; set; }
        public uint TeamColor { get; set; }
        public string TeamLabel => TeamType == TeamType.Home ? "Domači" : "Gostujoči";
        public RelayCommand EnabledEditCommand { get; }
        public RelayCommand DisableEditCommand { get; }
        public RelayCommand<string> ChangeScoreCommand { get; }
        public RelayCommand<string> ChangeFoulsCommand { get; }
        public bool IsTeamEdit { get; private set; }
        public Team[] Teams { get; private set; }
        bool isUpdating;
        public TeamControlsViewModel(IMainReduxDispatcher dispatcher, TeamType teamType)
        {
            this.dispatcher = dispatcher;
            dispatcher.StateChanged += Dispatcher_StateChanged;
            TeamType = teamType;
            EnabledEditCommand = new RelayCommand(() => dispatcher.Dispatch(new StartTeamEditAction()));
            DisableEditCommand = new RelayCommand(() => dispatcher.Dispatch(new EndTeamEditAction()));
            ChangeScoreCommand = new RelayCommand<string>(i => dispatcher.Dispatch(new ChangeScoreAction(teamType, int.Parse(i))));
            ChangeFoulsCommand = new RelayCommand<string>(i => dispatcher.Dispatch(new ChangeFoulsAction(teamType, int.Parse(i))));
        }

        private void Dispatcher_StateChanged(object sender, StateChangedEventArgs<RootState> e)
        {
            var state = e.State;
            isUpdating = true;
            try
            {
                TeamName = TeamType == TeamType.Home ? state.Home : state.Away;
                IsTeamEdit = state.IsTeamEdit;
                TeamColor = TeamType == TeamType.Home ? state.HomeColor : state.AwayColor;
                Teams = state.Configuration?.Teams;
            }
            finally
            {
                isUpdating = false;
            }
        }

        protected override void OnPropertyChanged(string name = null)
        {
            if (!isUpdating)
            {
                switch (name)
                {
                    case nameof(TeamName):
                        dispatcher.Dispatch(new SetTeamNameAction(TeamType, TeamName));
                        var team = Teams.Where(t => string.Equals(t.Name, TeamName, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
                        if (team != null)
                        {
                            dispatcher.Dispatch(new SetTeamColorAction(TeamType, (uint)(team.Color | 0xFF << 24)));
                            dispatcher.Dispatch(new SetTeamLogoAction(TeamType, team.Logo));
                        }
                        break;
                    case nameof(TeamColor):
                        dispatcher.Dispatch(new SetTeamColorAction(TeamType, TeamColor));
                        break;
                }
            }
            base.OnPropertyChanged(name);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dispatcher.StateChanged -= Dispatcher_StateChanged;
            }
            base.Dispose(disposing);
        }
    }
}
