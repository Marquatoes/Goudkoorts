namespace Goudkoorts
{
    public class Yard : Track
    {
        public Yard()
        {
            _CanBePlaced = true;
        }
        public override bool SetMovingObject(MovingObject movingObject)
        {
            if (inUseBy == null)
            {
                movingObject.CurrentPosition.SetUsedBy(null);
                SetUsedBy(movingObject);
                return true;
            }
            else
            {
                bool b = inUseBy.Move(true);
                if (b)
                {
                    movingObject.CurrentPosition.SetUsedBy(null);
                    SetUsedBy(movingObject);
                    return true;
                }
                else
                {
                    if (!inUseBy.Move())
                    {
                        movingObject.Crashed = true;
                    }
                    return true;
                }
            }
        }
    }
}