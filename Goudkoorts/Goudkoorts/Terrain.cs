using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class ImmovableObject
    {
        protected MovingObject InUseBy { get; set; }
        public ImmovableObject()
        {
            
        }
    }
}