using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Switch : Track
    {
        private ImmovableObject lane;
        public Switch() : base()
        {
            
        }
        public override void SetMovingObject(MovingObject movingObject)
        {
            if (this.inUseBy == null && movingObject.currentPosition == lane)
            {
                movingObject.currentPosition.setUsedBy(null);
                setUsedBy(movingObject);
            }
            else if(inUseBy != null)
            {
                inUseBy.Move();
            }
        }
        public void SwitchLane()
        {
            if(lane == this.Up)
            {
                lane = this.Down;
            }
            else
            {
                lane = this.Up;
            }
        }
        public void SetLaneDirection(ImmovableObject i)
        {
            this.lane = i;
        }

    }
}