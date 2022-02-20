using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TRNBulletHell.Game.Entity
{
    public abstract class AbstractEntity : ICloneable
    {
        protected Texture2D texture;
        public Vector2 position;
        public Vector2 origin;
        public Vector2 direction;
        protected float Xposition;
        protected float Yposition;
        public float speed = 2f;
        public bool isRemoved = false;
        public int counter = 0;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        public AbstractEntity(Texture2D image)
        {
            texture = image;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0, origin, 1, SpriteEffects.None, 0);
        }

        public virtual void Update(GameTime gameTime, List<AbstractEntity> entities)
        {

        }

        public Vector2 getPosition()
        {
            return this.position;
        }

        public Texture2D getImage()
        {
            return this.texture;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}