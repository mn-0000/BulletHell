using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game
{
    public class RootObject
    {
        public Waves waves { get; set; }
    }

    public class Waves
    {
        public Wave[] wave { get; set; }
    }

    public class Wave
    {
        public int waveTime { get; set; }
        public string enemyType { get; set; }
        public int enemyAmount { get; set; }
        public int spawnInterval { get; set; }
        public int bulletRate { get; set; }
        public int damage { get; set; }
    }
}
