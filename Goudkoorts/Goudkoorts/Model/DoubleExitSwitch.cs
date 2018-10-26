namespace Goudkoorts
{
    public class DoubleExitSwitch : Switch
    {
        public DoubleExitSwitch() { }

        public override void SwitchLane()
        {
            if (_lane == Up)
            {
                _lane.CanBePlaced = false;
                _lane = Down;
            }
            else
            {
                _lane.CanBePlaced = false;
                _lane = Up;
            }
            _lane.CanBePlaced = true;
        }

        public override bool SetMovingObject(MovingObject movingObject)
        {
            if (inUseBy == null)
            {
                movingObject.CurrentPosition.SetUsedBy(null);
                SetUsedBy(movingObject);
                return true;
            }
            else if (inUseBy != null)
                return inUseBy.Move();
            return false;
        }
        public override void SetLaneDirection(ImmovableObject i)
        {
            base.SetLaneDirection(i);
            if (_lane == Up)
                Down.CanBePlaced = false;
            else
                Up.CanBePlaced = false;
        }
    }
}