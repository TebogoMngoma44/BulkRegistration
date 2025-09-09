using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Speccon.Learnership.FrontEnd.Models.Common;
using System.Net.Http.Headers;

namespace Speccon.Learnership.FrontEnd.Services.Identity
{
    public class CustomAuthorizationMessageHandler : DelegatingHandler
    {
        private readonly IAccessTokenProvider _tokenProvider;

        public CustomAuthorizationMessageHandler(IAccessTokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tokenResult = await _tokenProvider.RequestAccessToken();
            if (tokenResult.TryGetToken(out var token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(Constants.BearerKey, token.Value);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
