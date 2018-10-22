using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class DoubleExitSwitch : Switch
    {
        public DoubleExitSwitch()
        {

        }
        public override void SwitchLane()
        {
            if (lane == this.Up)
            {
                lane.setCanBePlaced(false);
                lane = this.Down;   
            }
            else
            {
                lane.setCanBePlaced(false);
                lane = this.Up;
            }
            lane.setCanBePlaced(true);
        }

        public override void SetMovingObject(MovingObject movingObject)
        {
            if (this.inUseBy == null)
            {
                movingObject.currentPosition.setUsedBy(null);
                setUsedBy(movingObject);
            }
            else if (inUseBy != null)
            {
                inUseBy.Move();
            }
        }
        public override void SetLaneDirection(ImmovableObject i)
        {
            base.SetLaneDirection(i);
            if(lane == this.Up)
            {
                this.Down.setCanBePlaced(false);
            }
            else
            {
                this.Up.setCanBePlaced(false);
            }
        }
    }
}