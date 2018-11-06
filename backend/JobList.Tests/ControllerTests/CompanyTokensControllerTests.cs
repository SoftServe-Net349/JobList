using FakeItEasy;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Requests;
using JobList.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace JobList.Tests.ControllerTests
{
    [TestFixture]
    public class CompanyTokensControllerTests
    {
        ITokensService<CompanyDTO> _tokensService;

        [SetUp]
        public void Set_TokensService()
        {
            _tokensService = A.Fake<ITokensService<CompanyDTO>>();
        }

        [Test]
        public async Task Token_Should_Create_token_typeof_TokenDTO_And_Return_Status_Code_200()
        {
            // Arrange
            var request = new LoginRequest
            {
                Email = "pavlo@gmail.com",
                Password = "12345678"
            };
            A.CallTo(() => _tokensService.CreateTokenAsync(A<LoginRequest>._)).Returns(new TokenDTO { Jwt = "jwt_token", RefreshToken = "refreh_token" });

            var companyTokensController = new CompanyTokensController(_tokensService);

            //Act
            var actionResult =  await companyTokensController.Token(request);

            //Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.NotNull(result);

            var dto = result.Value as TokenDTO;

            Assert.IsInstanceOf(typeof(TokenDTO), dto);

        }

        [Test]
        public async Task Token_Should_Catch_HttpStatusCodeException_And_Return_Status_Code_400()
        {
            // Arrange
            var request = new LoginRequest
            {
                Email = "pavlo@gmail.com",
                Password = "12345678"
            };
            A.CallTo(() => _tokensService.CreateTokenAsync(A<LoginRequest>._))
                .Throws(new HttpStatusCodeException(HttpStatusCode.BadRequest, "Sth went wrong!"));

            var companyTokensController = new CompanyTokensController(_tokensService);

            //Act
            var actionResult = await companyTokensController.Token(request);

            //Assert
            Assert.NotNull(actionResult);

            BadRequestObjectResult result = actionResult as BadRequestObjectResult;

            Assert.NotNull(result);

        }

        [Test]
        public async Task RefreshToken_Should_Create_token_typeof_TokenDTO_And_Return_Status_Code_200()
        {
            // Arrange
            var request = new RefreshTokenRequest
            {
                UId = 1,
                RefreshToken = "refresh_token"
            };
            A.CallTo(() => _tokensService.RefreshTokenAsync(A<RefreshTokenRequest>._)).Returns(new TokenDTO { Jwt = "jwt_token", RefreshToken = "refreh_token" });

            var companyTokensController = new CompanyTokensController(_tokensService);

            //Act
            var actionResult = await companyTokensController.RefreshToken(request);

            //Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.NotNull(result);

            var dto = result.Value as TokenDTO;

            Assert.IsInstanceOf(typeof(TokenDTO), dto);

        }

        [Test]
        public async Task RefreshToken_Should_Catch_HttpStatusCodeException_And_Return_Status_Code_400()
        {
            // Arrange
            var request = new RefreshTokenRequest
            {
                UId = 1,
                RefreshToken = "refresh_token"
            };
            A.CallTo(() => _tokensService.RefreshTokenAsync(A<RefreshTokenRequest>._))
                .Throws(new HttpStatusCodeException(HttpStatusCode.BadRequest, "Sth went wrong!"));

            var companyTokensController = new CompanyTokensController(_tokensService);

            //Act
            var actionResult = await companyTokensController.RefreshToken(request);

            //Assert
            Assert.NotNull(actionResult);

            BadRequestObjectResult result = actionResult as BadRequestObjectResult;

            Assert.NotNull(result);


        }

    }
}
