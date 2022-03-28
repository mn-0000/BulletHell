using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace TRNBulletHell.Game.Entity
{
    public abstract class AbstractEntity : ICloneable
    {
        protected Texture2D texture;
        public bool isRemoved = false;
        public int counter = 0;
        public Movement movement;
        
        public virtual Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)movement.position.X, (int)movement.position.Y, texture.Width - 20, texture.Height - 20);
            }
        }

        public AbstractEntity(Texture2D image)
        {
            texture = image;

        }

        public AbstractEntity(GraphicsDevice graphics,Texture2D image)
        {
            texture = image;

        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, movement.position, null, Color.White, movement._rotation, new Vector2(texture.Width/2,texture.Height/2), 1, SpriteEffects.None, 0);
        }

        public virtual void Update(GameTime gameTime, List<AbstractEntity> entities)
        {

        }

        public Texture2D getImage()
        {
            return this.texture;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Boolean Removed()
        {
            return this.isRemoved;
        }

        internal void Update(GameTime gameTime, List<Bullet.Bullet> playerBullets)
        {
            throw new NotImplementedException();
        }
    }
}