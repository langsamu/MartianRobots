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
    /// Represents a robot somewhere on a world that can move around according to fiven commands.
    /// </summary>
    internal class Robot
    {
        private readonly IEnumerable<Command> commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="Robot"/> class.
        /// </summary>
        /// <param name="x">The initial horizontal location in grid units.</param>
        /// <param name="y">The initial vertical location in grid units.</param>
        /// <param name="orientation">The initial orientation in degrees.</param>
        /// <param name="commands">The list of movement commands to execute.</param>
        /// <remarks>Position 0,0 is bottom left. Orientation 0 is easward, grows counterclockwise.</remarks>
        internal Robot(int x, int y, double orientation, IEnumerable<Command> commands)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
            this.commands = commands;
        }

        /// <summary>
        /// Gets or sets the horizonal location in grid units.
        /// </summary>
        /// <remarks>0 is leftmost.</remarks>
        internal int X { get; set; }

        /// <summary>
        /// Gets or sets the vertical rotation in grid units.
        /// </summary>
        /// <remarks>0 is bottom-most.</remarks>
        internal int Y { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the robots is off the grid.
        /// </summary>
        internal bool Lost { get; set; }

        /// <summary>
        /// Gets or sets the orientation in degrees.
        /// </summary>
        /// <remarks>Zero is east, grows couterclockwise.</remarks>
        internal double Orientation { get; set; }

        /// <summary>
        /// Carries out the movement actions in the given world.
        /// </summary>
        /// <param name="world">The world to move in.</param>
        internal void Execute(World world)
        {
            foreach (var command in this.commands)
            {
                command.Execute(this, world);

                if (this.Lost)
                {
                    break;
                }
            }
        }
    }
}
