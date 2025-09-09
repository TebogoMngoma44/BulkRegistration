using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using Speccon.Learnership.FrontEnd.Models.Common;
using Speccon.Learnership.FrontEnd.Services.System;
using Speccon.Learnership.FrontEnd.Services.Identity;
using Speccon.Learnership.FrontEnd.Models.Account;

namespace Speccon.Learnership.FrontEnd.Services.Authorization
{
    public class AuthService(ILocalStorageService localStorage, HttpClient httpClient, AuthenticationStateProvider authStateProvider, NavigationManager navigationManager)
    {
        private readonly ApiEndpointCall apiEndpointCall = new ApiEndpointCall(localStorage, httpClient);

        private readonly ILocalStorageService _localStorage = localStorage;
        private readonly HttpClient _httpClient = httpClient;
        private readonly AuthenticationStateProvider _authStateProvider = authStateProvider;
        private readonly NavigationManager _navigationManager = navigationManager;
        public List<string> UserRoles { get; private set; } = new List<string>();

        public async Task<AuthResult> Login(LoginModel model)
        {
            string url = $"api/auth/login";
            var result = await apiEndpointCall.ModelEndpointAsync<LoginResponse>(url, HttpMethod.Post, model);
            if (result != null)
            {
                await _localStorage.SetItemAsync(Constants.AuthTokenKey, result.token);
                return new AuthResult { Success = true, Message = result.message, Token = result.token };
            }
            else
            {
                return new AuthResult { Success = false, Message = result?.message ?? string.Empty, Token = "" };
            }
        }


        public async Task<PreUserEmailDto> GetData(Guid key)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/account/getemail?key={key.ToString()}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<PreUserEmailDto>();
                    if (result != null)
                    {
                        return result;
                    }
                }
                else
                {
                    if (response.StatusCode != HttpStatusCode.BadRequest)
                    {
                        return new PreUserEmailDto();
                    }
                }
                return new PreUserEmailDto();
            }
            catch
            {
                return new PreUserEmailDto();
            }
        }


        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(Constants.AuthTokenKey);
            ((CustomAuthenticationStateProvider)_authStateProvider).MarkUserAsLoggedOut();
            _navigationManager.NavigateTo("/auth/login", true);
        }

        public async Task<bool> IsLoggedIn()
        {
            var token = await _localStorage.GetItemAsync<string>(Constants.AuthTokenKey);
            return !string.IsNullOrEmpty(token); // Return true if token exists, false otherwise
        }

        public async Task<bool> Validate()
        {
            var token = await _localStorage.GetItemAsync<string>(Constants.AuthTokenKey);
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.BearerKey, token);
            }

            var response = await _httpClient.GetAsync($"api/auth/validate");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
