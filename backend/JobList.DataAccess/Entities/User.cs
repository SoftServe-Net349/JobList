using System;
using System.Collections.Generic;

namespace JobList.DataAccess.Entities
{
    public class User : Entity<int>
    {
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PhotoData { get; set; }
        public string PhotoMimeType { get; set; }
        public string Sex { get; set; }
        public DateTime BirthData { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public Role Role { get; set; }
        public Resume Resumes { get; set; }
        public IList<FavoriteVacancy> FavoriteVacancies { get; set; }
    }
}
