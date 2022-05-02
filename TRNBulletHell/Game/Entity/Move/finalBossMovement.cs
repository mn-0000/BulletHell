using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    class finalBossMovement : Movement
    {
   
        float countDuration = 30f; //every  2s.
        float currentTime = 0f;
        public finalBossMovement()
        {
            position = new Vector2(-100, 100);

        }

        public override void Moving(GameTime gameTime)
        {
            //Moving to the right

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds; //Time passed since last Update() 


            if (this.position.X == 400)
            {
                //StartTimer;   
                if (currentTime >= countDuration)
                {
                    this.position.X += this.speed.X;
                }
         
            }
            else
            {
                this.position.X += this.speed.X;
            }
            this.outsideWidthBoundary();
        }
    }
}




