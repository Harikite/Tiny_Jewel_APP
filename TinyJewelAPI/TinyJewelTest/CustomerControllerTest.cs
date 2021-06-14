using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TinyJewel.Infrastructure.Repository;
using TinyJewelAPI.Controllers;
using TinyJewelCore.BusinessLogic.CustomerBL;
using TinyJewelCore.BusinessLogic.ViewModels;
using TinyJewelInfrastructure.Model;
using Xunit;

namespace TinyJewelTest
{
    public class CustomerControllerTest
    {
        private readonly Mock<ICustomerBL> _mockCustomerBL;
        private readonly Mock<ICustomerService> _mockCustomerService;

        public CustomerControllerTest()
        {
            _mockCustomerBL = new();
            _mockCustomerService = new();
        }

        [Fact]
        public void GetCustomerControllerTest()
        {
            _mockCustomerBL.Setup(e => e.GetById(It.IsAny<string>())).Returns(new Customer());
            CustomerController customerController = new(_mockCustomerBL.Object);

            var result = customerController.GetCustomer("test");

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            //Assert.Verify();
            
        }

        [Fact]
        public void GetCustomerBLTest()
        {
            _mockCustomerService.Setup(e => e.GetById(It.IsAny<string>())).Returns(new TinyJewelInfrastructure.Model.CustomerEntity());

            //mockMapper.Setup(x => x.Map<Customer>(It.IsAny<CustomerEntity>()))
            //   .Returns((CustomerEntity source) => new Customer() { CustomerType = "1", Discount = 0, Username = "test" });
            ICustomerBL customerBL = new CustomerBL(_mockCustomerService.Object);

            var result = customerBL.GetById("test");

            Assert.NotNull(result);
            Assert.IsType<Customer>(result);
        }
    }
}
