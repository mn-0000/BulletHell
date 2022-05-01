using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy.Boss
{
    abstract class Boss : Enemy
    {
        public Boss(Texture2D texture) : base(texture)
        {
            this.lifeDrop = false;
        }

    }
}
