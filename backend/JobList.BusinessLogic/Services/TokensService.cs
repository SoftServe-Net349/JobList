using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Options;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Services
{
    public class TokensService : ITokensService
    {
        private readonly IOptions<JobListTokenOptions> tokenOptions;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public TokensService(IUnitOfWork _uow, IMapper _mapper, IOptions<JobListTokenOptions> _tokenOptions)
        {
            uow = _uow;
            mapper = _mapper;
            tokenOptions = _tokenOptions;
        }

        public async Task<TokenDTO> CreateTokenAsync(UserLoginRequest request)
        {
            var entity = await uow.UsersRepository.GetFirstOrDefaultAsync(
                filter: u => u.Email == request.Email,
                include: r => r.Include(o => o.Role));

            if (entity == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "User with such E-Mail not registered yet!");
            }

            if (entity.Password != request.Password)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Password is uncorrect!");
            }
            var refreshToken = GenerateRefreshToken();

            entity.RefreshToken = refreshToken;

            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            var dto = mapper.Map<User, UserDTO>(entity);

            var jwt = GenerateJWT(dto);

            return new TokenDTO(jwt, refreshToken);
        }

        public string GenerateJWT(UserDTO userDTO)
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

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<TokenDTO> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var entity = await uow.UsersRepository.GetEntityAsync(
                request.UId,
                include: r => r.Include(o => o.Role));

            if (entity == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "User with such Id not registered yet!");
            }

            if (entity.RefreshToken != request.RefreshToken)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "RefreshToken is Invalid!");
            }

            var refreshToken = GenerateRefreshToken();

            entity.RefreshToken = refreshToken;

            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            var dto = mapper.Map<User, UserDTO>(entity);

            var jwt = GenerateJWT(dto);

            return new TokenDTO(jwt, refreshToken);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
