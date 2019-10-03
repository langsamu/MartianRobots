namespace UnitTestProject1
{
    internal class Robot
    {
        private readonly string movements;

        internal int X { get; set; }

        internal int Y { get; set; }

        internal bool Lost { get; set; }

        internal double Orientation { get; set; }

        internal Robot(int x, int y, double orientation, string movements)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
            this.movements = movements;
        }

        internal void Execute(World world)
        {
            foreach (var movement in movements)
            {
                Command.Parse(movement).Execute(this, world);

                if (Lost)
                {
                    break;
                }
            }
        }
    }
}
