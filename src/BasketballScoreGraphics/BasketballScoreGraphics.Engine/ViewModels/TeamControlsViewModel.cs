using System.Runtime.CompilerServices;
using BasketballScoreGraphics.Engine.Actions;
using BasketballScoreGraphics.Engine.Core;
using Sharp.Redux;

namespace BasketballScoreGraphics.Engine.ViewModels
{
    public class TeamControlsViewModel: NotifiableObject
    {
        readonly IMainReduxDispatcher dispatcher;
        public TeamType TeamType { get; }
        public string TeamName { get; set; }
        public string TeamLabel => TeamType == TeamType.Home ? "Domači" : "Gostujoči";
        public RelayCommand EnabledEditCommand { get; }
        public RelayCommand DisableEditCommand { get; }
        public RelayCommand<string> ChangeScoreCommand { get; }
        public RelayCommand<string> ChangeFoulsCommand { get; }
        public bool IsTeamEdit { get; private set; }
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
            TeamName = TeamType == TeamType.Home ? state.Home : state.Away;
            IsTeamEdit = state.IsTeamEdit;
        }

        protected override void OnPropertyChanged(string name = null)
        {
            switch (name)
            {
                case nameof(TeamName):
                    dispatcher.Dispatch(new SetTeamNameAction(TeamType, TeamName));
                    break;
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
