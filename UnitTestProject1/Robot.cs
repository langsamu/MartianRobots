namespace UnitTestProject1
{
    using System.Collections.Generic;

    internal class Robot
    {
        private readonly IEnumerable<Command> commands;

        internal int X { get; set; }

        internal int Y { get; set; }

        internal bool Lost { get; set; }

        internal double Orientation { get; set; }

        internal Robot(int x, int y, double orientation, IEnumerable<Command> commands)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
            this.commands = commands;
        }

        internal void Execute(World world)
        {
            foreach (var command in commands)
            {
                command.Execute(this, world);

                if (Lost)
                {
                    break;
                }
            }
        }
    }
}
