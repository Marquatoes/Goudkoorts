﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Yard : Track
    {
        public override bool CanBePlaced()
        {
            return true;
        }
    }
}