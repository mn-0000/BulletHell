﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy.EnemyA
{
    class EnemyAFactory : EnemyFactory
    {
        override
        public AbstractEntity CreateEnemy()
        {
            EnemyA spawn = new EnemyA();
            return spawn;
        }
    }
}
