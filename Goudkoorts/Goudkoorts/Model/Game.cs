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
            //PlaceCart();
            //_path.ShowField();
            //Notify();
            //System.Threading.Thread.Sleep(3000);
            //_path.MoveAllCarts();
            //_path.ShowField();
            //Notify();
            //System.Threading.Thread.Sleep(3000);
            //PlaceCart();
            //_path.ShowField();
            //Notify();
            //System.Threading.Thread.Sleep(3000);
            //_path.MoveAllCarts();
            //_path.ShowField();
            //Notify();
            //System.Threading.Thread.Sleep(3000);
            //PlaceCart();
            //_path.ShowField();
            //Notify();
            //System.Threading.Thread.Sleep(3000);
            //_path.MoveAllCarts();
            //_path.ShowField();
            //Notify();
            //System.Threading.Thread.Sleep(3000);
            //PlaceCart();
            //_path.ShowField();
            //System.Threading.Thread.Sleep(3000);
            //_path.MoveAllCarts();
            //_path.ShowField();
            //Notify();
            //System.Threading.Thread.Sleep(3000);

            Test();
        }

        private void Test()
        {
            Notify();
            Console.ReadLine();
            Test();
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