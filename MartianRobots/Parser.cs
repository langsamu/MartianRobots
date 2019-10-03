// Copyright (c) 2019 Samu Lang
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is furnished
// to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

namespace MartianRobots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains functionality for converting a texual representation of a world with robots and commands into objects.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Converts a textual representation of the world into objects.
        /// </summary>
        /// <param name="input">A string containing the textual representation.</param>
        /// <returns>The parsed world object.</returns>
        public static World Parse(string input)
        {
            input = input.Replace("\r\n", "\n");

            var e = input.AsEnumerable().GetEnumerator();

            e.MoveNext();
            var width = ParseInteger(e);
            e.MoveNext();
            var height = ParseInteger(e);
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
                var commands = ParseCommands(e).ToList();

                yield return new Robot(x, y, o, commands);
            }
            while (e.MoveNext() && e.MoveNext());
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