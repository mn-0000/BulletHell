using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity
{
    public abstract class EntityFactory
    {
        public abstract Enemy.Enemy CreateEnemy(string type, Texture2D texture);
        public abstract Bullet.Bullet CreateBullet(string type, Texture2D texture);
        public abstract Movement CreateMovement(string type);
    }
}