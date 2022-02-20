using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;

namespace TRNBulletHell.Game.Bullet
{
    abstract class Bullet : AbstractEntity
    {
        public Bullet(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<AbstractEntity> entities)
        {

        }
    }

}
