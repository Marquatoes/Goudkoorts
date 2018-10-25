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
            canBePlaced = true;
        }

        public override bool CanBePlaced()
        {
            return canBePlaced;
        }
        public override void setCanBePlaced(bool canBePlaced)
        {
            this.canBePlaced = canBePlaced;
        }
        public override void SetMovingObject(MovingObject movingObject)
        {

        }
        
    }
}