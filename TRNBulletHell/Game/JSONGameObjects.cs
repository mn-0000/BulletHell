using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game
{
    /// <summary>
    /// Class representing the root object of the JSON file.
    /// Contains a Stage object.
    /// </summary>
    public class RootObject
    {
        public Stage stage { get; set; }
    }

    /// <summary>
    /// Class representing a stage object.
    /// Contains an array of waves.
    /// </summary>
    public class Stage
    {
        public Wave[] wave { get; set; }
    }

    /// <summary>
    /// Class representing a wave object.
    /// Contains the details of a wave.
    /// </summary>
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
