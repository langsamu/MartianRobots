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

    [Route("api")]
    public class ApiController : Controller
    {
        [HttpPost]
        [HttpGet]
        public IActionResult Index(Parameters parameters)
        {
            var entity = Parser.Parse(parameters.World);
            return this.PostEntity(entity);
        }

        [HttpPost("entity")]
        public IActionResult PostEntity([FromBody]World world)
        {
            try
            {
                world.Execute();
                var output = Serialiser.Serialise(world);

                return this.Ok(output);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
