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

        public override void Moving()
        {
            this.position -= direction * speed;
        }
    }
}
