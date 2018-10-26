namespace Goudkoorts.Model
{
    public class EndPoint : StandardTrack
    {
        public override bool SetMovingObject(MovingObject movingObject)
        {
            movingObject.CurrentPosition.SetUsedBy(null);
            return true;
        }
    }
}
