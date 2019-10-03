namespace MartianRobots
{
    using System;
    using System.Linq;

    public class Serialiser
    {
        public static object Serialise(World world)
        {
            return string.Join(Environment.NewLine, world.Robots.Select(FormatRobot));
        }

        private static string FormatRobot(Robot robot)
        {
            return string.Format("{0} {1} {2}{3}", robot.X, robot.Y, FormatOrientation(robot.Orientation), robot.Lost ? " LOST" : string.Empty);
        }

        private static char FormatOrientation(double orientation)
        {
            switch (orientation % 360)
            {
                case 90:
                case -270:
                    return 'N';

                case 0:
                case -360:
                    return 'E';

                case 270:
                case -90:
                    return 'S';

                case 180:
                case -180:
                    return 'W';

                default:
                    throw new Exception();
            }
        }
    }
}