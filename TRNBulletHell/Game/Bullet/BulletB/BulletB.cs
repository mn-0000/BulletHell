using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Bullet.BulletB
{
    public class BulletB : Bullet
    {
        public BulletB(Texture2D texture) : base(texture)
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
