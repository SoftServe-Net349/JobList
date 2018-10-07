using System;

namespace JobList.Common.Pagination
{
    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public int? TotalRecords { get; set; }
        public int? TotalPages => TotalRecords.HasValue ? (int)Math.Ceiling(TotalRecords.Value / (double)PageCount) : (int?)null;
    }
}
