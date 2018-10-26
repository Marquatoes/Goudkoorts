using System;

namespace Goudkoorts
{
    public class Game
    {
        private Path _path;

        public Player Player
        {
            get => default(Player);
            set
            {
            }
        }

        public bool BoatIsAtDock { get { return false; } }
        public int BoatLocation { get { return _path.BoatLocation; } }

        public Game()
        {
            _path = new Path();
        }
        public void Start()
        {
            _path.SetPath(Parser.GetLevel(1));
            _path.Score = 0;
            _path.BoatLocation = -1;
            Round(500);
        }

        private void Round(int roundDurationMs)
        {
            Random r = new Random();
            if (r.Next(0, 4) == 1)
                if(_path.DebugCartAmount < 1)
                    _path.PlaceCart();
            if (!_path.MoveAllCarts())
            {
                //Show GameOver Screen
            }

            if (!_path.BoatIsDocked)
            {
                _path.BoatLocation++;
                if(BoatLocation == 14)
                {
                    _path.DockBoat();
                }
            }

            Notify();
            System.Threading.Thread.Sleep(roundDurationMs);
            Round(roundDurationMs);
        }

        internal void DebugAddScore()
        {
            _path.AddScore();
            Notify(true);
        }

        internal int GetScore()
        {
            return _path.Score;
        }

        internal void SwitchOnInput(int input)
        {
            _path.SwitchOnInput(input);
            Notify(true);
        }

        internal ImmovableObject GetPathFirst()
        {
            return _path.First;
        }

        #region Observable stuff

        public event EventHandler<NotifyEventArgs> Event;

        public void Notify(bool fromInput = false)
        {
            NotifyEventArgs args;
            if (fromInput)
                args = new NotifyEventArgs { RaisedByInput = true };
            else
                args = new NotifyEventArgs { RaisedByTimer = true };
            Event?.Invoke(this, args);
        }

        public class NotifyEventArgs : EventArgs
        {
            public bool RaisedByTimer { get; set; } = false;
            public bool RaisedByInput { get; set; } = false;
        }
        #endregion
    }
}