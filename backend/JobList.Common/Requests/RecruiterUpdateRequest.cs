
namespace JobList.Common.Requests
{
    public class RecruiterUpdateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PhotoData { get; set; }
        public string PhotoMimetype { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }
    }
}
