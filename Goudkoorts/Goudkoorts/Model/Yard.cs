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
                inUseBy = movingObject;
                return true;
            }
            else
            {
                bool b = inUseBy.Move();
                if(b)
                    inUseBy = movingObject;
                return b;
            }
        }
    }
}