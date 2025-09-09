using Blazored.LocalStorage;
using MudBlazor;
using Speccon.Learnership.FrontEnd.Models.Common;
using Speccon.Learnership.FrontEnd.Models.Disabilities;
using Speccon.Learnership.FrontEnd.Models.Qualification;
using Speccon.Learnership.FrontEnd.Services.System;

namespace Speccon.Learnership.FrontEnd.Services.TestQualifications
{
    public class TestQualificationService(ILocalStorageService localStorage, HttpClient httpClient)
    {
        private readonly ApiEndpointCall apiEndpointCall = new ApiEndpointCall(localStorage, httpClient);


        public async Task<PaginatedResult<QualificationDto>> LoadQualificationData(TableState state, string? searchTerm)
        {
            var response = await FetchQualificationDataAsync(state, searchTerm ?? string.Empty);
            return response != null ? response : CreateEmptyPaginatedResult();
        }


        private async Task<PaginatedResult<QualificationDto>?> FetchQualificationDataAsync(TableState state, string searchTerm)
        {
            string url = $"api/Qualification/Qualificationpaginated?start={state.Page}&length={state.PageSize}&search={Uri.EscapeDataString(searchTerm ?? string.Empty)}";
            var result = await apiEndpointCall.ModelEndpointAsync<PaginatedResult<QualificationDto>>(url, HttpMethod.Get);
            return result;
        }


        private static PaginatedResult<QualificationDto> CreateEmptyPaginatedResult()
        {
            return new PaginatedResult<QualificationDto>
            {
                Items = new List<QualificationDto>(),
                TotalCount = 0
            };
        }





        public async Task<QualificationDto?> CreateQualification(QualificationCreateDto qualificationCreateDto)
        {
            string url = "api/Qualification/CreateQualification";
            var result = await apiEndpointCall.ModelEndpointAsync<QualificationDto>(url, HttpMethod.Post, qualificationCreateDto);
            return result ?? new QualificationDto();
        }

        public async Task<QualificationDto?> UpdateQualification(QualificationUpdateDto qualificationUpdateDto)
        {
            string url = "api/Qualification/UpdateQualification";
            var result = await apiEndpointCall.ModelEndpointAsync<QualificationDto>(url, HttpMethod.Put, qualificationUpdateDto);
            return result ?? new QualificationDto();
        }

        public async Task<QualificationDto?> DeleteQualification(QualificationDeleteDto qualificationDeleteDto)
        {
            string url = "api/Qualification/DeleteQualification";
            var result = await apiEndpointCall.ModelEndpointAsync<QualificationDto>(url, HttpMethod.Put, qualificationDeleteDto);
            return result ?? new QualificationDto();
        }






        public async Task<List<QualificationDto>> GetList()
        {
            string url = $"api/Qualification/GetList";
            var result = await apiEndpointCall.ModelEndpointAsync<List<QualificationDto>>(url, HttpMethod.Get);
            return result ?? new();
        }

        public async Task<QualificationDto> GetQualificationByKey(Guid key)
        {
            string url = $"api/Qualification/GetQualificationByKey?key={key}";
            var result = await apiEndpointCall.ModelEndpointAsync<QualificationDto>(url, HttpMethod.Get);
            return result ?? new QualificationDto();
        }

        public async Task<List<QualificationDto>> GetQualificationByUserId(int id)
        {
            string url = $"api/Qualification/GetListByUserId?id={id}";
            var result = await apiEndpointCall.ModelEndpointAsync<List<QualificationDto>>(url, HttpMethod.Get);
            return result ?? new List<QualificationDto>();
        }

    }
}

