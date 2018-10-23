using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    
    public class Cart : MovingObject
    {
        private bool _isFull;
        private bool _crashed;
        public Cart(ImmovableObject i) : base(i)
        {
            this.currentPosition = i;
            this.previousPosition = null;
            _isFull = true;
        }

        public override void Move()
        {
            if (_moved)
            {
                _crashed = true;
                return;
            }

            if (currentPosition.Down.CanBePlaced() && currentPosition.Down != previousPosition)
            {
                currentPosition.Down.SetMovingObject(this);
                currentPosition = currentPosition.Down;
                previousPosition = currentPosition;
            }
            else if (currentPosition.Up.CanBePlaced() && currentPosition.Up != previousPosition)
            {
                currentPosition.Up.SetMovingObject(this);
                currentPosition = currentPosition.Up;
                previousPosition = currentPosition;
            }
            else if (currentPosition.Right.CanBePlaced() && currentPosition.Right != previousPosition)
            {
                currentPosition.Right.SetMovingObject(this);
                currentPosition = currentPosition.Right;
                previousPosition = currentPosition;
            }
            else if (currentPosition.Down.CanBePlaced() && currentPosition.Left != previousPosition)
            {
                currentPosition.Left.SetMovingObject(this);
                currentPosition = currentPosition.Left;
                previousPosition = currentPosition;
            }
            _moved = true;
        }

        public bool Unload()
        {    
            if(_isFull == false)
            {
                return false;
            }
            _isFull = false;
            return true;
        }
        public override bool crashed()
        {
            return this._crashed;
        }
    }
}