
namespace JobList.Common.DTOS
{
    public class TokenDTO
    {
        public TokenDTO()
        {

        }

        public TokenDTO(string _jwt, string _refreshToken)
        {
            Jwt = _jwt;
            RefreshToken = _refreshToken;
        }

        public string Jwt { get; set; }
        public string RefreshToken { get; set; }
    }
}
