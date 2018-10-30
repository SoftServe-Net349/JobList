using System;

namespace JobList.Common.Requests
{
    public class EmployeeUpdateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PhotoData { get; set; }
        public string PhotoMimeType { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int CityId { get; set; }
    }
}
