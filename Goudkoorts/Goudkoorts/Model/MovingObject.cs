using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public abstract class MovingObject
    {
        public ImmovableObject CurrentPosition { get; set; }
        public ImmovableObject PreviousPosition { get; set; }
        protected bool _moved;

        protected MovingObject(ImmovableObject i)
        {
            this.CurrentPosition = i;
            this.PreviousPosition = null;
            this._moved = false;
        }
        public abstract bool Move(bool force = false);

        internal void ResetMove()
        {
            _moved = false;
        }
        public virtual bool Crashed { get; set; }
    }
}