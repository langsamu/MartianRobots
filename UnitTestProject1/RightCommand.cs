namespace UnitTestProject1
{
    internal class RightCommand : Command
    {
        internal override void Execute(Robot robot, World world)
        {
            // TODO: trig
            switch (robot.Orientation)
            {
                case 'N':
                    robot.Orientation = 'E';
                    break;

                case 'E':
                    robot.Orientation = 'S';
                    break;

                case 'S':
                    robot.Orientation = 'W';
                    break;

                default:
                case 'W':
                    robot.Orientation = 'N';
                    break;
            }
        }
    }
}
