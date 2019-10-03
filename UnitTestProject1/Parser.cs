namespace UnitTestProject1
{
    using System;
    using System.Linq;

    internal class Parser
    {
        internal static World Parse(string input)
        {
            var lines = input.Split("\r\n").Except(new[] { string.Empty });
            var coordinates = lines.First().Split(' ');
            var robotLines = lines.Skip(1);
            var oddLines = robotLines.Where((_, i) => i % 2 == 0);
            var evenLines = robotLines.Where((_, i) => i % 2 != 0);
            var robots = oddLines.Zip(evenLines, (locationLine, commandsLine) =>
            {
                var location = locationLine.Split(' ');
                return new Robot(int.Parse(location[0]), int.Parse(location[1]), ParseOrientation(location[2]), commandsLine.Select(CommandToken.Parse).Select(Command.Parse));
            }).ToList();

            return new World(int.Parse(coordinates[0]), int.Parse(coordinates[1]), robots);
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

                case "W":
                    return 180;

                default:
                    throw new Exception();
            }
        }
    }
}