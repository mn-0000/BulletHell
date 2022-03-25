using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    class AcrossScreen : Movement
    {
        public AcrossScreen()
        {
            position = new Vector2(-100, 100);

        }

        public override void Moving()
        {
            //Moving to the right

            this.position.X += this.speed.X;

            if(this.position.X > this.screenWidth)
            {
                this.speed.X = (-this.speed.X)*2;
            }

            this.outsideWidthBoundary();
        }
    }
}
