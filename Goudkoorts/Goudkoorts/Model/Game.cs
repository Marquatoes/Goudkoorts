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

        public Game()
        {
            _path = new Path();
            Start();
        }
        public void Start()
        {
            _path.SetPath(Parser.GetLevel(1));
            PlaceCar();
            _path.ShowField();
            System.Threading.Thread.Sleep(3000);
            _path.MoveAllCarts();
            _path.ShowField();
            System.Threading.Thread.Sleep(3000);
            PlaceCar();
            _path.ShowField();
            System.Threading.Thread.Sleep(3000);
            _path.MoveAllCarts();
            _path.ShowField();
            System.Threading.Thread.Sleep(3000);
            PlaceCar();
            _path.ShowField();
            System.Threading.Thread.Sleep(3000);
            _path.MoveAllCarts();
            _path.ShowField();
            System.Threading.Thread.Sleep(3000);
            PlaceCar();
            _path.ShowField();
            System.Threading.Thread.Sleep(3000);
            _path.MoveAllCarts();
            _path.ShowField();
            System.Threading.Thread.Sleep(3000);


        }
        public void PlaceCar()
        {
            _path.PlaceCart();
        }

        #region Observable stuff
        public event EventHandler<UpdateEventArgs> Event;

        public void Notify()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            args.FieldChanged = true;
            Event?.Invoke(this, args);
        }

        public void Notify(UpdateEventArgs args)
        {
            Event?.Invoke(this, args);
        }

        public class UpdateEventArgs : EventArgs
        {
            public bool FieldChanged { get; set; }
            public bool SwitchChanged { get; set; }
        }
        #endregion
    }
}