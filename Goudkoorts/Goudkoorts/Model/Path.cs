using Goudkoorts.Model;
using System;
using System.Collections.Generic;

namespace Goudkoorts
{
    public class Path
    {
        public ImmovableObject First { get; private set; }
        public int Score { get; set; }
        public bool BoatIsDocked { get { return _dock.BoatIsDocked; } }
        private int _BoatLocation;
        public int BoatLocation
        {
            get { return _BoatLocation; }
            set
            {
                _BoatLocation = value;
                _BoatLocation = _BoatLocation == 31 ? 0 : _BoatLocation;
            }
        }

        private List<StartingPoint> _startingPoints;
        private List<Switch> _switches;
        private List<Cart> _carts;
        private Dock _dock;

        public Path()
        {
            _startingPoints = new List<StartingPoint>();
            _switches = new List<Switch>();
            _carts = new List<Cart>();
        }

        internal void AddScore()
        {
            Score += 100;
            if (BoatLocation >= 14)
            {
                BoatLocation++;
                if (BoatLocation == 24)
                    _dock.BoatIsDocked = false;
            }
        }

        internal void DockBoat() => _dock.BoatIsDocked = true;

        internal void SetPath(List<List<char>> levelLayout)
        {
            List<List<ImmovableObject>> layout = new List<List<ImmovableObject>>();
            for (int i = 0; i < levelLayout.Count; i++)
            {
                List<ImmovableObject> rowList = new List<ImmovableObject>();
                for (int j = 0; j < levelLayout[i].Count; j++)
                    rowList.Add(GetObject(levelLayout[i][j], i));
                layout.Add(rowList);
            }
            LinkField(layout);
            foreach (Switch s in _switches)
                s.SetLaneDirection(s.Up);
        }

        internal void PlaceCart()
        {
            int placement = RandomNumber.Next(_startingPoints.Count);
            Cart cart = new Cart(_startingPoints[placement]);
            _startingPoints[placement].SetUsedBy(cart);
            _carts.Add(cart);
        }

        public int DebugCartAmount { get { return _carts.Count; } }

        public bool MoveAllCarts()
        {
            foreach (MovingObject c in _carts)
            {
                c.Move();
                if (c.Crashed)
                    return false;
            }
            foreach (MovingObject c in _carts)
            {
                c.ResetMove();
                if (c.Crashed)
                {
                    return false;
                }
            }
            return true;
        }

        public void SwitchOnInput(int input)
        {
            var s = _switches[input];
            s.GetType().GetMethod("SwitchLane").Invoke(s, null);
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
                    _startingPoints.Add(immovableObject as StartingPoint);
                    break;
                case 'E':
                    immovableObject = new DoubleEntranceSwitch();
                    _switches.Add(immovableObject as Switch);
                    break;
                case 'X':
                    immovableObject = new DoubleExitSwitch();
                    _switches.Add(immovableObject as Switch);
                    break;
                case 'Y':
                    immovableObject = new Yard();
                    break;
                case 'D':
                    immovableObject = new Dock(this);
                    _dock = immovableObject as Dock;
                    break;
                case '.':
                    immovableObject = new EndPoint();
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
                        layout[i][j].Up = layout[i - 1][j];
                    if (i != layout.Count - 1 && layout[i + 1].Count > j && layout[i + 1][j] != null)
                        layout[i][j].Down = layout[i + 1][j];
                    if (j < layout[i].Count - 1)
                        layout[i][j].Right = layout[i][j + 1];
                    if (j > 0)
                        layout[i][j].Left = layout[i][j - 1];
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
                    else if (firstToRight is Yard)
                        Console.Write('Y');
                    else if (firstToRight is Empty)
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