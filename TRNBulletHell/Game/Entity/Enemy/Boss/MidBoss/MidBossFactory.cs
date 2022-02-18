using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy.Boss.MidBoss
{
    class MidBossFactory : BossFactory
    {
        override
      public AbstractEntity CreateEnemy()
        {
            MidBoss spawn = new MidBoss();
            return spawn;
        }
    }
}
