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
        public Boat()
        {
            _isDocked = false;
            _cargo = 0;
        }
        public void AddCargo()
        { 
           if(_isDocked)          
               _cargo++;    
        }
    }
}