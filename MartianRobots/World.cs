namespace MartianRobots
{
    using System.Collections.Generic;

    public class World
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

        public void Execute()
        {
            foreach (var robot in Robots)
            {
                robot.Execute(this);
            }
        }

        internal bool IsIn(int x, int y)
        {
            return x >= 0 && y >= 0 && x <= width && y <= height;
        }
    }
}
