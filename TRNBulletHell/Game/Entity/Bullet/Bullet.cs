using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;

namespace TRNBulletHell.Game.Entity.Bullet
{
    public abstract class Bullet : AbstractEntity
    {
        protected float life = 0f;
        protected int damage = 0;

        public Bullet(Texture2D texture) : base(texture)
        {

        }

        public Bullet(Texture2D texture, int bulletDamage) : base(texture)
        {
            damage = bulletDamage;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public int GetDamage()
        {
            return damage;
        }

    }

}
