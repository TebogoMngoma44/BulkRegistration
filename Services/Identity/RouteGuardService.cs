using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace Speccon.Learnership.FrontEnd.Services.Identity
{
    public class RouteGuardService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly NavigationManager _navigationManager;

        public RouteGuardService(AuthenticationStateProvider authStateProvider, NavigationManager navigationManager)
        {
            _authStateProvider = authStateProvider;
            _navigationManager = navigationManager;
        }

        public async Task GuardRouteAsync(string redirectUrl)
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity != null && !authState.User.Identity.IsAuthenticated)
            {
                _navigationManager.NavigateTo(redirectUrl);
            }
        }
    }
}
