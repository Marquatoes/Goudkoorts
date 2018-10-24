using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Path
    {
        public ImmovableObject First;
        private List<ImmovableObject> _startingPoints;
        private List<ImmovableObject> _switches;
        private List<MovingObject> _carts;

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
            _carts = new List<MovingObject>();
        }

        internal void SetPath(List<List<char>> levelLayout)
        {
            List<List<ImmovableObject>> layout = new List<List<ImmovableObject>>();
            for (int i = 0; i < levelLayout.Count; i++)
            {
                List<ImmovableObject> rowList = new List<ImmovableObject>();
                for (int j = 0; j < levelLayout[i].Count; j++)
                {
                    rowList.Add(GetObject(levelLayout[i][j], i));
                }
                layout.Add(rowList);
            }
            LinkField(layout);
            foreach(Switch s in _switches)
            {
                s.SetLaneDirection(s.Up);
            }
            
        }

        internal void PlaceCart()
        {
            Random random = new Random();
            int placement = random.Next(0, _startingPoints.Count);
            MovingObject cart = new Cart(_startingPoints[placement]);
            _startingPoints[placement].setUsedBy(cart);
            _carts.Add(cart);
            
        }

        internal ImmovableObject GetFirst()
        {
            return First;
        }

        public void MoveAllCarts()
        {
            foreach(MovingObject c in _carts)
            {
                c.Move();
            }
        }

        private ImmovableObject GetObject(char type, int row)
        {
            ImmovableObject immovableObject = null;
            switch (type)
            {            
                case '-':
                    immovableObject = new Flat();
                    break;
                case 'S':
                    immovableObject = new StartingPoint();
                    _startingPoints.Add(immovableObject);
                    break;
                case '#':
                    immovableObject = new Switch();
                    _switches.Add(immovableObject);
                    break;
                case 'Y':
                    immovableObject = new Yard();
                    break;
                case 'D':
                    immovableObject = new Dock();
                    break;
                case ' ':
                    immovableObject = new Empty();
                    break;
            }
            return immovableObject ?? null;
        }
        private void LinkField(List<List<ImmovableObject>> layout)
        {
            First = layout[0][0];
            for (int i = 0; i < layout.Count; i++)
            {
                for (int j = 0; j < layout[i].Count; j++)
                {
                    if (i != 0 && layout[i - 1].Count > j && layout[i - 1][j] != null)
                    {
                        layout[i][j].Up = layout[i - 1][j];
                    }
                    if (i != layout.Count - 1 && layout[i + 1].Count > j && layout[i + 1][j] != null)
                    {
                        layout[i][j].Down = layout[i + 1][j];
                    }
                    if (j < layout[i].Count - 1)
                    {
                        layout[i][j].Right = layout[i][j + 1];
                    }
                    if (j > 0)
                    {
                        layout[i][j].Left = layout[i][j - 1];
                    }
                }

            }
        }

        public void ShowField()
        {
            Console.Clear();
            for (ImmovableObject first = First; first != null; first = first.Down)
            {
                for (ImmovableObject firstToRight = first; firstToRight != null; firstToRight = firstToRight.Right)
                {
                    if (firstToRight is Flat)
                    {
                        if (firstToRight.InUseBy() is Cart)
                            Console.Write('C');
                        else
                            Console.Write('-');
                    }
                    else if(firstToRight is Yard)
                        Console.Write('Y');
                    else if(firstToRight is Empty)
                    {
                        Console.Write(' ');
                    }
                    else if (firstToRight is StartingPoint)
                    {
                        if (firstToRight.InUseBy() is Cart)
                            Console.Write('C');
                        else
                            Console.Write('S');
                    }
                    else if (firstToRight is Dock)
                    {
                        Console.Write('D');
                    }
                    else if (firstToRight is Switch)
                    {
                        if (firstToRight.InUseBy() is Cart)
                            Console.Write('C');
                        else
                            Console.Write('#');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}  