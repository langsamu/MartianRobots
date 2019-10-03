namespace UnitTestProject1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
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
            var world = (Width: int.Parse(coordinates[0]), Height: int.Parse(coordinates[1]));
            var robotLines = lines.Skip(1);
            var oddLines = robotLines.Where((_, i) => i % 2 == 0);
            var evenLines = robotLines.Where((_, i) => i % 2 != 0);
            var robots = oddLines.Zip(evenLines, (locationLine, commandsLine) =>
            {
                var location = locationLine.Split(' ');
                return new Robot { Location = (int.Parse(location[0]), int.Parse(location[1])), Orientation = location[2], Lost = false, Movements = commandsLine };
            }).ToArray();

            var scents = new List<(int X, int Y)>();
            
            foreach (var robot in robots)
            {
                foreach (var movement in robot.Movements)
                {
                    if (robot.Lost)
                    {
                        break;
                    }

                    switch (movement)
                    {
                        case 'F':
                            var movementVector = (X: 0, Y: 0);

                            switch (robot.Orientation)
                            {
                                case "N":
                                    movementVector.Y++;
                                    break;

                                case "E":
                                    movementVector.X++;
                                    break;

                                case "S":
                                    movementVector.Y--;
                                    break;

                                default:
                                case "W":
                                    movementVector.X--;
                                    break;
                            }

                            var x = robot.Location.X + movementVector.X;
                            var y = robot.Location.Y + movementVector.Y;

                            if (x > world.Width || y > world.Height)
                            {
                                if (scents.Contains(robot.Location))
                                {
                                    break;
                                }

                                scents.Add(robot.Location);
                                robot.Lost = true;
                            }
                            else
                            {
                                robot.Location.X = x;
                                robot.Location.Y = y;
                            }

                            break;

                        case 'L':
                            switch (robot.Orientation)
                            {
                                case "N":
                                    robot.Orientation = "W";
                                    break;

                                case "E":
                                    robot.Orientation = "N";
                                    break;

                                case "S":
                                    robot.Orientation = "E";
                                    break;

                                default:
                                case "W":
                                    robot.Orientation = "S";
                                    break;
                            }
                            break;

                        default:
                        case 'R':
                            switch (robot.Orientation)
                            {
                                case "N":
                                    robot.Orientation = "E";
                                    break;

                                case "E":
                                    robot.Orientation = "S";
                                    break;

                                case "S":
                                    robot.Orientation = "W";
                                    break;

                                default:
                                case "W":
                                    robot.Orientation = "N";
                                    break;
                            }
                            break;
                    }
                }
            }

            var actual = string.Join("\r\n", robots.Select(robot => string.Format("{0} {1} {2}{3}", robot.Location.X, robot.Location.Y, robot.Orientation, robot.Lost ? " LOST" : string.Empty)));

            var expected = @"
1 1 E
3 3 N LOST
2 3 S
".Trim();

            Assert.AreEqual(expected, actual);
        }
    }

    internal class Robot
    {
        internal (int X, int Y) Location;
        internal string Orientation;
        internal bool Lost;
        internal string Movements;
    }
}
