using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class City : Entity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string LogoData { get; set; }
        public string LogoMimetype { get; set; }


        public IList<User> Users { get; set; }
        public IList<Vacancy> Vacancies { get; set; }
    }
}
