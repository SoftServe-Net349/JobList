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
    public class RecruiterTokensService: ITokensService<RecruiterDTO>
    {
        private readonly IOptions<JobListTokenOptions> tokenOptions;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public RecruiterTokensService(IUnitOfWork _uow, IMapper _mapper, IOptions<JobListTokenOptions> _tokenOptions)
        {
            uow = _uow;
            mapper = _mapper;
            tokenOptions = _tokenOptions;
        }

        public async Task<TokenDTO> CreateTokenAsync(LoginRequest request)
        {
            var entity = await uow.RecruitersRepository.GetFirstOrDefaultAsync(
                filter: u => u.Email == request.Email,
                include: r => r.Include(o => o.Role));

            if (entity == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Login is uncorrect!");
            }
            byte[] hashBytes = Convert.FromBase64String(entity.Password);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var hashRequestPassword = new Rfc2898DeriveBytes(request.Password, salt, 1000);
            byte[] hashRequest = hashRequestPassword.GetBytes(20);
            bool flag = false;
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] == hashRequest[i])
                {
                    flag = true;
                }
                else break;

            }

            if (flag == false)
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

            var dto = mapper.Map<Recruiter, RecruiterDTO>(entity);

            var jwt = GenerateJWT(dto);

            return new TokenDTO(jwt, refreshToken);
        }

        public string GenerateJWT(RecruiterDTO recruiterDTO)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, recruiterDTO.Id.ToString()),
                new Claim(ClaimTypes.Email, recruiterDTO.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, recruiterDTO.Role.Name)
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
            var entity = await uow.RecruitersRepository.GetEntityAsync(
                request.UId,
                include: r => r.Include(o => o.Role));

            if (entity == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Recruiter with such Id not registered yet!");
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

            var dto = mapper.Map<Recruiter, RecruiterDTO>(entity);

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
