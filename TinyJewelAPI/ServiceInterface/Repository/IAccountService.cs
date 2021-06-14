using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJewelInfrastructure.Model;

namespace TinyJewel.Infrastructure.Repository
{
    public interface IAccountService
    {
        CustomerEntity Authenticate(string UserID, string Password);
    }
}
