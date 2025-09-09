// Services/PracticalService/IPracticalAssignmentService.cs
using Speccon.Learnership.FrontEnd.Models.PracticalAssignment;

namespace Speccon.Learnership.FrontEnd.Services.PracticalService
{
    public interface IPracticalAssignmentService
    {
        Task<PracticalDashboardData> GetPracticalDashboardDataAsync();
        Task<List<NavigationItem>> GetNavigationItemsAsync();
        Task<UserProfile> GetUserProfileAsync();
        Task<List<PracticalBreadcrumbItem>> GetBreadcrumbsAsync(string currentRoute);
        Task<PracticalAssignmentModel?> GetCurrentAssignmentAsync(string assignmentId);
        Task<List<PracticalAssignmentModel>> GetPracticalAssignmentsAsync();
        Task<bool> SubmitAssignmentAsync(string assignmentId);
        Task<bool> SaveProgressAsync(string assignmentId, object progressData);
    }
}