
namespace JobList.Common.DTOS
{
    public class TokenDTO
    {
        public TokenDTO()
        {

        }

        public TokenDTO(string jwt, UserDTO user)
        {
            Jwt = jwt;
            User = user;
        }

        public string Jwt { get; set; }

        public UserDTO User { get; set; }
    }
}
