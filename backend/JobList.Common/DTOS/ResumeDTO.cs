using JobList.Common.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace JobList.Common.DTOS
{
    public class ResumeDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public string Facebook { get; set; }
        public string Skype { get; set; }
        public string Instagram { get; set; }
        public string FamilyState { get; set; }
        public string SoftSkills { get; set; }
        public string KeySkills { get; set; }
        public string Introduction { get; set; }
        public string Position { get; set; }
        public string Courses { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModDate { get; set; }

        public EmployeeDTO User { get; set; }
        public WorkAreaDTO WorkArea { get; set; }
        public IList<EducationPeriodDTO> EducationPeriods { get; set; }
        public IList<ExperienceDTO> Experiences { get; set; }
        public IList<ResumeLanguageDTO> ResumeLanguages { get; set; }
    }
}
