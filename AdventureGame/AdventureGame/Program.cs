using System;

namespace AdventureGameNamespace
{
    static class Program
    {
        static void Main(string[] args)
        {
            using (AdventureGame game = new AdventureGame())
            {
                game.Run();
            }
        }
    }
}

