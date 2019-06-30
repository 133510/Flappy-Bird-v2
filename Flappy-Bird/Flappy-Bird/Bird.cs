namespace flap
{
    public static class Bird
    {
        public const int X = 15;
        public static int Y { get; set; } = 5;
        public static string Matter { get; set; }
        public static int JumpTime { get; set; }
        public static int JumpStrength { get; set; }

        public static void Jump()
        {
            Y -= 2;
            JumpTime--;
        }
        public static void Fall()
        {
            Y++;
        }
    }
}