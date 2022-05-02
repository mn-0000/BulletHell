using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game
{
    public static class GameOptions
    {
        public enum Difficulty
        {
            EASY,
            MED,
            HARD,
        }

        private static Difficulty difficulty = Difficulty.MED;
        private static double difficultyOffset = 1;
        private static bool godMode = false;

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
                difficultyOffset = .75;
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

        public static void ToggleGodMode()
        {
            godMode = !godMode;
        }

        public static String GetGodMode()
        {
            if (godMode)
            {
                return "Enabled";
            }
            else return "Disabled";
        }

        public static bool IsGodModeEnabled()
        {
            bool retVal = godMode;
            return retVal;
        }
    }
}
