using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy.EnemyB
{
    class EnemyBFactory : EnemyFactory 
    {
        override
      public Entity CreateEnemy()
        {
            EnemyB spawn = new EnemyB();
            return spawn;
        }
    }
}
