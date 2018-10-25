using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class DoubleEntranceSwitch : Switch
    {
        public DoubleEntranceSwitch()
        {
            
        }

        public override void SetMovingObject(MovingObject movingObject)
        {
            if (this.inUseBy == null && movingObject.currentPosition == this.lane)
            {
                movingObject.currentPosition.setUsedBy(null);
                setUsedBy(movingObject);
            }
            else if (inUseBy != null)
            {
                inUseBy.Move();
            }
        }
    }
}