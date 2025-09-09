using Blazored.LocalStorage;
using MudBlazor;
using Speccon.Learnership.FrontEnd.Models.Client;
using Speccon.Learnership.FrontEnd.Models.Common;
using Speccon.Learnership.FrontEnd.Services.System;

namespace Speccon.Learnership.FrontEnd.Services.TestClients
{
    public class TestClientService(ILocalStorageService localStorage, HttpClient httpClient)
    {
        private readonly ApiEndpointCall apiEndpointCall = new ApiEndpointCall(localStorage, httpClient);


        public async Task<List<ClientDto>> GetList()
        {
            string url = $"api/Client/GetList";
            var result = await apiEndpointCall.ModelEndpointAsync<List<ClientDto>>(url, HttpMethod.Get);
            return result ?? new();
        }



    }
}

