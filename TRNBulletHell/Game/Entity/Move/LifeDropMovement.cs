using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    public class LifeDropMovement : Movement
    {
        public LifeDropMovement()
        {
            
        }

        public override void Moving(GameTime gameTime)
        {
            this.position -= direction * speed;
        }
    }
}
