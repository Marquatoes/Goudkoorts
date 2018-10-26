namespace Goudkoorts
{
    public class Water : ImmovableObject
    {
        public override bool CanBePlaced { get { return _CanBePlaced; } }

        public override bool SetMovingObject(MovingObject movingObject)
        {
            if (movingObject is Boat)
            {
                this.inUseBy = movingObject;
                return true;
            }
            return false;
        }
    }
}