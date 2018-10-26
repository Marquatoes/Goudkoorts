namespace Goudkoorts
{
    public class DoubleEntranceSwitch : Switch
    {
        public DoubleEntranceSwitch() { }

        public override void SwitchLane()
        {
            if (_lane == Up)
            {
                _lane = Down;
            }
            else
            {
                _lane = Up;
            }
        }

        public override bool SetMovingObject(MovingObject movingObject)
        {
            if (inUseBy == null && movingObject.CurrentPosition == _lane)
            {
                movingObject.CurrentPosition.SetUsedBy(null);
                SetUsedBy(movingObject);
                return true;
            }
            else if (inUseBy != null && movingObject.CurrentPosition == _lane)
            {
                if (!inUseBy.Move())
                {
                    movingObject.Crashed = true;
                    return false;
                }
                movingObject.CurrentPosition.SetUsedBy(null);
                SetUsedBy(movingObject);
                return true;

            }
            return false;
        }
    }
}