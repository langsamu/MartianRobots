namespace MartianRobots
{
    using System;

    internal class ForwardCommand : Command
    {
        internal override void Execute(Robot robot, World world)
        {
            var orientationRadians = robot.Orientation * Math.PI / 180;

            var x = robot.X + (int)Math.Cos(orientationRadians);
            var y = robot.Y + (int)Math.Sin(orientationRadians);

            if (!world.IsIn(x, y))
            {
                if (world.Scents.Contains((robot.X, robot.Y)))
                {
                    return;
                }

                world.Scents.Add((robot.X, robot.Y));
                robot.Lost = true;
                return;
            }

            robot.X = x;
            robot.Y = y;
        }
    }
}
