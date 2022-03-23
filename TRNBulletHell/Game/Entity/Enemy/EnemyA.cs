using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Bullet.BulletA;

namespace TRNBulletHell.Game.Entity.Enemy
{
    class EnemyA : Enemy
    {
        public float Speed;
        public int Step;
        public BulletA BulletClone;

        public EnemyA(Texture2D texture) : base(texture)
        {
            Speed = 2f;
        }

    


       

    }
}
