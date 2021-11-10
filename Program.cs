using System;

namespace topDownShooterProject
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Classes.GameWorld())
                game.Run();
        }
    }
}
