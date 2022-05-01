using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;


namespace TRNBulletHell.Game.Entity.Bullet
{
    public class BulletFactory : EntityFactory
    {
        public override Bullet CreateBullet(string type, Texture2D texture, int damage)
        {
            switch (type)
            {
                case "BulletA":
                    return new BulletA.BulletA(texture, damage);
                case "BulletB":
                    return new BulletB.BulletB(texture, damage);
            }
            throw new ArgumentException("Unsupported bullet type");
        }

        public override Enemy.Enemy CreateEnemy(string type, Texture2D texture)
        {
            throw new NotImplementedException();
        }

        public override Movement CreateMovement(string type)
        {
            throw new NotImplementedException();
        }

    }
}