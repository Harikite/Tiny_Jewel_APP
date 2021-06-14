using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyJewelCore.BusinessLogic.AccountBL;
using TinyJewelCore.BusinessLogic.ViewModel.Request;

namespace TinyJewelAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountBL _accountBL;
        public AuthController(IAccountBL accountBL)
        {
            _accountBL = accountBL;
        }

        [AllowAnonymous]
        [HttpPost("RequestToken")]
        public IActionResult RequestToken(AuthenticateRequest model)
        {
            var response = _accountBL.Authenticate(model);
            if (response is not null)
                return Ok(response);
            else
                return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("GetRequestToken")]
        public IActionResult GetRequestToken()
        {
            var response = _accountBL.Authenticate(new AuthenticateRequest() { Username="test",Password= "VGVzdEAxMjM=" });
            if (response is not null)
                return Ok(response);
            else
                return NoContent();
        }
    }
}
