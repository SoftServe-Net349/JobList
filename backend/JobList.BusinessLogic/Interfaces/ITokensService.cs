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
        TokenDTO CreateTokenDTO(UserDTO userDTO);
        Task<TokenDTO> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
