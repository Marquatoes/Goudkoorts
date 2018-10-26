namespace Goudkoorts.Controller
{
    public class GameController
    {
        private Game _observable;
        private GameView _observer;

        public GameController(Game g)
        {
            _observable = g;
            _observer = new GameView(this);
            _observable.Event += _observer.Update;
        }

        public ImmovableObject GetPathFirst() { return _observable.GetPathFirst(); }

        internal bool BoatIsAtDock { get { return _observable.BoatIsAtDock; } }

        internal void SwitchOnInput(int input) { _observable.SwitchOnInput(input); }

        internal int GetScore() { return _observable.GetScore(); }

        internal int GetBoatLocation() { return _observable.BoatLocation; }

        internal void DebugAddScore() { _observable.DebugAddScore(); }
    }
}
