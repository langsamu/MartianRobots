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

    /// <summary>
    /// Represents an action robots can carry out.
    /// </summary>
    internal abstract class Command
    {
        /// <summary>
        /// Converts a character to its equivalent command.
        /// </summary>
        /// <param name="command">A character representing the command.</param>
        /// <returns>A command equivalent to the character.</returns>
        internal static Command Parse(char command)
        {
            switch (command)
            {
                case 'L':
                    return new LeftCommand();

                case 'R':
                    return new RightCommand();

                case 'F':
                    return new ForwardCommand();

                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Executes the command over a robot in a certain world.
        /// </summary>
        /// <param name="robot">The robot to execute the command on.</param>
        /// <param name="world">The world to execute the command in.</param>
        internal abstract void Execute(Robot robot, World world);
    }
}
