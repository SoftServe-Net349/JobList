using System.ComponentModel.DataAnnotations;

namespace JobList.Common.Requests
{
    public class UserLoginRequest
    {
        public UserLoginRequest()
        {

        }

        public UserLoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
        
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
