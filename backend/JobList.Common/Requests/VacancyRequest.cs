using System;

namespace JobList.Common.Requests
{
    public class VacancyRequest
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Offering { get; set; }
        public string Requirements { get; set; }
        public string BePlus { get; set; }
        public bool? IsChecked { get; set; }
        public decimal? Salary { get; set; }
        public string FullPartTime { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        public int RecruiterId { get; set; }
        public int CityId { get; set; }
    }
}
