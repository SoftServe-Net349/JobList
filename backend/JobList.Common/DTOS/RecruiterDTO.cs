﻿using JobList.Common.Interfaces.Entities;

namespace JobList.Common.DTOS
{
    public class RecruiterDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PhotoData { get; set; }
        public string PhotoMimetype { get; set; }
        public string Email { get; set; }

        public RoleDTO Role { get; set; }
        public CompanyDTO Company { get; set; }
    }
}
