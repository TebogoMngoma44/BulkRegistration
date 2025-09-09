using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Speccon.Learnership.FrontEnd.Models.Assignment
{
    // Models/Assignment/AssignmentSubmission.cs
    public class AssignmentSubmission
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime SubmissionDate { get; set; }
        public string Status { get; set; } = ""; // "Draft", "Submitted", "Graded"
        public List<FileInfo> Files { get; set; } = new();
        public int? Grade { get; set; }
        public string? Feedback { get; set; }
        public string? StudentId { get; set; }
        public string? AssignmentId { get; set; }
        public bool IsLate { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class ResourceItem
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Icon { get; set; } = "";
        public string Color { get; set; } = "";
    }
    // Models/Assignment/FileInfo.cs
    public class FileInfo
    {
        public string FileName { get; set; } = "";
        public long FileSize { get; set; }
        public string FileType { get; set; } = "";
        public string? FilePath { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public string? FileId { get; set; }
        public string? StorageType { get; set; } // "localStorage", "download", "server"
        public bool IsCorrupted { get; set; } = false;
        public string? CheckSum { get; set; }
    }

    // Models/Assignment/MockBrowserFile.cs
    public class MockBrowserFile : IBrowserFile
    {
        public string Name { get; private set; }
        public DateTimeOffset LastModified { get; private set; }
        public long Size { get; private set; }
        public string ContentType { get; private set; }

        public MockBrowserFile(string name, long size, string contentType)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Size = size;
            ContentType = contentType ?? "application/octet-stream";
            LastModified = DateTimeOffset.Now;
        }

        public Stream OpenReadStream(long maxAllowedSize = 512000, CancellationToken cancellationToken = default)
        {
            // For a mock implementation, return an empty stream
            // In a real implementation, this would read the actual file content
            return new MemoryStream();
        }
    }

    // Models/Assignment/AssignmentConfiguration.cs
    public class AssignmentConfiguration
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DueDate { get; set; }
        public int MaxFileSize { get; set; } = 10 * 1024 * 1024; // 10MB
        public List<string> AllowedFileTypes { get; set; } = new() { ".pdf", ".doc", ".docx" };
        public int MaxFileCount { get; set; } = 5;
        public bool AllowLateSubmissions { get; set; } = true;
        public int LatePenaltyPercentage { get; set; } = 10;
        public int MaxLateDays { get; set; } = 7;
        public bool RequireAntiPlagiarismCheck { get; set; } = false;
        public int PassingGrade { get; set; } = 50;
        public int TotalPoints { get; set; } = 100;
        public List<AssignmentCriterion> GradingCriteria { get; set; } = new();
    }

    // Models/Assignment/AssignmentCriterion.cs
    public class AssignmentCriterion
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int MaxPoints { get; set; }
        public int Weight { get; set; } // Percentage weight of this criterion
        public bool IsRequired { get; set; } = true;
        public List<string> RubricLevels { get; set; } = new(); // "Excellent", "Good", "Fair", "Poor"
    }

    // Models/Assignment/SubmissionStatus.cs
    public enum SubmissionStatus
    {
        NotStarted,
        InProgress,
        Draft,
        Submitted,
        UnderReview,
        Graded,
        Returned,
        Resubmitted,
        Late,
        Rejected
    }

    // Models/Assignment/FileUploadResult.cs
    public class FileUploadResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public string? FileId { get; set; }
        public string? FilePath { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public string? ErrorCode { get; set; }
        public Exception? Exception { get; set; }
        public string StorageType { get; set; } = "localStorage"; // "localStorage", "download", "server"
    }

    // Models/Assignment/AssignmentGrade.cs
    public class AssignmentGrade
    {
        public string Id { get; set; } = "";
        public string SubmissionId { get; set; } = "";
        public string StudentId { get; set; } = "";
        public string AssignmentId { get; set; } = "";
        public int TotalPoints { get; set; }
        public int EarnedPoints { get; set; }
        public decimal Percentage { get; set; }
        public string LetterGrade { get; set; } = "";
        public string? Feedback { get; set; }
        public DateTime GradedDate { get; set; }
        public string GradedBy { get; set; } = "";
        public List<CriterionGrade> CriterionGrades { get; set; } = new();
        public bool IsLate { get; set; }
        public int LatePenalty { get; set; }
        public bool IsPlagiarismFlagged { get; set; }
        public string? PlagiarismReport { get; set; }
    }

    // Models/Assignment/CriterionGrade.cs
    public class CriterionGrade
    {
        public string CriterionId { get; set; } = "";
        public string CriterionName { get; set; } = "";
        public int MaxPoints { get; set; }
        public int EarnedPoints { get; set; }
        public string? Feedback { get; set; }
        public string? RubricLevel { get; set; }
        public DateTime GradedDate { get; set; }
    }

    // Models/Assignment/StorageQuotaInfo.cs
    public class StorageQuotaInfo
    {
        public long TotalBytes { get; set; }
        public long UsedBytes { get; set; }
        public long AvailableBytes { get; set; }
        public double UsagePercentage { get; set; }
        public int FileCount { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<string> LargestFiles { get; set; } = new();
        public List<string> OldestFiles { get; set; } = new();
    }

    // Models/Assignment/AssignmentMetrics.cs
    public class AssignmentMetrics
    {
        public string AssignmentId { get; set; } = "";
        public int TotalStudents { get; set; }
        public int SubmittedCount { get; set; }
        public int DraftCount { get; set; }
        public int LateCount { get; set; }
        public int NotSubmittedCount { get; set; }
        public double AverageGrade { get; set; }
        public double MedianGrade { get; set; }
        public int HighestGrade { get; set; }
        public int LowestGrade { get; set; }
        public TimeSpan AverageSubmissionTime { get; set; }
        public List<string> CommonIssues { get; set; } = new();
        public Dictionary<string, int> FileTypeDistribution { get; set; } = new();
    }

    // Models/Assignment/AssignmentNotification.cs
    public class AssignmentNotification
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public NotificationType Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRead { get; set; }
        public string? AssignmentId { get; set; }
        public string? SubmissionId { get; set; }
        public string? ActionUrl { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public Dictionary<string, string> Data { get; set; } = new();
    }

    public enum NotificationType
    {
        Info,
        Success,
        Warning,
        Error,
        Reminder,
        Deadline,
        Grade,
        Feedback
    }

    // Models/Assignment/BrowserFileExtensions.cs
    public static class BrowserFileExtensions
    {
        public static bool IsValidType(this IBrowserFile file, string[] allowedExtensions)
        {
            var extension = Path.GetExtension(file.Name).ToLowerInvariant();
            return allowedExtensions.Contains(extension);
        }

        public static bool IsValidSize(this IBrowserFile file, long maxSize)
        {
            return file.Size <= maxSize;
        }

        public static string GetSizeString(this IBrowserFile file)
        {
            if (file.Size < 1024) return $"{file.Size} B";
            if (file.Size < 1024 * 1024) return $"{file.Size / 1024:F1} KB";
            return $"{file.Size / (1024 * 1024):F1} MB";
        }

        public static string GetFileIcon(this IBrowserFile file)
        {
            var extension = Path.GetExtension(file.Name).ToLowerInvariant();
            return extension switch
            {
                ".pdf" => "fa-file-pdf",
                ".doc" or ".docx" => "fa-file-word",
                ".xls" or ".xlsx" => "fa-file-excel",
                ".ppt" or ".pptx" => "fa-file-powerpoint",
                ".txt" => "fa-file-text",
                ".zip" or ".rar" => "fa-file-archive",
                ".jpg" or ".jpeg" or ".png" or ".gif" => "fa-file-image",
                _ => "fa-file"
            };
        }
    }
}
