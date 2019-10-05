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

namespace MartianRobots.Web
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a data transfer object for Martian Robots operations.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Gets or sets a textual representation of the world.
        /// </summary>
        [Display(Name = "World")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string World { get; set; }

        /// <summary>
        /// Gets or sets a textual representation of the state of the world after executing commands.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the error message in case of failure to execute the world.
        /// </summary>
        public string Error { get; set; }
    }
}
