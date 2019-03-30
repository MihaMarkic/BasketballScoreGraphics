using BasketballScoreGraphics.Engine.Actions;
using BasketballScoreGraphics.Engine.Config;
using BasketballScoreGraphics.Engine.Core;
using BasketballScoreGraphics.Engine.Services.Implementation;
using Newtonsoft.Json;
using Sharp.Redux;
using System;
using System.IO;

namespace BasketballScoreGraphics.Engine.ViewModels
{
    public class MainViewModel : NotifiableObject
    {
        readonly IMainReduxDispatcher dispatcher;
        public RelayCommand AdvancePeriodCommand { get; }
        public RelayCommand BackPeriodCommand { get; }
        public RelayCommand ResetCommand { get; }
        public RelayCommand EndGameCommand { get; }
        public RelayCommand ToggleTeamEditCommand { get; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }
        public string HomeTeam { get; private set; }
        public string AwayTeam { get; private set; }
        public int HomeFouls { get; private set; }
        public int AwayFouls { get; private set; }
        public uint HomeColor { get; private set; }
        public uint AwayColor { get; private set; }
        public string HomeLogo { get; private set; }
        public string AwayLogo { get; private set; }
        public string Period { get; private set; }
        public string PeriodDescription { get; private set; }
        public TeamControlsViewModel HomeTeamControls { get; }
        public TeamControlsViewModel AwayTeamControls { get; }
        public string EditingButtonText { get; private set; }
        readonly string persistenceFileName;
        public MainViewModel(IMainReduxDispatcher dispatcher, Func<TeamType, TeamControlsViewModel> teamControlsViewModelFactory)
        {
            this.dispatcher = dispatcher;
            dispatcher.StateChanged += UpdateReduxState;
            HomeTeamControls = teamControlsViewModelFactory(TeamType.Home);
            AwayTeamControls = teamControlsViewModelFactory(TeamType.Away);
            AdvancePeriodCommand = new RelayCommand(() => dispatcher.Dispatch(new ChangePeriodAction(+1)));
            BackPeriodCommand = new RelayCommand(() => dispatcher.Dispatch(new ChangePeriodAction(-1)));
            ResetCommand = new RelayCommand(() => dispatcher.Dispatch(new ResetAction()));
            EndGameCommand = new RelayCommand(() => dispatcher.Dispatch(new EndGameAction()));
            ToggleTeamEditCommand = new RelayCommand(() => dispatcher.Dispatch(new ToggleTeamEditAction()));
            persistenceFileName = Path.Combine(Path.GetDirectoryName(typeof(MainViewModel).Assembly.Location), "persistence.json");
        }
        public void Start()
        {
            dispatcher.Start();
            try
            {
                if (File.Exists(persistenceFileName))
                {
                    var content = File.ReadAllText(persistenceFileName);
                    var loadedState = JsonConvert.DeserializeObject<RootState>(content);
                    dispatcher.Dispatch(new LoadStateAction(loadedState));
                }
                var configuration = ConfigLoader.Load();
                if (configuration != null)
                {
                    dispatcher.Dispatch(new LoadConfigurationAction(configuration));
                }
            }
            catch (Exception)
            { }
        }
        static void SaveState(RootState state, string fileName)
        {
            try
            {
                string content = JsonConvert.SerializeObject(state);
                File.WriteAllText(fileName, content);
            }
            catch
            {
                
            }
        }
        void UpdateReduxState(object sender, StateChangedEventArgs<RootState> e)
        {
            if (!(e.Action is LoadStateAction))
            {
                SaveState(e.State, persistenceFileName);
            }
            var state = e.State;
            EditingButtonText = state.IsTeamEdit ? "D" : "E";
            HomeScore = state.HomeScore;
            AwayScore = state.AwayScore;
            HomeTeam = state.Home;
            AwayTeam = state.Away;
            HomeFouls = state.HomeFouls;
            AwayFouls = state.AwayFouls;
            HomeColor = state.HomeColor;
            AwayColor = state.AwayColor;
            HomeLogo = state.HomeLogo;
            AwayLogo = state.AwayLogo;
            if (state.IsEndGame)
            {
                Period = "KON";
                PeriodDescription = "Konec";
            }
            else
            {
                switch (state.PeriodType)
                {
                    case PeriodType.Quarter:
                    case PeriodType.QuarterBreak:
                        Period = $"{state.Period}/4";
                        break;
                    case PeriodType.Overtime:
                    case PeriodType.OvertimeBreak:
                        Period = $"{state.Period}P";
                        break;
                    case PeriodType.HalfTime:
                        Period = "POL";
                        break;
                    case PeriodType.BeforeGame:
                        Period = "";
                        break;
                    case PeriodType.EndRegularGame:
                        Period = "4/4";
                        break;
                }
                switch (state.PeriodType)
                {
                    case PeriodType.Quarter:

                        PeriodDescription = "";
                        break;
                    case PeriodType.HalfTime:
                        PeriodDescription = "polčas";
                        break;
                    case PeriodType.OvertimeBreak:
                    case PeriodType.QuarterBreak:
                        PeriodDescription = "odmor";
                        break;
                    case PeriodType.Overtime:
                        PeriodDescription = "podaljšek";
                        break;
                    default:
                        PeriodDescription = "";
                        break;
                }
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dispatcher.StateChanged -= UpdateReduxState;
            }
            base.Dispose(disposing);
        }
    }
}
