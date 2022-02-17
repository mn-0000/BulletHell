using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TRNBulletHell.Game.Entity
{
    abstract class Entity
    {
        protected Texture2D texture;
        protected Vector2 position;
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