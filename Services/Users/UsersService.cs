using Blazored.LocalStorage;
using MudBlazor;
using Speccon.Learnership.FrontEnd.Models.Common;
using Speccon.Learnership.FrontEnd.Models.Users;
using Speccon.Learnership.FrontEnd.Services.System;

namespace Speccon.Learnership.FrontEnd.Services.Users
{
    public class UsersService(ILocalStorageService localStorage, HttpClient httpClient)
    {
        private readonly ApiEndpointCall apiEndpointCall = new ApiEndpointCall(localStorage, httpClient);

        public async Task<PaginatedResult<UserReportDto>> LoadUserData(TableState state, string? searchTerm)
        {
            var response = await FetchUserDataAsync(state, searchTerm ?? string.Empty);
            return response != null ? response : CreateEmptyPaginatedResult();
        }

        private async Task<PaginatedResult<UserReportDto>?> FetchUserDataAsync(TableState state, string searchTerm)
        {
            //string url = $"api/users/paginated?start={state.Page}&length={state.PageSize}&search={Uri.EscapeDataString(searchTerm ?? string.Empty)}";
            string url = $"api/users/paginated?start={state.Page * state.PageSize}&length={state.PageSize}&search={Uri.EscapeDataString(searchTerm ?? string.Empty)}";
            var result = await apiEndpointCall.ModelEndpointAsync<PaginatedResult<UserReportDto>>(url, HttpMethod.Get);
            return result;
        }

        private static PaginatedResult<UserReportDto> CreateEmptyPaginatedResult()
        {
            return new PaginatedResult<UserReportDto>
            {
                Items = new List<UserReportDto>(),
                TotalCount = 0
            };
        }

        public async Task<EditUserDto> Getuser(Guid key)
        {
            string url = $"api/users/GetUser?key={key}";
            var result = await apiEndpointCall.ModelEndpointAsync<EditUserDto>(url, HttpMethod.Get);
            return result ?? new EditUserDto();
        }
        public async Task<UserDto?> UpdateUser(EditUserDto user)
        {
            string url = "api/user/UpdateProfile";
            var result = await apiEndpointCall.ModelEndpointAsync<UserDto>(url, HttpMethod.Post, user);
            return result ?? new();
        }
    }
}
