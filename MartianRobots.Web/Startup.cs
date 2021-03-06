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
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Cors.Infrastructure;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Rewrite;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Net.Http.Headers;
    using Swashbuckle.AspNetCore.SwaggerUI;

    /// <summary>
    /// Represents a startup for ASPNET Core web hosts.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures ASPNET Core services.
        /// </summary>
        /// <param name="services">Dependency injected service collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(ConfigureCors);
            services.AddMvc(ConfigureMvc);
        }

        /// <summary>
        /// Confgures ASPNET Core middleware.
        /// </summary>
        /// <param name="app">Dependency injected application builder.</param>
        /// <param name="env">Dependency injected hosting environment.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRewriter(new RewriteOptions().AddRewrite("^openapi$", "swagger/index.html", false).AddRewrite("^(swagger|favicon)(.+)$", "swagger/$1$2", true));
            app.UseCors();
            app.UseMvc();
            app.UseSwaggerUI(ConfigureSwaggerUI);
        }

        private static void ConfigureMvc(MvcOptions mvc)
        {
            mvc.InputFormatters.Insert(0, new WorldInputFormatter());
        }

        private static void ConfigureSwaggerUI(SwaggerUIOptions swaggerUI)
        {
            swaggerUI.DocumentTitle = "Martian Robots OpenAPI";
            swaggerUI.SwaggerEndpoint("./openapi.json", "live");
            swaggerUI.DefaultModelsExpandDepth(-1);
            swaggerUI.DisplayRequestDuration();
            swaggerUI.InjectStylesheet("./openapi.css");
            swaggerUI.InjectJavascript("./openapi.js");
            swaggerUI.EnableDeepLinking();
        }

        private static void ConfigureCors(CorsOptions cors)
        {
            cors.AddDefaultPolicy(policy => policy
                .AllowAnyOrigin()
                .WithHeaders(HeaderNames.ContentType)
                .WithMethods(HttpMethods.Post));
        }
    }
}
