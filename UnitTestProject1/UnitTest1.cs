namespace UnitTestProject1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            var lines = input.Split("\r\n").Except(new[] { string.Empty });
            var coordinates = lines.First().Split(' ');
            var world = new World(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            var robotLines = lines.Skip(1);
            var oddLines = robotLines.Where((_, i) => i % 2 == 0);
            var evenLines = robotLines.Where((_, i) => i % 2 != 0);
            var robots = oddLines.Zip(evenLines, (locationLine, commandsLine) =>
            {
                var location = locationLine.Split(' ');
                return new Robot(int.Parse(location[0]), int.Parse(location[1]), ParseOrientation(location[2]), commandsLine);
            }).ToArray();

            foreach (var robot in robots)
            {
                robot.Execute(world);
            }

            var actual = string.Join("\r\n", robots.Select(robot => string.Format("{0} {1} {2}{3}", robot.X, robot.Y, FormatOrientation(robot.Orientation), robot.Lost ? " LOST" : string.Empty)));

            var expected = @"
1 1 E
3 3 N LOST
2 3 S
".Trim();

            Assert.AreEqual(expected, actual);
        }

        private static double ParseOrientation(string location)
        {
            switch (location)
            {
                case "N":
                    return 90;

                case "E":
                    return 0;

                case "S":
                    return 270;

                default:
                case "W":
                    return 180;
            }
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

                default:
                case 180:
                    return 'W';
            }
        }
    }
}
