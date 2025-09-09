using Blazored.LocalStorage;
using MudBlazor;
using Speccon.Learnership.FrontEnd.Models.Common;
using Speccon.Learnership.FrontEnd.Models.Disabilities;
using Speccon.Learnership.FrontEnd.Services.System;

namespace Speccon.Learnership.FrontEnd.Services.Disabilities
{
    public class DisabilityService(ILocalStorageService localStorage, HttpClient httpClient)
    {
        private readonly ApiEndpointCall apiEndpointCall = new ApiEndpointCall(localStorage, httpClient);


        public async Task<PaginatedResult<DisabilityDto>> LoadDisabilityData(TableState state, string? searchTerm)
        {
            var response = await FetchDisabilityDataAsync(state, searchTerm ?? string.Empty);
            return response != null ? response : CreateEmptyPaginatedResult();
        }


        private async Task<PaginatedResult<DisabilityDto>?> FetchDisabilityDataAsync(TableState state, string searchTerm)
        {
            string url = $"api/Disability/Disabilitypaginated?start={state.Page}&length={state.PageSize}&search={Uri.EscapeDataString(searchTerm ?? string.Empty)}";
            var result = await apiEndpointCall.ModelEndpointAsync<PaginatedResult<DisabilityDto>>(url, HttpMethod.Get);
            return result;
        }


        private static PaginatedResult<DisabilityDto> CreateEmptyPaginatedResult()
        {
            return new PaginatedResult<DisabilityDto>
            {
                Items = new List<DisabilityDto>(),
                TotalCount = 0
            };
        }
  
        public async Task<DisabilityCreateDto> CreateDisability(string description)
        {
            string url = $"api/Disability/DisabilityCreate?description={description}";
            var result = await apiEndpointCall.ModelEndpointAsync<DisabilityCreateDto>(url, HttpMethod.Get);
            return result ?? new DisabilityCreateDto();
        }

        public async Task<DisabilityDto?> UpdateDisability(DisabilityUpdateDto Disability)
        {
            string url = "api/Disability/DisabilityUpdate";
            var result = await apiEndpointCall.ModelEndpointAsync<DisabilityDto>(url, HttpMethod.Post, Disability);
            return result ?? new();
        }

        public async Task<DisabilityDto?> DeleteDisability(DisabilityDeleteDto Disability)
        {
            string url = "api/Disability/DisabilityDelete";
            var result = await apiEndpointCall.ModelEndpointAsync<DisabilityDto>(url, HttpMethod.Put, Disability);
            return result ?? new();
        }

        public async Task<List<DisabilityDto>> GetList()
        {
            string url = $"api/Disability/DisabilityGetList";
            var result = await apiEndpointCall.ModelEndpointAsync<List<DisabilityDto>>(url, HttpMethod.Get);
            return result ?? new();
        }

        public async Task<DisabilityUpdateDto> GetDisability(Guid key)
        {
            string url = $"api/Disability/DisabilityGet?key={key}";
            var result = await apiEndpointCall.ModelEndpointAsync<DisabilityUpdateDto>(url, HttpMethod.Get);
            return result ?? new DisabilityUpdateDto();
        }

    }
}

