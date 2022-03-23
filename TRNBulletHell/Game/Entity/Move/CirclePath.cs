using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    class CirclePath : Movement
    {
       
        public CirclePath()
        
       {
                int start = 320;

                position = new Vector2(0, 0);
                position.X = start;
                position.Y = start;
            
        }
        double radius = 40;
        float angle = 0;

        public override void Moving()
        {
            while (angle <= 360)
            {

                // xn = r * cos(a) and yn = r * sin(a)

                position.X = position.X + (float)(radius * Math.Cos(2 * Math.PI));
                position.Y = position.Y + (float)(radius * Math.Sin(2 * Math.PI));
                angle++;
            }
           
        }


    }
}
