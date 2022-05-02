using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Bullet
{
    public class BulletA : Bullet
    {
        private double timer;

        public BulletA(Texture2D texture) : base(texture)
        {
           
            movement = new BulletMovement();
            movement.speed = new Vector2(4f, 4f);
            life = 10;
            damage = 10;
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

            this.movement.Moving(gameTime);
        }

    }

}
