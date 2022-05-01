using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game
{
    public class JSONGameObject
    {
        public int Time { get; set; } // maximum time alloted for the wave
        public string EnemyType { get; set; } // enemy type of the wave
        public int EnemyAmount { get; set; } // number of enemies in the wave
        public int Interval { get; set; } // amount of time to wait between each enemy spawn
        public int BulletRate { get; set; } // rate at which the enemy(ies) would spawn bullets
        public int Damage { get; set; } // damage of each bullet
    }
}
