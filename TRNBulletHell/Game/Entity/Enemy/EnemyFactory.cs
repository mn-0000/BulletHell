using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Enemy.Boss;

namespace TRNBulletHell.Game.Entity.Enemy
{
    public class EnemyFactory : EntityFactory
    {
        public override Bullet.Bullet CreateBullet(string type, Texture2D texture)
        {
            throw new NotImplementedException();
        }

        public override Enemy CreateEnemy(string type, Texture2D texture)
        {
            switch (type)
            {
                case "EnemyA":
                    return new EnemyA(texture);
                case "EnemyB":
                    return new EnemyB(texture);
                case "MidBoss":
                    return new MidBoss(texture);
                case "FinalBoss":
                    return new FinalBoss(texture);
                default:
                    throw new ArgumentException("Unexpected enemy type");
            }
            
        }

        public override Movement CreateMovement(string type)
        {
            throw new NotImplementedException();
        }
    }
}
