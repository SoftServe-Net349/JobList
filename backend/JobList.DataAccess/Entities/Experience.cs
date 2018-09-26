using System;

namespace JobList.DataAccess.Entities
{
    public class Experience : Entity<int>
    {
        public override int Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int ResumeId { get; set; }

        public Resume Resume { get; set; }
    }
}
