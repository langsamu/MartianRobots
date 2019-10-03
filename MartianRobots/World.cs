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
    using System.Collections.Generic;

    /// <summary>
    /// Represents a world robots can move in.
    /// </summary>
    public class World
    {
        private readonly int width;
        private readonly int height;

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        /// <param name="width">The horizontal size of the world.</param>
        /// <param name="height">The vertical size of the world.</param>
        /// <param name="robots">The robots inhabiting the world.</param>
        internal World(int width, int height, IEnumerable<Robot> robots)
        {
            this.width = width;
            this.height = height;
            this.Robots = robots;
        }

        /// <summary>
        /// Gets a list of locations where robots are known to have been lost.
        /// </summary>
        internal IList<(int, int)> Scents { get; } = new List<(int, int)>();

        /// <summary>
        /// Gets a list of robots inhabiting the world.
        /// </summary>
        internal IEnumerable<Robot> Robots { get; private set; }

        /// <summary>
        /// Carries out robots' movement commands.
        /// </summary>
        public void Execute()
        {
            foreach (var robot in this.Robots)
            {
                robot.Execute(this);
            }
        }

        /// <summary>
        /// Checks whether a location is on the world grid or outside it.
        /// </summary>
        /// <param name="x">The horizontal component of the location.</param>
        /// <param name="y">The vertical conponent of the location.</param>
        /// <returns>A valu indicating whether the location is on the world grid or not.</returns>
        internal bool IsIn(int x, int y)
        {
            return x >= 0 && y >= 0 && x <= this.width && y <= this.height;
        }
    }
}
