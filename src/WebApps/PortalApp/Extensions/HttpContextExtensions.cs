using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;

namespace PortalApp.Extensions
{
  public static class HttpContextExtensions
  {
    public static string GetUserId(this ClaimsPrincipal claimsPricipal)
    {
      var claim = ((ClaimsIdentity)claimsPricipal.Identity)
          .Claims
          .SingleOrDefault(x => x.Type == JwtClaimTypes.Subject);
      return claim?.Value;
    }
    public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
    {
      var claim = ((ClaimsIdentity)claimsPrincipal.Identity)
          .Claims
          .SingleOrDefault(x => x.Type == ClaimTypes.Email);
      return claim?.Value;
    }
  }
}