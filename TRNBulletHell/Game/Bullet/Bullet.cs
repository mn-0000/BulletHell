using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Bullet
{
    public abstract class Bullet : ICloneable
    {
        // The sprite
        public Texture2D Texture;

        // Where the sprite is and where it's going.
        public Vector2 Position;
        public Vector2 Direction;

        // How fast is it going
        public float LinearVelocity = 1f;

        public Bullet(Texture2D texture)
        {
            Texture = texture;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
