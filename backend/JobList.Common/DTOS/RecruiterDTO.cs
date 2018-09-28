using JobList.Common.Interfaces.Entities;
using System.Collections.Generic;

namespace JobList.Common.DTOS
{
    public class RecruiterDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }

        public CompanyDTO Company { get; set; }
        public IList<VacancyDTO> Vacancies { get; set; }
    }
}
