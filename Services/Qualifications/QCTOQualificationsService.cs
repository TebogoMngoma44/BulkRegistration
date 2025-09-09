using MudBlazor;
using Speccon.Learnership.FrontEnd.Models.Qualifications;
using System.Text.Json;

namespace Speccon.Learnership.FrontEnd.Services.Qualifications
{
    public interface IQCTOQualificationService
    {
        Task<List<Qualification>> GetQualificationsAsync();
        Task<List<CertificateInfo>> GetCertificatesAsync();
        Task<Qualification?> GetQualificationByNameAsync(string name);
        void CalculateProgressMetrics(Qualification qualification);
        Color GetTimelineColor(TimelineStatus status);
        Color GetStatusColor(string status);
        Color GetGradeColor(string gradeStatus);
        string GetStageDescription(string title, TimelineStatus status);
        Task DownloadCertificateAsync(string certificateId);
    }

    public class QCTOQualificationService : IQCTOQualificationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<QCTOQualificationService> _logger;
        private List<Qualification>? _cachedQualifications;
        private List<CertificateInfo>? _cachedCertificates;

        public QCTOQualificationService(IHttpClientFactory httpClientFactory, ILogger<QCTOQualificationService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<List<Qualification>> GetQualificationsAsync()
        {
            if (_cachedQualifications != null)
                return _cachedQualifications;

            try
            {
                // Create a client specifically for static files from the Blazor app
                using var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri("https://localhost:7029/"); // Your Blazor app's base URL

                _logger.LogInformation($"Attempting to load qualifications from: {client.BaseAddress}Data/qualifications.json");

                var jsonString = await client.GetStringAsync("Data/qualifications.json");
                var jsonDocument = JsonDocument.Parse(jsonString);

                var qualifications = new List<Qualification>();

                foreach (var qualElement in jsonDocument.RootElement.GetProperty("qualifications").EnumerateArray())
                {
                    var qualification = ParseQualification(qualElement);
                    CalculateProgressMetrics(qualification);
                    qualifications.Add(qualification);
                }

                _cachedQualifications = qualifications;
                _logger.LogInformation($"Successfully loaded {qualifications.Count} qualifications from JSON");
                return qualifications;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading qualifications data");
                return new List<Qualification>();
            }
        }

        public async Task<List<CertificateInfo>> GetCertificatesAsync()
        {
            if (_cachedCertificates != null)
                return _cachedCertificates;

            try
            {
                // Create a client specifically for static files from the Blazor app
                using var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri("https://localhost:7029/"); // Your Blazor app's base URL

                var jsonString = await client.GetStringAsync("Data/qualifications.json");
                var jsonDocument = JsonDocument.Parse(jsonString);

                var certificates = new List<CertificateInfo>();

                foreach (var certElement in jsonDocument.RootElement.GetProperty("certificates").EnumerateArray())
                {
                    certificates.Add(new CertificateInfo
                    {
                        ModuleNumber = certElement.GetProperty("moduleNumber").GetInt32(),
                        ModuleName = certElement.GetProperty("moduleName").GetString() ?? "",
                        ModuleCode = certElement.GetProperty("moduleCode").GetString() ?? "",
                        CompletionDate = certElement.GetProperty("completionDate").GetDateTime(),
                        TimeAgo = certElement.GetProperty("timeAgo").GetString() ?? "",
                        GradePercentage = certElement.GetProperty("gradePercentage").GetInt32(),
                        GradeStatus = certElement.GetProperty("gradeStatus").GetString() ?? "",
                        CertificateId = certElement.GetProperty("certificateId").GetString() ?? ""
                    });
                }

                _cachedCertificates = certificates;
                _logger.LogInformation($"Successfully loaded {certificates.Count} certificates from JSON");
                return certificates;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading certificates data");
                return new List<CertificateInfo>();
            }
        }

        public async Task<Qualification?> GetQualificationByNameAsync(string name)
        {
            var qualifications = await GetQualificationsAsync();
            return qualifications.FirstOrDefault(q => q.Name == name);
        }

        public void CalculateProgressMetrics(Qualification qualification)
        {
            int totalModulesUnits = 0;
            int completedModulesUnits = 0;

            foreach (var module in qualification.Modules)
            {
                completedModulesUnits += module.CompletedUnits;
                totalModulesUnits += module.TotalUnits;
            }

            qualification.UnitsCompleted = completedModulesUnits;
            qualification.TotalUnits = totalModulesUnits;

            if (totalModulesUnits > 0)
            {
                qualification.OverallProgress = (int)Math.Round((double)completedModulesUnits / totalModulesUnits * 100);
            }
            else
            {
                qualification.OverallProgress = 0;
            }

            if (qualification.QualificationInfo.ExpectedEndDate != default(DateTime))
            {
                var today = DateTime.Today;
                var monthsDiff = ((qualification.QualificationInfo.ExpectedEndDate.Year - today.Year) * 12) +
                                qualification.QualificationInfo.ExpectedEndDate.Month - today.Month;
                qualification.MonthsRemaining = Math.Max(0, monthsDiff);
            }
            else
            {
                qualification.MonthsRemaining = 0;
            }
        }

        public Color GetTimelineColor(TimelineStatus status)
        {
            return status switch
            {
                TimelineStatus.Completed => Color.Success,
                TimelineStatus.InProgress => Color.Primary,
                TimelineStatus.Pending => Color.Default,
                _ => Color.Default
            };
        }

        public Color GetStatusColor(string status)
        {
            return status?.ToLower() switch
            {
                "in progress" => Color.Primary,
                "completed" => Color.Success,
                "pending" => Color.Warning,
                _ => Color.Default
            };
        }

        public Color GetGradeColor(string gradeStatus)
        {
            return gradeStatus?.ToLower() switch
            {
                "excellent" => Color.Success,
                "good" => Color.Info,
                "satisfactory" => Color.Warning,
                _ => Color.Default
            };
        }

        public string GetStageDescription(string title, TimelineStatus status)
        {
            return title switch
            {
                "Registration" => "Initial registration and enrollment process for the qualification program.",
                "Induction" => "Orientation and introduction to the program structure and requirements.",
                "Documentation Received" => "All necessary documentation and materials have been received and verified.",
                "Qualification Completion" => "Working through the qualification modules and completing required assessments.",
                "Internal Assessment" => "Assessment of completed work by internal moderators and assessors.",
                "Internal Moderation" => "Internal review and moderation of assessment results for quality assurance.",
                "External Verification" => "External verification by appointed QCTO representatives.",
                "Qualification Achieved" => "Successful completion of all qualification requirements.",
                "QCTO Certificate Issued" => "Official QCTO certificate has been issued and is available for collection.",
                _ => $"This stage represents: {title}. Status: {status}"
            };
        }

        public async Task DownloadCertificateAsync(string certificateId)
        {
            try
            {
                _logger.LogInformation($"Downloading certificate: {certificateId}");
                // Simulate download delay
                await Task.Delay(1000);
                // In a real implementation, this would trigger a file download
                _logger.LogInformation($"Certificate {certificateId} downloaded successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error downloading certificate {certificateId}");
                throw;
            }
        }

        private Qualification ParseQualification(JsonElement qualElement)
        {
            return new Qualification
            {
                Name = qualElement.GetProperty("name").GetString() ?? "",
                Status = qualElement.GetProperty("status").GetString() ?? "",
                NQFLevel = qualElement.GetProperty("nqfLevel").GetString() ?? "",
                TimelineItems = ParseTimelineItems(qualElement.GetProperty("timelineItems")),
                QualificationInfo = ParseQualificationInfo(qualElement.GetProperty("qualificationInfo")),
                Modules = ParseModules(qualElement.GetProperty("modules"))
            };
        }

        private List<TimelineItem> ParseTimelineItems(JsonElement timelineElement)
        {
            var items = new List<TimelineItem>();
            foreach (var item in timelineElement.EnumerateArray())
            {
                items.Add(new TimelineItem
                {
                    Number = item.GetProperty("number").GetString() ?? "",
                    Title = item.GetProperty("title").GetString() ?? "",
                    StatusText = item.GetProperty("statusText").GetString() ?? "",
                    Status = (TimelineStatus)item.GetProperty("status").GetInt32()
                });
            }
            return items;
        }

        private QualificationInformation ParseQualificationInfo(JsonElement infoElement)
        {
            return new QualificationInformation
            {
                DealNumber = infoElement.GetProperty("dealNumber").GetString() ?? "",
                ClientCompany = infoElement.GetProperty("clientCompany").GetString() ?? "",
                Facilitator = infoElement.GetProperty("facilitator").GetString() ?? "",
                ChiefLearningOfficer = infoElement.GetProperty("chiefLearningOfficer").GetString() ?? "",
                StartDate = infoElement.GetProperty("startDate").GetDateTime(),
                ExpectedEndDate = infoElement.GetProperty("expectedEndDate").GetDateTime(),
                SETA = infoElement.GetProperty("seta").GetString() ?? "",
                QualificationCode = infoElement.GetProperty("qualificationCode").GetString() ?? "",
                NQFLevel = infoElement.GetProperty("nqfLevel").GetString() ?? "",
                Credits = infoElement.GetProperty("credits").GetString() ?? "",
                ProgrammeDuration = infoElement.GetProperty("programmeDuration").GetString() ?? "",
                WorkplaceMentor = infoElement.GetProperty("workplaceMentor").GetString() ?? ""
            };
        }

        private List<ModuleInfo> ParseModules(JsonElement modulesElement)
        {
            var modules = new List<ModuleInfo>();
            foreach (var module in modulesElement.EnumerateArray())
            {
                modules.Add(new ModuleInfo
                {
                    Name = module.GetProperty("name").GetString() ?? "",
                    Subtitle = module.GetProperty("subtitle").GetString() ?? "",
                    Description = module.GetProperty("description").GetString() ?? "",
                    Progress = module.GetProperty("progress").GetString() ?? "",
                    ProgressColor = (Color)module.GetProperty("progressColor").GetInt32(),
                    Feedback = module.GetProperty("feedback").GetString() ?? "",
                    FeedbackColor = (Color)module.GetProperty("feedbackColor").GetInt32(),
                    CompletedUnits = module.GetProperty("completedUnits").GetInt32(),
                    TotalUnits = module.GetProperty("totalUnits").GetInt32(),
                    Units = ParseUnits(module.GetProperty("units"))
                });
            }
            return modules;
        }

        private List<UnitInfo> ParseUnits(JsonElement unitsElement)
        {
            var units = new List<UnitInfo>();
            foreach (var unit in unitsElement.EnumerateArray())
            {
                units.Add(new UnitInfo
                {
                    UnitStandard = unit.GetProperty("unitStandard").GetString() ?? "",
                    UnitName = unit.GetProperty("unitName").GetString() ?? "",
                    Type = unit.GetProperty("type").GetString() ?? "",
                    Progress = unit.GetProperty("progress").GetString() ?? "",
                    ProgressColor = (Color)unit.GetProperty("progressColor").GetInt32(),
                    Actions = unit.GetProperty("actions").GetString() ?? "",
                    ActionColor = (Color)unit.GetProperty("actionColor").GetInt32(),
                    Submit = unit.GetProperty("submit").GetString() ?? "",
                    SubmitColor = (Color)unit.GetProperty("submitColor").GetInt32()
                });
            }
            return units;
        }
    }
}