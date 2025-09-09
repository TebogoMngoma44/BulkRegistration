using Blazored.LocalStorage;
using Speccon.Learnership.FrontEnd.Models.Common;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Speccon.Learnership.FrontEnd.Services.System
{
    public class ApiEndpointCall(ILocalStorageService localStorage, HttpClient httpClient)
    {
        private readonly ILocalStorageService _localStorage = localStorage;
        private readonly HttpClient _httpClient = httpClient;

        public async Task SetAuthorizationHeaderAsync()
        {
            var token = await _localStorage.GetItemAsync<string>(Constants.AuthTokenKey);
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.BearerKey, token);
            }
        }

        public async Task<HttpResponseMessage?> RawEndpointAsync(string url, HttpMethod method, object? content = null)
        {
            try
            {
                await SetAuthorizationHeaderAsync();
                var request = new HttpRequestMessage(method, url)
                {
                    Content = content != null ? JsonContent.Create(content) : null
                };
                var response = await _httpClient.SendAsync(request);
                return response;
            }
            catch
            {
                return null;
            }
        }

        public async Task<T?> ParamEndpointAsync<T>(string url, HttpMethod method, object? content = null)
        {
            try
            {
                await SetAuthorizationHeaderAsync();

                var request = new HttpRequestMessage(method, url)
                {
                    Content = content != null ? JsonContent.Create(content) : null
                };

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(result);
                }

                return default;
            }
            catch
            {
                return default;
            }
        }

        public async Task<T?> ModelEndpointAsync<T>(string url, HttpMethod method, object? content = null) where T : class
        {
            try
            {
                await SetAuthorizationHeaderAsync();
                var request = new HttpRequestMessage(method, url)
                {
                    Content = content != null ? JsonContent.Create(content) : null
                };

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<T>();
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
