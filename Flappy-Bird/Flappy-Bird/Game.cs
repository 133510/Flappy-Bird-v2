using System;
using System.Collections.Generic;

namespace flap
{
    public static class Game
    {
        public static int Frames { get; private set; } = 0;
        public static int Score { get; private set; } = 0;
        public const int ScreenWidth = 32;
        public const int ScreenHeight = 18;
        public static string Border { get; private set; } = "+";
        public static string Air { get; private set; } = " ";

        public static List<Pipe> pipes { get; private set; } = new List<Pipe>();

        public static void AddFrame()
        {
            Frames++;
        }

        public static void DrawScreen()
        {
            var frame = "";

            for (int y = 0; y <= ScreenHeight; y++)
            {
                for (int x = 0; x <= ScreenWidth; x++)
                {
                    var pixel = CheckForObject(x, y);
                    frame = frame.Insert(frame.Length, pixel + " ");
                }
                frame = frame.Insert(frame.Length, "\r\n");
            }
            frame = frame.Insert(frame.Length, $"Score: {Score}");
            Console.Clear();
            Console.WriteLine(frame);
        }
        private static string CheckForObject(int x, int y)
        {
            if (x == 0 || x == ScreenWidth ||
                y == 0 || y == ScreenHeight) return Border;

            if (Bird.X == x && Bird.Y == y) return Bird.Matter;

            foreach (var pipe in pipes)
            {
                if (pipe.X == x)
                {
                    if (!pipe.Holes.Contains(y)) return pipe.Matter;
                }
            }
            return Air;
        }
        public static void Motion()
        {
            AddFrame();

            while (Console.KeyAvailable &&
                Console.ReadKey(true).Key == ConsoleKey.Spacebar && Bird.Y > 1) { Bird.JumpTime = Bird.JumpStrength; break; }
            if (Bird.JumpTime > 0) Bird.Jump();
            else if (Frames % 2 == 0) Bird.Fall();
            if (Bird.Y > 18) Program.End();

            if (Frames % 50 == 0) { var newPipe = new Pipe("#"); }
            foreach (var pipe in pipes)
            {
                pipe.X--;
                if (pipe.X == Bird.X - 1) Score++;
                else if (pipe.X == Bird.X) if (Bird.Y < pipe.Holes[0] || Bird.Y > pipe.Holes[2]) Program.End();
            }
        }
        public static void NewPipe(Pipe pipe)
        {
            pipes.Add(pipe);
        }
    }
}