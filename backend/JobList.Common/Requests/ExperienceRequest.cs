using System;

namespace JobList.Common.Requests
{
    public class ExperienceRequest
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int ResumeId { get; set; }
    }
}
