using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;

namespace TRNBulletHell.Game.Bullet.BulletA
{
    public class BulletA : Bullet
    {
        private double timer;

        public BulletA(Texture2D texture, int bulletDamage) : base(texture)
        {
            movement = new BulletMovement();
         
            movement.speed = new Vector2(4f, 4f);
            damage = bulletDamage;
        }

        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)movement.position.X - 1, (int)movement.position.Y - 1, 5, 5);
            }
        }

        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= life)
            {
                isRemoved = true;
            }

            movement.Moving();
        }

    }

}
