using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class WorkArea : Entity<int>
    {
        public WorkArea()
        {
            Resumes = new HashSet<Resume>();
            Vacancies = new HashSet<Vacancy>();
        }

        public override int Id { get; set; }
        public string Name { get; set; }
        public byte[] PhotoData { get; set; }
        public string PhotoMimetype { get; set; }

        public ICollection<Resume> Resumes { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
