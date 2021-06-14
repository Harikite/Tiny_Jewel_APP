using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJewel.Infrastructure.Repository;
using TinyJewelCore.BusinessLogic.Utility;
using TinyJewelCore.BusinessLogic.ViewModel.Request;
using TinyJewelCore.BusinessLogic.ViewModel.Response;
// using AutoMapper;
using TinyJewelCore.BusinessLogic.ViewModels;
using TinyJewelInfrastructure.Model;

namespace TinyJewelCore.BusinessLogic.AccountBL
{
    public class AccountBL : IAccountBL
    {
        private readonly IAccountService _accountService;
        private readonly IJwtUtils _jwtUtils;
       // private readonly IMapper _mapper;

        public AccountBL(IAccountService accountService, IJwtUtils jwtUtils)
        {
            _accountService = accountService;
            _jwtUtils = jwtUtils;
            
            //var config = new MapperConfiguration(cfg =>
            //        cfg.CreateMap<CustomerEntity, Customer>()
            //    );

        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            AuthenticateResponse authenticateResponse = null;
            var customer = _accountService.Authenticate(model.Username, model.Password) ;


            if (customer is not null)
            {
                authenticateResponse = new()
                {
                    Username=customer.Username,
                    JwtToken=_jwtUtils.GenerateJwtToken(new Customer() { Username=customer.Username })
                };

                return authenticateResponse;
            }

            return authenticateResponse;
        }
    }
}