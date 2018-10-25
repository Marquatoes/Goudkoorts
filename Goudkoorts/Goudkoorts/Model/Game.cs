using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public bool BoatIsAtDock
        {
            get
            {
                return false;
            }
            set
            {

            }
        }

        public Game()
        {
            _path = new Path();
        }
        public void Start()
        {
            _path.SetPath(Parser.GetLevel(1));
            for (int i = 0; i < 10; i++)
            {
                PlaceCart();
                _path.ShowField();
                System.Threading.Thread.Sleep(3000);
                if(!_path.MoveAllCarts())
                {
                    //Show GameOver Screen.
                }
                _path.ShowField();
                System.Threading.Thread.Sleep(3000);
                Notify();
            }            
            
        }

        internal ImmovableObject GetPathFirst()
        {
            return _path.GetFirst();
        }

        public void PlaceCart()
        {
            _path.PlaceCart();
        }

        #region Observable stuff
        public event EventHandler<EventArgs> Event;

        public void Notify()
        {
            EventArgs args = new EventArgs();
            Event?.Invoke(this, args);
        }
        #endregion
    }
}