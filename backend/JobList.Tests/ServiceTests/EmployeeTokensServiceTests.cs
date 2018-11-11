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
    public class EmployeeTokensServiceTests
    {
        IEmployeeTokensService _employeeTokensService;
        IOptions<JobListTokenOptions> _tokenOptions;
        IOptions<FacebookAuthOptions> _facebookAuthOptions;
        IUnitOfWork _unitOfWork;

        [SetUp]
        public void Set_UnitOfWork_And_EmployeesService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmployeeProfile>();
            });

            _tokenOptions = Options.Create(new JobListTokenOptions
            {
                Issuer = "http://localhost:56681/",
                Audience = "http://localhost:56681/",
                Access_Token_Lifetime = 5,
                Security_Key = "TokensSuperSecretKey"
            });

            _facebookAuthOptions = Options.Create(new FacebookAuthOptions
            {
                AppId = "720973974952428",
                AppSecret = "5964c51c163c0918ade28eb3c6b6bc89"
            });

            _unitOfWork = A.Fake<IUnitOfWork>();
            _employeeTokensService = new EmployeeTokensService(_unitOfWork, config.CreateMapper(), _tokenOptions, _facebookAuthOptions);
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

            A.CallTo(() => _unitOfWork.EmployeesRepository
            .GetFirstOrDefaultAsync(A<Expression<Func<Employee, bool>>>._, null, A<Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>>._))
            .Returns(new Employee
            {
                Id = 1,
                BirthDate = new DateTime(1998, 7, 12),
                Email = "pavlo@gmail.com",
                FirstName = "Pavlo",
                LastName = "Paitak",
                CityId = 1,
                Password = "QM0rSdDxR1hZa+zFebNYrF4JHC+hm6INGMi4RKbf71exF2cO",
                Phone = null,
                PhotoData = null,
                PhotoMimeType = null,
                RoleId = 1,
                Role = new Role {Id = 1, Name = "employee"},
                Sex = null
            });
            A.CallTo(() => _unitOfWork.SaveAsync()).Returns(true);

            // Act
            var resualt = await _employeeTokensService.CreateTokenAsync(request);

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

            A.CallTo(() => _unitOfWork.EmployeesRepository
            .GetFirstOrDefaultAsync(A<Expression<Func<Employee, bool>>>._, null, A<Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>>._))
            .Returns((Employee) null);

            // Assert & Act
            var ex = Assert.ThrowsAsync<HttpStatusCodeException>(() => _employeeTokensService.CreateTokenAsync(request));
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

            A.CallTo(() => _unitOfWork.EmployeesRepository
            .GetFirstOrDefaultAsync(A<Expression<Func<Employee, bool>>>._, null, A<Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>>._))
            .Returns(new Employee
            {
                Id = 1,
                BirthDate = new DateTime(1998, 7, 12),
                Email = "pavlo@gmail.com",
                FirstName = "Pavlo",
                LastName = "Paitak",
                CityId = 1,
                Password = "QM0rSdDxR1hZa+zFebNYrF4JHC+hm6INGMi4RKbf71exF2cO",
                Phone = null,
                PhotoData = null,
                PhotoMimeType = null,
                RoleId = 1,
                Role = new Role { Id = 1, Name = "employee" },
                Sex = null
            });

            // Assert & Act
            var ex = Assert.ThrowsAsync<HttpStatusCodeException>(() => _employeeTokensService.CreateTokenAsync(request));
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

            A.CallTo(() => _unitOfWork.EmployeesRepository
            .GetEntityAsync(A<int>._, A<Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>>._))
            .Returns(new Employee
            {
                Id = 1,
                BirthDate = new DateTime(1998, 7, 12),
                Email = "pavlo@gmail.com",
                FirstName = "Pavlo",
                LastName = "Paitak",
                CityId = 1,
                Password = "QM0rSdDxR1hZa+zFebNYrF4JHC+hm6INGMi4RKbf71exF2cO",
                Phone = null,
                PhotoData = null,
                PhotoMimeType = null,
                RoleId = 1,
                Role = new Role { Id = 1, Name = "employee" },
                Sex = null,
                RefreshToken = "refresh_Token"
            });
            A.CallTo(() => _unitOfWork.SaveAsync()).Returns(true);

            // Act
            var resualt = await _employeeTokensService.RefreshTokenAsync(request);

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

            A.CallTo(() => _unitOfWork.EmployeesRepository
            .GetEntityAsync(A<int>._, A<Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>>._))
            .Returns((Employee)null);

            // Assert & Act
            var ex = Assert.ThrowsAsync<HttpStatusCodeException>(() => _employeeTokensService.RefreshTokenAsync(request));
            Assert.That(ex.Message, Is.EqualTo("Employee with such Id not registered yet!"));

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

            A.CallTo(() => _unitOfWork.EmployeesRepository
            .GetEntityAsync(A<int>._, A<Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>>._))
            .Returns(new Employee
            {
                Id = 1,
                BirthDate = new DateTime(1998, 7, 12),
                Email = "pavlo@gmail.com",
                FirstName = "Pavlo",
                LastName = "Paitak",
                CityId = 1,
                Password = "QM0rSdDxR1hZa+zFebNYrF4JHC+hm6INGMi4RKbf71exF2cO",
                Phone = null,
                PhotoData = null,
                PhotoMimeType = null,
                RoleId = 1,
                Role = new Role { Id = 1, Name = "employee" },
                Sex = null,
                RefreshToken = "refresh_Token"
            });

            // Assert & Act
            var ex = Assert.ThrowsAsync<HttpStatusCodeException>(() => _employeeTokensService.RefreshTokenAsync(request));
            Assert.That(ex.Message, Is.EqualTo("RefreshToken is Invalid!"));
        }

    }
}
