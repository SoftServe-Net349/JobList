using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class WorkArea : Entity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }

        public IList<Resume> Resumes { get; set; }
        public IList<Vacancy> Vacancies { get; set; }
    }
}
