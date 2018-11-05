using AutoMapper;
using FakeItEasy;
using JobList.BusinessLogic.Interfaces;
using JobList.BusinessLogic.MappingProfiles;
using JobList.BusinessLogic.Services;
using JobList.Common.Options;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JobList.Tests.ServiceTests
{
    [TestFixture]
    public class EmployeeTokensServiceTests
    {
        IEmployeeTokensService _employeeTokensService;
        IMapper _mapper;
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
        public void CreateTokenAsync_Should_Create_token_typeof_TokenDTO()
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
                Sex = null
            });

            // Act
            var resualt = _employeeTokensService.CreateTokenAsync(request);

            // Assert
            Assert.IsNotNull(resualt);

        }
    }
}
