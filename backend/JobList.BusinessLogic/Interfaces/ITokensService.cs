using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface ITokensService<T>
    {
        Task<TokenDTO> CreateTokenAsync(LoginRequest request);
        string GenerateJWT(T entity);
        string GenerateRefreshToken();
        Task<TokenDTO> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
