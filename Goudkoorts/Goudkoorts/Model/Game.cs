using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Game
    {
        private Parser _parser;
        private Path _path;

        public Path Path
        {
            get => default(Path);
            set
            {
            }
        }

        public Player Player
        {
            get => default(Player);
            set
            {
            }
        }

        public Parser Parser
        {
            get => default(Parser);
            set
            {
            }
        }
        public Game()
        {
            _parser = new Parser();
            _path = new Path();
        }
        public void Start()
        {
            _path.setPath(_parser.GetLevel(1));
            PlaceCar();
            _path.ShowField();
            
        }
        public void PlaceCar()
        {
            _path.PlaceCar();
        }
    }
}