
namespace JobList.Common.Pagination
{
    public class PaginationUrlQuery
    {
        private const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageCount = maxPageSize;
        public int PageSize
        {
            get { return _pageCount; }
            set { _pageCount = (value > maxPageSize) ? maxPageSize : value; }
        }

        public string Query { get; set; }
    }
}
