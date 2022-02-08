using System;

namespace TRNBulletHell
{
    public static class RunGame
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameDriver())
                game.Run();
        }
    }
}
