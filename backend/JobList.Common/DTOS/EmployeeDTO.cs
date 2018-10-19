using JobList.Common.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace JobList.Common.DTOS
{
    public class EmployeeDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public byte[] PhotoData { get; set; }
        public string PhotoMimeType { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        public RoleDTO Role { get; set; }
        public CityDTO City { get; set; }
        public IList<FavoriteVacancyDTO> FavoriteVacancies { get; set; }
    }
}
