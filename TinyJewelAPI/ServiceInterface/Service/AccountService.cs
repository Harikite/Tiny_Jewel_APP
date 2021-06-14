using System;
using System.Linq;
using TinyJewel.Infrastructure.Repository;
using TinyJewelInfrastructure.DataAccess;
using TinyJewelInfrastructure.Model;

namespace TinyJewelInfrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly CustomerDBContext _customerDBContext; 
        public AccountService(CustomerDBContext customerDBContext)
        {
            _customerDBContext = customerDBContext;
        }
        public CustomerEntity Authenticate(string UserID, string Password)
        {

            return _customerDBContext.Customers.Where(a => a.Username.ToLower() == UserID.ToLower() && a.PasswordHash == Password).FirstOrDefault();
        }

       
    }
}
