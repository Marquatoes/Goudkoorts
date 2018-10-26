namespace Goudkoorts.Model
{
    public class EndPoint : Flat
    {
        public override bool SetMovingObject(MovingObject movingObject)
        {
            movingObject.CurrentPosition.SetUsedBy(null);
            return true;
        }
    }
}
