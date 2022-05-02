using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Enemy.Boss
{
    class FinalBoss : Boss
    {
       /* public float Speed;

        public int Step;
        public BulletA BulletClone;
        public float timer;*/

        public FinalBoss(Texture2D texture) : base(texture)
        {
          //  timer = 0f;
         //   Speed = 2f;
            health = 300;

            this.frequencyOfBullets = 15;
            this.type = "finalBoss";
        }
    }
}
