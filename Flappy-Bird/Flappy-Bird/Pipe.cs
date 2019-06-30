using System;
using System.Collections.Generic;

namespace flap
{
    public class Pipe
    {
        public Pipe(string matter)
        {
            Random rand = new Random();
            X = Game.ScreenWidth;
            var hole = rand.Next(3, Game.ScreenHeight - 3);
            Holes = new List<int>() { hole - 1, hole, hole + 1 };
            Matter = matter;
            Game.NewPipe(this);
        }

        public int X { get; set; }
        public List<int> Holes { get; set; } = new List<int>();
        public string Matter { get; set; }
    }
}