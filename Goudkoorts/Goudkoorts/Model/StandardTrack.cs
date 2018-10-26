namespace Goudkoorts
{
    public class StandardTrack : Track
    {
        public StandardTrack() : base()
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
            {
                if (!inUseBy.Move())
                {
                    inUseBy.Crashed = true;
                }
                movingObject.CurrentPosition.SetUsedBy(null);
                SetUsedBy(movingObject);
                return true;
            }
        }
    }
}