
namespace SupportSystem.Models
{
    public class MessageOverview
    {
        public int NewCount { get; set; }
        public int InProgressCount { get; set; }
        public int ResolvedCount { get; set; }

        public int TotalCount => NewCount + InProgressCount + ResolvedCount;
    }
}