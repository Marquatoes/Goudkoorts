using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Track : ImmovableObject
    {
        public Track() : base()
        {

        }

        public override bool CanBePlaced()
        {
            return true;
        }
        public override void SetMovingObject(MovingObject movingObject)
        {

        }
        
    }
}