using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Bullet.BulletB
{
    public class BulletB : Bullet
    {
        public BulletB(Texture2D texture, int bulletDamage) : base(texture)
        {
            damage = 20;
        }
    }
}
