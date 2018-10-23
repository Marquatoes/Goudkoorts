﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Flat : Track
    {
        public Flat() : base()
        {
            this.canBePlaced = true;
        }
        public override bool CanBePlaced()
        { 
            return this.canBePlaced;
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