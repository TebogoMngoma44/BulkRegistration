using System.ComponentModel.DataAnnotations;

namespace Speccon.Learnership.FrontEnd.Models.Disabilities
{
    public class Disability
    {
        [Key]
        public int DisabilityId { get; set; }
        public Guid DisabilityKey { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string DisabilityDescription { get; set; } = string.Empty;
    }

    public class DisabilityDto
    {
        public int DisabilityId { get; set; }
        public Guid DisabilityKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DisabilityDescription { get; set; }
    }

    public class DisabilityCreateDto
    {
        public string DisabilityDescription { get; set; }
    }

    public class DisabilityUpdateDto
    {
        public Guid DisabilityKey { get; set; }
        public int DisabilityId { get; set; }
        public string DisabilityDescription { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class DisabilityDeleteDto
    {
        public Guid DisabilityKey { get; set; }
    }
}

