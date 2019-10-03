namespace UnitTestProject1
{
    using System.Collections.Generic;

    internal class World
    {
        private int width;
        private int height;

        internal World(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public List<(int, int)> Scents { get; } = new List<(int, int)>();

        internal bool IsIn(int x, int y)
        {
            return x >= 0 && y >= 0 && x <= width && y <= height;
        }
    }
}
