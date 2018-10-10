using JobList.Common.DTOS;
using JobList.Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface ITokensService
    {
        Task<TokenDTO> CreateTokenAsync(UserLoginRequest request);
        string GenerateJWT(UserDTO userDTO);
        string GenerateRefreshToken();
        Task<TokenDTO> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
