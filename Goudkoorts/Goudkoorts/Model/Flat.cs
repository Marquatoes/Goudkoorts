namespace Goudkoorts
{
    public class Flat : Track
    {
        public Flat() : base()
        {
            this._CanBePlaced = true;
        }
        public override bool CanBePlaced { get { return this._CanBePlaced; } }
        public override bool SetMovingObject(MovingObject movingObject)
        {
            if (inUseBy == null)
            {
                movingObject.CurrentPosition.SetUsedBy(null);
                SetUsedBy(movingObject);
                return true;
            }
            else
                return inUseBy.Move();
        }
    }
}