using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyJewelCore.BusinessLogic.ViewModel.Response
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }
        public string JwtToken { get; set; }

    }
}
