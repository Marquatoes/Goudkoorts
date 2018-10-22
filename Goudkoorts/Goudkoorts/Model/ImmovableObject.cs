using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public abstract class ImmovableObject
    {
        protected MovingObject inUseBy;
        public ImmovableObject Up { get; set; }
        public ImmovableObject Down { get; set; }
        public ImmovableObject Left { get; set; }
        public ImmovableObject Right { get; set; }

        public ImmovableObject()
        {
            
        }
        public MovingObject InUseBy()
        {
            return this.inUseBy;
        }
        public void setUsedBy(MovingObject m)
        {
            this.inUseBy = m;
        }

        public virtual void SetMovingObject(MovingObject movingObject) { }
        public virtual bool CanBePlaced() { return true; }
    }
}