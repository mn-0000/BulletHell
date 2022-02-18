using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy.EnemyA
{
    class EnemyA : Enemy
    {
        public float Speed;

        public EnemyA(Texture2D texture) { 
         
            this.texture = texture;
        
       
            Speed = 2f;
        }
        public EnemyA()
        {

        }
        public void firstAttack()
        {

            if (this.position.X < 230)
            {
                this.position.X += Speed;
            }
            else if (this.position.Y < 150)
            {
                this.position.Y += Speed;
            }
            else if (this.position.X < 375)
            {
                this.position.X += Speed;
            }
            else if (this.position.Y < 300)
            {
                this.position.Y += Speed;
            }
            else if (this.position.X < 750)
            {
                this.position.X += Speed;
            }

            /*Cant move the enemy up or left.
             * 
             * else if (this.position.Y > 500){
             *      this.position.Y -= Speed
             * }
             * 
             */
            
        }
    }
}
