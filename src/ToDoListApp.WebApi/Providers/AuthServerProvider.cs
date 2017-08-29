using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using ToDoListApp.Infrastructure.Services.Interfaces;

namespace ToDoListApp.Web.Providers
{
  public class AuthServerProvider : OAuthAuthorizationServerProvider
  {
    private readonly IAuthService _authservice;

    public AuthServerProvider(IAuthService authservice)
    {
      _authservice = authservice;
    }

    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();
    }

    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
      context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});


      var user = await _authservice.GetAsync(context.UserName, context.Password);

      if (user == null)
      {
        context.SetError("invalid_grant", "The user name or password is incorrect.");
        return;
      }

      var identity = new ClaimsIdentity(context.Options.AuthenticationType);
      identity.AddClaim(new Claim("sub", context.UserName));
      identity.AddClaim(new Claim("role", "user"));

      context.Validated(identity);
    }
  }
}