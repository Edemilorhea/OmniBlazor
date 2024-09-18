using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace OmniBlazor.Services;

public class CustomAuthSateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var Identity = new ClaimsIdentity(new []{
            new Claim(ClaimTypes.Name, "Test User"),
            new Claim(ClaimTypes.Role, "Omni"),
        }, "custom");

        var user = new ClaimsPrincipal(Identity);

        return Task.FromResult(new AuthenticationState(user));
    }

}
