namespace Goudkoorts
{
    public abstract class Switch : Track
    {
        protected ImmovableObject _lane;
        public ImmovableObject Lane { get { return _lane; } set { _lane = value; } }

        public Switch() : base() { }

        public override abstract bool SetMovingObject(MovingObject movingObject);

        public virtual void SwitchLane() { }

        public virtual void SetLaneDirection(ImmovableObject i) => Lane = i;
    }
}