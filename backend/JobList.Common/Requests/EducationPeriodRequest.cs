using System;

namespace JobList.Common.Requests
{
    public class EducationPeriodRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int SchoolId { get; set; }
        public int ResumeId { get; set; }
    }
}
