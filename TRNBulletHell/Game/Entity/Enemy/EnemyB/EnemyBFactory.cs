using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy.EnemyB
{
    class EnemyBFactory : EnemyFactory 
    {
        override
      public AbstractEntity CreateEnemy()
        {
            EnemyB spawn = new EnemyB();
            return spawn;
        }
    }
}
