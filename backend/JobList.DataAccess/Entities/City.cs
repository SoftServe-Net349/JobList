using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class City : Entity<int>
    {
        public City()
        {
            Users = new HashSet<User>();
            Vacancies = new HashSet<Vacancy>();
        }

        public override int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
