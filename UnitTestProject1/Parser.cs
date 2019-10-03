namespace UnitTestProject1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Parser
    {
        internal static World Parse(string input)
        {
            var e = input.AsEnumerable().GetEnumerator();

            e.MoveNext();
            var width = ParseInteger(e);
            e.MoveNext();
            var height = ParseInteger(e);
            e.MoveNext();
            e.MoveNext();
            var robots = ParseRobots(e).ToList();

            return new World(width, height, robots);
        }

        private static int ParseInteger(IEnumerator<char> e)
        {
            var builder = new StringBuilder();

            while (char.IsDigit(e.Current))
            {
                builder.Append(e.Current);
                e.MoveNext();
            }

            return int.Parse(builder.ToString());
        }

        private static IEnumerable<Robot> ParseRobots(IEnumerator<char> e)
        {
            do
            {
                var x = ParseInteger(e);
                e.MoveNext();
                var y = ParseInteger(e);
                e.MoveNext();
                var o = ParseOrientation(e);
                e.MoveNext();
                e.MoveNext();
                var commands = ParseCommands(e).ToList();

                yield return new Robot(x, y, o, commands);
            } while (e.MoveNext() && e.MoveNext() && e.MoveNext() && e.MoveNext());
        }

        private static double ParseOrientation(IEnumerator<char> e)
        {
            switch (e.Current)
            {
                case 'N':
                    return 90;

                case 'E':
                    return 0;

                case 'S':
                    return 270;

                case 'W':
                    return 180;

                default:
                    throw new Exception();
            }
        }

        private static IEnumerable<Command> ParseCommands(IEnumerator<char> e)
        {
            while (e.MoveNext() && !char.IsWhiteSpace(e.Current))
            {
                yield return Command.Parse(e.Current);
            }
        }
    }
}