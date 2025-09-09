using Speccon.Learnership.FrontEnd.Models.Qualification;

namespace Speccon.Learnership.FrontEnd.Services
{
    public interface ISetaQualificationService
    {
        Task<List<QualificationOptionDto>> GetQualificationOptionsAsync(string userId);
        Task<SetaQualificationModel> GetQualificationByIdAsync(int qualificationId);
    }

    public class SetaQualificationService : ISetaQualificationService
    {
        private readonly HttpClient _httpClient;
        private readonly QualificationDataService _dataService;

        // HttpClient can be removed if you're only using mock data and not making actual API calls for now
        public SetaQualificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _dataService = new QualificationDataService();
        }

        public async Task<List<QualificationOptionDto>> GetQualificationOptionsAsync(string userId)
        {
            // For now, return mock data. Replace with actual API call later
            await Task.Delay(100); // Simulate API call latency

            // Get sample qualifications from the model
            var sampleQualifications = SetaQualificationModel.GetSampleQualifications();

            // Map sample qualifications to QualificationOptionDto
            var options = sampleQualifications.Select(q => new QualificationOptionDto
            {
                Id = q.Id,
                Value = q.Id.ToString(),
                Label = $"{q.QualificationName} NQF {q.NQFLevel} ({q.Status})", // Format as seen in dropdown
                QualificationName = q.QualificationName,
                Status = q.Status,
                NQFLevel = q.NQFLevel,
                Credits = q.Credits,
                SETA = q.SETA,
                Description = q.Description
            }).ToList();

            return options;
        }

        public async Task<SetaQualificationModel> GetQualificationByIdAsync(int qualificationId)
        {
            // For now, return mock data from the QualificationDataService.
            // Replace with actual API call later when you fetch real data from an API.
            await Task.Delay(100); // Simulate API call latency

            // Use the existing QualificationDataService to get full qualification data
            // Map the qualificationId to the string format expected by GetQualificationData
            string qualificationKey = qualificationId == 2 ? "qualification2" : "qualification1";

            var qualificationModel = _dataService.GetQualificationData(qualificationKey);

            // Update the Id to match the requested id
            qualificationModel.Id = qualificationId;

            return qualificationModel;
        }
    }
}