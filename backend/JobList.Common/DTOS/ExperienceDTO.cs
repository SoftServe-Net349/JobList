using JobList.Common.Interfaces.Entities;
using System;

namespace JobList.Common.DTOS
{
    public class ExperienceDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int ResumeId { get; set; }
    }
}
