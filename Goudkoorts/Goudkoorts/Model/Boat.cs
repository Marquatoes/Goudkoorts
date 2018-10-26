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
            this.CurrentPosition = i;
            this.PreviousPosition = null;
            _isDocked = false;
            _cargo = 0;
        }
        public void AddCargo()
        { 
           if(_isDocked)          
               _cargo++;    
        }
        public override bool Move(bool force)
        {
            CurrentPosition.Left.SetMovingObject(this);
            CurrentPosition = CurrentPosition.Left;
            return true;
        }
    }
}