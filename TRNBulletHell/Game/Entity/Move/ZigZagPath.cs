using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    class ZigZagPath : Movement
    {
        public ZigZagPath()
        {
            position = new Vector2(-10, 0);

        }
        float topBoundary = 0;
        float bottomBoundary = 150;
        float midBoundary = 500;


        public override void Moving(GameTime gameTime)
        {
            this.position.X += this.speed.X;
            this.position.Y += this.speed.Y;
            if (position.Y == this.topBoundary )
            {
                this.speed.Y = -this.speed.Y;

            }

           else if(position.X == this.bottomBoundary)
            {
                this.speed.Y = -this.speed.Y;
            }

           else if (position.X == this.midBoundary)
            {
                this.speed.Y = -this.speed.Y;
            }

            this.outsideWidthBoundary();
        }
    }
}
