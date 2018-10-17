using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Path
    {
        private List<List<ImmovableObject>> _layout;
        private List<ImmovableObject> _startingPoints;
        private List<ImmovableObject> _switches;
        public ImmovableObject ImmovableObject
        {
            get => default(ImmovableObject);
            set
            {
            }
        }
        public Path()
        {
            _startingPoints = new List<ImmovableObject>();
            _switches = new List<ImmovableObject>();
            _layout = new List<List<ImmovableObject>>();
        }

        internal void setPath(List<List<char>> levelLayout)
        {         
            for (int i = 0; i < levelLayout.Count; i++)
            {
                _layout.Add(new List<ImmovableObject>());
                for (int j = 0; j < levelLayout[i].Count; j++)
                {
                    AddObject(levelLayout[i][j], i);
                }
            }
            LinkField();
        }

        internal void PlaceCar()
        {
            Random random = new Random();
            int placement = random.Next(0, _startingPoints.Count);
            _startingPoints[placement].setUsedBy(new Car());
        }

        private void AddObject(char type, int row)
        {
            ImmovableObject immovableObject;
            switch (type)
            {            
                case '-':
                    immovableObject = new Flat();
                    _layout[row].Add(immovableObject);
                    break;
                case 'S':
                    immovableObject = new StartingPoint();
                    _layout[row].Add(immovableObject);
                    _startingPoints.Add(immovableObject);
                    break;
                case '#':
                    immovableObject = new Switch();
                    _layout[row].Add(immovableObject);
                    _switches.Add(immovableObject);
                    break;
                case 'Y':
                    immovableObject = new Yard();
                    _layout[row].Add(immovableObject);
                    break;
                case 'D':
                    immovableObject = new Shore();
                    _layout[row].Add(immovableObject);
                    break;
                case ' ':
                    immovableObject = new Empty();
                    _layout[row].Add(immovableObject);
                    break;
            } 
        }
        private void LinkField()
        {
            for (int i = 0; i < _layout.Count; i++)
            {
                for (int j = 0; j < _layout[i].Count; j++)
                {
                    if (i != 0 && _layout[i - 1].Count > j && _layout[i - 1][j] != null)
                    {
                        _layout[i][j].Up = _layout[i - 1][j];
                    }
                    if (i != _layout.Count - 1 && _layout[i + 1].Count > j && _layout[i + 1][j] != null)
                    {
                        _layout[i][j].Down = _layout[i + 1][j];
                    }
                    if (j < _layout[i].Count - 1)
                    {
                        _layout[i][j].Right = _layout[i][j + 1];
                    }
                    if (j > 0)
                    {
                        _layout[i][j].Left = _layout[i][j - 1];
                    }
                }

            }
        }
        public void ShowField()
        {
            Console.Clear();
            for (ImmovableObject first = _layout[0][0]; first != null; first = first.Down)
            {
                for (ImmovableObject firstToRight = first; firstToRight != null; firstToRight = firstToRight.Right)
                {
                    if (firstToRight is Flat)
                        Console.Write('-');
                    else if(firstToRight is Yard)
                        Console.Write('Y');
                    else if(firstToRight is Empty)
                    {
                        Console.Write(' ');
                    }
                    else if (firstToRight is StartingPoint)
                    {
                        if (firstToRight.InUseBy() is Car)
                            Console.Write('C');
                        else
                            Console.Write('S');
                    }
                    else if (firstToRight is Shore)
                    {
                        Console.Write('D');
                    }
                    else if (firstToRight is Switch)
                    {
                        Console.Write('#');
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}  