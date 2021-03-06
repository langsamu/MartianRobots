﻿// Copyright (c) 2019 Samu Lang
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
    /// Represents a controller that can execute robots' movement commands and expose an API.
    /// </summary>
    [Route("api")]
    public class ApiController : Controller
    {
        /// <summary>
        /// Represents get and post with parameter actions.
        /// </summary>
        /// <param name="parameters">A data transfer object.</param>
        /// <returns>A textual representation of the state of the world after executing robots' movement commands.</returns>
        [HttpPost]
        [HttpGet]
        public IActionResult Index(Parameters parameters)
        {
            try
            {
                var entity = Parser.Parse(parameters.World);
                return this.PostEntity(entity);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Represents the post with body action.
        /// </summary>
        /// <param name="world">A world object deserialised from the request body.</param>
        /// <returns>A textual representation of the state of the world after executing robots' movement commands.</returns>
        [HttpPost("entity")]
        public IActionResult PostEntity([FromBody]World world)
        {
            if (world is null)
            {
                return this.BadRequest();
            }

            world.Execute();
            var output = Serialiser.Serialise(world);

            return this.Ok(output);
        }

        /// <summary>
        /// Represents a head request (for CORS preflight).
        /// </summary>
        /// <returns>An empty response.</returns>
        [HttpHead]
        public IActionResult Head()
        {
            return this.Ok();
        }
    }
}
