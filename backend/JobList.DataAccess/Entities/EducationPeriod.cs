using System;

namespace JobList.DataAccess.Entities
{
    public class EducationPeriod : Entity<int>
    {
        public override int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int SchoolId { get; set; }
        public int ResumeId { get; set; }

        public Resume Resume { get; set; }
        public School School { get; set; }
    }
}
