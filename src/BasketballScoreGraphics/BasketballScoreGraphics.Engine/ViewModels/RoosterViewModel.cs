using BasketballScoreGraphics.Engine.Config;
using BasketballScoreGraphics.Engine.Core;
using Sharp.Redux;
using System;
using System.Linq;

namespace BasketballScoreGraphics.Engine.ViewModels
{
    public class RoosterViewModel : NotifiableObject
    {
        readonly IMainReduxDispatcher dispatcher;
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public RoosterViewModel(IMainReduxDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            dispatcher.StateChanged += Dispatcher_StateChanged;
        }

        void Dispatcher_StateChanged(object sender, StateChangedEventArgs<RootState> e)
        {
            var state = e.State;
            HomeTeam = state.Configuration?.Teams.Where(t => string.Equals(t.Name, state.Home, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
            AwayTeam = state.Configuration?.Teams.Where(t => string.Equals(t.Name, state.Away, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
        }
    }
}
