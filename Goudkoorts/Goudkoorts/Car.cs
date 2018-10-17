using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    
    public class Car : MovingObject
    {
        private bool _isFull;
        public Car()
        {
            _isFull = true;
        }
        public void Unload()
        {
            _isFull = false;
        }
    }
}