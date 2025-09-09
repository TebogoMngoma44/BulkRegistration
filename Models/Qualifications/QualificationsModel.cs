using MudBlazor;

namespace Speccon.Learnership.FrontEnd.Models.Qualifications
{
    public enum TimelineStatus
    {
        Completed,
        InProgress,
        Pending
    }

    public class TimelineItem
    {
        public string Number { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string StatusText { get; set; } = string.Empty;
        public TimelineStatus Status { get; set; }
    }

    public class UnitInfo
    {
        public string UnitStandard { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Progress { get; set; } = string.Empty;
        public Color ProgressColor { get; set; }
        public string Actions { get; set; } = string.Empty;
        public Color ActionColor { get; set; }
        public string Submit { get; set; } = string.Empty;
        public Color SubmitColor { get; set; }
    }

    public class ModuleInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Progress { get; set; } = string.Empty;
        public Color ProgressColor { get; set; }
        public string Feedback { get; set; } = string.Empty;
        public Color FeedbackColor { get; set; }
        public int CompletedUnits { get; set; }
        public int TotalUnits { get; set; }
        public List<UnitInfo> Units { get; set; } = new();
    }

    public class QualificationInformation
    {
        public string DealNumber { get; set; } = string.Empty;
        public string ClientCompany { get; set; } = string.Empty;
        public string Facilitator { get; set; } = string.Empty;
        public string ChiefLearningOfficer { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public string SETA { get; set; } = string.Empty;
        public string QualificationCode { get; set; } = string.Empty;
        public string NQFLevel { get; set; } = string.Empty;
        public string Credits { get; set; } = string.Empty;
        public string ProgrammeDuration { get; set; } = string.Empty;
        public string WorkplaceMentor { get; set; } = string.Empty;
    }

    public class Qualification
    {
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string NQFLevel { get; set; } = string.Empty;
        public int OverallProgress { get; set; }
        public int UnitsCompleted { get; set; }
        public int TotalUnits { get; set; }
        public int MonthsRemaining { get; set; }
        public List<TimelineItem> TimelineItems { get; set; } = new();
        public QualificationInformation QualificationInfo { get; set; } = new();
        public List<ModuleInfo> Modules { get; set; } = new();
    }

    public class CertificateInfo
    {
        public int ModuleNumber { get; set; }
        public string ModuleName { get; set; } = string.Empty;
        public string ModuleCode { get; set; } = string.Empty;
        public DateTime CompletionDate { get; set; }
        public string TimeAgo { get; set; } = string.Empty;
        public int GradePercentage { get; set; }
        public string GradeStatus { get; set; } = string.Empty;
        public string CertificateId { get; set; } = string.Empty;
    }
}
