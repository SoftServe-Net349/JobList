using System;
using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class Resume :  Entity<int>
    {
        public override int Id { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public string Facebook { get; set; }
        public string Skype { get; set; }
        public string Instagram { get; set; }
        public string FamilyState { get; set; }
        public string SoftSkills { get; set; }
        public string KeySkills { get; set; }
        public string Courses { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        public int WorkAreaId { get; set; }

        public User User { get; set; }
        public WorkArea WorkArea { get; set; }
        public IList<EducationPeriod> EducationPeriods { get; set; }
        public IList<Experience> Experiences { get; set; }
        public IList<ResumeLanguage> ResumeLanguages { get; set; }
    }
}
