using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    class CirclePath : Movement
    {
        double radius = 100;
        float angle = 0;
        float originX = 300;
        float originY = 175;
        public CirclePath()
    
       {
            position = new Vector2(300, 0);

        }
        

        public override void Moving()
        {
                 
     
                  position.X = originX + (float)(radius * Math.Cos(angle));
                  position.Y = originY + (float)(radius * Math.Sin(angle));
                  angle = (float)(angle + 0.03);
           

        }
    }
}