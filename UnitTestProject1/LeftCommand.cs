namespace UnitTestProject1
{
    internal class LeftCommand : Command
    {
        internal override void Execute(Robot robot, World world)
        {
            // TODO: trig
            switch (robot.Orientation)
            {
                case 'N':
                    robot.Orientation = 'W';
                    break;

                case 'E':
                    robot.Orientation = 'N';
                    break;

                case 'S':
                    robot.Orientation = 'E';
                    break;

                default:
                case 'W':
                    robot.Orientation = 'S';
                    break;
            }
        }
    }
}
