using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Water : ImmovableObject
    {
        public override bool CanBePlaced()
        {
            return canBePlaced;
        }

        public override void SetMovingObject(MovingObject movingObject)
        {
            if(movingObject is Boat)
            {
                this.inUseBy = movingObject;
            }
        }
    }
}