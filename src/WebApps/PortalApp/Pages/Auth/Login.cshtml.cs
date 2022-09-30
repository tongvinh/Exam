using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalApp.Core;

namespace PortalApp.Pages.Auth
{
  public class Login : PageModel
  {
    public async Task OnGetAsync()
    {
      await HttpContext.ChallengeAsync(AuthenticationConsts.OidcAuthenticationScheme, new AuthenticationProperties
      {
        RedirectUri = "/"
      });
    }
  }
}