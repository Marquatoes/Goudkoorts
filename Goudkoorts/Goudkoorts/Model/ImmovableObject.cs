using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public abstract class ImmovableObject
    {
        protected MovingObject inUseBy;
        protected bool _CanBePlaced;
        public ImmovableObject Up { get; set; }
        public ImmovableObject Down { get; set; }
        public ImmovableObject Left { get; set; }
        public ImmovableObject Right { get; set; }

        public ImmovableObject() { }

        public MovingObject InUseBy()
        {
            return this.inUseBy;
        }
        public void SetUsedBy(MovingObject m)
        {
            this.inUseBy = m;
        }
        public virtual void SetCanBePlaced(bool canBePlaced)
        {
            this._CanBePlaced = canBePlaced;
        }

        public virtual bool SetMovingObject(MovingObject movingObject) { return true; }
        public virtual bool CanBePlaced { get { return _CanBePlaced; }set { _CanBePlaced = value; } }
    }
}