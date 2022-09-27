using System.ComponentModel;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Examination.Application.Extensions
{
    public static class HttpContextExtension
    {
        public static string GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor?.HttpContext?.User?.GetClaim<string>(ClaimTypes.NameIdentifier);
        }
        public static TId GetClaim<TId>(this ClaimsPrincipal principal, string type)
        {
            if (principal == null || principal.Identity == null ||
            !principal.Identity.IsAuthenticated)
            {
                throw new ArgumentNullException(nameof(principal));
            }
            var loggedInUserId = principal.FindFirst(type)?.Value;

            if (typeof(TId) == typeof(string) || typeof(TId) == typeof(int) || typeof(TId) == typeof(long) || typeof(TId) == typeof(Guid))
            {
                var converter = TypeDescriptor.GetConverter(typeof(TId));

                return (TId)converter.ConvertFromInvariantString(loggedInUserId);
            }

            throw new InvalidOperationException("The user id type is invalid.");
        }
    }
}