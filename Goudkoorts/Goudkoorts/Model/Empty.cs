using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Empty : ImmovableObject
    {
        public override bool CanBePlaced()
        {
            return false;
        }

        public override void SetMovingObject(MovingObject movingObject)
        {
            
        }
    }
}