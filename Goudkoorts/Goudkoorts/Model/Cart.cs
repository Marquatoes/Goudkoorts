namespace Goudkoorts
{

    public class Cart : MovingObject
    {
        public override bool Crashed { get; set; }
        public Cart(ImmovableObject i) : base(i)
        {
            CurrentPosition = i;
            PreviousPosition = null;
            IsFull = true;
        }

        public bool IsFull { get; private set; }

        public override bool Move(bool force = false)
        {
            if (_moved)
            {
                Crashed = true;
            }

            if(CurrentPosition is Yard && !force)
            {
                return false;
            }

            if (CurrentPosition.Down != null
                && CurrentPosition.Down.CanBePlaced
                && CurrentPosition.Down != PreviousPosition
                && !(CurrentPosition is DoubleEntranceSwitch))
            {
                if (CurrentPosition.Down.SetMovingObject(this))
                {
                    PreviousPosition = CurrentPosition;
                    CurrentPosition = CurrentPosition.Down;

                    _moved = true;
                    return true;
                }
            }
            else if (CurrentPosition.Up != null
                && CurrentPosition.Up.CanBePlaced
                && CurrentPosition.Up != PreviousPosition
                && !(CurrentPosition is DoubleEntranceSwitch))
            {
                if (CurrentPosition.Up.SetMovingObject(this))
                {
                    PreviousPosition = CurrentPosition;
                    CurrentPosition = CurrentPosition.Up;
                    
                    _moved = true;
                    return true;
                }
            }
            else if (CurrentPosition.Right != null
                && CurrentPosition.Right.CanBePlaced
                && CurrentPosition.Right != PreviousPosition
                && !(CurrentPosition is DoubleExitSwitch))
            {
                if (CurrentPosition.Right.SetMovingObject(this))
                {
                    PreviousPosition = CurrentPosition;
                    CurrentPosition = CurrentPosition.Right;

                    _moved = true;
                    return true;
                }
            }
            else if (CurrentPosition.Left != null
                && CurrentPosition.Left.CanBePlaced
                && CurrentPosition.Left != PreviousPosition
                && !(CurrentPosition is DoubleExitSwitch))
            {
                if (CurrentPosition.Left.SetMovingObject(this))
                {
                    PreviousPosition = CurrentPosition;
                    CurrentPosition = CurrentPosition.Left;

                    _moved = true;
                    return true;
                }
            }
            _moved = true;
            return false;
        }

        public bool Unload()
        {
            if (IsFull == false)
                return false;
            IsFull = false;
            return true;
        }
    }
}