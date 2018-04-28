using Sharp.Redux;
using System.Threading.Tasks;

namespace BasketballScoreGraphics.Engine
{
    public class MainReduxDispatcher : ReduxDispatcher<RootState, IReduxReducer<RootState>>, IMainReduxDispatcher
    {
        public MainReduxDispatcher(RootState initialState, IReduxReducer<RootState> reducer) :
            base(initialState, reducer, TaskScheduler.FromCurrentSynchronizationContext())
        {

        }
    }
}