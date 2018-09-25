using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class Role : Entity<int>
    {
        public Role()
        {
            Companies = new HashSet<Company>();
            Recruiters = new HashSet<Recruiter>();
            Users = new HashSet<User>();
        }

        public override int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Company> Companies { get; set; }
        public ICollection<Recruiter> Recruiters { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
