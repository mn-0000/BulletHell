using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    class BulletRope : Movement
    {
        double radius = 80;
        float angle = 0;
        float originX = 500;
        float originY = 60;


        public BulletRope()

        {
            position = new Vector2(500, 100);

        }


        public override void Moving(GameTime gameTime)
        {

            if (angle < 2)
            {
                position.X = originX + (float)(radius * Math.Cos(angle));
                position.Y = originY + (float)(radius * Math.Sin(angle));
                angle = (float)(angle + .01);

            }
            else if (angle >= 2)
            {
                this.completedMovement();
            }
        }

    }


}
