namespace Infrastructure.Dtos
{
    public class PaginationMetadata
    {
        public string PreviousPageLink { get; set; }
        public string NextPageLink { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}