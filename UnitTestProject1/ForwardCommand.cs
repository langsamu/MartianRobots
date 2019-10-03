namespace UnitTestProject1
{
    internal class ForwardCommand : Command
    {
        internal override void Execute(Robot robot, World world)
        {
            var movementVector = (X: 0, Y: 0);

            switch (robot.Orientation)
            {
                case 'N':
                    movementVector.Y++;
                    break;

                case 'E':
                    movementVector.X++;
                    break;

                case 'S':
                    movementVector.Y--;
                    break;

                default:
                case 'W':
                    movementVector.X--;
                    break;
            }

            var x = robot.X + movementVector.X;
            var y = robot.Y + movementVector.Y;

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
