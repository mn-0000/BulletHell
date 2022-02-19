using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Bullet.BulletA
{
    public class BulletA : Bullet
    {

        public BulletA(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Bullet> bullets)
        {
            Position += Direction * LinearVelocity;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }

}
