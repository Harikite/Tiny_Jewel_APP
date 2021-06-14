using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJewelInfrastructure.DataAccess;
using TinyJewelInfrastructure.Model;
using TinyJewel.Infrastructure.Repository;

namespace TinyJewelInfrastructure.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDBContext _customerDBContext;
        public CustomerService(CustomerDBContext customerDBContext)
        {
            _customerDBContext = customerDBContext;
        }
        public CustomerEntity GetById(string userID)
        {

            var result = _customerDBContext.Customers.Where(e => e.Username.ToLower() == userID.ToLower()).Join(
                                        _customerDBContext.CustomerTypes, c => c.CustomerType, ct => ct.CustomerTypeID,
                                        (c, ct) => new CustomerEntity() { CustomerType = ct.CustomerTypeID, Username = c.Username, Discount = c.Discount > 0 ? c.Discount : ct.Discount }
                                        ).FirstOrDefault();
            return result;
        }
    }
}
