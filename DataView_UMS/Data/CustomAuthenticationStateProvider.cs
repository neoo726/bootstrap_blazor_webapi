using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
namespace DataView_UMS.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly NavigationManager _navigationManager;
        private bool isLoggedIn;

        public CustomAuthenticationStateProvider(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (isLoggedIn)
            {
                identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "admin") }, "apiauth_type");
            }

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }

        public void MarkUserAsAuthenticated()
        {
            isLoggedIn = true;
            NotifyAuthenticationStateChanged(Task.FromResult(GetAuthenticationStateAsync().Result));
        }

        public void MarkUserAsLoggedOut()
        {
            isLoggedIn = false;
            NotifyAuthenticationStateChanged(Task.FromResult(GetAuthenticationStateAsync().Result));
        }
    }
}
