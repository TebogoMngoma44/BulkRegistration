using Blazored.LocalStorage;
using MudBlazor;
using Speccon.Learnership.FrontEnd.Models.Common;
using Speccon.Learnership.FrontEnd.Models.Disabilities;
using Speccon.Learnership.FrontEnd.Models.Qualification;
using Speccon.Learnership.FrontEnd.Services.System;

namespace Speccon.Learnership.FrontEnd.Services.TestQualificationTypes
{
    public class TestQualificationTypeService(ILocalStorageService localStorage, HttpClient httpClient)
    {
        private readonly ApiEndpointCall apiEndpointCall = new ApiEndpointCall(localStorage, httpClient);


        public async Task<List<QualificationTypeDto>> GetList()
        {
            string url = $"api/QualificationType/GetList";
            var result = await apiEndpointCall.ModelEndpointAsync<List<QualificationTypeDto>>(url, HttpMethod.Get);
            return result ?? new();
        }

       

    }
}

