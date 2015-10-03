using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace TutorialProj1
{
    // You may need to install the Microsoft.AspNet.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private IFoo _foo;
        public Middleware(RequestDelegate next, IFoo foo)
        {
            _next = next;
            _foo = foo;
        }

        public Task Invoke(HttpContext httpContext)
        {
            return httpContext.Response.WriteAsync("in my middleware" + _foo.GetFoo());
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
