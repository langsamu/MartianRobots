namespace UnitTestProject1
{
    using System;
    using System.Linq;

    internal class Serialiser
    {
        internal static object Serialise(World world)
        {
            return string.Join("\r\n", world.Robots.Select(robot => string.Format("{0} {1} {2}{3}", robot.X, robot.Y, FormatOrientation(robot.Orientation), robot.Lost ? " LOST" : string.Empty)));
        }

        private static char FormatOrientation(double orientation)
        {
            var o = orientation % 360;
            if (o < 0)
            {
                o += 360;
            }

            switch (o)
            {
                case 90:
                    return 'N';

                case 0:
                    return 'E';

                case 270:
                    return 'S';

                case 180:
                    return 'W';

                default:
                    throw new Exception();
            }
        }
    }
}