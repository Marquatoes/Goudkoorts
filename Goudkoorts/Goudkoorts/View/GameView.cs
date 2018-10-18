using Goudkoorts.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Goudkoorts.Game;

namespace Goudkoorts
{
    public class GameView
    {
        private GameController _gameController;
        public GameView(GameController gc)
        {
            _gameController = gc;
        }
        public void Update(object sender, UpdateEventArgs args)
        {
            if (args.FieldChanged)
            {
                
            }
            
            Console.WriteLine("Test");
            Console.ReadLine();
        }
    }
}