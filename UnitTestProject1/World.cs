namespace UnitTestProject1
{
    using System.Collections.Generic;

    internal class World
    {
        private readonly int width;
        private readonly int height;

        internal World(int width, int height, IEnumerable<Robot> robots)
        {
            this.width = width;
            this.height = height;
            this.Robots = robots;
        }

        internal IList<(int, int)> Scents { get; } = new List<(int, int)>();

        internal IEnumerable<Robot> Robots { get; private set; }

        internal bool IsIn(int x, int y)
        {
            return x >= 0 && y >= 0 && x <= width && y <= height;
        }

        internal void Execute()
        {
            foreach (var robot in Robots)
            {
                robot.Execute(this);
            }
        }
    }
}
