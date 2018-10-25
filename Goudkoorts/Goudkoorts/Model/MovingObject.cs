using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public abstract class MovingObject
    {
        public ImmovableObject currentPosition { get; set; }
        public ImmovableObject previousPosition { get; set; }
        protected bool _moved;

        protected MovingObject(ImmovableObject i)
        {
            this.currentPosition = i;
            this.previousPosition = null;
            this._moved = false;
        }
        public abstract void Move();

        internal void resetMove()
        {
            _moved = false;
        }
        public virtual bool crashed()
        {
            return false;
        }
    }
}