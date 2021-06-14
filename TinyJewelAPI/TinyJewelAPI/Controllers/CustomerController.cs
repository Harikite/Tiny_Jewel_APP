using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyJewelCore.BusinessLogic.CustomerBL;

namespace TinyJewelAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerBL _customerBL;
        public CustomerController(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }

        [HttpGet]
        [Route("GetCustomer/{Id}")]
        public IActionResult GetCustomer(string Id)
        {
            var response = _customerBL.GetById(Id);
            return Ok(response);
        }

    }
}
