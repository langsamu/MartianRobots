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
    using System.Linq;

    /// <summary>
    /// Contains functionality for converting a world with robots and commands into a texual representation.
    /// </summary>
    public class Serialiser
    {
        /// <summary>
        /// Converts the world into a textual representation.
        /// </summary>
        /// <param name="world">The world object to serialise.</param>
        /// <returns>A Textual representation of the world.</returns>
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