using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Dock : ImmovableObject
    {
        public override bool CanBePlaced()
        {
            throw new NotImplementedException();
        }

        public override void SetMovingObject(MovingObject movingObject)
        {
            throw new NotImplementedException();
        }
    }
}