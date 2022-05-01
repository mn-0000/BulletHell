using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell
{
    class JSONGameObject
    {
        public int ID { get; set; }
        public int Time { get; set; }
        public string EnemyType { get; set; }
        public int EnemyAmount { get; set; }
        public int Interval { get; set; }
        public int BulletRate { get; set; }
        public int Damage { get; set; }
    }
}
