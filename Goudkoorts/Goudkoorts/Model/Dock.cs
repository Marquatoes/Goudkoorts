using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Dock : Track
    {
        private Boat boat;
        public Dock()
        {
            boat = null;
        }
        public override bool CanBePlaced()
        {
            return true;
        }
        public override void SetMovingObject(MovingObject movingObject)
        {
            if(movingObject is Cart && boat != null)
            {
                Cart cart = (Cart)movingObject;
                if (cart.Unload())
                {
                    boat.AddCargo();
                }
            }
        }
        public void addBoat(Boat boat)
        {
            this.boat = boat;
        }
    }
}