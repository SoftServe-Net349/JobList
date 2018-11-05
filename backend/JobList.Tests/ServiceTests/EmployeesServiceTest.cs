using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using NUnit.Framework;
using System;
using FakeItEasy;
using System.Collections.Generic;
using System.Text;
using JobList.DataAccess.Interfaces.Repositories;
using JobList.BusinessLogic.Interfaces;
using JobList.BusinessLogic.Services;
using JobList.DataAccess.Interfaces;
using AutoMapper;
using JobList.BusinessLogic.MappingProfiles;
using System.Threading.Tasks;

namespace JobList.Tests.ServiceTests
{
    [TestFixture]
    public class EmployeesServiceTest
    {
        IUnitOfWork _unitOfWork;
        IEmployeesService _employeesService;

        [SetUp]
        public void Set_UnitOfWork_And_EmployeesService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmployeeProfile>();
            });

            _unitOfWork = A.Fake<IUnitOfWork>();
            _employeesService = new EmployeesService(_unitOfWork, config.CreateMapper());
        }


        [Test]
        public async Task CreateEmployee_Should_Create_employee_typeof_Employee()
        {
            // Arrange
            A.CallTo(() => _unitOfWork.EmployeesRepository.GetAllEntitiesAsync(null)).Returns(new List<Employee> { new Employee() { Id = 1 } });
            EmployeeRequest request = new EmployeeRequest
            {
                BirthDate = new DateTime(1998, 7, 12),
                Email = "pavlopaitak@gmail.comm",
                FirstName = "Pavlo",
                LastName = "Paitak",
                CityId = 1,
                Password = "12345678",
                Phone = null,
                PhotoData = null,
                PhotoMimeType = null,
                RoleId = 1,
                Sex = null
            };

            // Act
            var dto = await _employeesService.CreateEntityAsync(request);

            // Assert
            A.CallTo(() => _unitOfWork.SaveAsync()).MustHaveHappenedOnceOrMore();
        }
    }
}
