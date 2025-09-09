// Models/PracticalAssignment/PracticalModel.cs
using System.ComponentModel.DataAnnotations;

namespace Speccon.Learnership.FrontEnd.Models.PracticalAssignment
{
    public class PracticalAssignmentModel
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ModuleNumber { get; set; } = string.Empty;
        public string ModuleTitle { get; set; } = string.Empty;
        public PracticalType Type { get; set; }
        public int DurationWeeks { get; set; }
        public string Tool { get; set; } = string.Empty;
        public int WeightPercentage { get; set; }
        public int PassMarkPercentage { get; set; }
        public string Files { get; set; } = string.Empty;
        public PracticalStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public string QualificationPath { get; set; } = string.Empty;
        public string AssignmentType { get; set; } = string.Empty;
    }

    public enum PracticalType
    {
        Practical,
        Theory,
        Assessment,
        Project
    }

    public enum PracticalStatus
    {
        NotStarted,
        InProgress,
        Completed,
        Overdue,
        Submitted
    }

    public class NavigationItem
    {
        public string Text { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class UserProfile
    {
        public string Initials { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int NotificationCount { get; set; }
    }

    public class PracticalBreadcrumbItem
    {
        public string Text { get; set; } = string.Empty;
        public string? Route { get; set; }
        public bool IsActive { get; set; }
    }

    public class PracticalDashboardData
    {
        public List<NavigationItem> NavigationItems { get; set; } = new();
        public UserProfile User { get; set; } = new();
        public List<PracticalBreadcrumbItem> Breadcrumbs { get; set; } = new();
        public PracticalAssignmentModel? CurrentAssignment { get; set; }
    }
}