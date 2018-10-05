using JobList.Common.Interfaces.Entities;
using System;

namespace JobList.Common.DTOS
{
    public class EducationPeriodDTO : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int SchoolId { get; set; }

        public FacultyDTO Faculty { get; set; }
        public SchoolDTO School { get; set; }
    }
}
