using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using TinyJewel.Infrastructure.Repository;
using TinyJewelCore.BusinessLogic.AccountBL;
using TinyJewelCore.BusinessLogic.Utility;
using TinyJewelCore.BusinessLogic.ViewModel.Request;
using TinyJewelCore.BusinessLogic.ViewModel.Response;
using TinyJewelCore.BusinessLogic.ViewModels;
using TinyJewelInfrastructure.Model;
using Xunit;

namespace TinyJewelTest
{
    public class UtilityTest
    {
        private readonly Mock<IJwtUtils> mockJwtUtils;
        public UtilityTest()
        {
            mockJwtUtils = new();
        }
        [Fact]
        public void CreateTokenTest()
        {
            //mockJwtUtils.Setup(e => e.GenerateJwtToken(It.IsAny<Customer>())).Returns("kjhlkjhlkj.jgkjgkjhgjh.kjh");
            var jwtUtils = new JwtUtils();
            var result = jwtUtils.GenerateJwtToken(new () {Username="test" });

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("test123")]
        public void ValidateTokenTest(string userId)
        {
            var jwtUtils = new JwtUtils();
            string result=null;
            var token = jwtUtils.GenerateJwtToken(new() { Username = userId });
            result = jwtUtils.ValidateJwtToken(token);

            Assert.NotNull(result);
            Assert.Equal(userId, result);

        }

        [Fact]
        public void ValidateNullTokenTest()
        {
            var jwtUtils = new JwtUtils();
            var result = jwtUtils.ValidateJwtToken(null);
            Assert.Null(result);

        }

    }
}

