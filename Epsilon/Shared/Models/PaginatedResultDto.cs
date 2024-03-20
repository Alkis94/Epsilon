namespace Epsilon.Shared.Models
{
    public class PaginatedResultDto<T> where T : class
    {
        public IEnumerable<T>? Data { get; set; }

        public int Total { get; set; }
    }
}
