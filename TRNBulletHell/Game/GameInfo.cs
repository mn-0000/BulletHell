using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game
{
    public static class GameInfo
    {
        public enum Difficulty
        {
            EASY,
            MED,
            HARD,
        }

        private static Difficulty difficulty = Difficulty.MED;
        private static double difficultyOffset = 1;

        public static double GetDifficultyOffset()
        {
            double retVal = difficultyOffset;
            return retVal;
        }

        public static Difficulty GetDifficultyEnum()
        {
            Difficulty retval = difficulty;
            return retval;
        }

        public static String GetDifficulty()
        {
            switch(difficulty)
            {
                case Difficulty.EASY:
                    return "Easy";

                case Difficulty.MED:
                    return "Medium";

                case Difficulty.HARD:
                    return "Hard";

                default:
                    return null;
            }
        }

        public static void SwitchDifficulty()
        {
            if(difficulty == Difficulty.MED)
            {
                difficulty = Difficulty.HARD;
                difficultyOffset = .6;
            } else if(difficulty == Difficulty.HARD)
            {
                difficulty = Difficulty.EASY;
                difficultyOffset = 2;
            } else if(difficulty == Difficulty.EASY)
            {
                difficulty = Difficulty.MED;
                difficultyOffset = 1;
            }
        }
    }
}
