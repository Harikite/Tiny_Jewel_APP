using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJewelCore.BusinessLogic.ViewModels;

namespace TinyJewelCore.BusinessLogic.CustomerBL
{
    public interface ICustomerBL
    {
        Customer GetById(string userID);
    }
}
