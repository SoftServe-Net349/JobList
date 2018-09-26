using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class School : Entity<int>
    {
        public School()
        {
            EducationPeriods = new HashSet<EducationPeriod>();
            Faculties = new HashSet<Faculty>();
        }

        public override int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EducationPeriod> EducationPeriods { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
    }
}
