using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Boat : MovingObject
    {
        private bool _isDocked;
        private int _cargo;
        public Boat(ImmovableObject i) : base(i)
        {
            this.currentPosition = i;
            this.previousPosition = null;
            _isDocked = false;
            _cargo = 0;
        }
        public void AddCargo()
        { 
           if(_isDocked)          
               _cargo++;    
        }
        public override void Move()
        {
            currentPosition.Left.SetMovingObject(this);
            currentPosition = currentPosition.Left;
        }
    }
}