﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy
{
    abstract class Enemy : AbstractEntity
    {
     
        public Enemy(Texture2D texture) :base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<AbstractEntity> entities)
        {

        }
    }
}
