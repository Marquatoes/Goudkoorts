using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ImmovableObject GetPathFirst()
        {
            return _observable.GetPathFirst();
        }
    }
}
