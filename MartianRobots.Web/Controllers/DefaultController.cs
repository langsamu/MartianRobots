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
    using System;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Represents a controller that can execute robots' movement commands and render a UI.
    /// </summary>
    [Route("")]
    public class DefaultController : Controller
    {
        /// <summary>
        /// Represents the get action.
        /// </summary>
        /// <returns>The default view.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Represents the post action.
        /// </summary>
        /// <param name="parameters">Post parameters in a DTO.</param>
        /// <returns>A view populated with the result of executing movement commands.</returns>
        [HttpPost]
        public IActionResult Index(Parameters parameters)
        {
            try
            {
                var world = Parser.Parse(parameters.World);
                world.Execute();

                parameters.Output = Serialiser.Serialise(world);
            }
            catch (Exception e)
            {
                parameters.Error = e.Message;
            }

            return this.View(parameters);
        }
    }
}
