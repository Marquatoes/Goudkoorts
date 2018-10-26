namespace Goudkoorts
{
    public class Empty : ImmovableObject
    {
        public override bool CanBePlaced { get { return false; } }

        public override bool SetMovingObject(MovingObject movingObject) { return false; }
    }
}