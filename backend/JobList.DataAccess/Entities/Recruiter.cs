using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class Recruiter : Entity<int>
    {
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }

        public Company Company { get; set; }
        public Role Role { get; set; }
        public IList<Vacancy> Vacancies { get; set; }
    }
}
