using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    class CirclePath : Movement
    {
        double radius = 80;
        float angle = 0;
        float originX = 300;
        float originY = 75;
        public CirclePath()

        {
            position = new Vector2(700, 75);

        }


        public override void Moving()
        {

            // Enter Screen
            if (this.position.X > 401)
            {
                this.position.X -= this.speed.X;
            }
            //Exit Screen
            else if (angle >= 10)
            {
                this.position.X -= this.speed.X;
            }
            //Circle
            else
            {
                position.X = originX + (float)(radius * Math.Cos(angle));
                position.Y = originY + (float)(radius * Math.Sin(angle));
                angle = (float)(angle + 0.03);

            }
            this.outsideWidthBoundary();
        }
    }
}