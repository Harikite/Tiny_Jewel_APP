using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using TinyJewel.Infrastructure.Repository;
using TinyJewelAPI.Controllers;
using TinyJewelCore.BusinessLogic.AccountBL;
using TinyJewelCore.BusinessLogic.Utility;
using TinyJewelCore.BusinessLogic.ViewModel.Request;
using TinyJewelCore.BusinessLogic.ViewModel.Response;
using TinyJewelCore.BusinessLogic.ViewModels;
using TinyJewelInfrastructure.Model;
using Xunit;

namespace TinyJewelTest
{
    public class AccountControllerTest
    {
        private readonly Mock<IAccountBL> mockAccountBL;
        private readonly Mock<IAccountService> mockAccountService;
        private readonly Mock<IJwtUtils> mockJwtUtils;
        private readonly Mock<AutoMapper.IMapper> mockMapper;
        public AccountControllerTest()
        {
            mockAccountBL = new();
            mockAccountService = new();
            mockJwtUtils = new();
            mockMapper = new();
        }
        [Theory]
        [InlineData("test", "Test123", true)]
        [InlineData("test", "Test823", false)]
        public void LoginTest(string userName, string Password, bool success)
        {
            if(success)
            mockAccountBL.Setup(e => e.Authenticate(It.IsAny<AuthenticateRequest>())).Returns(new AuthenticateResponse()
            {
                Username = "test",
                JwtToken = "3423423erg-45345mwtlk34lcwlkjwvlej.43535656536.345346356-04-0ic04345"

            });

            var authController = new AuthController(mockAccountBL.Object);
            var result = authController.RequestToken(new AuthenticateRequest() { Username = userName, Password = Password });

            if (success)
            {
                Assert.NotNull(result);
                Assert.IsType<OkObjectResult>(result);
            }
            else
            {
                Assert.IsType<NoContentResult>(result);
            }
            //Assert.Verify();

        }

        [Theory]
        [InlineData("test", "Test123", true)]
        [InlineData("test", "Test823", false)]
        public void LoginBLTest(string userName, string Password, bool success)
        {
            mockAccountService.Setup(e => e.Authenticate("test", "Test123")).Returns(new TinyJewelInfrastructure.Model.CustomerEntity()
            {
                Username = "test",
                Discount = 20,
                
            });

            mockJwtUtils.Setup(e => e.GenerateJwtToken(It.IsAny<Customer>())).Returns("kjhlkjhlkj.jgkjgkjhgjh.kjh");
            mockMapper.Setup(x => x.Map<Customer>(It.IsAny<CustomerEntity>()))
               .Returns((CustomerEntity source) => new Customer() { CustomerType = "1", Discount = 0, Username = "test" });

            var authBL = new AccountBL(mockAccountService.Object, mockJwtUtils.Object);
            var result = authBL.Authenticate(new AuthenticateRequest() { Username = userName, Password = Password });

            if (success)
            {
                Assert.NotNull(result);
                Assert.IsType<AuthenticateResponse>(result);
                Assert.Equal("test", result.Username);
                Assert.NotNull(result.JwtToken);
            }
            else
            {
                Assert.Null(result);
            }

        }

    }
}

