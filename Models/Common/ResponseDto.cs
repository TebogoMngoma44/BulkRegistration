namespace Speccon.Learnership.FrontEnd.Models.Common
{
    public class PagedResponseDto<T>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
