using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    public class BulletMovement : Movement
    {
        public BulletMovement()
        {
            
        }

        public override void Moving()
        {
            this.position -= direction * speed;
        }
    }
}
