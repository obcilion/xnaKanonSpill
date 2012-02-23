using System;

namespace CannonGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (CannonGame game = new CannonGame())
            {
                game.Run();
            }
        }
    }
#endif
}

