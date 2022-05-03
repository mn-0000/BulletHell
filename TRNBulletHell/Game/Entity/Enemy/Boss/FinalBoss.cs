using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Enemy.Boss
{
    class FinalBoss : Boss
    {

        public FinalBoss(Texture2D texture) : base(texture)
        {
            health = 300;

            this.frequencyOfBullets = 15;
            this.type = "finalBoss";

        }
        public FinalBoss(Texture2D texture, int bulletFrequency) : base(texture)
        {
            health = 300;

            this.frequencyOfBullets = bulletFrequency;
            this.type = "finalBoss";

        }
    }
}
