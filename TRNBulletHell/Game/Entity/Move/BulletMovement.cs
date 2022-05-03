using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    public class BulletMovement : Movement
    {
        public float testSpeed = 5f;

        public BulletMovement()
        {
            
        }
    
        public override void Moving(GameTime gameTime)
        {
            //this.position -= this.direction * this.speed;
            this.position -= this.direction * testSpeed;
        }

      
    }
}
