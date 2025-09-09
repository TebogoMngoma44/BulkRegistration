using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Speccon.Learnership.FrontEnd.Models.Common;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;

namespace Speccon.Learnership.FrontEnd.Services.Identity
{
    public class CustomAuthenticationStateProvider(ILocalStorageService localStorage, HttpClient httpClient) : AuthenticationStateProvider
    {
        private ClaimsPrincipal _cachedUser = new ClaimsPrincipal();
        private bool _isCached = false;
        private List<string> _cachedRoles = new();
        private readonly ILocalStorageService _localStorage = localStorage;
        private readonly HttpClient _httpClient = httpClient;

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_isCached && _cachedUser != null)
            {
                return new AuthenticationState(_cachedUser);
            }

            var token = await _localStorage.GetItemAsync<string>(Constants.AuthTokenKey);
            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

            // Fetch roles if they are not cached
            if (_cachedRoles.Count == 0)
            {
                _cachedRoles = await FetchUserRoles();
            }

            // Add roles to the identity
            foreach (var role in _cachedRoles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            _cachedUser = new ClaimsPrincipal(identity);
            _isCached = true;
            return new AuthenticationState(_cachedUser);
        }

        public async Task RefreshRolesAsync()
        {
            // Clear cached roles
            _cachedRoles.Clear();
            _isCached = false;

            // Re-fetch the authentication state to refresh roles
            var authState = await GetAuthenticationStateAsync();

            // Notify subscribers of the updated authentication state
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        private async Task<List<string>> FetchUserRoles()
        {
            try
            {
                var token = await _localStorage.GetItemAsync<string>(Constants.AuthTokenKey);
                if (!string.IsNullOrWhiteSpace(token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.BearerKey, token);
                }

                var response = await _httpClient.GetAsync("api/identity/getuserroles"); // or your roles endpoint
                response.EnsureSuccessStatusCode(); // throws if not 2xx

                // Check if the content is JSON before parsing
                var content = await response.Content.ReadAsStringAsync();
                if (!content.TrimStart().StartsWith('{') && !content.TrimStart().StartsWith('['))
                {
                    Console.WriteLine("Unexpected response format.");
                    return new List<string>(); // Return empty list or handle as needed
                }

                // Parse JSON into a list of roles
                return await response.Content.ReadFromJsonAsync<List<string>>() ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching roles: {ex.Message}");
                return new List<string>(); // Return an empty list or handle the error as needed
            }
        }


        private static List<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1]; // Get the payload part of the JWT

            // Adjust for Base64 URL encoding
            payload = payload.Replace('-', '+').Replace('_', '/');
            switch (payload.Length % 4)
            {
                case 2: payload += "=="; break;
                case 3: payload += "="; break;
            }

            // Decode the Base64 URL encoded payload
            var jsonBytes = Convert.FromBase64String(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            if (keyValuePairs == null) return claims;

            foreach (var kvp in keyValuePairs)
            {
                var claimValue = kvp.Value?.ToString() ?? string.Empty;
                if (kvp.Key == "role" || kvp.Key == "roles")
                {
                    var roles = kvp.Value is JsonElement element && element.ValueKind == JsonValueKind.Array ? element.EnumerateArray().Select(r => r.GetString()) : claimValue.Split(',');

                    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role != null ? role.Trim() : string.Empty)));
                }
                else
                {
                    claims.Add(new Claim(kvp.Key, claimValue));
                }
            }

            return claims;
        }

        public void MarkUserAsLoggedOut()
        {
            // Clear the user's authentication state
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            _cachedRoles.Clear();
            _isCached = false;

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task SetAuthorizationHeaderAsync()
        {
            var token = await _localStorage.GetItemAsync<string>(Constants.AuthTokenKey);
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.BearerKey, token);
            }
        }
    }
}
