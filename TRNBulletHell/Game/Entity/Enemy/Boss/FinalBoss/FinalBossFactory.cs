using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy.Boss.FinalBoss
{
    class FinalBossFactory : BossFactory
    {
        override
      public Entity CreateEnemy()
        {
            FinalBoss spawn = new FinalBoss();
            return spawn;
        }
    }
}
