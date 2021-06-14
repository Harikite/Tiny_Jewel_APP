using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJewelInfrastructure.Model;
using TinyJewel.Infrastructure.Repository;
//using AutoMapper;
using TinyJewelCore.BusinessLogic.ViewModels;

namespace TinyJewelCore.BusinessLogic.CustomerBL
{
    public class CustomerBL : ICustomerBL
    {
        private readonly ICustomerService _customerService;
       // private readonly IMapper _mapper;
        public CustomerBL(ICustomerService customerService)
        {
            _customerService = customerService;
            //_mapper = mapper;
        }
        public Customer GetById(string userID)
        {
            var customerEntity = _customerService.GetById(userID);

            if(customerEntity is not null)
            {
                //return _mapper.Map<Customer>(customerEntity);

                return new() { Username=customerEntity.Username,CustomerType=customerEntity.CustomerType,Discount=customerEntity.Discount };
            }

            return null;
        }

    }
}
