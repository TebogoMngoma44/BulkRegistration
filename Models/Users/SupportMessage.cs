using System.ComponentModel.DataAnnotations;

namespace SupportSystem.Models
{
    public class SupportMessage
    {
        public int Id { get; set; }

        [Required]
        public string MessageId { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public MessageStatus Status { get; set; }

        public MessagePriority Priority { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int ResponseCount { get; set; }

        public List<MessageResponse> Responses { get; set; } = new List<MessageResponse>();
    }

    public class MessageResponse
    {
        public int Id { get; set; }

        public int SupportMessageId { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public bool IsStaffResponse { get; set; }

        // Navigation property
        public SupportMessage? SupportMessage { get; set; }
    }

    public enum MessageStatus
    {
        New,
        InProgress,
        Resolved
    }

    public enum MessagePriority
    {
        Low,
        Medium,
        High
    }
}
