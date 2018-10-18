using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Flat : Track
    {
        public Flat() : base()
        {
            
        }
        public override bool CanBePlaced()
        { 
            return true;
        }
        public override void SetMovingObject(MovingObject movingObject)
        {
            if (this.inUseBy == null)
            {
                movingObject.currentPosition.setUsedBy(null);
                setUsedBy(movingObject);
            }
            else
            {
                inUseBy.Move();
            }
        }
    }
}