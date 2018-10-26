namespace Goudkoorts
{
    public class Dock : Track
    {
        private readonly Path _path;
        public bool BoatIsDocked { get; set; }
        public Dock(Path p)
        {
            _path = p;
        }
        public override bool CanBePlaced { get { return true; } }
        public override bool SetMovingObject(MovingObject movingObject)
        {
            if (movingObject is Cart cart && BoatIsDocked)
                if (cart.Unload())
                    _path.AddScore();

            if (inUseBy == null)
            {
                movingObject.CurrentPosition.SetUsedBy(null);
                SetUsedBy(movingObject);
                return true;
            }
            else
                return false;
        }
    }
}