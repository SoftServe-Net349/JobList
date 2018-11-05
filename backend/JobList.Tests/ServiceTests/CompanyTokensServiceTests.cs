using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FakeItEasy;
using JobList.BusinessLogic.Interfaces;
using JobList.BusinessLogic.MappingProfiles;
using JobList.BusinessLogic.Services;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Options;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.Tests.ServiceTests
{
    [TestFixture]
    public class CompanyTokensServiceTests
    {
        ITokensService<CompanyDTO> _companyTokensService;
        IMapper _mapper;
        IOptions<JobListTokenOptions> _tokenOptions;
        IOptions<FacebookAuthOptions> _facebookAuthOptions;
        IUnitOfWork _unitOfWork;

        [SetUp]
        public void Set_UnitOfWork_And_CompaniesService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CompanyProfile>();
            });

            _tokenOptions = Options.Create(new JobListTokenOptions
            {
                Issuer = "http://localhost:56681/",
                Audience = "http://localhost:56681/",
                Access_Token_Lifetime = 5,
                Security_Key = "TokensSuperSecretKey"
            });

            _unitOfWork = A.Fake<IUnitOfWork>();
            _companyTokensService = new CompanyTokensService(_unitOfWork, config.CreateMapper(), _tokenOptions);
        }

        [Test]
        public async Task CreateTokenAsync_Should_Create_token_typeof_TokenDTO()
        {
            // Arrange
            var request = new LoginRequest
            {
                Email = "pavlo@gmail.com",
                Password = "1620856d708f0918693c2bfda4f962adff6344b248eb1a39b7c82146"
            };

            A.CallTo(() => _unitOfWork.CompaniesRepository
            .GetFirstOrDefaultAsync(A<Expression<Func<Company, bool>>>._, null, A<Func<IQueryable<Company>, IIncludableQueryable<Company, object>>>._))
            .Returns(new Company
            {
                Id = 1,
                Email = "pavlo@gmail.com",
                BossName = "Pavlo Paitak",
                Password = "QM0rSdDxR1hZa+zFebNYrF4JHC+hm6INGMi4RKbf71exF2cO",
                RoleId = 1,
                Role = new Role { Id = 1, Name = "company" },
            });
            A.CallTo(() => _unitOfWork.SaveAsync()).Returns(true);

            // Act
            var resualt = await _companyTokensService.CreateTokenAsync(request);

            // Assert
            Assert.IsInstanceOf(typeof(TokenDTO), resualt);

        }

        [Test]
        public void CreateTokenAsync_Should_Throw_HttpStatusCodeException_Uncorrect_Login()
        {
            // Arrange
            var request = new LoginRequest
            {
                Email = "pavlo@gmail.com",
                Password = "1620856d708f0918693c2bfda4f962adff6344b248eb1a39b7c82146"
            };

            A.CallTo(() => _unitOfWork.CompaniesRepository
            .GetFirstOrDefaultAsync(A<Expression<Func<Company, bool>>>._, null, A<Func<IQueryable<Company>, IIncludableQueryable<Company, object>>>._))
            .Returns((Company)null);

            // Assert & Act
            var ex = Assert.ThrowsAsync<HttpStatusCodeException>(() => _companyTokensService.CreateTokenAsync(request));
            Assert.That(ex.Message, Is.EqualTo("Login is uncorrect!"));
        }

        [Test]
        public void CreateTokenAsync_Should_Throw_HttpStatusCodeException_Uncorrect_Password()
        {
            // Arrange
            var request = new LoginRequest
            {
                Email = "pavlo@gmail.com",
                Password = "not correct password"
            };

            A.CallTo(() => _unitOfWork.CompaniesRepository
            .GetFirstOrDefaultAsync(A<Expression<Func<Company, bool>>>._, null, A<Func<IQueryable<Company>, IIncludableQueryable<Company, object>>>._))
            .Returns(new Company
            {
                Id = 1,
                Email = "pavlo@gmail.com",
                BossName = "Pavlo Paitak",
                Password = "QM0rSdDxR1hZa+zFebNYrF4JHC+hm6INGMi4RKbf71exF2cO",
                RoleId = 1,
                Role = new Role { Id = 1, Name = "company" },
            });

            // Assert & Act
            var ex = Assert.ThrowsAsync<HttpStatusCodeException>(() => _companyTokensService.CreateTokenAsync(request));
            Assert.That(ex.Message, Is.EqualTo("Password is uncorrect!"));
        }

        [Test]
        public async Task RefreshTokenAsync_Should_Create_token_typeof_TokenDTO()
        {
            // Arrange
            var request = new RefreshTokenRequest
            {
                UId = 1,
                RefreshToken = "refresh_Token"
            };

            A.CallTo(() => _unitOfWork.CompaniesRepository
            .GetEntityAsync(A<int>._, A<Func<IQueryable<Company>, IIncludableQueryable<Company, object>>>._))
            .Returns(new Company
            {
                Id = 1,
                Email = "pavlo@gmail.com",
                BossName = "Pavlo Paitak",
                Password = "QM0rSdDxR1hZa+zFebNYrF4JHC+hm6INGMi4RKbf71exF2cO",
                RoleId = 1,
                Role = new Role { Id = 1, Name = "company" },
                RefreshToken = "refresh_Token"
            });
            A.CallTo(() => _unitOfWork.SaveAsync()).Returns(true);

            // Act
            var resualt = await _companyTokensService.RefreshTokenAsync(request);

            // Assert
            Assert.IsInstanceOf(typeof(TokenDTO), resualt);

        }

        [Test]
        public void RefreshTokenAsync_Should_HttpStatusCodeException_Uncorrect_UId()
        {
            // Arrange
            var request = new RefreshTokenRequest
            {
                UId = 1,
                RefreshToken = "refresh_Token"
            };

            A.CallTo(() => _unitOfWork.CompaniesRepository
            .GetEntityAsync(A<int>._, A<Func<IQueryable<Company>, IIncludableQueryable<Company, object>>>._))
            .Returns((Company)null);

            // Assert & Act
            var ex = Assert.ThrowsAsync<HttpStatusCodeException>(() => _companyTokensService.RefreshTokenAsync(request));
            Assert.That(ex.Message, Is.EqualTo("Company with such Id not registered yet!"));

        }

        [Test]
        public void RefreshTokenAsync_Should_HttpStatusCodeException_Invalid_Refresh_Token()
        {
            // Arrange
            var request = new RefreshTokenRequest
            {
                UId = 1,
                RefreshToken = "invalid_refresh_Token"
            };

            A.CallTo(() => _unitOfWork.CompaniesRepository
            .GetEntityAsync(A<int>._, A<Func<IQueryable<Company>, IIncludableQueryable<Company, object>>>._))
            .Returns(new Company
            {
                Id = 1,
                Email = "pavlo@gmail.com",
                BossName = "Pavlo Paitak",
                Password = "QM0rSdDxR1hZa+zFebNYrF4JHC+hm6INGMi4RKbf71exF2cO",
                RoleId = 1,
                Role = new Role { Id = 1, Name = "company" },
                RefreshToken = "refresh_Token"
            });

            // Assert & Act
            var ex = Assert.ThrowsAsync<HttpStatusCodeException>(() => _companyTokensService.RefreshTokenAsync(request));
            Assert.That(ex.Message, Is.EqualTo("RefreshToken is Invalid!"));
        }

    }
}
