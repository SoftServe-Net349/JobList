using System;
using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class Resume :  Entity<int>
    {
        public Resume()
        {
            EducationPeriods = new HashSet<EducationPeriod>();
            Experiences = new HashSet<Experience>();
            ResumeLanguages = new HashSet<ResumeLanguage>();
        }

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

        public User IdNavigation { get; set; }
        public WorkArea WorkArea { get; set; }
        public ICollection<EducationPeriod> EducationPeriods { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<ResumeLanguage> ResumeLanguages { get; set; }
    }
}
