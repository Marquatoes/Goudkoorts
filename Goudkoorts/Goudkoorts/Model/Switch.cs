using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public abstract class Switch : Track
    {
        protected ImmovableObject lane;
        public Switch() : base()
        {
            
        }
        public override abstract void SetMovingObject(MovingObject movingObject);
        public virtual void SwitchLane()
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
        public virtual void SetLaneDirection(ImmovableObject i)
        {
            this.lane = i;
        }

        public ImmovableObject Lane { get { return this.lane; } }
    }
}