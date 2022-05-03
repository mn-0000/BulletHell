using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    class FinalBossBullet : Movement
    {
        double radius = 50;
        float angle = 0;
        float originX = 500;
        float originY = 60;


        public FinalBossBullet()
        {
            position = new Vector2(-100, 100);

        }


        public override void Moving(GameTime gameTime)
        {

            if (this.position.X == 500)
            {
                this.completedMovement();


            }
            else
            {
                this.position.X += this.speed.X;
            }
        }
    
    }
}
