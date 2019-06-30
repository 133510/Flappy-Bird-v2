using System;
using System.Threading;

namespace flap
{
    public static class Program
    {
        public static bool Running { get; private set; } = true;

        public static void Main()
        {
            Bird.Matter = "o";
            Bird.JumpStrength = 1;

            while (Running)
            {
                Thread.Sleep(100);
                Game.AddFrame();
                Game.Motion();
                Game.DrawScreen();
            }
            ShowEndScreen();
        }
        public static void End()
        {
            Running = false;
        }
        private static void ShowEndScreen()
        {
            Console.Clear();
            var frame = "";
            for (int i = 0; i < 8; i++) frame = frame.Insert(frame.Length, "\r\n");
            frame = frame.Insert(frame.Length, "         RIP, Birdo!\r\n");
            frame = frame.Insert(frame.Length, $"      Birdo's score: {Game.Score}");
            for (int i = 0; i < 8; i++) frame = frame.Insert(frame.Length, "\r\n");
            Console.WriteLine(frame);
        }
    }
}
