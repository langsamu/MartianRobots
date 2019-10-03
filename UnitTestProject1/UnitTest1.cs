namespace UnitTestProject1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"
5 3
1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL

0 3 W
LLFFFLFLFL
";

            var world = Parser.Parse(input);
            world.Execute();

            var actual = string.Join("\r\n", world.Robots.Select(robot => string.Format("{0} {1} {2}{3}", robot.X, robot.Y, FormatOrientation(robot.Orientation), robot.Lost ? " LOST" : string.Empty)));

            var expected = @"
1 1 E
3 3 N LOST
2 3 S
".Trim();

            Assert.AreEqual(expected, actual);
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
