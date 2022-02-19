using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TRNBulletHell.Game.Entity
{
    public abstract class AbstractEntity
    {
        protected Texture2D texture;
        public Vector2 position;
        public Vector2 origin;
        public Vector2 direction;
        protected float Xposition;
        protected float Yposition;

        public Vector2 getPosition()
        {
            return this.position;
        }

        public Texture2D getImage()
        {
            return this.texture;
        }
    }
}