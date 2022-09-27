using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination.API.Middlewares;

namespace Examination.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorWrapping(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorWrappingMiddleware>();
        }
    }
}