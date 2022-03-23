using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Bullet.BulletA;

namespace TRNBulletHell.Game.Entity.Enemy.Boss
{
    class MidBoss : Boss
    {
        public float Speed;
        public int Step;
        public BulletA BulletClone;
        public float timer;

        public MidBoss(Texture2D texture) : base(texture)
        {
            timer = 0f;
            Speed = 2f;
        }

      

        

      
    }
}
