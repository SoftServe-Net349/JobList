
namespace JobList.Common.Pagination
{
    public class UrlQuery
    {
        private const int maxPageCount = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageCount = maxPageCount;
        public int PageCount
        {
            get { return _pageCount; }
            set { _pageCount = (value > maxPageCount) ? maxPageCount : value; }
        }

        public string Query { get; set; }
    }
}
