using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet.BulletA;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Enemy.Boss
{
    class MidBoss : Boss
    {

        public float timer;

        public MidBoss(Texture2D texture) : base(texture)
        {
            timer = 0f;
            health = 100;

            this.frequencyOfBullets = 40;
            this.type = "midBoss";
        }

      

        

      
    }
}
