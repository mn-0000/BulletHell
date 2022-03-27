using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Bullet.BulletA
{
    public class BulletA : Bullet
    {
        private double timer;
        private double life;

        public BulletA(Texture2D texture) : base(texture)
        {
            movement = new CirclePath();
            movement.speed = new Vector2(4f, 4f);
            life = 10;
        }

        public override void Update(GameTime gameTime, List<AbstractEntity> entities)
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
