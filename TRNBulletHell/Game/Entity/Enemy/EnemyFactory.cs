using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy
{
    abstract class EnemyFactory : EntityFactory
    {
        AbstractEntity enemy;
        public abstract AbstractEntity CreateEnemy();
    }
}
