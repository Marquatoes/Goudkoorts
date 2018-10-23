using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Yard : Track
    {
       public Yard()
       {
            this.canBePlaced = true;
       }
        public override void SetMovingObject(MovingObject movingObject)
        {
            if(this.inUseBy == null)
            {
                this.inUseBy = movingObject;
            }
            else
            {
                inUseBy.Move();
                this.inUseBy = movingObject;
            }
        }
    }
}