using System;
using TinyJewelCore.BusinessLogic.ViewModel.Request;
using TinyJewelCore.BusinessLogic.ViewModel.Response;

namespace TinyJewelCore.BusinessLogic.AccountBL
{
    public interface IAccountBL
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
