using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Options;
using JobList.Common.Requests;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Services
{
    public class TokensService : ITokensService
    {
        private readonly IUsersService usersService;
        private readonly IOptions<JobListTokenOptions> tokenOptions;

        public TokensService(IUsersService _usersService, IOptions<JobListTokenOptions> _tokenOptions)
        {
            usersService = _usersService;
            tokenOptions = _tokenOptions;
        }

        public async Task<TokenDTO> CreateTokenAsync(UserLoginRequest request)
        {
            var userDTO = await usersService.GetAuthenticatedUserAsync(request.Email);

            if (userDTO == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "User with such E-Mail not registered yet!");
            }

            if (userDTO.Password != request.Password)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Password is uncorrect!");
            }

            return CreateTokenDTO(userDTO);
        }

        public TokenDTO CreateTokenDTO(UserDTO userDTO)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userDTO.Id.ToString()),
                new Claim(ClaimTypes.Email, userDTO.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userDTO.Role.Name)
            };

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Value.Issuer,
                audience: tokenOptions.Value.Audience,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(tokenOptions.Value.Access_Token_Lifetime)),
                signingCredentials: new SigningCredentials(tokenOptions.Value.GetSymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            );

            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenDTO(encodeJwt, userDTO);
        }

        public async Task<TokenDTO> RefreshTokenAsync(RefreshTokenRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
